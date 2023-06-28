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
        [ApiKey]
        public async Task<ActionResult<IEnumerable<Launch>>> GetAllLaunchers()
        {
            var lstLaunchers = await _lauchRepository.GetAll();
            
            return Ok(lstLaunchers);
        }
    }
}
