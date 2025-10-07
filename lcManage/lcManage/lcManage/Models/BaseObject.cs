using System.ComponentModel.DataAnnotations.Schema;

namespace lcManage.Models
{
    public class BaseObject
    {

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy  { get; set; }
        public bool IsDeleted { get; set; }
    }
}
