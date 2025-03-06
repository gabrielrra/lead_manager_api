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
    public async Task<ActionResult<IEnumerable<Lead>>> Get()
    {
        try
        {
            var leads = await _leadService.GetAllLeadsAsync();
            return Ok(leads);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching leads");
            return StatusCode(500, "An error occurred while fetching leads");
        }
    }

    [HttpPost(Name = "GenerateFakeLeads")]
    public async Task<ActionResult<IEnumerable<Lead>>> GenerateFake()
    {
        try
        {
            var leads = await _leadService.GetAllLeadsAsync();
            return Ok(leads);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching leads");
            return StatusCode(500, "An error occurred while fetching leads");
        }
    }
}
