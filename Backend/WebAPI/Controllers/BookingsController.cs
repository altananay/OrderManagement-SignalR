using Application.Abstractions;
using Application.Requests.Booking;
using Application.Responses.Booking;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController(IBookingService _bookingService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _mapper.Map<Task<List<GetAllBookingsResponse>>>(_bookingService.GetAllAsync());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateBookingRequest request)
        {
            await _bookingService.AddAsync(_mapper.Map<CreateBookingRequest, Booking>(request));
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(Guid id)
        {
            var value = await _bookingService.GetByIdAsync(id);
            _bookingService.Delete(value);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateBookingRequest request)
        {
            _bookingService.Update(_mapper.Map<UpdateBookingRequest, Booking>(request));
            return Ok();
        }

        [HttpGet("/api/Bookings/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _bookingService.GetByIdAsync(id));
        }
    }
}