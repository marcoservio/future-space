using FutureSpace.Controllers;
using FutureSpace.Interfaces;
using FutureSpace.Models;

using Microsoft.AspNetCore.Mvc;

using Moq;

namespace FutureSpace.TestesIntegracao
{
    public class LaunchControllerTestes
    {
        private readonly Mock<ILaunchRepository> _launchRepositoryMock;
        private readonly LaunchController _launchController;

        public LaunchControllerTestes()
        {
            _launchRepositoryMock = new Mock<ILaunchRepository>();
            _launchController = new LaunchController(_launchRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllLaunchers_DeveRetornarListaDeLancamentos_QuandoExistirRegistros()
        {
            var lancamentos = new List<Launch> { new Launch(), new Launch() };
            _launchRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(lancamentos);

            var resultado = await _launchController.GetAllLaunchers();

            Assert.IsType<OkObjectResult>(resultado.Result);
            var okObjectResult = resultado.Result as OkObjectResult;
            var listaRetornada = okObjectResult.Value as IEnumerable<Launch>;
            Assert.Equal(lancamentos.Count, listaRetornada.Count());
        }

        [Fact]
        public async Task GetAllLaunchers_DeveRetornarNotFound_QuandoNaoExistirRegistros()
        {
            _launchRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(new List<Launch>());

            var resultado = await _launchController.GetAllLaunchers();

            Assert.IsType<NotFoundObjectResult>(resultado.Result);
            var notFoundObjectResult = resultado.Result as NotFoundObjectResult;
            Assert.Equal("Não foi encontrado nenhum registro.", notFoundObjectResult.Value);
        }

        [Fact]
        public async Task GetLaunchById_DeveRetornarLaunch_QuandoExistirRegistro()
        {
            var id = Guid.NewGuid();
            var launch = new Launch { Id = id };
            _launchRepositoryMock.Setup(repo => repo.GetById(id)).ReturnsAsync(launch);

            var resultado = await _launchController.GetLaunchById(id);

            Assert.IsType<OkObjectResult>(resultado);
            var okObjectResult = resultado as OkObjectResult;
            var launchRetornado = okObjectResult.Value as Launch;
            Assert.Equal(id, launchRetornado.Id);
        }

        [Fact]
        public async Task GetLaunchById_DeveRetornarNotFound_QuandoRegistroNaoExistir()
        {
            var id = Guid.NewGuid();
            _launchRepositoryMock.Setup(repo => repo.GetById(id)).ReturnsAsync((Launch)null);

            var resultado = await _launchController.GetLaunchById(id);

            Assert.IsType<NotFoundObjectResult>(resultado);
            var notFoundObjectResult = resultado as NotFoundObjectResult;
            Assert.Equal("Não foi encontrado nenhum lançamento.", notFoundObjectResult.Value);
        }

        [Fact]
        public async Task UpdateLaunch_DeveRetornarOk_QuandoAtualizacaoForBemSucedida()
        {
            var launchId = Guid.NewGuid();
            var updatedLaunch = new Launch { Id = launchId, Name = "Updated Launch" };
            _launchRepositoryMock.Setup(repo => repo.GetById(launchId)).ReturnsAsync(updatedLaunch);
            _launchRepositoryMock.Setup(repo => repo.SaveAllAsync()).ReturnsAsync(true);

            var resultado = await _launchController.UpdateLaunch(updatedLaunch);

            Assert.IsType<OkObjectResult>(resultado);
            var okObjectResult = resultado as OkObjectResult;
            Assert.Equal("Lançamento alterado com sucesso.", okObjectResult.Value);
        }

        [Fact]
        public async Task UpdateLaunch_DeveRetornarBadRequest_QuandoOcorrerErroNaAtualizacao()
        {
            var launch = new Launch();
            _launchRepositoryMock.Setup(repo => repo.SaveAllAsync()).ReturnsAsync(false);

            var resultado = await _launchController.UpdateLaunch(launch);

            Assert.IsType<BadRequestObjectResult>(resultado);
            var badRequestObjectResult = resultado as BadRequestObjectResult;
            Assert.Equal("Ocorreu um erro ao alterar o lançamento.", badRequestObjectResult.Value);
        }

        [Fact]
        public async Task DeleteLaunch_DeveRetornarOk_QuandoExclusaoForBemSucedida()
        {
            var id = Guid.NewGuid();
            var launch = new Launch { Id = id };
            _launchRepositoryMock.Setup(repo => repo.GetById(id)).ReturnsAsync(launch);
            _launchRepositoryMock.Setup(repo => repo.SaveAllAsync()).ReturnsAsync(true);

            var resultado = await _launchController.DeleteLaunch(id);

            Assert.IsType<OkObjectResult>(resultado);
            var okObjectResult = resultado as OkObjectResult;
            Assert.Equal("Lançamento excluido com sucesso.", okObjectResult.Value);
        }

        [Fact]
        public async Task DeleteLaunch_DeveRetornarNotFound_QuandoRegistroNaoExistir()
        {
            var id = Guid.NewGuid();
            _launchRepositoryMock.Setup(repo => repo.GetById(id)).ReturnsAsync((Launch)null);

            var resultado = await _launchController.DeleteLaunch(id);

            Assert.IsType<NotFoundObjectResult>(resultado);
            var notFoundObjectResult = resultado as NotFoundObjectResult;
            Assert.Equal("Lançamento não encontrado.", notFoundObjectResult.Value);
        }

        [Fact]
        public async Task DeleteLaunch_DeveRetornarBadRequest_QuandoOcorrerErroNaExclusao()
        {
            var id = Guid.NewGuid();
            var launch = new Launch { Id = id };
            _launchRepositoryMock.Setup(repo => repo.GetById(id)).ReturnsAsync(launch);
            _launchRepositoryMock.Setup(repo => repo.SaveAllAsync()).ReturnsAsync(false);

            var resultado = await _launchController.DeleteLaunch(id);

            Assert.IsType<BadRequestObjectResult>(resultado);
            var badRequestObjectResult = resultado as BadRequestObjectResult;
            Assert.Equal("Ocorreu um erro ao excluir o lançamento.", badRequestObjectResult.Value);
        }
    }
}
