using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Foodie_Api.Data;
using Foodie_Api.Models;
using Foodie_Api.Dtos.Contact;
using Foodie_Api.Dtos.Categories;

namespace Foodie_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CategoriesController(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetCategoryDto>>>> GetCategory()
        {
            var serviceResponse = new ServiceResponse<List<GetCategoryDto>>();
            if (_context.Categories == null)
            {
                return NotFound();
            }
            //var dbCategories = await _context.Categories.ToListAsync();
            var dbCategories = await _context.Categories.Include(c => c.Items).ToListAsync();
            serviceResponse.Data = dbCategories.Select(c => _mapper.Map<GetCategoryDto>(c)).ToList();
            return serviceResponse;
        }



        // GET: api/Categories/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Category>> GetCategory(int id)
        //{
        //    if (_context.Categories == null)
        //    {
        //        return NotFound();
        //    }
        //    var category = await _context.Categories.FindAsync(id);

        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return category;
        //}

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCategory(int id, Category category)
        //{
        //    if (id != category.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(category).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CategoryExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ServiceResponse<AddCategoryDto>> PostCategory(AddCategoryDto newCategory)
        {
            var serviceResponse = new ServiceResponse<AddCategoryDto>();
            try
            {
                var category = _mapper.Map<Category>(newCategory);
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                serviceResponse.Data = newCategory;
                serviceResponse.Message = "contact saved";
                return serviceResponse;
            }catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.InnerException.Message;
                return serviceResponse;
            }
        }

        // DELETE: api/Categories/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCategory(int id)
        //{
        //    if (_context.Categories == null)
        //    {
        //        return NotFound();
        //    }
        //    var category = await _context.Categories.FindAsync(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Categories.Remove(category);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool CategoryExists(int id)
        {
            return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
