﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prestamo_con_Detalla.Entidades
{
    public class MorasDetalle
    {
        [Key]
        public int IdDetalle { get; set; }
        public int MoraId { get; set; }
        public int PrestamoId { get; set; }
        public DateTime FechaMoraDetalle { get; set; } = DateTime.Now;
        public float Valor { get; set; }
        public MorasDetalle(int idDetalle, int moraId, int prestamoId, DateTime fechaMoraDetalle, float valor)
        {
            IdDetalle = idDetalle;
            MoraId = moraId;
            PrestamoId = prestamoId;
            FechaMoraDetalle = fechaMoraDetalle;
            Valor = valor;
        }
    }
}