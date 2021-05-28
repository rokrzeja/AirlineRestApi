using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class AirplaneController : ControllerBase
    {
        private IAirplaneService _service;

        public AirplaneController(IAirplaneService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAirplanes()
        {
            return Ok( await _service.GetAirplanes());
        }

        [HttpGet("Capacity")]
        public async Task<IActionResult> GetAirplanesOrderedByCapacity()
        {
            return Ok(await _service.GetAirplanesOrderedByCapacity());
        }

        [HttpGet("Economy/{capacity}")]
        public async Task<IActionResult> GetAirplanesByEconomyClassCapacity(int capacity)
        {
            if (capacity < 1)
            {
                return BadRequest("Capacity has to be more than 0");
            }

            return Ok(await _service.GetAirplanesByEconomyClassCapacity(capacity));
        }

        [HttpGet("Business/{capacity}")]
        public async Task<IActionResult> GetAirplanesByBusinessClassCapacity(int capacity)
        {
            if (capacity < 1)
            {
                return BadRequest("Capacity has to be more than 0");
            }

            return Ok(await _service.GetAirplanesByBusinessClassCapacity(capacity));
        }

        [HttpGet("First/{capacity}")]
        public async Task<IActionResult> GetAirplanesByFirstClassCapacity(int capacity)
        {
            if (capacity < 1)
            {
                return BadRequest("Capacity has to be more than 0");
            }

            return Ok(await _service.GetAirplanesByFirstClassCapacity(capacity));
        }

        [HttpPost]
        public async Task<IActionResult> AddAirplane(Airplane airplane)
        {
            try
            {
                await _service.AddAirplane(airplane);
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
            return Ok(airplane.airplaneId);
        }

        [HttpPut("{index}")]
        public async Task<IActionResult> changeAirplaneData(int index, Airplane airplane)
        {
            if(!await _service.IsAirplaneExist(index))
            {
                return BadRequest("Airplane does not exist");
            }

            if(!await _service.IsPossibleToDeleteOrUpdate(index))
            {
                return BadRequest("Impossible to change data of Airplane that has booked flights");
            }

            await _service.changeAirplaneData(index,airplane);
            return Ok("Airplane data has changed");
        }

        [HttpDelete("{index}")]
        public async Task<IActionResult> DeleteAirplane(int index)
        {
            if (!await _service.IsAirplaneExist(index))
            {
                return BadRequest("Airplane does not exist");
            }

            if (!await _service.IsPossibleToDeleteOrUpdate(index))
            {
                return BadRequest("Impossible to delete the Airplane that has booked flights");
            }

            await _service.DeleteAirplane(index);
            return Ok("Airplane has deleted");
        }




    }
}
