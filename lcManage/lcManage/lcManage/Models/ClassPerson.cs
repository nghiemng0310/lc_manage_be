using System.ComponentModel.DataAnnotations;

namespace lcManage.Models
{
    public class ClassPerson: BaseObject
    {
        [Key]
        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public int ClassId { get; set; }
        public int? StudentId { get; set; }
        public RoleEnum Role { get; set; }
        public StatusEnum Status { get; set; }

        public void UpdateModel(ClassPerson source)
        {
            TeacherId = source.TeacherId;
            ClassId = source.ClassId;
            StudentId = source.StudentId;
            Role = source.Role;
            Status = source.Status;
        }

    }
}
