using Aspose.Pdf;
using Aspose.Words;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models;
using ProjectManager.Models.DTOs;
using ProjectManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Document = Aspose.Words.Document;

namespace ProjectManager.Controllers
{
    [ApiController]
    [Route("reports")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ReportController : ControllerBase
    {
        private readonly IReportService Service;

        public ReportController(IReportService service)
        {
            Service = service;
        }
        [HttpGet]
        public IEnumerable<Report> Get()
        {
            return Service.FindAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Report> GetById(Guid id)
        {
            Report report = Service.FindById(id);
            if(report is null)
            {
                return NotFound();
            }
            return Ok(report);
        }
        [HttpPost]
        public ActionResult<Report> Create(Report report)
        {
            try
            {
                Report saved = Service.Save(report);
                return Ok(saved);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public ActionResult<Report> Update(Report report)
        {
            if(Service.FindById(report.Id) is null)
            {
                return NotFound();
            }
            try
            {
                return Ok(Service.Edit(report));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            if (Service.FindById(id) is null)
            {
                return NotFound();
            }
            Service.Delete(id);
            return Ok();
        }
        [HttpPost("search")]
        public ActionResult<IEnumerable<Report>> AdvancedSearch(ReportSearchDto reportSearch)
        {
            IEnumerable<Report> reports = Service.Search(reportSearch);
            if(!reports.Any())
            {
                return NotFound();
            }
            return Ok(reports);
        }
        [HttpGet("hours/{date}")]
        public ActionResult<double> HourCountForDate(string date)
        {
            ClaimsIdentity claims = HttpContext.User.Identity as ClaimsIdentity;
            Guid teamMemberId = Guid.Parse(claims.Name);
            try
            {
                DateTime dateFormatted = DateTime.Parse(date);
                double calculated = Service.CountHoursByDate(dateFormatted, teamMemberId);
                return Ok(calculated);
            }
            catch(Exception)
            {
                return BadRequest("Bad date format");
            }
        }
        [HttpGet("date/{date}")]
        public ActionResult<IEnumerable<Report>> GetByDate(string date)
        {
            ClaimsIdentity claims = HttpContext.User.Identity as ClaimsIdentity;
            Guid teamMemberId = Guid.Parse(claims.Name);
            try
            {
                DateTime dateFormatted = DateTime.Parse(date);
                IEnumerable<Report> reports = Service.FindByDate(dateFormatted, teamMemberId);
                return Ok(reports);
            }
            catch (Exception)
            {
                return BadRequest("Bad date format");
            }
        }
        [HttpGet("total/{month}/{year}")]
        public ActionResult<double> GetTotalForMonth(int month, int year)
        {
            ClaimsIdentity claims = HttpContext.User.Identity as ClaimsIdentity;
            Guid teamMemberId = Guid.Parse(claims.Name);
            return Ok(Service.TotalHoursForMonth(month, year, teamMemberId));
        }
        [HttpPost("pdf")]
        public ActionResult CreatePdf(IEnumerable<Report> reports)
        {
            try
            {
                Service.CreatePdf(reports);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
    }
}
