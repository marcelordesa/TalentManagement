using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TalentManagement.UI.Controllers
{
    public class PersonController : Controller
    {
        [Route("Person/Index/{profileId}/{id}")]
        public IActionResult Index(int profileId, int id)
        {
            if (profileId == (int)EnumProfile.Administrator)
                return View("ListPerson", new { id = id });
            else
                return View("PersonPanel", new { id = id });
        }

        [Route("Person/EditPerson/{idSelected}/{id?}")]
        public IActionResult EditPerson(int idSelected, int? id)
        {
            return View();
        }

        [Route("Person/PersonPanel/{id}")]
        public IActionResult PersonPanel(int id)
        {
            return View();
        }

        [Route("Person/ListPerson/{id}")]
        public IActionResult ListPerson(int id)
        {
            return View();
        }

        [Route("Person/CreatePerson/{id}")]
        public IActionResult CreatePerson(int id)
        {
            return View();
        }

        [Route("Person/UpdatePassword/{idSelected}/{id?}")]
        public IActionResult UpdatePassword(int idSelected, int? id)
        {
            return View();
        }
        [Route("Person/UpdateProfile/{idSelected}/{id?}")]
        public IActionResult UpdateProfile(int idSelected, int? id)
        {
            return View();
        }
    }

    public enum EnumProfile
    {
        Administrator = 1,
        Talent = 2
    }
}