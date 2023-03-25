using Foodie_Api.Dtos.Categories;
using Foodie_Api.Dtos.Contact;
using Foodie_Api.Dtos.Items;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodie_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ItemsController(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetItemDto>>>> Get()
        {
            var serviceResponse = new ServiceResponse<List<GetItemDto>>();

            var dbContacts = await _context.Items.ToListAsync();
            serviceResponse.Data = dbContacts.Select(c => _mapper.Map<GetItemDto>(c)).ToList();
            return serviceResponse;
        }
        [HttpPost]

        public async Task<ServiceResponse<AddItemDto>> Post([FromBody] AddItemDto newItem)
        {
            var serviceResponse = new ServiceResponse<AddItemDto>();
            try
            {
                var item = _mapper.Map<Items>(newItem);
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                serviceResponse.Data = newItem;
                serviceResponse.Message = "contact saved";
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
