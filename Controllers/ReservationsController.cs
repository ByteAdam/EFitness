using EFitness.Data;
using EFitness.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFitness.Controllers;

public class ReservationController : Controller
{
    private readonly EFitnessContext _context;

    public ReservationController(EFitnessContext context)
    {
        _context = context;
    }

 
public IActionResult Index()
{
    var reservations = _context.Reservations
        .Include(r => r.Member)
        .Include(r => r.Activity1)
        .ToList();

    if (reservations is List<Reservation>)
    {
        Console.WriteLine("Model type is correct.");
    }
    else
    {
        Console.WriteLine("Model type mismatch.");
    }

    return View(reservations);
}



    public IActionResult Details(int id)
    {
        var reservation = _context.Reservations
            .Include(r => r.Member)
            .Include(r => r.Activity1) // Correct navigation property
            .FirstOrDefault(r => r.Id == id);

        if (reservation == null) return NotFound();
        return View(reservation);
    }

    public IActionResult Create()
    {
        ViewData["Activities"] = _context.Activities.ToList(); // Correct DbSet name
        ViewData["Members"] = _context.Members.ToList();
        return View();
    }

    [HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Reservation reservation)
{
    // Debugging for ModelState
    if (!ModelState.IsValid)
    {
        foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
        {
            Console.WriteLine(error.ErrorMessage);
        }

        // Reload dropdowns if ModelState fails
        ViewData["Members"] = _context.Members.ToList();
        ViewData["Activities"] = _context.Activities.ToList();
        return View(reservation);
    }

    // Log reservation data for debugging
    Console.WriteLine($"Saving Reservation: MemberId={reservation.MemberId}, ActivityId={reservation.ActivityId}, Date={reservation.Date}");

    // Save to the database
    _context.Reservations.Add(reservation);
    _context.SaveChanges();

    return RedirectToAction(nameof(Index));
}

    public IActionResult Edit(int id)
    {
        var reservation = _context.Reservations.Find(id);
        if (reservation == null) return NotFound();

        ViewData["Activities"] = _context.Activities.ToList(); // Correct DbSet name
        ViewData["Members"] = _context.Members.ToList();
        return View(reservation);
    }

    [HttpPost]
    public IActionResult Edit(int id, Reservation reservation)
    {
        if (id != reservation.Id) return BadRequest();

        if (ModelState.IsValid)
        {
            _context.Reservations.Update(reservation);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        ViewData["Activities"] = _context.Activities.ToList(); // Correct DbSet name
        ViewData["Members"] = _context.Members.ToList();
        return View(reservation);
    }

    public IActionResult Delete(int id)
    {
        var reservation = _context.Reservations.Find(id);
        if (reservation == null) return NotFound();
        return View(reservation);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var reservation = _context.Reservations.Find(id);
        if (reservation == null) return NotFound();

        _context.Reservations.Remove(reservation);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}