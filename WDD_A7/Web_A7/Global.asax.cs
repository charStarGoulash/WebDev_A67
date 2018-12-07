/*
* FILE          : Global.asax.cs
* PROJECT       : PROG2000 - Assignment #7
* PROGRAMMER    : Alex Kozak & Attila Katona
* FIRST VERSION : 2018-12-06
* DESCRIPTION   : This file contains the class structure to be sent back and forth throug the API in JSON blocks
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Web_A7
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
