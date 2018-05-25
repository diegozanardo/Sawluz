using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Sawlux.Data.Repositorios;
using Sawlux.Service.Services;
using Sawluz.Model;

namespace Sawlux.Tests.Services
{
    [TestClass]
    public class RestauranteServiceTest
    {
        [TestMethod]
        public void TestCadastroCall1TimeAdd()
        {
            var restauranteRepositorio = Substitute.For<IRestauranteRepositorio>();
            var restauranteService = new RestauranteService(restauranteRepositorio);

            // setup
            var restaurante = new Restaurante { Nome = "Italy" };
            var expectedCalls = 1;

            // act
            restauranteService.Cadastro(restaurante);

            // assert
            restauranteRepositorio.ReceivedWithAnyArgs(expectedCalls).Add(restaurante);
        }
    }
}
