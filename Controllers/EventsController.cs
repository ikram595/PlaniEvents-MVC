using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaniEvents123.Data;
using PlaniEvents123.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PlaniEvents123.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EventsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        
        public IActionResult GetAllEvents()
        {
            var events = _context.Events.Include(e => e.Tags).ToList();//assurer que la liste des tag est chargée
            return View(events);
        }
        // filtre par "tag", affichere tous les evennements ayant le même tag
        public IActionResult EventsByTag(string tag)
        {
            var events = _context.Events.Where(e => e.Tags.Any(t => t.NomTag == tag)).ToList();
            return View("GetAllEvents", events);
        }

        // GET: Events/Create

        [Authorize(Roles = "Admin,Organizateur")]
        public IActionResult Create()
        {
            return View();
        }
       

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nom,Description,Jour,Temps,Lieu,Categorie,TagsInput")] Event @event)
        {// Set the organizer's email

            if (ModelState.IsValid)
            {
                // Process tags and add to the event
                if (!string.IsNullOrEmpty(@event.TagsInput))
                {
                    var tags = @event.TagsInput.Split(',');
                    foreach (var tag in tags)
                    {
                        // Trim the tag and add '#' if not present
                        string cleanedTag = tag.Trim();
                        if (!cleanedTag.StartsWith("#"))
                        {
                            cleanedTag = "#" + cleanedTag;
                        }
                        @event.Tags.Add(new Tag { NomTag = cleanedTag });
                    }
                }


                Console.WriteLine("Modele valide");
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GetAllEvents));
            }
            else { Console.WriteLine("Modele invalide"); }





            return View(@event);
        }
        // GET: Events/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.Include(e => e.Participants).Include(e => e.Tags).FirstOrDefaultAsync(e => e.EventId == id);

            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);

            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,Nom,Description,Jour,Temps,Lieu,Categorie,TagsInput")] Event @event)
        {
            if (id != @event.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {  // Update the tags based on TagsInput
                    UpdateTags(@event);
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(GetAllEvents));
            }
            return View(@event);

        }
        //maj tags
        private void UpdateTags(Event @event)
        {
            // Clear existing tags
            @event.Tags.Clear();

            if (!string.IsNullOrEmpty(@event.TagsInput))
            {
                var tags = @event.TagsInput.Split(',');
                foreach (var tag in tags)
                {
                    string cleanedTag = tag.TrimStart('#').Trim();
                    @event.Tags.Add(new Tag { NomTag = cleanedTag });
                }
            }
        }
        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FirstOrDefaultAsync(e => e.EventId == id);

            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Events == null)
            {

                return Problem("Entity set 'ApplicationDbContext.Events' is null.");
            }

            var @event = await _context.Events.FindAsync(id);

            if (@event != null)
            {
                _context.Events.Remove(@event);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(GetAllEvents));
        }


        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventId == id);
        }

        // GET: Events/Participate/5
        [Authorize(Roles = "Participant")]
        public async Task<IActionResult> Participate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.Include(e => e.Participants).FirstOrDefaultAsync(e => e.EventId == id);

            if (@event == null)
            {
                return NotFound();
            }

            // Add the current user to the participants list
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                @event.Participants.Add(user);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Details), new { id = @event.EventId });
        }
    }

}
