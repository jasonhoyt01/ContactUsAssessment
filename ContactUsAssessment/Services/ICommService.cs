using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactUsAssessment.Models;

namespace ContactUsAssessment.Services
{
    public interface ICommService
    {
        void WriteContactInfo(ContactUsModel contactUsModel);
        
    }
}
