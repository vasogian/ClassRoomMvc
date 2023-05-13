namespace ClassRoomMvc.Models
{
    public class ClassRoom
    {
        public int ClassRoomId { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public int StudentId { get; set; }
        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
        public int AssignmentId { get; set; }

    }
}
