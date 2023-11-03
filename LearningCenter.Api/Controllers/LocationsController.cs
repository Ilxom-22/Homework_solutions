using LearningCenter.Application.Common.Location;
using LearningCenter.Domain.Entities.Common.Location;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly ILocationService _locationService;

    public LocationsController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet]
    public IActionResult GetAllLocations()
       => Ok(_locationService.Get(null));

    [HttpGet("{locationId}")]
    public async ValueTask<IActionResult> GetLocationById(Guid locationId)
        => Ok(await _locationService.GetByIdAsync(locationId));

    [HttpPost]
    public async ValueTask<IActionResult> CreateLocationAsync(LocationEntity location)
        => Ok(await _locationService.CreateAsync(location));

    [HttpPut]
    public async ValueTask<IActionResult> UpdateLocationAsync(LocationEntity user)
        => Ok(await _locationService.UpdateAsync(user));

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteLocationAsync(LocationEntity user)
        => Ok(await _locationService.DeleteAsync(user));

    [HttpDelete("{locationId}")]
    public async ValueTask<IActionResult> DeleteLocationByIdAsync(Guid locationId)
        => Ok(await _locationService.DeleteByIdAsync(locationId));
}