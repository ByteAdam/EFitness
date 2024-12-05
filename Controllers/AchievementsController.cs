using EFitness.Data;
using EFitness.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFitness.Controllers;

public class AchievementsController : Controller
{
    private readonly EFitnessContext _context;

    public AchievementsController(EFitnessContext context)
    {
        _context = context;
    }

   public IActionResult Index()
{
    var achievements = _context.Achievements.ToList();
    return View(achievements); // Ensure the 'Index.cshtml' matches this call
}


    public IActionResult Details(int id)
    {
        var achievement = _context.Achievements.Find(id);
        if (achievement == null) return NotFound();
        return View(achievement);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Achievement achievement)
    {
        if (ModelState.IsValid)
        {
            _context.Achievements.Add(achievement);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(achievement);
    }

    public IActionResult Edit(int id)
    {
        var achievement = _context.Achievements.Find(id);
        if (achievement == null) return NotFound();
        return View(achievement);
    }

    [HttpPost]
    public IActionResult Edit(int id, Achievement achievement)
    {
        if (id != achievement.Id) return BadRequest();
        if (ModelState.IsValid)
        {
            _context.Achievements.Update(achievement);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(achievement);
    }

    public IActionResult Delete(int id)
    {
        var achievement = _context.Achievements.Find(id);
        if (achievement == null) return NotFound();
        return View(achievement);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var achievement = _context.Achievements.Find(id);
        if (achievement == null) return NotFound();

        _context.Achievements.Remove(achievement);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
