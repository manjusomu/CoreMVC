using Microsoft.AspNetCore.Mvc;
using WebAppAssesment.Models;
using Task = WebAppAssesment.Models.Task;
namespace WebAppAssesment.Controllers
{
    public class TaskController : Controller
    {
        static List<Task> tasks = new List<Task>()
        {
        new Task{Id=1,Title="java",Description ="java is a high lang",DueDate=new DateTime(day:12,month:6,year:2022) },
        new Task{Id=2,Title="c",Description ="C is a Dynamic lang",DueDate=new DateTime(day:07,month:7,year:2023) },
        new Task{Id=3,Title="python",Description ="Opensource",DueDate=new DateTime(day:25,month:11,year:2021) },
        new Task{Id=4,Title="C#",Description ="C# is used to .NETframe work",DueDate=new DateTime(day:05,month:9,year:2023) },




        };
        public IActionResult Index()
        {
            return View(tasks);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Task());
        }
        [HttpPost]
        public IActionResult Create( Task t)
        {
            if(t != null)
            {
                if (ModelState.IsValid)
                {
                    tasks.Add(t);
                    return RedirectToAction("Index");
                }
              
            }
            return View(t);
        }


        [HttpGet]

        public IActionResult Delete(int id)
        {
            Task tem = tasks.SingleOrDefault(e => e.Id == id);
            if (tem == null)
            {
                return HttpNotFound();
            }
            return View(tem);
        }

        private IActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            Task tem = tasks.SingleOrDefault(e => e.Id == id);
            if (tem != null)
            {

                tasks.Remove(tem);
            }
            return RedirectToAction("Index");

        }

    }
}
