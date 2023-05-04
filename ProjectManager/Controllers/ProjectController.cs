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
    [Route("projects")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProjectController : Controller
    {
        private readonly IProjectService Service;

        public ProjectController(IProjectService service)
        {
            Service = service;
        }

        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return Service.FindAllInclude();
        }
        [HttpGet("{id}")]
        public ActionResult<Project> GetById(Guid id)
        {
            Project project = Service.FindById(id);
            if(project is null)
            {
                return NotFound();
            }
            return Ok(project);
        }
        [HttpPost]
        public ActionResult<Project> Create(Project project)
        {
            try
            {
                Project saved = Service.Save(project);
                return Ok(saved);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public ActionResult<Project> Update(Project project)
        {
            if(Service.FindById(project.Id) is null)
            {
                return NotFound();
            }
            try
            {
                return Ok(Service.Edit(project));
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
        public ActionResult Search(string name)
        {
            IEnumerable<Project> projects = Service.Search(name);
            if(!projects.Any())
            {
                return NotFound();
            }
            return Ok(projects);
        }
        [HttpGet("page/{index}/{count}")]
        public IEnumerable<Project> GetPage(int index, int count)
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
