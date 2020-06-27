using Prestamo_con_Detalla.Entidades;
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
        public static bool Guardar(Moras prestamos)
        {
            if (!Existe(prestamos.MoraId))
                return Insertar(prestamos);
            else
                return Modificar(prestamos);
        }
        private static bool Insertar(Moras prestamos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Prestamos.Add(prestamos);
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
       
        public static bool Modificar(Moras prestamos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                
                contexto.Database.ExecuteSqlRaw($"Delete FROM ArticulosDetalle Where TareaId={prestamos.MoraId}");

                foreach (var item in prestamos.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
               

                contexto.Entry(prestamos).State = EntityState.Modified;
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
       
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var articulos = contexto.Prestamos.Find(id);
                if (articulos != null)
                {
                    contexto.Prestamos.Remove(articulos);
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
        
        public static Moras Buscar(int id)
        {
            
            Moras moras = new Moras();
            
            Contexto contexto = new Contexto();
            //Articulos articulos;
            try
            {
               
                moras = contexto.Prestamos.Include(x => x.Detalle)
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
        
        public static List<Moras> GetList(Expression<Func<Moras, bool>> criterio)
        {
            List<Moras> lista = new List<Moras>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Prestamos.Where(criterio).ToList();
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
        
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Prestamos.Any(d => d.MoraId == id);
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
        
        public static List<Moras> GetArticulos()
        {
            List<Moras> lista = new List<Moras>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Prestamos.ToList();
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
    