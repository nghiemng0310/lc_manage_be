using System.ComponentModel.DataAnnotations;

namespace lcManage.Models
{
    public class Teacher: BaseObject
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(128)]
        public string FullName { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }

        public StatusEnum Status { get; set; }
        public void UpdateModel(Teacher source)
        {
            FullName = source.FullName;
            Address = source.Address;
            DateOfBirth = source.DateOfBirth;
            Status = source.Status;
        }
    }
}
