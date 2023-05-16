using ClassRoomMvc.Data;
using ClassRoomMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassRoomMvc.Services
{
    public class StudentService
    {
        private readonly ClassRoomMvcContext _context;

        public StudentService(ClassRoomMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetStudents()
        {
            var allStudents = await _context.Student

                .ToListAsync();

            if (allStudents.Any())
            {
                return allStudents;
            }
            else return new List<Student>();

        }

        public async Task<Student> GetStudent(int id)
        {
            var selectedStudent = await _context.Student
                .Include(x => x.StudentName)
                .Include(x => x.StudentLastName)
                .Include(x => x.ClassRoomId)
                .FirstOrDefaultAsync(x => x.StudentId == id);

            if (selectedStudent == null)
            {
                return new Student();
            }
            return selectedStudent;

        }

        public async Task<Student> AddStudent(Student student)
        {
            if (student != null)
            {
                _context.Student.Add(student);
                await _context.SaveChangesAsync();
            }
            return new Student();
        }


        public async Task<Student> DeleteClassRoom(int id)
        {
            var studentToBeDeleted = await GetStudent(id);
            if (studentToBeDeleted != null)
            {
                _context.Student.Remove(studentToBeDeleted);
                await _context.SaveChangesAsync();

            }
            return studentToBeDeleted;
        }
    }
}
