using Microsoft.AspNetCore.Mvc;
using lead_manager.Services;
using lead_manager.Models;

namespace lead_manager.Controllers;

[ApiController]
[Route("[controller]")]
public class LeadController : ControllerBase
{
    private readonly ILogger<LeadController> _logger;
    private readonly LeadService _leadService;

    public LeadController(ILogger<LeadController> logger, LeadService leadService)
    {
        _logger = logger;
        _leadService = leadService;
    }

    [HttpGet(Name = "GetLeads")]
    public async Task<ActionResult<IEnumerable<Lead>>> Get(
        [FromQuery] string sort = "desc",
        [FromQuery] LeadStatus[]? status = null)
    {
        try
        {
            status = status?.Length > 0 ? status : [LeadStatus.Invited];
            var leads = await _leadService.GetAllLeadsAsync(status, sort);
            return Ok(leads);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching leads");
            return StatusCode(500, "An error occurred while fetching leads");
        }
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> UpdateLead(int id, [FromBody] LeadUpdateDto data)
    {
        try
        {
            _logger.LogInformation($"Updating lead {id} with status {data.Status}");
            var updatedLead = await _leadService.UpdateLeadPartialAsync(id, data.Status);
            return Ok(updatedLead);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Lead not found");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating lead");
            return StatusCode(500, "An error occurred while updating the lead");
        }
    }

    [HttpPost]
    [Route("fake")]
    public async Task<ActionResult<IEnumerable<Lead>>> GenerateFake([FromBody] int quantity = 10)
    {
        try
        {
            await _leadService.GenerateFakeLeads(quantity);
            return Ok($"Successfully generated {quantity} fake leads");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating fake leads");
            return StatusCode(500, "An error occurred while generating fake leads");
        }
    }
}
