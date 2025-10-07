using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Numerics;

namespace lcManage.Models
{
    public class Subject : BaseObject
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(128)]
        public string Title { get; set; }

        [MaxLength(128)]
        public string Code { get; set; }

        public StatusEnum Status { get; set; }

        public void UpdateModel(Subject source)
        {
            Title = source.Title;
            Code = source.Code;
            Status = source.Status;
        }

    }
}
