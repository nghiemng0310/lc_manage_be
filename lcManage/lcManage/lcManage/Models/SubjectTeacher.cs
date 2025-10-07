using System.ComponentModel.DataAnnotations;

namespace lcManage.Models
{
    public class SubjectTeacher: BaseObject
    {
        [Key]
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }

        public StatusEnum Status { get; set; }
        public void UpdateModel(SubjectTeacher source)
        {
            TeacherId = source.TeacherId;
            SubjectId = source.SubjectId;
            Status = source.Status;
        }


    }
}
