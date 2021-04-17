using System.Threading.Tasks;
using AutoMapper;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        private IPersonFacade _facade;

        public PersonController(IPersonFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonListResponse>> Get() => Response(await _facade.FindAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonResponse>> Get(int id)
        {
            return Response(await _facade.FindPerson(id));
        }

        [HttpGet("phone/{id}")]
        public async Task<ActionResult<PersonPhoneResponse>> GetPhone(int id)
        {
            return Response(await _facade.FindPersonPhone(id));
        }

        [HttpPut]
        public IActionResult Put([FromBody] ExampleRequest request)
        {
            return Response(0, null);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ExampleRequest request)
        {
            return Response(0, null);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] ExampleRequest request)
        {
            return Response(0, null);
        }
    }
}
