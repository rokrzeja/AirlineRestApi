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
    public class DepartureController : ControllerBase
    {

        private IDepartureService _service;

        public DepartureController(IDepartureService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlaces()
        {
            return Ok(await _service.GetPlaces());
        }

        [HttpGet("ordered")]
        public async Task<IActionResult> GetDeparturesOrderedByCountry()
        {
            return Ok(await _service.GetDeparturesOrderedByCountry());
        }

        [HttpPost]
        public async Task<IActionResult> AddDeparture(Departure departure)
        {
            await _service.AddDeparture(departure);
            return Ok();
        }

        [HttpDelete("{airportShortcut}")]
        public async Task<IActionResult> DeletePlace(string airportShortcut)
        {
            if(!await _service.IsAirportShortcutExist(airportShortcut))
            {
                return BadRequest(airportShortcut + " does not exist");
            }

            if(!await _service.IsPossibleToDeletePlace(airportShortcut))
            {
                return BadRequest("Imposible to delete place that have booked Flights");
            }

            await _service.DeletePlace(airportShortcut);
            return Ok(airportShortcut + " deleted");
        }


    }
}
