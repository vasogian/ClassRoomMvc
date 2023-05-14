using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassRoomMvc.Data;
using ClassRoomMvc.Models;
using ClassRoomMvc.Services;

namespace ClassRoomMvc.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentService _service;

        public StudentsController(StudentService service)
        {
            _service = service;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var allStudents = await _service.GetStudents();
            if (!allStudents.Any())
            {
                return Problem("Entity set 'ClassRoomMvcContext.Student'  is null.");
            }

            return View(allStudents);

        }

        // GET: Students/Details/5
        public async Task<IActionResult> GetStudent(int id)
        {
            var selectedStudent = await _service.GetStudent(id);
            if (selectedStudent == null)
            {
                return NotFound();
            }

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
        
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,StudentLastName")] Student student)
        {
            if (ModelState.IsValid)
            {
                await this._service.AddStudent(student);

                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

    }
}
