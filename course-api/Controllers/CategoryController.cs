using Microsoft.EntityFrameworkCore;
using course_api.Data;
using course_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace course_api.Controllers
{
    [ApiController]
    [Route("v1/categories")]
    public class CategoryController : Controller 
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Course>>> GetAsync([FromServices] DataContext context)
        {
            var courses = await context.Courses.Include(c=> c.Category).ToListAsync();
            return courses;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Course>> GetById([FromServices] DataContext context, int id)
        {
            var course = await context.Courses.Include(c=> c.Category).FirstOrDefaultAsync(c=> c.Id == id);

            if(course == null) return NotFound();

            return Ok(course);    
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> PostAsync([FromServices] DataContext context, [FromBody] Category model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            context.Categories.Add(model);
            await context.SaveChangesAsync();
            return model;
        }
    }
}
