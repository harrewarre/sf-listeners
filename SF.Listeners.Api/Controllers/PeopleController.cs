using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using SF.Listeners.People.Interfaces;
using System;
using System.Threading.Tasks;

namespace SF.Listeners.Api.Controllers
{
    [Route("api/people/v1")]
    public class PeopleController : Controller
    {
        private readonly INameService _namesProxy;
        private readonly IAgeService _ageProxy;

        public PeopleController()
        {
            _namesProxy = ServiceProxy.Create<INameService>(new Uri("fabric:/SF.Listeners/SF.Listeners.People"), listenerName: "NameService");
            _ageProxy = ServiceProxy.Create<IAgeService>(new Uri("fabric:/SF.Listeners/SF.Listeners.People"), listenerName: "AgeService");
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> AllNames()
        {
            try
            {
                return Ok(await _namesProxy.GetAllNames());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("avgage")]
        public async Task<IActionResult> AverageAge()
        {
            try
            {
                return Ok(await _ageProxy.GetAverageAge());
            }
            catch (Exception ex
            )
            {
                throw;
            }
        }

        [HttpPost]
        [Route("addname")]
        public async Task AddName([FromForm] string name)
        {
            try
            {
                await _namesProxy.AddName(name);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
