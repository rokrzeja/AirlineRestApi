using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project.Models;
using project.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrivalController : ControllerBase
    {

        private IArrivalService _service;

        public ArrivalController(IArrivalService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlaces()
        {
            return Ok(await _service.GetPlaces());
        }

        [HttpGet("ordered")]
        public async Task<IActionResult> GetArrivalsOrderedByCountry()
        {
            return Ok(await _service.GetArrivalsOrderedByCountry());
        }

        [HttpPost]
        public async Task<IActionResult> AddDeparture(Arrival arrival)
        {
            await _service.AddArrival(arrival);
            return Ok();
        }

        [HttpDelete("{airportShortcut}")]
        public async Task<IActionResult> DeletePlace(string airportShortcut)
        {
            if (!await _service.IsAirportShortcutExist(airportShortcut))
            {
                return BadRequest(airportShortcut + " does not exist");
            }

            if (!await _service.IsPossibleToDeletePlace(airportShortcut))
            {
                return BadRequest("Imposible to delete place that have booked Flights");
            }

            await _service.DeletePlace(airportShortcut);
            return Ok(airportShortcut + " deleted");
        }


    }
}
