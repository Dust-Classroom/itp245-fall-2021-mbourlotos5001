using System.Configuration;
using System.Web.Optimization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITP245_2021_Fall
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));


            //var month =  DateTime.Today.Month;
            
            //var season = "x";
            //if (month > 11 || month < 3)
            //    season = "winter";
            //else if (month > 2 && month < 6)
            //    season = "~/Content/lux.css";
            //else if (month > 5 && month < 9)
            //    season = "~/Content/bootstrap.css";
            //else if (month > 8 && month < 12)
            //    season = "~/Content/mint.css";

            bundles.Add(new StyleBundle("~/Content/css").Include( 
                     $"~/Content/{ConfigurationManager.AppSettings["Bootstrap"]}.css",
                      "~/Content/site.css"));

           


        }
    }
}
