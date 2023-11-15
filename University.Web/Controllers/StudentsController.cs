using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using University.Core.Entities;
using University.Persistence.Data;

namespace University.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly UniversityContext db;

        public StudentsController(UniversityContext context)
        {
            db = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            //var t = db.Student.ToList();
            //var t2 = db.Student.Include(s => s.Enrollments).ToList();
            //var t3 = db.Student.Include(s => s.Enrollments).ThenInclude(e => e.Course).ToList();
            //var c = db.Student.Include(s => s.Courses).ToList();

            var model = db.Student.AsNoTracking()
                                  .Select(s => new StudentIndexViewModel
                                  {
                                      Id = s.Id,
                                      Avatar = s.Avatar,
                                      FullName = s.Name.FullName,
                                      Street = s.Address.Street,
                                      //CourseInfos = s.Enrollments.Select(e => new CourseInfo
                                      //{
                                      //     CourseName = e.Course.Title,
                                      //     Grade = e.Grade
                                      //})
                                     
                                  });
            

            return View(await model.ToListAsync());
                        
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || db.Student == null)
            {
                return NotFound();
            }

            var student = await db.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
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
        public async Task<IActionResult> Create([Bind("Id,Avatar,FirstName,LastName,Email")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Add(student);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || db.Student == null)
            {
                return NotFound();
            }

            var student = await db.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Avatar,FirstName,LastName,Email")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(student);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            if (id == null || db.Student == null)
            {
                return NotFound();
            }

            var student = await db.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (db.Student == null)
            {
                return Problem("Entity set 'UniversityContext.Student'  is null.");
            }
            var student = await db.Student.FindAsync(id);
            if (student != null)
            {
                db.Student.Remove(student);
            }
            
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
          return (db.Student?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
