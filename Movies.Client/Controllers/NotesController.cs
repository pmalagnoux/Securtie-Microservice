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


        // GET: Notes/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            //Pas implémenté
            return View();
        }

        // GET: Notes/Create
        public IActionResult Create()
        {
            //Pas implémenté
            return View();
        }

        // POST: Notes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,Date,Owner")] Note note)
        {
            //Pas implémenté
            return View();
        }

        // GET: Notes/Edit/id
        public async Task<IActionResult> Edit(int? id)
        {
            return View();

        }

        // POST: Notes/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,Date,Owner")] Note note)
        {
            //Pas implémenté
            return View();

        }

        // GET: Notes/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            //Pas implémenté
            return View();
        }

        // POST: Notes/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //Pas implémenté
            return View();
        }

        private bool NoteExists(int id)
        {
            //Pas implémenté
            return true;
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);            
        }

    }
}
