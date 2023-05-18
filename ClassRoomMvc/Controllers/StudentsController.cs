using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassRoomMvc.Data;
using ClassRoomMvc.Models;
using ClassRoomMvc.ViewModels;

namespace ClassRoomMvc.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ClassRoomMvcContext _context;

        public StudentsController(ClassRoomMvcContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var studentsFromDb = await _context.Student.ToListAsync();
            var studentViewModels = new List<StudentViewModel>();

            if (studentsFromDb.Any())
            {
                foreach (var student in studentsFromDb)
                {
                    studentViewModels.Add(new StudentViewModel
                    {
                        StudentId = student.StudentId,
                        StudentName = student.StudentName,
                        StudentLastName = student.StudentLastName,
                        Assignment = student.Assignment,
                        ClassRoomId = student.ClassRoomId
                    });
                }
            }

            return View(studentViewModels);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(x => x.Assignment)
                .Where(c => c.StudentId == id)
                .FirstOrDefaultAsync();

            if (student == null)
            {
                return NotFound();
            }
            var selectedStudent = new StudentViewModel()
            {
                StudentName = student.StudentName,
                StudentLastName = student.StudentLastName,
                StudentId = student.StudentId,
                Assignment = student.Assignment,
                ClassRoomId = student.ClassRoomId

            };

            return View(selectedStudent);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,StudentLastName")] StudentViewModel student)
        {
            var studentToCreate = new Student()
            {
                StudentLastName = student.StudentLastName,
                StudentId = student.StudentId,
                StudentName = student.StudentName,
                Assignment = student.Assignment,
                ClassRoomId = student.ClassRoomId

            };

            if (ModelState.IsValid)
            {
                _context.Add(studentToCreate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            ViewData["ClassRoomId"] = new SelectList(_context.ClassRoom, "ClassRoomId", "ClassRoomId");
            ViewData["AssignmentId"] = new SelectList(_context.Assignment, "AssignmentId", "AssignmentId");

            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FirstOrDefaultAsync(x => x.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }
            var studentToEdit = new UpdateStudentViewModel()
            {
                StudentId = student.StudentId,
                StudentLastName = student.StudentLastName,
                StudentName = student.StudentName,
                Assignment = student.Assignment,
                AssignmentId = student.AssignmentId,
            };
            return View(studentToEdit);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,StudentLastName,ClassRoomId,AssignmentId")] UpdateStudentViewModel student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
             
                var assignmentFromDb = await _context.Assignment.FirstOrDefaultAsync(x => x.AssignmentId == student.AssignmentId);
                var studentToEdit = new Student()
                {
                    StudentId = student.StudentId,
                    StudentName = student.StudentName,
                    StudentLastName = student.StudentLastName,
                    AssignmentId = student.AssignmentId,
                    Assignment = student.Assignment,
                    ClassRoomId = student.ClassRoomId,
                };

                if (assignmentFromDb != null)
                {
                    student.Assignment.Add(assignmentFromDb);
                }

                try
                {
                    _context.Update(studentToEdit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }

            var studentToDelete = new StudentViewModel()
            {
                StudentId = student.StudentId,
                StudentName = student.StudentName,
                StudentLastName = student.StudentLastName,
                Assignment = student.Assignment,
                AssignmentId = student.AssignmentId,
                ClassRoomId = student.ClassRoomId
            };
            return View(studentToDelete);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Student == null)
            {
                return Problem("Entity set 'ClassRoomMvcContext.Student'  is null.");
            }
            var student = await _context.Student.FindAsync(id);

            if (student != null)
            {
                _context.Student.Remove(student);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return (_context.Student?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
