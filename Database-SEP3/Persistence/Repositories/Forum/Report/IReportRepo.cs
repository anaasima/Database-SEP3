using System.Collections.Generic;
using System.Threading.Tasks;
using Database_SEP3.Persistence.Model.Forum.Report;

namespace Database_SEP3.Persistence.Repositories.Forum.Report
{
    public interface IReportRepo
    {
        Task CreateReport(ReportModel reportModel);
        Task<IList<ReportModel>> ReadAllReports();
        Task DeleteReport(int reportId);
    }
}