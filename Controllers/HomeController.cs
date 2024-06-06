using Crud.NET7.Data;
using Crud.NET7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Crud.NET7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public HomeController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.Contacts.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid) 
            {
                contact.CreateDate = DateTime.Now;
                _dbContext.Contacts.Add(contact);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }



        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) 
            {
                return NotFound();
            }

            var contact = _dbContext.Contacts.Find(id);

            if (contact == null) 
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.CreateDate = _dbContext.Contacts.AsNoTracking().FirstOrDefault(a => a.Id == contact.Id).CreateDate;
                _dbContext.Update(contact);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        [HttpGet]
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _dbContext.Contacts.Find(id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _dbContext.Contacts.Find(id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteContact(int? id)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);

            if (contact != null) 
            {
                _dbContext.Contacts.Remove(contact);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}