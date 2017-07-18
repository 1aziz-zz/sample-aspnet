using System.Net;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Persistence;

namespace WebApplication2.Controllers
{
    public class CompaniesController : Controller
    {
        // private IService _companyService;
        private readonly UnitOfWork _unitOfWork;

        public CompaniesController( /*IService companyService*/)
        {
            //      _companyService = companyService;
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        // GET: Companies
        public ActionResult Index()
        {
            return View(_unitOfWork.Companies.GetAll());
        }

        // GET: Companies/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = _unitOfWork.Companies.GetById(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Company company)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Companies.Add(company);
                _unitOfWork.Companies.Save();
                return RedirectToAction("Index");
            }

            return View(company);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var company = _unitOfWork.Companies.GetById(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Company company)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Companies.Update(company);
                _unitOfWork.Companies.Save();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = _unitOfWork.Companies.GetById(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = _unitOfWork.Companies.GetById(id);
            _unitOfWork.Companies.Remove(company);
            _unitOfWork.Companies.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Companies.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}