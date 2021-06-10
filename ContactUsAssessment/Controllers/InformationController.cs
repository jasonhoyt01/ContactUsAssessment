using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactUsAssessment.Models;
using ContactUsAssessment.Services;

namespace ContactUsAssessment.Models
{
    public class InformationController : Controller
    {
        //using a separate, injectable service in the event that later comms may be added
        //to handle other types of submissions. 
        private readonly ICommService _commService;

        public InformationController(ICommService commService)
        {
            _commService = commService;
        }

        public ActionResult ContactUs()
        {
            return View();
        }


        //using System.ComponentModel.DataAnnotations for validation. This allows NOT adding TLD to an email address
        //however. The requirements did not specify searching for a '.com' or other TLD. I believe that would require 
        //some complex regex.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactUs(ContactUsModel contactUsModel)
        {
            if (ModelState.IsValid)
            {
                _commService.WriteContactInfo(contactUsModel);
                ModelState.Clear();
                return ContactUs();
            }
            return View();
        }
    }
}
