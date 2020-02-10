using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DB = CompanyInovicesEF.Tables;
using VM = CompanyInvoicesWeb.Models;

namespace CompanyInvoicesWeb.App_Start
{
    public class MapperConfig
    {
        public static Mapper Mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<DB.Company, VM.Company>();
            cfg.CreateMap<VM.Company, DB.Company>();
            cfg.CreateMap<VM.Inovice, DB.CompanyInvoice>();
            cfg.CreateMap<DB.CompanyInvoice, VM.Inovice>();
            cfg.CreateMap<DB.Charge, VM.Charge>();
        }));
    }
}