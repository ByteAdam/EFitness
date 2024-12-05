using EFitness.Data;
using EFitness.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFitness.Controllers;

public class Activity1Controller : Controller
{
    private readonly EFitnessContext _context;

    public Activity1Controller(EFitnessContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Activities.ToList());
    }

    public IActionResult Details(int id)
    {
        var activity = _context.Activities.Find(id);
        if (activity == null) return NotFound();
        return View(activity);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Activity1 activity)
    {
        if (ModelState.IsValid)
        {
            _context.Activities.Add(activity);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(activity);
    }

    public IActionResult Edit(int id)
    {
        var activity = _context.Activities.Find(id);
        if (activity == null) return NotFound();
        return View(activity);
    }

    [HttpPost]
    public IActionResult Edit(int id, Activity1 activity)
    {
        if (id != activity.Id) return BadRequest();
        if (ModelState.IsValid)
        {
            _context.Activities.Update(activity);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(activity);
    }

    public IActionResult Delete(int id)
    {
        var activity = _context.Activities.Find(id);
        if (activity == null) return NotFound();
        return View(activity);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var activity = _context.Activities.Find(id);
        if (activity == null) return NotFound();

        _context.Activities.Remove(activity);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
