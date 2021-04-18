using AutoMapper;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        
        [HttpPut]
        public IActionResult Put([FromBody] PersonRequest request)
        {
            return Response(0, null);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonRequest request)
        {
            return Response(0, null);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] PersonRequest request)
        {
            return Response(await _facade.RemovePerson(request.Id));
        }
    }
}
