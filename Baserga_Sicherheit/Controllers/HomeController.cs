using Baserga_Sicherheit.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baserga_Sicherheit.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Login(UserProfile objUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var db = new DBContext())
                    {
                        var obj = db.UserProfile.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                        if (obj != null)
                        {
                            Log.Info("Anmeldung erfolgreich : " + objUser.UserName);
                            Session["UserID"] = obj.UserId.ToString();
                            Session["UserName"] = obj.UserName.ToString();
                            return RedirectToAction("UserDashBoard");
                        }
                    }
                }
                catch
                {
                    Log.Error("Ein Fehler bei der Verbindung zur Datenbank während der Anmeldung wurde entdeckt");
                }
            }
            Log.Info("Anmeldung gescheitert");
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult UserDashBoard(Ticket ticket)
        {
            using (var db = new DBContext())
            {
                if (ticket.Beschreibung != "0" && ticket.NameAufTicket != null && ticket.Zahlungsmittel != "0" && ticket.Bereich != "0")
                {
                    try
                    {
                        db.Ticket.Add(ticket);
                        db.SaveChanges();

                        Log.Info("Ticket Bestellung erfolgreich");
                        return View();
                    }
                    catch
                    {
                        Log.Error("Ein Fehler bei der Verbindung zur Datenbank während dem abspeichern eines Tickets entdeckt");
                        return View();
                    }
                }
                else
                {
                    Log.Info("Ticket Bestellung gescheitert");
                    return View();
                }
            }
        }
    }
}