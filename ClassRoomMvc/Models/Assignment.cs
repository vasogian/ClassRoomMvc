namespace ClassRoomMvc.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public decimal Grade { get; set; }
        public int ClassRoomId { get; set; }
        public ICollection<Student> Students { get; } = new List<Student>();

    }
}

