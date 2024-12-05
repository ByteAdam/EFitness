using EFitness.Data;
using EFitness.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFitness.Controllers;

public class MembersController : Controller
{
    private readonly EFitnessContext _context;

    public MembersController(EFitnessContext context)
    {
        _context = context;
    }

    public IActionResult Index()
{
    var members = _context.Members.ToList();
    return View(members);
}


    public IActionResult Details(int id)
    {
        var member = _context.Members.FirstOrDefault(m => m.Id == id);
        if (member == null) return NotFound();
        return View(member);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Member member)
    {
        if (ModelState.IsValid)
        {
            _context.Members.Add(member);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(member);
    }

    public IActionResult Edit(int id)
    {
        var member = _context.Members.FirstOrDefault(m => m.Id == id);
        if (member == null) return NotFound();
        return View(member);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Member member)
    {
        if (id != member.Id) return NotFound();

        if (ModelState.IsValid)
        {
            _context.Members.Update(member);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(member);
    }

    public IActionResult Delete(int id)
    {
        var member = _context.Members.FirstOrDefault(m => m.Id == id);
        if (member == null) return NotFound();
        return View(member);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var member = _context.Members.FirstOrDefault(m => m.Id == id);
        if (member != null)
        {
            _context.Members.Remove(member);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
}
