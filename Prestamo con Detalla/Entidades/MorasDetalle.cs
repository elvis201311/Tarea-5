using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prestamo_con_Detalla.Entidades
{
    class MorasDetalle
    {
        [Key]
        public int Id { get; set; }
        public int PrestamoId { get; set; }
        public string Requerimiento { get; set; }
        public float Valor { get; set; }
        public MorasDetalle(int Prestamoid, string requerimiento, float valor)
        {
            Id = 0;
            PrestamoId = Prestamoid;
            Requerimiento = requerimiento;
            Valor = valor;
        }
    }
}