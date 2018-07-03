using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class PaytweakController : Controller
    {
        wrapper pWrapper;
        string sEtatPtwk;
        char quote;
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Paytweak()
        {
            
            pWrapper  = new wrapper("#ce355ffdc234627f33fd46ffb938592e92bc0f750c8ac91015ad15be1a863908#", "a06f4fff21589b02");
            sEtatPtwk=pWrapper.ApiConnect();
         
            ViewData["Etat"] =sEtatPtwk ;
            return View();
           
        }
    }
}