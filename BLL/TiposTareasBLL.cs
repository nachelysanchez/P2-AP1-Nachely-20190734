using P2_AP1_Nachely_20190734.DAL;
using P2_AP1_Nachely_20190734.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Nachely_20190734.BLL
{
    public class TiposTareasBLL
    {
        public static TiposTareas Buscar(int id)
        {
            TiposTareas tarea;
            Contexto contexto = new Contexto();
            try
            {
                tarea = contexto.TiposTareas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return tarea;
        }

        public static List<TiposTareas> GetTiposTareas()
        {
            Contexto contexto = new Contexto();
            List<TiposTareas> lista = new List<TiposTareas>();
            try
            {
                lista = contexto.TiposTareas.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static List<TiposTareas> GetList(Expression<Func<TiposTareas, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<TiposTareas> lista = new List<TiposTareas>();
            try
            {
                lista = contexto.TiposTareas.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
