using Aspose.Words;
using ProjectManager.Models;
using ProjectManager.Models.DTOs;
using ProjectManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Services.Implementation
{
    public class ReportService : CrudService<Report>, IReportService
    {
        private readonly ITeamMemberRepository TeamMemberRepository;
        public ReportService(IReportRepository repository, ITeamMemberRepository teamMemberRepository) : base(repository) 
        {
            TeamMemberRepository = teamMemberRepository;
        }

        public IEnumerable<Report> Search(ReportSearchDto reportSearch)
        {
            IReportRepository repository = Repository as IReportRepository;
            DateTime parsedStart = DateTime.Parse(reportSearch.StartDate);
            DateTime parsedFinish = DateTime.Parse(reportSearch.EndDate);
            return repository
                    .FindAllInclude()
                    .Where(report => report.ClientId == reportSearch.ClientId)
                    .Where(report => report.TeamMemberId == reportSearch.TeamMemberId)
                    .Where(report => report.ProjectId == reportSearch.ProjectId)
                    .Where(report => report.CategoryId == reportSearch.CategoryId)
                    .Where(report => report.CreatedAt > parsedStart && report.CreatedAt < parsedFinish);
        }

        public override IEnumerable<Report> FindAll()
        {
            IReportRepository repository = Repository as IReportRepository;
            return repository
                    .FindAllInclude();
        }
        public IEnumerable<Report> FindByDate(DateTime date, Guid teamMemberId)
        {
            IReportRepository repository = Repository as IReportRepository;
            IEnumerable<Report> allReports = repository
                                            .FindAllInclude()
                                            .Where(report => report.CreatedAt.Date == date.Date);

            IEnumerable<Report> filterByRole = FilterByRole(allReports, teamMemberId);
            return filterByRole;
        }
        public double CountHoursByDate(DateTime date, Guid teamMemberId)
        {
            IReportRepository repository = Repository as IReportRepository;
            IEnumerable<Report> reportsForDate = FilterByRole(repository.FindByDate(date), teamMemberId);
            double hours = 0;
            foreach(Report report in reportsForDate)
            {
                hours += report.Time + report.Overtime;
            }
            return hours;
        }

        public double TotalHoursForMonth(int month, int year, Guid teamMemberId)
        {
            month++;
            IEnumerable<Report> monthReports = FilterByRole(
                                                Repository
                                                .FindAll()
                                                .Where(report => 
                                                    report.CreatedAt.Month == month && 
                                                    report.CreatedAt.Year == year), teamMemberId);
            double total = 0;
            foreach(Report report in monthReports)
            {
                total += report.Time + report.Overtime;
            }
            return total;
        }

        private IEnumerable<Report> FilterByRole(IEnumerable<Report> reports, Guid teamMemberId)
        {
            TeamMember teamMember = TeamMemberRepository.FindById(teamMemberId);
            if (teamMember.Role.Name.Equals("Admin"))
            {
                return reports;
            }
            else
            {
                return reports.Where(report => report.TeamMemberId == teamMemberId);
            }
        }
        public void CreatePdf(IEnumerable<Report> reports)
        {
            Document document = new Document();
            DocumentBuilder builder = new DocumentBuilder(document);

            builder.Font.Size = 10;
            Aspose.Words.Tables.Table table = builder.StartTable();

            builder.CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;

            builder.InsertCell();
            builder.Write("Date");
            builder.InsertCell();
            builder.Write("Team member");
            builder.InsertCell();
            builder.Write("Project");
            builder.InsertCell();
            builder.Write("Category");
            builder.InsertCell();
            builder.Write("Description");
            builder.InsertCell();
            builder.Write("Time");
            builder.EndRow();

            foreach (Report report in reports)
            {
                builder.InsertCell();
                builder.Write(Convert.ToString(report.CreatedAt));

                builder.InsertCell();
                builder.Write(Convert.ToString(report.TeamMember.Name));

                builder.InsertCell();
                builder.Write(Convert.ToString(report.Project.Name));

                builder.InsertCell();
                builder.Write(Convert.ToString(report.Category.Name));

                builder.InsertCell();
                builder.Write(report.Description);

                builder.InsertCell();
                builder.Write(Convert.ToString(report.Time + report.Overtime));
                builder.EndRow();
            }
            builder.EndTable();
            document.Save($"report-{DateTime.Now.Millisecond}.pdf");
        }
    }
}
