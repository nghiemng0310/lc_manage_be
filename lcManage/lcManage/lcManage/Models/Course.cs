using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Numerics;

namespace lcManage.Models
{
    public class Course : BaseObject
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(128)]
        public string Title { get; set; }

        [MaxLength(128)]
        public string Code { get; set; }

        public StatusEnum Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SubjectId { get; set; }

        public void UpdateModel(Course source)
        {
            Title = source.Title;
            Code = source.Code;
            Status = source.Status;
            StartDate = source.StartDate;
            EndDate = source.EndDate;
            SubjectId = source.SubjectId;
        }

    }
}
