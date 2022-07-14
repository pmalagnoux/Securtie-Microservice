using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Notes.Client.ApiServices;
using Notes.Client.Models;

namespace Notes.Client.Controllers
{
    [Authorize]
    public class NotesController : Controller
    {        
        private readonly INoteApiService _noteApiService;

        public NotesController(INoteApiService noteApiService)
        {
            _noteApiService = noteApiService ?? throw new ArgumentNullException(nameof(noteApiService));
        }

        // GET: Notes
        public async Task<IActionResult> Index()
        {
            await LogTokenAndClaims();
            return View(await _noteApiService.GetNotes());
        }
        public async Task LogTokenAndClaims()
        {
            var identityToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            Debug.WriteLine($"Identity token: {identityToken}");

            foreach (var claim in User.Claims)
            {
                Debug.WriteLine($"Claim type: {claim.Type} - Claim value: {claim.Value}");
            }
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> OnlyAdmin()
        {
            var userInfo = await _noteApiService.GetUserInfo();
            return View(userInfo);            
        }


        // GET: Notes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return View();

            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var note = await _context.Note
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (note == null)
            //{
            //    return NotFound();
            //}

            //return View(note);
        }

        // GET: Notes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,Date,Owner")] Note note)
        {
            return View();

            //if (ModelState.IsValid)
            //{
            //    _context.Add(note);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(note);
        }

        // GET: Notes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return View();

            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var note = await _context.Note.FindAsync(id);
            //if (note == null)
            //{
            //    return NotFound();
            //}
            //return View(note);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,Date,Owner")] Note note)
        {
            return View();

            //if (id != note.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(note);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!NoteExists(note.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(note);
        }

        // GET: Notes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return View();

            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var note = await _context.Note
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (note == null)
            //{
            //    return NotFound();
            //}

            //return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return View();

            //var note = await _context.Note.FindAsync(id);
            //_context.Note.Remove(note);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
        }

        private bool NoteExists(int id)
        {
            return true;

            //return _context.Note.Any(e => e.Id == id);
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);            
        }

    }
}
