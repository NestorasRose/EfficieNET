using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EfficieNET.Data;
using VRtour.Lib.Models;

namespace EfficieNET.Controllers
{
    public class BuyRealEstatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BuyRealEstatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BuyRealEstates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Buy.Include(b => b.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BuyRealEstates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyRealEstate = await _context.Buy
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buyRealEstate == null)
            {
                return NotFound();
            }

            return View(buyRealEstate);
        }

        // GET: BuyRealEstates/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: BuyRealEstates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Price,VRtourURL,City,Area,Type,Condition,PlotSizeSquareMeters,NumberOfParkingSpaces,NumberOfBalconies,NumberOfAirCondition,NumberOfBedrooms,NumberOfBathrooms,IsFurnishing,HasPool,HasGarden,HasElevator,HasAlarm,HasFireplace,HasPlayroom,HasAtticLoft,HasStorageRoom,HasSauna,CreatedDate,UpdatedDate")] BuyRealEstate buyRealEstate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buyRealEstate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", buyRealEstate.UserId);
            return View(buyRealEstate);
        }

        // GET: BuyRealEstates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyRealEstate = await _context.Buy.FindAsync(id);
            if (buyRealEstate == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", buyRealEstate.UserId);
            return View(buyRealEstate);
        }

        // POST: BuyRealEstates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Price,VRtourURL,City,Area,Type,Condition,PlotSizeSquareMeters,NumberOfParkingSpaces,NumberOfBalconies,NumberOfAirCondition,NumberOfBedrooms,NumberOfBathrooms,IsFurnishing,HasPool,HasGarden,HasElevator,HasAlarm,HasFireplace,HasPlayroom,HasAtticLoft,HasStorageRoom,HasSauna,CreatedDate,UpdatedDate")] BuyRealEstate buyRealEstate)
        {
            if (id != buyRealEstate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buyRealEstate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyRealEstateExists(buyRealEstate.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", buyRealEstate.UserId);
            return View(buyRealEstate);
        }

        // GET: BuyRealEstates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buyRealEstate = await _context.Buy
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buyRealEstate == null)
            {
                return NotFound();
            }

            return View(buyRealEstate);
        }

        // POST: BuyRealEstates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buyRealEstate = await _context.Buy.FindAsync(id);
            _context.Buy.Remove(buyRealEstate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuyRealEstateExists(int id)
        {
            return _context.Buy.Any(e => e.Id == id);
        }
    }
}
