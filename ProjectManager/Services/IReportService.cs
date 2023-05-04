using ProjectManager.Models;
using ProjectManager.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Services
{
    public interface IReportService : ICrudService<Report>
    {
        public IEnumerable<Report> Search(ReportSearchDto reportSearch);
        public IEnumerable<Report> FindByDate(DateTime date, Guid teamMemberId);
        public double CountHoursByDate(DateTime date, Guid teamMemberId);
        public double TotalHoursForMonth(int month, int year, Guid teamMemberId);
        public void CreatePdf(IEnumerable<Report> reports);
    }
}
