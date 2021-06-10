using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using ContactUsAssessment.Models;
using System.Net.Mail;

namespace ContactUsAssessment.Services
{
    public class CommService : ICommService
    {

        //Since this is usually sent by email, or saved in another fashion, the meat of the work is done already.
        //If a later requirement to email a different type of info is added, a new member can be added with 
        //appropriate parameters.

        private readonly IWebHostEnvironment _webHostEnvironment;

        public CommService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public void WriteContactInfo(ContactUsModel contactUsModel)
        {
            try
            {
                string path = $"{_webHostEnvironment.ContentRootPath}\\{contactUsModel.EmailAddress}.json";
                string json = JsonSerializer.Serialize(contactUsModel);
                File.WriteAllText(path, json);
            }
            catch
            {
                //not much to do here, but if there was...
            }
        }
    }
}
