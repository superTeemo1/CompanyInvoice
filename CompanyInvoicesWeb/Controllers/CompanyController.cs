using AutoMapper;
using CompanyInovicesEF.Tables;
using CompanyInvoicesWeb.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL = CompanyInovicesEF.DAL;
using VM = CompanyInvoicesWeb.Models;

namespace CompanyInvoicesWeb.Controllers
{
    public class CompanyController : Controller
    {
        DAL.Company companyDAL = new DAL.Company();

      
        public ActionResult AddNewCompany()
        {
            var company = new VM.Company();
            return View(company);
        }
        [HttpPost]
        public ActionResult AddNewCompany(VM.Company company)
        {
            var dbCompany = new Company();
            
            dbCompany.CompanyName = company.CompanyName;
            dbCompany.City = company.City;
            dbCompany.Address = company.Address;
            dbCompany.Email = company.Email;
            dbCompany.Street = company.Street;
            dbCompany.Phone = company.Phone;
            dbCompany.ContactPerson = company.ContactPerson;
            dbCompany.StreetNumber = company.StreetNumber;
            dbCompany.Zip = company.Zip;
            dbCompany.ContractStartDate = company.ContractStartDate;
            dbCompany.ContractEndDate = company.ContractEndDate;
            dbCompany.ContractStatus = company.ContractStatus;
            companyDAL.AddNewCompany(dbCompany);
            return View();
        }

        // GET: Company
        public ActionResult Index()
        {
            List<CompanyInvoicesWeb.Models.Company> companiesVM = new List<CompanyInvoicesWeb.Models.Company>();
            var dbCompanies = companyDAL.GetAllCompanies();
            dbCompanies.ForEach(item =>
                {
                    companiesVM.Add(MapperConfig.Mapper.Map< CompanyInvoicesWeb.Models.Company>(item));
                });

            return View(companiesVM);
        }
        public ActionResult EditCompany(string id)
        {
            var dbCompany = new VM.Company();

            var company = companyDAL.GetCompanyByName(id);

            dbCompany.CompanyName = company.CompanyName;
            dbCompany.Address = company.Address;
            dbCompany.Street = company.Street;
            dbCompany.StreetNumber = company.StreetNumber;
            dbCompany.Zip = company.Zip;
            dbCompany.Email = company.Email;
            dbCompany.ContactPerson = company.ContactPerson;
            dbCompany.Phone = company.Phone;
            dbCompany.City = company.City;
            dbCompany.ContractStartDate = company.ContractStartDate;
            dbCompany.ContractEndDate = company.ContractEndDate;
            dbCompany.ContractStatus = company.ContractStatus;

            return View(dbCompany);
        }

        [HttpPost]
        public ActionResult EditCompany (VM.Company company)
        {

            var dbCompany = new Company();
            dbCompany.CompanyName = company.CompanyName;
            dbCompany.City = company.City;
            dbCompany.Address = company.Address;
            dbCompany.Email = company.Email;
            dbCompany.Street = company.Street;
            dbCompany.Phone = company.Phone;
            dbCompany.ContactPerson = company.ContactPerson;
            dbCompany.StreetNumber = company.StreetNumber;
            dbCompany.Zip = company.Zip;
            dbCompany.ContractStartDate = company.ContractStartDate;
            dbCompany.ContractEndDate = company.ContractEndDate;
            dbCompany.ContractStatus = company.ContractStatus;
            companyDAL.EditCompany(dbCompany);
            return RedirectToAction("Index");
        }
        public ActionResult CompanyDetails(string id)
        {
            var company = companyDAL.GetCompanyByName(id);

            return View(MapperConfig.Mapper.Map<VM.Company>(company));
        }
       
        [HttpPost]
        public ActionResult DeleteCompany(string companyName)
        {
            companyDAL.DeleteCompany(companyName);

            return RedirectToAction("Index");
        }
    }

}