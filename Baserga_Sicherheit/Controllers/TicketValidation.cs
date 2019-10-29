using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Baserga_Sicherheit.Controllers
{
    public class TicketValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                if (value.ToString() != "0")
                {
                    return true;
                }
            }
            return false;
        }
    }
}