namespace ClassRoomMvc.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentLastName { get; set; }
        public int? ClassRoomId { get; set; }    
        public ICollection<Assignment> Assignment { get; set; }

    }
}
