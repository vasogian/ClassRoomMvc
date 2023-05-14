namespace ClassRoomMvc.Models
{
    public class ClassRoom
    {
        public int ClassRoomId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public Teacher? Teacher { get; set; }
        public ICollection<Student>? Students { get; set; }
        public ICollection<Assignment>? Assignments { get; set; }
    }
}
