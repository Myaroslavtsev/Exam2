using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Exam2_webapp.Resistors;
using System.ComponentModel.DataAnnotations;

namespace Exam2_webapp.Controllers
{
    [ApiController]
    [Route("resistors")]
    public class ResistorsController : ControllerBase
    {
        private readonly ResistorsService resistorsService;

        public ResistorsController(ResistorsService resistorsService)
        {
            this.resistorsService = resistorsService;
        }

        [HttpPost("")]
        public async Task<ActionResult> CreateAsync([FromBody] View.Resistors.ResistorCreateInfo createInfo, CancellationToken token)
        {
            try
            {
                var resistor = await this.resistorsService.CreateResistorAsync(createInfo, token);
                return this.Ok(resistor);
            }
            catch (ValidationException ex)
            {
                return this.BadRequest(ex.ValidationResult);
            }
        }

        //[HttpGet("{id}")]
        //[HttpGet("")]
        //[HttpPatch("{id}")]
        //[HttpDelete("{id}")]
    }
}
