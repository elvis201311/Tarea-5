using Microsoft.EntityFrameworkCore;
using Prestamo_con_Detalla.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prestamo_con_Detalla.DAL
{
   
        public class Contexto : DbContext
    {
        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<Moras> Moras { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite(@"Data Source= DATA\TeacherControl.db");
            }
        }
    }
