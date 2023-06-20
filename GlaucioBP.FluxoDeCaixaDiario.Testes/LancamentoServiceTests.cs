using GlaucioBP.FluxoDeCaixaDiario.Aplicacao.Service;
using GlaucioBP.FluxoDeCaixaDiario.Dominio.Interfaces.Repositories;
using GlaucioBP.FluxoDeCaixaDiario.Dominio.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaucioBP.FluxoDeCaixaDiario.Testes
{
    // Classe de teste para o serviço de controle de lançamentos
    [TestFixture]
    public class LancamentoServiceTests
    {
        private Mock<ILancamentoRepository> _lancamentoRepositoryMock;
        private LancamentoService _lancamentoService;

        [SetUp]
        public void SetUp()
        {
            _lancamentoRepositoryMock = new Mock<ILancamentoRepository>();
            _lancamentoService = new LancamentoService(_lancamentoRepositoryMock.Object);
        }

        [Test]
        public async Task CriarLancamento_DeveChamarMetodoAddDoRepositorio()
        {
            // Arrange
            var lancamento = new Lancamento { Valor = 100, Tipo = TipoLancamento.Debito, Data = DateTime.Now };

            // Act
            object value = await _lancamentoService.CriarLancamento(lancamento);

            // Assert
            _lancamentoRepositoryMock.Verify(r => r.Add(It.IsAny<Lancamento>()), Times.Once);
        }
    }

}
