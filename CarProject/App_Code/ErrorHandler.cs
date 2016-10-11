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
        }

        void context_Error(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;

            app.Context.RewritePath("/Admin");
        }
    }
