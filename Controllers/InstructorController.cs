using EFitness.Data;
using EFitness.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFitness.Controllers;

public class InstructorsController : Controller
{
    private readonly EFitnessContext _context;

    public InstructorsController(EFitnessContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Instructors.ToList());
    }

    public IActionResult Details(int id)
    {
        var instructor = _context.Instructors.Find(id);
        if (instructor == null) return NotFound();
        return View(instructor);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Instructor instructor)
    {
        if (ModelState.IsValid)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(instructor);
    }

    public IActionResult Edit(int id)
    {
        var instructor = _context.Instructors.Find(id);
        if (instructor == null) return NotFound();
        return View(instructor);
    }

    [HttpPost]
    public IActionResult Edit(int id, Instructor instructor)
    {
        if (id != instructor.Id) return BadRequest();
        if (ModelState.IsValid)
        {
            _context.Instructors.Update(instructor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(instructor);
    }

    public IActionResult Delete(int id)
    {
        var instructor = _context.Instructors.Find(id);
        if (instructor == null) return NotFound();
        return View(instructor);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var instructor = _context.Instructors.Find(id);
        if (instructor == null) return NotFound();

        _context.Instructors.Remove(instructor);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}