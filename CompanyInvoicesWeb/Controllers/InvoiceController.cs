using CompanyInvoicesWeb.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL = CompanyInovicesEF.DAL;
using VM = CompanyInvoicesWeb.Models;
using DB = CompanyInovicesEF.Tables;

namespace CompanyInvoicesWeb.Controllers
{
    public class InvoiceController : Controller
    {
        DAL.Company companyDAL = new DAL.Company();
        DAL.Invoice invoiceDAL = new DAL.Invoice();
        // GET: Invoice
        public ActionResult Index()
        {
            List<CompanyInvoicesWeb.Models.Inovice> invoiceVM = new List<CompanyInvoicesWeb.Models.Inovice>();
            var dbCompanies = invoiceDAL.GetAllInvoices();

            dbCompanies.ForEach(item =>
            {
                invoiceVM.Add(MapperConfig.Mapper.Map<VM.Inovice>(item));
            });
            return View(invoiceVM);
        }

        public ActionResult AddNewInvoice()
        {
            var charges =  invoiceDAL.GetAllCharges();
            var companies = companyDAL.GetAllCompanies();
            var vmChargesList = new List<VM.Charge>();
            var vmCompanyList = new List<VM.Company>();
            var invoice = new VM.Inovice();

            charges.ForEach(a => vmChargesList.Add(MapperConfig.Mapper.Map<VM.Charge>(a)));
            companies.ForEach(a => vmCompanyList.Add(MapperConfig.Mapper.Map<VM.Company>(a)));

            invoice.Charges = vmChargesList;
            invoice.Companies = vmCompanyList;
            return View(invoice);
        }
        [HttpPost]
        public ActionResult AddNewInvoice(VM.Inovice invoice)
        {
            var vmChargesList = new List<VM.Charge>();
            var vmCompaniesList = new List<VM.Company>();

            var charges = invoiceDAL.GetAllCharges();
            var companies = companyDAL.GetAllCompanies();

            charges.ForEach(a => vmChargesList.Add(MapperConfig.Mapper.Map<VM.Charge>(a)));
            companies.ForEach(a => vmCompaniesList.Add(MapperConfig.Mapper.Map<VM.Company>(a)));

            invoiceDAL.AddNewInvoice(MapperConfig.Mapper.Map<DB.CompanyInvoice>(invoice));
            return View(new VM.Inovice { Charges = vmChargesList, Companies = vmCompaniesList });
        }
        public ActionResult InvoiceDetails(int ID, string companyName)
        {
            var invoice = invoiceDAL.GetInvoiceById(ID, companyName);

            return View(MapperConfig.Mapper.Map<VM.Inovice>(invoice));
        }

        [HttpPost]
        public ActionResult DeleteInvoice(int ID, string companyName)
        {
            invoiceDAL.DeleteInvoice(ID, companyName);

            return RedirectToAction("Index");
        }
        public ActionResult EditInvoice(int id, string companyName)
        {
            var invoice = invoiceDAL.GetInvoiceById(id, companyName);

            return View(MapperConfig.Mapper.Map<VM.Inovice>(invoice));
        }

        [HttpPost]
        public ActionResult EditInvoice(VM.Inovice invoice)
        {

            invoiceDAL.EditInvoice(MapperConfig.Mapper.Map<DB.CompanyInvoice>(invoice));
            return RedirectToAction("Index");
        }
    }
}