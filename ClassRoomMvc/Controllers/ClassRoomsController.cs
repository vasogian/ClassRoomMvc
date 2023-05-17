using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassRoomMvc.Data;
using ClassRoomMvc.Models;
using ClassRoomMvc.ViewModels;

namespace ClassRoomMvc.Controllers
{
    public class ClassRoomsController : Controller
    {
        private readonly ClassRoomMvcContext _context;

        public ClassRoomsController(ClassRoomMvcContext context)
        {
            _context = context;
        }

        // GET: ClassRooms
        public async Task<IActionResult> Index()
        {
            var classroomsFromDb = await _context.ClassRoom.ToListAsync();
            var classroomViewModels = new List<ClassroomViewModel>();

            if (classroomsFromDb.Any())
            {
                foreach (var classroom in classroomsFromDb)
                {
                    classroomViewModels.Add(new ClassroomViewModel
                    {
                        ClassroomId = classroom.ClassRoomId,
                        Assignments = classroom.Assignments,
                        Capacity = classroom.Capacity,
                        Name = classroom.Name,
                        Students = classroom.Students,
                        Teacher = classroom.Teacher,
                    });
                }
            }

            return View(classroomViewModels);
        }

        // GET: ClassRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null || _context.ClassRoom == null)
            {
                return NotFound();
            }

            var classRoom = await _context.ClassRoom
                .Include(x => x.Students)
                .Include(x => x.Assignments)
                .FirstOrDefaultAsync(m => m.ClassRoomId == id);

            if (classRoom == null)
            {
                return NotFound();
            }

            var selectedClassroom = new ClassroomViewModel()
            {
                ClassroomId = classRoom.ClassRoomId,
                Name = classRoom.Name,
                Capacity = classRoom.Capacity,
                Teacher = classRoom.Teacher,
                Assignments = classRoom.Assignments,
                Students = classRoom.Students
            };

            return View(selectedClassroom);
        }

        // GET: ClassRooms/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: ClassRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Capacity")] ClassroomViewModel classRoom)
        {
            if (ModelState.IsValid)
            {
                var classroomToCreate = new ClassRoom()
                {
                    Assignments = classRoom.Assignments,
                    Capacity = classRoom.Capacity,
                    Name = classRoom.Name,
                    Students = classRoom.Students,
                    Teacher = classRoom.Teacher,
                };

                _context.Add(classroomToCreate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classRoom);
        }

        // GET: ClassRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClassRoom == null)
            {
                return NotFound();
            }

            var classRoom = await _context.ClassRoom.FindAsync(id);
            if (classRoom == null)
            {
                return NotFound();
            }
            var classroomToEdit = new UpdateClassroomViewModel()
            {
                ClassroomId = classRoom.ClassRoomId,
                Name = classRoom.Name,
                Students = classRoom.Students,
                Capacity = classRoom.Capacity,
                Assignments = classRoom.Assignments,
                Teacher = classRoom.Teacher,
            };
            return View(classroomToEdit);
        }

        // POST: ClassRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Capacity,ClassroomId")] UpdateClassroomViewModel classRoom)
        {
            if (id != classRoom.ClassroomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var classroomToUpdate = new ClassRoom()
                {
                    ClassRoomId = classRoom.ClassroomId,
                    Name = classRoom.Name,
                    Students = classRoom.Students,
                    Capacity = classRoom.Capacity,
                    Assignments = classRoom.Assignments,
                    Teacher = classRoom.Teacher,
                };

                try
                {
                    _context.Update(classroomToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassRoomExists(classRoom.ClassroomId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(classRoom);
        }

        // GET: ClassRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClassRoom == null)
            {
                return NotFound();
            }

            var classRoom = await _context.ClassRoom
                .FirstOrDefaultAsync(m => m.ClassRoomId == id);
            if (classRoom == null)
            {
                return NotFound();
            }

            var classroomToDelete = new ClassroomViewModel()
            {
                Name = classRoom.Name,
                Students = classRoom.Students,
                Capacity = classRoom.Capacity,
                Assignments = classRoom.Assignments,
                Teacher = classRoom.Teacher,
            };

            return View(classroomToDelete);
        }

        // POST: ClassRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClassRoom == null)
            {
                return Problem("Entity set 'ClassRoomMvcContext.ClassRoom'  is null.");
            }

            var classRoom = await _context.ClassRoom.FindAsync(id);

            if (classRoom != null)
            {
                _context.ClassRoom.Remove(classRoom);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ClassRoomExists(int id)
        {
            return (_context.ClassRoom?.Any(e => e.ClassRoomId == id)).GetValueOrDefault();
        }
    }
}
