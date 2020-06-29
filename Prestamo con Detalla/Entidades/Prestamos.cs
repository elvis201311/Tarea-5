using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Prestamo_con_Detalla.Entidades
{
    public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public double Monto { get; set; }

        //REGISTRO DETALLADO
        [ForeignKey("PrestamoId")]
        public List<MorasDetalle> Detalle { get; set; } = new List<MorasDetalle>();
    }
}