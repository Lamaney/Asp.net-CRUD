using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotnetCrud.Models;

namespace DotnetCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SchoolContext _dbContext;

        public HomeController(ILogger<HomeController> logger,SchoolContext context)
        {
            _dbContext=context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var list=_dbContext.student.ToList();
            return View(list);
        }

        public async Task<IActionResult> Delete(int Id){
            var student=await _dbContext.student.FindAsync(Id);
            _dbContext.Remove(student);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create(Student student){


            if (student.Id==0)
            {
                 await _dbContext.AddAsync(student);        
            }
            else
            {
                _dbContext.Update(student);
            }

           
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Students(int? Id)
        {
            Student student;

            if (Id.HasValue)
            {
                student=_dbContext.student.Find(Id);
            }
            else
            {
                student=new Student();
            }
          

            
            return View(student);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
