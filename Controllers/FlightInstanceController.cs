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
    public class FlightInstanceController : ControllerBase
    {
        private FlightInstanceService _service;

        public FlightInstanceController(FlightInstanceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task <IActionResult> GetFlightInstances()
        {
            return Ok(await _service.GetFlightInstances());
        }

        [HttpGet("economy/{flightNumber}")]
        public async Task <IActionResult> GetNumberOfBookedEconomySeats(int flightNumber)
        {
            if (!await _service.IsFlightInstanceExist(flightNumber))
            {
                return BadRequest("Entered flightNumber of FlightInstance does not exist");
            }

            return Ok(await _service.GetNumberOfBookedEconomySeats(flightNumber));
        }

        [HttpGet("business/{flightNumber}")]
        public async Task<IActionResult> GetNumberOfBookedBusinessSeats(int flightNumber)
        {
            if (!await _service.IsFlightInstanceExist(flightNumber))
            {
                return BadRequest("Entered flightNumber of FlightInstance does not exist");
            }

            return Ok(await _service.GetNumberOfBookedBusinessSeats(flightNumber));
        }

        [HttpGet("first/{flightNumber}")]
        public async Task<IActionResult> GetNumberOfFirstClassBookedSeats(int flightNumber)
        {
            if (!await _service.IsFlightInstanceExist(flightNumber))
            {
                return BadRequest("Entered flightNumber of FlightInstance does not exist");
            }

            return Ok(await _service.GetNumberOfFirstClassBookedSeats(flightNumber));
        }

        [HttpPost]
        public async Task <IActionResult> AddFlightInstance(FlightInstance flightInstance)
        {
            if(!await _service.IsFlightExist(flightInstance.flightId))
            {
                return BadRequest("Entered flightid: " + flightInstance.flightId + " does not exist");
            }

            await _service.AddFlightInstance(flightInstance);

            return Ok("Added FlightInstance");
        }

        [HttpPut("delay/{flightNumber}/{delay}")]
        public async Task <IActionResult> AddDelay(int flightNumber, int delay)
        {
            if(!await _service.IsFlightInstanceExist(flightNumber))
            {
                return BadRequest("Entered flightNumber of FlightInstance does not exist");
            }

            await _service.AddDelay(flightNumber, delay);
            return Ok();
        }

        [HttpDelete("{flightNumber}")]
        public async Task <IActionResult> DeleteFlightInstance(int flightNumber)
        {
            if(!await _service.IsFlightInstanceExist(flightNumber))
            {
                return BadRequest("Entered flightNumber of FlightInstance does not exist");
            }

            if(!await _service.IsPossibleToDeleteFlightInstance(flightNumber))
            {
                return BadRequest("Impossible to Delete FlightInstance that has booked");
            }

            await _service.DeleteFlightInstance(flightNumber);
            return Ok("FlightInstance deleted");
        }
    }
}
