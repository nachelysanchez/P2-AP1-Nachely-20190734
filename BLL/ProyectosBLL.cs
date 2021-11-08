using Microsoft.EntityFrameworkCore;
using P2_AP1_Nachely_20190734.DAL;
using P2_AP1_Nachely_20190734.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Nachely_20190734.BLL
{
    public class ProyectosBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Proyectos.Any(e => e.ProyectoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        public static bool Guardar(Proyectos proyecto)
        {
            if (!Existe(proyecto.ProyectoId))
            {
                return Insertar(proyecto);
            }
            else
            {
                return Modificar(proyecto);
            }
        }
        private static bool Insertar(Proyectos proyecto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Proyectos.Add(proyecto);

                foreach(var detalle in proyecto.Detalle)
                {
                    contexto.Entry(detalle).State = EntityState.Added;
                    contexto.Entry(detalle.TiposTarea).State = EntityState.Modified;
                    contexto.Entry(detalle.Proyecto).State = EntityState.Modified;
                    detalle.TiposTarea.TiempoAcumulado += detalle.Tiempo;
                    detalle.Proyecto.Total += detalle.Tiempo;
                }

                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Modificar(Proyectos proyecto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var proyectoAnterior = contexto.Proyectos
                    .Where(x => x.ProyectoId == proyecto.ProyectoId)
                    .Include(x => x.Detalle)
                    .ThenInclude(x => x.TiposTarea)
                    .AsNoTracking()
                    .SingleOrDefault();


                foreach(var detalle in proyectoAnterior.Detalle)
                {
                    detalle.TiposTarea.TiempoAcumulado -= detalle.Tiempo;
                    detalle.Proyecto.Total -= detalle.Tiempo;
                }

                contexto.Database.ExecuteSqlRaw($"Delete FROM ProyectosDetalle where Id={proyecto.ProyectoId}");

                foreach(var detalle in proyectoAnterior.Detalle)
                {
                    contexto.Entry(detalle).State = EntityState.Added;
                    contexto.Entry(detalle.TiposTarea).State = EntityState.Modified;
                    contexto.Entry(detalle.Proyecto).State = EntityState.Modified;
                    detalle.TiposTarea.TiempoAcumulado += detalle.Tiempo;
                    detalle.Proyecto.Total += detalle.Tiempo;
                }

                contexto.Entry(proyecto).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static Proyectos Buscar(int id)
        {
            Proyectos proyecto = new Proyectos();
            Contexto contexto = new Contexto();

            try
            {
                proyecto = contexto.Proyectos.Include(x => x.Detalle)
                    .Where(x => x.ProyectoId == id)
                    .Include(x => x.Detalle)
                    .ThenInclude(x => x.TiposTarea)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return proyecto;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                var proyecto = Buscar(id);
                if (proyecto != null)
                {
                    foreach(var item in proyecto.Detalle)
                    {
                        contexto.Entry(item.Proyecto).State = EntityState.Modified;
                        contexto.Entry(item.TiposTarea).State = EntityState.Modified;
                        item.TiposTarea.TiempoAcumulado -= item.Tiempo;
                        item.Proyecto.Total -= item.Tiempo;
                    }

                    contexto.Proyectos.Remove(proyecto);
                    paso = contexto.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
    }
}
