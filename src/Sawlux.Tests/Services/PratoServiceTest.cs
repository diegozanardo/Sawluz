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
    public class PratoServiceTest
    {
        [TestMethod]
        public void TestCadastroCall1TimeAdd()
        {
            var pratoRepositorio = Substitute.For<IPratoRepositorio>();
            var restauranteService = Substitute.For<IRestauranteService>();
            var pratoService = new PratoService(pratoRepositorio, restauranteService);

            // setup
            var prato = new Prato { Nome = "Teste", Preco = 5 };
            var restaurante = new Restaurante { Id = 1, Nome = "Xpto" };

            var restauranteId = 1;
            var expectedCalls = 1;

            // act
            pratoService.Cadastro(prato, restauranteId);

            // assert
            pratoRepositorio.ReceivedWithAnyArgs(expectedCalls).Add(prato);
        }
    }
}
