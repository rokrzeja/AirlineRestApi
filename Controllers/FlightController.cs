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
    public class FlightController : ControllerBase
    {
        private IFlightService _service;

        public FlightController(IFlightService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetFlights()
        {
            return Ok(await _service.GetFlights());
        }

        [HttpPost]
        public async Task<IActionResult> AddFlight(Flight flight)
        {
            if(!await _service.IsAirplaneExist(flight.airplaneId))
            {
                return BadRequest("Entered idAirplane does not exist");
            }

            if(!await _service.IsDeparturePlaceExist(flight.departureId))
            {
                return BadRequest("Entered idDeparture does not exist");
            }

            if(!await _service.IsArrivalPlaceExist(flight.arrivalId))
            {
                return BadRequest("Entered idArrival does not exist");
            }

            await _service.AddFlight(flight);
            return Ok("Flight added");
        }
        
        [HttpDelete("{flightNumber}")]
        public async Task <IActionResult> DeleteFlight(string flightNumber)
        {
            if(!await _service.IsFlightExist(flightNumber))
            {
                return BadRequest("Fligh nr: " + flightNumber + " does not exist");
            }

            if(!await _service.IsPossibleToDelete(flightNumber))
            {
                return BadRequest("Impossible to delete flight that has booked");
            }

            await _service.DeleteFlight(flightNumber);
            return Ok("flight deleted");
        }

    }
}
