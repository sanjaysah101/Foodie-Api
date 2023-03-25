using Foodie_Api.Dtos.Booking;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodie_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public BookingController(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetBookingDto>>>> Get()
        {
            var serviceResponse = new ServiceResponse<List<GetBookingDto>>();
            if (_context.Booking == null)
            {
                return NotFound();
            }
            //var dbCategories = await _context.Categories.ToListAsync();
            var dbBooking = await _context.Booking.ToListAsync();
            serviceResponse.Data = dbBooking.Select(c => _mapper.Map<GetBookingDto>(c)).ToList();
            return serviceResponse;
        }
        [HttpPost]
        public async Task<ServiceResponse<AddBookingDto>> Post(AddBookingDto newBooking)
        {
            var serviceResponse = new ServiceResponse<AddBookingDto>();
            try
            {
                var booking = _mapper.Map<Booking>(newBooking);
                _context.Booking.Add(booking);
                await _context.SaveChangesAsync();
                serviceResponse.Data = newBooking;
                serviceResponse.Message = "booking saved";
                return serviceResponse;
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.InnerException.Message;
                return serviceResponse;
            }
        }
    }
}
