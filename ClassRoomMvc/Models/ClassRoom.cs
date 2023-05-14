namespace ClassRoomMvc.Models
{
    public class ClassRoom
    {
        public int ClassRoomId { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public ICollection<Student>Students { get; set; } = new List<Student>();       
        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
        
    }
}
