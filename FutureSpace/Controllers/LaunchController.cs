using FutureSpace.Authentication;
using FutureSpace.Interfaces;
using FutureSpace.Models;

using Microsoft.AspNetCore.Mvc;

namespace FutureSpace.Controllers
{
    [ApiController]
    [Route("launchers")]
    public class LaunchController : ControllerBase
    {
        private readonly ILaunchRepository _lauchRepository;

        public LaunchController(ILaunchRepository lauchRepository)
        {
            _lauchRepository = lauchRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Launch>>> GetAllLaunchers()
        {
            var lstLaunchers = await _lauchRepository.GetAll();

            if (lstLaunchers != null && lstLaunchers.ToList().Count() > 0)
                return Ok(lstLaunchers);

            return NotFound("Não foi encontrado nenhum registro.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetLaunchById(Guid id)
        {
            var launch = await _lauchRepository.GetById(id);

            if (launch != null)
                return Ok(launch);

            return NotFound("Não foi encontrado nenhum lançamento.");
        }

        [HttpPut]
        [ApiKey]
        public async Task<ActionResult> UpdateLaunch(Launch launch)
        {
            _lauchRepository.Update(launch);

            if (await _lauchRepository.SaveAllAsync())
                return Ok("Lançamento alterado com sucesso.");

            return BadRequest("Ocorreu um erro ao alterar o lançamento.");
        }

        [HttpDelete("{id}")]
        [ApiKey]
        public async Task<ActionResult> DeleteLaunch(Guid id)
        {
            var launch = await _lauchRepository.GetById(id);

            if (launch == null)
                return NotFound("Lançamento não encontrado.");

            _lauchRepository.Delete(launch);

            if (await _lauchRepository.SaveAllAsync())
                return Ok("Lançamento excluido com sucesso.");

            return BadRequest("Ocorreu um erro ao excluir o lançamento.");
        }
    }
}
