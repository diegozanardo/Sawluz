using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sawlux.Data.Contexto;
using Sawlux.Data.Repositorios;
using Sawluz.Model;
using System.Linq;

namespace Sawlux.Tests.Respositorios
{
    [TestClass]
    public class RestauranteRepositorioTest
    {
        private readonly RestauranteRepositorio repo;

        public RestauranteRepositorioTest()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            var contexto = new SawluxContexto(connection);
            repo = new RestauranteRepositorio(contexto);
        }

        [TestMethod]
        public void TestAddRestaurante()
        {
            // Setup
            var restaurante = new Restaurante { Nome = "Restaurante1" };

            // Act
            repo.Add(restaurante);
            repo.Save();
            var restauranteBd = repo.Get(x => x.Nome == restaurante.Nome).FirstOrDefault();
            var restauranteBdl = repo.Get(x => x.Nome == restaurante.Nome).ToList();

            // Assert
            Assert.AreEqual(restaurante.Nome, restauranteBd.Nome);
        }
    }
}
