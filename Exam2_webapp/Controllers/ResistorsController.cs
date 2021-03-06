using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Exam2_webapp.Resistors;
using System.ComponentModel.DataAnnotations;
using Model.Exceptions;

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
                var resistor = await this.resistorsService.CreateResistorAsync(createInfo, token).ConfigureAwait(false);
                return this.Ok(resistor);
            }
            catch (ValidationException ex)
            {
                return this.BadRequest(ex.ValidationResult);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(string id, CancellationToken token)
        {
            try
            {
                var resistor = await this.resistorsService.GetResistorAsync(id, token).ConfigureAwait(false);
                return this.Ok(resistor);
            }
            catch (ResistorNotFoundException)
            {
                return this.NotFound();
            }
        }

        [HttpGet("")]
        public async Task<ActionResult> SearchAsync([FromQuery] View.Resistors.ResistorSearchInfo searchInfo, CancellationToken token)
        {            
            var resistors = await this.resistorsService.SearchResistorAsync(searchInfo, token).ConfigureAwait(false);
            return this.Ok(resistors);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(string id, CancellationToken token)
        {
            await this.resistorsService.DeleteResistorAsync(id, token).ConfigureAwait(false);
            return this.NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateAsync(
            string id, 
            [FromBody] View.Resistors.ResistorUpdateInfo updateInfo, 
            CancellationToken token)
        {
            try
            {
                await this.resistorsService.UpdateResistorAsync(id, updateInfo, token).ConfigureAwait(false);
                return this.NoContent();
            }
            catch (ValidationException ex)
            {
                return this.BadRequest(ex.ValidationResult);
            }
            catch (ResistorNotFoundException)
            {
                return this.NotFound();
            }
        }
    }
}
