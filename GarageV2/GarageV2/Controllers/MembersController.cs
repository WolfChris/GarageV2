using GarageV2.DataAccessLayer;
using GarageV2.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GarageV2.Controllers
{
    public class MembersController : Controller
    {
        private ParkedVehicleContext db = new ParkedVehicleContext();

        // GET: Members
        public ActionResult Index()
        {
            return View(db.Member.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        public ActionResult CreateDetails(string FirstName, string LastName)
        {
            Member member = new Member() { FirstName = FirstName, LastName = LastName};
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName")] Member member)
        {
            if (ModelState.IsValid)
            {

                db.Member.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MemberNo,FirstName,LastName")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        public ActionResult MemberOverview(string searchBy, string search)
        {
            var dbMember = db.Member;
            List<Member> Members = dbMember.ToList();

            if (searchBy == "FirstName")
            {
                var memberFirstName = Members.Where(m => m.FirstName == search).
                Select(m => new GarageV2.ViewModels.MemberOverviewViewModel
                {
                    Id = m.Id,
                    FirstName = m.FirstName,
                    LastName = m.LastName
                })
                .ToList();

                return View(memberFirstName);
            }

            //if (searchBy == "Color")
            //{
            //    var vehiclesRegNo = parkedVehicles.Where(v => v.Color == search).
            //    Select(v => new GarageV2.ViewModels.OverviewViewModel
            //    {
            //        Id = v.Id,
            //        RegNo = v.RegNo,
            //        Type = v.Type.ToString(),
            //        Color = v.Color,
            //        TimeParked = TimeParked(v.CheckInTime, DateTime.Now)
            //    })
            //    .ToList();

            //    return View(vehiclesRegNo);
            //}
            var member = Members
                .Select(m => new GarageV2.ViewModels.MemberOverviewViewModel
                {
                    Id = m.Id,
                    FirstName = m.FirstName,
                    LastName = m.LastName
                })
                .ToList();

            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Member.Find(id);
            db.Member.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
