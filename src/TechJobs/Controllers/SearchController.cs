using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        public IActionResult Results(string searchType,string searchTerm)
        {
           
            List<Dictionary<string, string>> jobs;

            if (searchTerm==null)
            {
                searchTerm = " ";
                
            }
           
            ViewBag.title = "Search in all: ";
            
            if (searchType.Equals("all")){
                jobs = JobData.FindByValue(searchTerm);
                ViewBag.title += searchTerm;
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType,searchTerm);
                ViewBag.title += searchType + " " + searchTerm;
            }

            ViewBag.jobs = jobs;
            ViewBag.columns = ListController.columnChoices;

            return View("Index");

        }
        // TODO #1 - Create a Results action method to process 
        // search request and display results

    }
}
