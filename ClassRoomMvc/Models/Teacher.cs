namespace ClassRoomMvc.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherLastName { get; set; }
        public int ClassRoomId { get; set; }
        public ClassRoom? ClassRoom { get; set; }
    }
}
