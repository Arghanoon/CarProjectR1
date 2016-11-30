using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class ErrorHandler : IHttpModule
    {
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.Error += context_Error;
            context.EndRequest += context_EndRequest;
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;
            if (app.Context.Response.StatusCode == 404)
            {
                //app.Context.Response.Clear();
                //app.Context.Response.Redirect("/");
            }
        }

        void context_Error(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;

            //app.Context.RewritePath("/");
            //app.Context.Response.Redirect("/");
        }
    }
