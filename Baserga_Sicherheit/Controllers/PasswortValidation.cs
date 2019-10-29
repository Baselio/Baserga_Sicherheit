using Baserga_Sicherheit.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Baserga_Sicherheit.Controllers
{
    public class PasswortValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            using (var db = new DBContext())
            {
                if (value != null)
                {
                    var obj = db.UserProfile.Where(a => a.Password.Equals(value.ToString())).FirstOrDefault();
                    if (obj != null)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}