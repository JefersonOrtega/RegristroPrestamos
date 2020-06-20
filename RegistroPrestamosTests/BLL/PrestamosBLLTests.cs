using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroPrestamos.BLL;
using RegistroPrestamos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroPrestamos.BLL.Tests
{
    [TestClass()]
    public class PrestamosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;
            paso = PrestamosBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            bool paso = false;
            Prestamos prestamo = new Prestamos();

            prestamo.PrestamoId = 0;
            prestamo.Fecha = DateTime.Now;
            prestamo.NombrePersona = "Juan Miguel";
            prestamo.Concepto = "Compra de Vehiculo";
            prestamo.Monto = 300000;

            paso = PrestamosBLL.Guardar(prestamo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            Prestamos prestamo = new Prestamos();

            prestamo.PrestamoId = 1;
            prestamo.Fecha = DateTime.Now;
            prestamo.NombrePersona = "Juan Miguel Mercedes";
            prestamo.Concepto = "Compra de Vehiculo";
            prestamo.Monto = 350000;

            paso = PrestamosBLL.Guardar(prestamo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            paso = PrestamosBLL.Eliminar(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            bool paso = false;
            Prestamos prestamo;

            prestamo = PrestamosBLL.Buscar(1);

            if (prestamo != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetPrestamosTest()
        {
            Assert.Fail();
        }
    }
}