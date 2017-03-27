using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nibackendservice.Controllers
{
    public class tokenController : Controller
    {
        public string gettoken(string cardnumber)
        {
            if (cardnumber == "1")
            {
                return "1000";
            }
            else
            {
                return "2000";
            }

        }

    }
}