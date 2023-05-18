using ClassRoomMvc.Models;

namespace ClassRoomMvc.ViewModels
{
    public class UpdateStudentViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentLastName { get; set; }
        public int? ClassRoomId { get; set; }
        public int? AssignmentId { get; set; }
        public ICollection<Assignment>? Assignment { get; set; } = new List<Assignment>();
    }
}
