using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gobi.Test.Jr.Domain;
using Gobi.Test.Jr.Infra.Data;
using Gobi.Test.Jr.Domain.Interfaces.Services;

namespace Gobi.Tests.Jr.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITodoItemService _service;

        public HomeController(ITodoItemService todoItemService)
        {
           _service = todoItemService;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAll();

            return View(result);
        }

        // GET: Home/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.todoItems == null)
        //    {
        //        return NotFound();
        //    }

        //    var todoItem = await _context.todoItems
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (todoItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(todoItem);
        //}

        // GET: Home/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Completed,Description")] TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
               await _service.Add(todoItem);
               
                return RedirectToAction(nameof(Index));
            }
            return View(todoItem);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
           

            var todoItem = await _service.GetById(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            
            return View((TodoItem)todoItem);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Completed,Description,Finished,Time")] TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _service.Update(todoItem);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(todoItem);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            

            var todoItem = await _service.GetById(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return View(todoItem);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todoItem = await _service.GetById(id);
            if (todoItem != null)
            {
              await _service.Delete(todoItem);
            }
            
           
            return RedirectToAction(nameof(Index));
        }

      
    }
}
