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
    [Route("roles")]
    public class RoleController : Controller
    {
        public IRoleService Service;
        public RoleController(IRoleService service)
        {
            Service = service;
        }
        [HttpGet]
        public IEnumerable<Role> Get()
        {
            return Service.FindAll();
        }
    }
}
