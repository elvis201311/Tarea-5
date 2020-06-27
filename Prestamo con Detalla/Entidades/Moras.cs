using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Prestamo_con_Detalla.Entidades
{
    public class Moras
    {
        [Key]
        public int MoraId { get; set; }
        public DateTime Fecha { get; set; }
        public int total { get; set; }


        [ForeignKey("IdArticulo")]
        public List<MorasDetalle> Detalle { get; set; } = new List<MorasDetalle>();
    }
}

