using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Nachely_20190734.Entidades
{
    public class ProyectosDetalle
    {
        [Key]
        public int Id { get; set; }
        public int ProyectoId { get; set; }
        public int TipoTareaId { get; set; }
        public string Requerimiento { get; set; }
        public int Tiempo { get; set; }

        [ForeignKey("TipoTareaId")]
        public TiposTareas TiposTarea { get; set; }
        public Proyectos Proyecto { get; set; }

        public ProyectosDetalle()
        {
            Id = 0;
            ProyectoId = 0;
            TipoTareaId = 0;
            Requerimiento = string.Empty;
            Tiempo = 0;
            TiposTarea = null;
            Proyecto = null;
        }
        public ProyectosDetalle(int proy, int tipo, string req, int tiempo, TiposTareas tarea, Proyectos proyecto)
        {
            Id = 0;
            ProyectoId = proy;
            TipoTareaId = tipo;
            Requerimiento = req;
            Tiempo = tiempo;
            TiposTarea = tarea;
            Proyecto = proyecto;
        }
    }
}
