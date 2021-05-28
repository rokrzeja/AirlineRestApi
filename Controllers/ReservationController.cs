using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project.Models;
using project.Models.DTO.request;
using project.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IReservationService _service;

        public ReservationController(IReservationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task <IActionResult> GetReservations()
        {
            return Ok(await _service.GetReservations());
        }

        [HttpPost]
        public async Task <IActionResult> AddDefoultReservation(ReservationRequestDTO reservationRequestDTO)
        {
            if(!await _service.IsClientExist(reservationRequestDTO.ClientPersonalId))
            {
                return BadRequest("Client does not exist");
            }

            if(!await _service.IsFlightInstanceExist(reservationRequestDTO.FlightNumber))
            {
                return BadRequest("Flight Number does not exist");
            }

            if(!await _service.IsAlreadyBooked(reservationRequestDTO))
            {
                return BadRequest("Client already booked this flight");
            }

            await _service.Book(reservationRequestDTO);
            return Ok("Booked");
        }

    }
}
