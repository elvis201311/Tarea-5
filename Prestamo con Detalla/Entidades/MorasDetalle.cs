using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prestamo_con_Detalla.Entidades
{
   public class MorasDetalle
    {
        public MorasDetalle( int prestamoId, float valor)
        {
            Id = 0;
            PrestamoId = prestamoId;
            Valor = valor;
        }

        [Key]
        public int Id { get; set; }
        public int PrestamoId { get; set; }
        public float Valor { get; set; }

        
    }
}