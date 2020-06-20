using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RegistroPrestamos.DAL;
using RegistroPrestamos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroPrestamos.BLL
{
    public class PrestamosBLL
    {
        
        public static bool Guardar(Prestamos prestamo)
        {
            if (!Existe(prestamo.PrestamoId))
                return Insertar(prestamo);
            else
                return Modificar(prestamo);
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Prestamos.Any(e => e.PrestamoId == id);
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

        public static bool Insertar(Prestamos prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                prestamo.Balance = prestamo.Monto;

                contexto.Prestamos.Add(prestamo);
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

        public static bool Modificar(Prestamos prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            decimal valor = 0;
            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM MorasDetalle Where PrestamoId = {prestamo.PrestamoId}");

                foreach(var item in prestamo.MorasDetalle)
                {
                    valor += item.Valor;
                    contexto.Entry(item).State = EntityState.Added;
                }

                prestamo.Balance = prestamo.Monto;
                prestamo.Balance += valor;

                contexto.Entry(prestamo).State = EntityState.Modified;
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
                var prestamo = contexto.Prestamos.Find(id);
                if (prestamo != null)
                {
                    contexto.Prestamos.Remove(prestamo);
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

        public static Prestamos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamos prestamo;
            try
            {
                prestamo = contexto.Prestamos
                    .Where(p => p.PrestamoId == id)
                    .Include(p => p.MorasDetalle)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return prestamo;
        }

        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> criterio)
        {
            List<Prestamos> lista = new List<Prestamos>();
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

        public static List<Prestamos> GetPrestamos()
        {
            List<Prestamos> lista = new List<Prestamos>();
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
