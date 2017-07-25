using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication2.Models;
using WebApplication2.Persistence;

namespace WebApplication2.Controllers
{
    public class RestController : ApiController
    {
        private readonly UnitOfWork _unitOfWork;

        public RestController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        // GET: api/Rest
        public IQueryable<Company> GetCompanies()
        {
            return _unitOfWork.Companies.GetAll().AsQueryable();
        }
        // GET: api/Rest/5
        [ResponseType(typeof(Company))]
        public IHttpActionResult GetCompany(int id)
        {
            Company company = _unitOfWork.Companies.GetById(id);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // PUT: api/Rest/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompany(int id, Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != company.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Companies.Update(company);

            try
            {
                _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Rest
        [ResponseType(typeof(Company))]
        public IHttpActionResult PostCompany(Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.Companies.Add(company);
            _unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new {id = company.Id}, company);
        }

        // DELETE: api/Rest/5
        [ResponseType(typeof(Company))]
        public IHttpActionResult DeleteCompany(int id)
        {
            Company company = _unitOfWork.Companies.GetById(id);
            if (company == null)
            {
                return NotFound();
            }

            _unitOfWork.Companies.Remove(company);
            _unitOfWork.Complete();

            return Ok(company);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyExists(int id)
        {
            return _unitOfWork.Companies.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}