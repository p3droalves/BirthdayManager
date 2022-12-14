using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BirthdayManager.Data;
using BirthdayManager.Models;
using BirthdayManager.Services;

namespace BirthdayManager.Controllers
{
    public class FriendsController : Controller
    {
        private readonly FriendService service;

        public FriendsController(FriendService service)
        {
            this.service = service;
        }

        // GET: Friends
        public async Task<IActionResult> Index()
        {
            return View(await service.GetAll());
        }

        // GET: Friends/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var friend = await service.GetById(id);

            if (friend == null)
            {
                return NotFound();
            }

            return View(friend);
        }

        // GET: Friends/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Friends/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FriendId,FirstName,LastName,Birthday")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                await service.Create(friend);
                return RedirectToAction(nameof(Index));
            }
            return View(friend);
        }

        // GET: Friends/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var friend = await service.GetById(id);

            if (friend == null)
            {
                return NotFound();
            }

            return View(friend);
        }

        // POST: Friends/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FriendId,FirstName,LastName,Birthday")] Friend friend)
        {
            if (id != friend.FriendId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await service.Update(friend);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await FriendExists(friend.FriendId) == false)
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
            return View(friend);
        }

        // GET: Friends/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var friend = await service.GetById(id);

            if (friend == null)
            {
                return NotFound();
            }

            return View(friend);
        }

        // POST: Friends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var friend = await service.GetById(id);
            if (friend != null)
            {
                await service.Delete(friend);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> FriendExists(int id)
        {
            var friend = await service.GetById(id);

            return friend == null ? false : true;
        }
    }
}