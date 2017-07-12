using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WebApi.Infrastructure;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Formatters.Insert(0, new XmlMediaTypeFormatter());
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
