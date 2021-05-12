using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.Models;
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
        private MainDbContext _context;

        public AirplaneController(MainDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAirplanes()
        {
            return Ok(_context.Airplanes);
        }

        [HttpPost]
        public async Task<IActionResult> AddAirplane(Airplane airplane)
        {
            try
            {
                _context.Airplanes.Add(airplane);
                await _context.SaveChangesAsync();
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
            return Ok(airplane.airplaneId);
        }

        [HttpGet("Manufacturer")]
        public async Task<IActionResult> GetAirplanesOrderedByCapacity()
        {
            var airplanes = from t in _context.Airplanes
                            orderby t.economyClassCapacity + t.firstClassCapacity + t.businessClassCapacity descending
                            select t;


            return Ok(airplanes);
        }

        [HttpGet("Economy")]
        public async Task<IActionResult> GetAirplanesByEconomyClassCapacity([FromQuery] int capacity)
        {
            if (capacity < 1)
            {
                return BadRequest("Capacity has to be more than 0");
            }

            var airplanes = await _context.Airplanes
                                .Where(a => a.economyClassCapacity >= capacity)
                                .OrderBy(a => a.economyClassCapacity).ToListAsync();

            return Ok(airplanes);
        }

        [HttpGet("Business")]
        public async Task<IActionResult> GetAirplanesByBusinessClassCapacity([FromQuery] int capacity)
        {
            if (capacity < 1)
            {
                return BadRequest("Capacity has to be more than 0");
            }

            var airplanes = await _context.Airplanes
                                .Where(a => a.businessClassCapacity >= capacity)
                                .OrderBy(a => a.businessClassCapacity).ToListAsync();

            return Ok(airplanes);
        }

        [HttpGet("First")]
        public async Task<IActionResult> GetAirplanesByFirstClassCapacity([FromQuery] int capacity)
        {
            if (capacity < 1)
            {
                return BadRequest("Capacity has to be more than 0");
            }

            var airplanes = await _context.Airplanes
                                .Where(a => a.firstClassCapacity >= capacity)
                                .OrderBy(a => a.firstClassCapacity).ToListAsync();

            return Ok(airplanes);
        }

        [HttpPut("{index}")]
        public async Task<IActionResult> changeAirplaneData(int index, Airplane airplane)
        {

            var tempAirplane = new Airplane
            {
                airplaneId = index,
                code = airplane.code,
                shortcut = airplane.shortcut,
                fullName = airplane.fullName,
                economyClassCapacity = airplane.economyClassCapacity,
                businessClassCapacity = airplane.businessClassCapacity,
                firstClassCapacity = airplane.firstClassCapacity,
                range = airplane.range,
                productionYear = airplane.productionYear,
                manufacturer = airplane.manufacturer,
                hoursFlown = airplane.hoursFlown
            };

            _context.Airplanes.Attach(tempAirplane);
            _context.Entry(tempAirplane).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok(index);
        }

        [HttpDelete("{index}")]
        public async Task<IActionResult> DeleteAirplane(int index)
        {
            var airplane = new Airplane
            {
                airplaneId = index
            };

            _context.Airplanes.Attach(airplane);
            _context.Entry(airplane).State = EntityState.Deleted;

            await _context.SaveChangesAsync();

            return Ok(index);
        }
    }
}
