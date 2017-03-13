using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;

public class test_model { }

public class TestModelDTO
{
    public string setInside { get; set; }
    public string setOutside { get; set; }
}

namespace AutoMapperOutsideValueSet
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string outsideValue = "outside";

            Mapper.Initialize(cfg =>
            {
                string insideValue = null;

                cfg.CreateMap<test_model, TestModelDTO>()
                    .ForMember(dest => dest.setInside, opt => opt.MapFrom(src => insideValue))
                    .ForMember(dest => dest.setOutside, opt => opt.MapFrom(src => outsideValue)) // Comment this line out to set insideValue
                    ;
            });
        }
    }
}