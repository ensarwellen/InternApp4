using InternApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternApp.Controllers
{
    public class NotesController : Controller
    {
        private readonly AppDbContext _context;

        public NotesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var notes = _context.Notes.ToList();
            ViewBag.Notes = notes;
            return View();
        }
        public IActionResult ListNotes()
        {
            var notes = _context.Notes.OrderByDescending(x => x.Id).ToList();
            
            return Json(notes);
        }
        public IActionResult RemoveNote(int id)
        {
            var note = _context.Notes.Find(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [HttpPost]
        public IActionResult UpdateCheckbox(int id, bool isSelected)
        {
            var note = _context.Notes.Find(id);
            if (note != null)
            {
                note.IsSelected = isSelected;
                _context.Notes.Update(note);
                _context.SaveChanges();
            }
            return Json(new { IsSuccess = true });
        }
        [HttpPost]
        public IActionResult SaveNote(Notes noted)
        {
            
                var savedNot = _context.Notes.Add(noted);
                _context.SaveChanges();

            return Json(new { IsSuccess = "true" });

            

        }
    }
}
