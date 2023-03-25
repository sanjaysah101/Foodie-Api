using Foodie_Api.Dtos.Contact;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Foodie_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ContactsController(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetContactDto>>>> Get()
        {
            var serviceResponse = new ServiceResponse<List<GetContactDto>>();

            var dbContacts = await _context.Contacts.ToListAsync();
            serviceResponse.Data = dbContacts.Select(c => _mapper.Map<GetContactDto>(c)).ToList();
            return serviceResponse;
        }

        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpPost]
        public async Task<ServiceResponse<AddContactDto>> Post([FromBody] AddContactDto newContact)
        {
            var serviceResponse = new ServiceResponse<AddContactDto>();
            try
            {
                var contact = _mapper.Map<Contact>(newContact);
                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();
                serviceResponse.Data = newContact;
                serviceResponse.Message = "contact saved";

            }catch (Exception ex)
            {

            }
            return serviceResponse;
        }

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
