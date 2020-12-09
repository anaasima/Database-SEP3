using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Database_SEP3.Persistence.DataAccess;
using Database_SEP3.Persistence.Model.Account;
using Database_SEP3.Persistence.Model.Forum.Report;
using Database_SEP3.Persistence.Model.Post;
using Microsoft.EntityFrameworkCore;

namespace Database_SEP3.Persistence.Repositories.Forum.Report
{
    public class ReportRepo : IReportRepo
    {
        private Sep3DBContext _context;
        public async Task CreateReport(ReportModel reportModel)
        {
            await using (_context = new Sep3DBContext())
            {
                PostModel postModel = await _context.Posts
                    .Include(post => post.Reports)
                    .FirstAsync(p => p.Id == reportModel.PostModelId);
                postModel.Reports.Add(reportModel);
                _context.Posts.Update(postModel);
                await _context.Reports.AddAsync(reportModel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IList<ReportModel>> ReadAllReports()
        {
            await using (_context = new Sep3DBContext())
            {
                List<ReportModel> reports = await _context.Reports.ToListAsync();
                foreach (var report in reports)
                {
                    AccountModel accountModel = await _context.Accounts.FirstAsync(a => a.UserId == report.AccountModelId);
                    report.Username = accountModel.Username;
                    Console.WriteLine(report.Username);
                }
                return reports;
            }
        }

        public async Task DeleteReport(int reportId)
        {
            await using (_context = new Sep3DBContext())
            {
                ReportModel reportModel = await _context.Reports
                    .FirstAsync(r => r.Id == reportId);
                _context.Reports.Remove(reportModel);
                await _context.SaveChangesAsync();
            }
        }
    }
}