using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models;
using ProjectManager.Repositories.Implementation;
using ProjectManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Controllers
{
    [ApiController]
    [Route("clients")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClientController : ControllerBase
    {
        private readonly IClientService Service;

        public ClientController(IClientService service)
        {
            Service = service;
        }
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return Service.FindAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Client> GetById(Guid id)
        {
            Client client = Service.FindById(id);
            if(client is null)
            {
                return NotFound();
            }
            return Ok(client);
        }
        [HttpPost]
        public ActionResult<Client> Create(Client client)
        {
            try
            {
                Client saved = Service.Save(client);
                return Ok(saved);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public ActionResult<Client> Update(Client client)
        {
            if (Service.FindById(client.Id) is null)
            {
                return NotFound();
            }
            try
            {
                return Ok(Service.Edit(client));
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
        public ActionResult<IEnumerable<Client>> Search(string name)
        {
            IEnumerable<Client> clients = Service.Search(name);
            if(!clients.Any())
            {
                return NotFound();
            }
            return Ok(clients);
        }
        [HttpGet("page/{index}/{count}")]
        public IEnumerable<Client> GetPage(int index, int count)
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
