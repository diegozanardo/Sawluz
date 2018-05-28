using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sawlux.Data.Contexto;
using Sawlux.Data.Repositorios;
using Sawlux.Service.Services;
using Sawluz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sawlux.Tests.Integration
{
    [TestClass]
    public class RetauranteIntegrationTest
    {
        private readonly RestauranteService restauranteService;
        private readonly SawluxContexto contexto;

        public RetauranteIntegrationTest()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            contexto = new SawluxContexto(connection);
            var restauranteRepositorio = new RestauranteRepositorio(contexto);
            restauranteService = new RestauranteService(restauranteRepositorio);
        }

        [TestMethod]
        public void TestAddRestaurante()
        {
            // Setup
            var restaurante = new Restaurante { Nome = "Restaurante" };

            // Act
            restauranteService.Cadastro(restaurante);

            // Assert
            var restauranteResult = contexto.Restaurante.FirstOrDefault(x => x.Nome == restaurante.Nome);
            Assert.AreEqual(restaurante.Nome, restauranteResult.Nome);
        }


        [TestMethod]
        public void TestUpdateRestaurante()
        {
            // Setup
            var restaurante = contexto.Restaurante.Add(new Restaurante
            {
                Nome = "Restaurante",
                Pratos = new List<Prato> {
                    new Prato {
                        Nome = "Prato Feito"
                    }
                }
            });
            contexto.SaveChanges();
            var restauranteNovo = new Restaurante { Id = restaurante.Id, Nome = "Italiano" };

            // Act
            restauranteService.Cadastro(restauranteNovo);

            // Assert
            var restauranteResult = contexto.Restaurante.FirstOrDefault(x => x.Nome == restauranteNovo.Nome);
            Assert.AreEqual(restauranteNovo.Nome, restauranteResult.Nome);
            Assert.AreEqual(restauranteNovo.Id, restauranteResult.Id);
            Assert.AreEqual(restaurante.Pratos.FirstOrDefault().Id, restauranteResult.Pratos.FirstOrDefault().Id);
            Assert.AreEqual(restaurante.Pratos.FirstOrDefault().Nome, restauranteResult.Pratos.FirstOrDefault().Nome);
        }
    }
}
