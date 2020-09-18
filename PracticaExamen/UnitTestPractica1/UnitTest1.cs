using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticaExamen.Controllers;
using PracticaExamen.Models;

namespace UnitTestPractica1
{
    [TestClass]
    public class UnitTest1
    {
        public object ValverdeID { get; private set; }

        [TestMethod]
        public void TestGet()
        {
            //arrange
            ValverdesController controlador = new ValverdesController();
            //act
            var lista = controlador.GetValverdes();
            //assert
            Assert.IsNotNull(lista);
        }
        [TestMethod]
        public void TestPost()
        {
            //arrange
            ValverdesController controlador = new ValverdesController();
            Valverde esperado = new Valverde()
            {
                ValverdeID = 1,
                FriendofValverde = "Gean",
                Birthdate = DateTime.Now,
                Email = "gean@gmail.com",
                Place = placeType.Kiky
            };
            //act
            IHttpActionResult actionResult = controlador.PostValverde(esperado);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Valverde>;
            //assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }
        [TestMethod]
        public void TestPut()
        {
            //arrange
            ValverdesController controlador = new ValverdesController();
            Valverde esperado = new Valverde()
            {
                ValverdeID = 1,
                FriendofValverde = "Gean",
                Birthdate = DateTime.Now,
                Email = "gean@gmail.com",
                Place = placeType.Kiky
            };
            //act
            IHttpActionResult actionResult = controlador.PostValverde(esperado);
            var result = controlador.PutValverde(esperado.ValverdeID, esperado) as StatusCodeResult;
            //assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }
        [TestMethod]
        public void TestDelete()
        {
            //arrange
            ValverdesController controlador = new ValverdesController();
            Valverde esperado = new Valverde()
            {
                ValverdeID = 1,
                FriendofValverde = "Gean",
                Birthdate = DateTime.Now,
                Email = "gean@gmail.com",
                Place = placeType.Kiky
            };
            //act
            IHttpActionResult actionResultPost = controlador.PostValverde(esperado);
            IHttpActionResult actionResultDelete = controlador.DeleteValverde(esperado.ValverdeID);
            //assert
            Assert.IsInstanceOfType(actionResultDelete, typeof(OkNegotiatedContentResult<Valverde>));
        }
    }
}
