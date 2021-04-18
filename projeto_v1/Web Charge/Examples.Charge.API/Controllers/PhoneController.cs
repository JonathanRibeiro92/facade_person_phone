using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : BaseController
    {
        private readonly IPersonFacade _facade;

        public PhoneController(IPersonFacade facade)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonPhoneListResponse>> Get()
        {
            return Response(await _facade.FindAllPersonPhone());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonPhoneResponse>> Get(int id)
        {
            return Response(await _facade.FindPersonPhone(id));
        }


        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] PersonPhoneDto phone)
        {
            return Response(await _facade.UpdatePersonPhone(id, phone));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonPhoneDto phone)
        {
            return Response(await _facade.AddPersonPhone(phone));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Response(await _facade.RemovePersonPhone(id));
        }
    }
}
