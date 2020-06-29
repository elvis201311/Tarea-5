﻿using Prestamo_con_Detalla.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Prestamo_con_Detalla.DAL;

namespace Prestamo_con_Detalla.BLL
{
    public class MorasBLL
    {
        //---[ GUARDAR ]---
        public static bool Guardar(Moras moras)
        {
            if (!Existe(moras.MoraId))
                return Insertar(moras);
            else
                return Modificar(moras);
        }
        //---[ INSERTAR ]---
        private static bool Insertar(Moras moras)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Moras.Add(moras);
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
        //---[ MODIFICAR ]---
        public static bool Modificar(Moras moras)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //---[ REGISTRO DETALLADO ]---
                contexto.Database.ExecuteSqlRaw($"Delete FROM MorasDetalle Where MoraId={moras.MoraId}");

                foreach (var item in moras.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
               

                contexto.Entry(moras).State = EntityState.Modified;
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
        //---[ ELIMINAR ]---
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var moras = contexto.Moras.Find(id);
                if (moras != null)
                {
                    contexto.Moras.Remove(moras);
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
        //---[ BUSCAR ]---
        public static Moras Buscar(int id)
        {
            //---[ REGISTRO DETALLADO ] ---
            Moras moras = new Moras();
           
            Contexto contexto = new Contexto();
           
            try
            {
                
                moras = contexto.Moras.Include(x => x.Detalle)
                    .Where(x => x.MoraId == id)
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
            return moras;
        }
        //---[ GET LIST ]---
        public static List<Moras> GetList(Expression<Func<Moras, bool>> criterio)
        {
            List<Moras> lista = new List<Moras>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Moras.Where(criterio).ToList();
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
        //---[ EXISTE ]---
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Moras.Any(d => d.MoraId == id);
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
    }
}