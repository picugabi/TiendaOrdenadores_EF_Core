using Microsoft.AspNetCore.Mvc;
using MVC_ComponentesCodeFirst.Controllers;
using MVC_ComponentesCodeFirst.Models;
using MVC_ComponentesCodeFirst.Servicios;
using MVC_ComponentesCodeFirst.Servicios.ComponenteRepository;

namespace MVC_ComponentesCodeFirstTests
{
    [TestClass]
    public class ComponenteTest
    {
        private readonly ComponentesController controlador = new(new FakeComponenteRepository());

        [TestMethod]
        public void TestComponenteDetalleVistaEncontrado()
        {
            var result = controlador.Details(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var componente = result.ViewData.Model as Componente;
            Assert.IsNotNull(componente);
            Assert.AreEqual("879FH", componente.NumeroDeSerie);
        }
        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void TestComponenteDetallesVistaNoEncontrado()
        {
            var result = controlador.Details(4) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
            Assert.IsNull(result.ViewData.Model);
            var componente = result.ViewData.Model as Componente;
            Assert.IsNull(componente);
            Assert.AreEqual("ActivoLaExcepcion", componente!.NumeroDeSerie);
           
        }
        [TestMethod]
        public void TestComponenteIndexVistaOk()
        {
            var result = controlador.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var listaComponentes = result.ViewData.Model as List<Componente>;
            Assert.IsNotNull(listaComponentes);
            Assert.AreEqual(3, listaComponentes.Count);
        }
    }
}