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
    [Route("members")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TeamMemberController : ControllerBase
    {
        private readonly ITeamMemberService Service;

        public TeamMemberController(ITeamMemberService service)
        {
            Service = service;
        }
        [HttpGet]
        public IEnumerable<TeamMember> Get()
        {
            return Service.FindAll();
        }
        [HttpGet("{id}")]
        public ActionResult<TeamMember> GetById(Guid id)
        {
            TeamMember member = Service.FindById(id);
            if(member is null)
            {
                return NotFound();
            }
            return Ok(member);
        }
        [HttpPost]
        public ActionResult<TeamMember> Create(TeamMember member)
        {
            try
            {
                TeamMember saved = Service.Save(member);
                return Ok(saved);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public ActionResult<TeamMember> Update(TeamMember member)
        {
            if(Service.FindById(member.Id) is null)
            {
                return NotFound();
            }
            try
            {
                return Ok(Service.Edit(member));
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
        [HttpGet("page/{index}/{count}")]
        public IEnumerable<TeamMember> GetPage(int index, int count)
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
