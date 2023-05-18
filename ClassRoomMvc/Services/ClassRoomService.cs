using ClassRoomMvc.Data;
using ClassRoomMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassRoomMvc.Services
{

    //Δεν είχα χρόνο να τα χρησιμοποιήσω. Είχα σκοπό να τα κάνω inject στους αντίστοιχους controllers.
    public class ClassRoomService
    {
        private readonly ClassRoomMvcContext _context;

        public ClassRoomService(ClassRoomMvcContext context)
        {
            _context = context;
        }

        public async Task<List<ClassRoom>> GetAllClassRooms()
        {
            var allClassrooms = await _context!.ClassRoom!.ToListAsync();

            if (allClassrooms.Any())
            {
                return allClassrooms;
            }
            else return new List<ClassRoom>();

        }

        public async Task<ClassRoom> GetClassRoom(int id)
        {
            var selectedClassRoom = await _context.ClassRoom
                .Include(x => x.Teacher)
                .Include(x => x.Students)
                .Include(x => x.Assignments)
                .FirstOrDefaultAsync(x => x.ClassRoomId == id);

            if (selectedClassRoom == null)
            {
                return new ClassRoom();
            }
            return selectedClassRoom;

        }

        public async Task<ClassRoom> CreateClassRoom(ClassRoom classroom)
        {
            if (classroom != null)
            {
                _context.ClassRoom.Add(classroom);
                await _context.SaveChangesAsync();
            }
            return new ClassRoom();
        }


        public async Task<ClassRoom> DeleteClassRoom(int id)
        {
            var classToBeDeleted = await GetClassRoom(id);
            if (classToBeDeleted != null)
            {
                _context.ClassRoom.Remove(classToBeDeleted);
                await _context.SaveChangesAsync();

            }
            return classToBeDeleted;
        }
    }
}
