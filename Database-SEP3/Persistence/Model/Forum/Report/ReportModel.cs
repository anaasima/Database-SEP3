using System.ComponentModel.DataAnnotations;

namespace Database_SEP3.Persistence.Model.Forum.Report
{
    public class ReportModel
    {
        [Key]
        public int Id { get; set; }
        public int PostModelId { get; set; }
        public int AccountModelId { get; set; }
    }
}