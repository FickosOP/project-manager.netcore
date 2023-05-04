using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models;
using ProjectManager.Models.DTOs;
using ProjectManager.Services;
using ProjectManager.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManager.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService Service;
        private readonly JwtService JwtService;

        public AccountController(IAccountService service, JwtService jwtService)
        {
            Service = service;
            JwtService = jwtService;
        }
        [HttpPost]
        public ActionResult<Account> Create(Account account)
        {
            try
            {
                Account saved = Service.Save(account);
                return Ok(saved);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public ActionResult<Account> Update(Account account)
        {
            try
            {
                Account updated = Service.Edit(account);
                return Ok(updated);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("login")]
        public ActionResult<TeamMemberTokenDto> Login(CredentialsDto credentials)
        {
            try
            {
                TeamMember teamMember = Service.Login(credentials);
                string token = JwtService.GenerateJwtToken(teamMember);
                return new TeamMemberTokenDto()
                {
                    TeamMember = teamMember,
                    Token = token
                };
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet("reset/{id}")]
        public ActionResult Reset(Guid id)
        {
            bool success = Service.ResetPassword(id);
            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("password/{old}/{newPassword}")]
        public ActionResult Change(string old, string newPassword)
        {
            ClaimsIdentity claims = HttpContext.User.Identity as ClaimsIdentity;
            Guid teamMemberId = Guid.Parse(claims.Name);
            bool success = Service.ChangePassword(teamMemberId, old, newPassword);
            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
