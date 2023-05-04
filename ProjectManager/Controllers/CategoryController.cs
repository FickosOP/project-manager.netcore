using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models;
using ProjectManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Controllers
{
    [ApiController]
    [Route("categories")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService Service;

        public CategoryController(ICategoryService service)
        {
            Service = service;
        }
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return Service.FindAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Category> GetById(Guid id)
        {
            Category category = Service.FindById(id);
            if(category is null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPost]
        public ActionResult<Category> Create(Category category)
        {
            try
            {
                Category saved = Service.Save(category);
                return Ok(saved);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public ActionResult<Category> Update(Category category)
        {
            if(Service.FindById(category.Id) is null)
            {
                return NotFound();
            }
            try
            {
                return Ok(Service.Edit(category));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            if(Service.FindById(id) is null)
            {
                return NotFound();
            }
            Service.Delete(id);
            return Ok();
        }
        [HttpGet("search/{name}")]
        public ActionResult<IEnumerable<Category>> Search(string name)
        {
            IEnumerable<Category> categories = Service.Search(name);
            if (!categories.Any())
            {
                return NotFound();
            }
            return Ok(categories);
        }
        [HttpGet("page/{index}/{count}")]
        public IEnumerable<Category> GetPage(int index, int count)
        {
            return Service.FindPage(index, count);
        }
        [HttpGet("nop/{pageSize}")]
        public ActionResult<int> GetPageCount(int pageSize)
        {
            return Ok(Service.GetPageCount(pageSize));
        }
    }
}
