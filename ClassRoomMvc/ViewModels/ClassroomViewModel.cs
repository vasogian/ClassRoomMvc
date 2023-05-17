using ClassRoomMvc.Models;

namespace ClassRoomMvc.ViewModels
{
    public class ClassroomViewModel
    {
        public string Name { get; set; }
        //public int Capacity { get; set; }
        public Teacher? Teacher { get; set; }
        public ICollection<Student>? Students { get; set; }
        public ICollection<Assignment>? Assignments { get; set; }
    }
}
