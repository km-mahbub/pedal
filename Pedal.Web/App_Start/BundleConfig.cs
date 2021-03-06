﻿using System.Web;
using System.Web.Optimization;

namespace Pedal.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.3.1.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/DataTables/jquery.dataTables.min.js",
                      "~/Scripts/DataTables/dataTables.bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/font-awesome.min.css",
                      "~/Content/bootstrap.flaty.min.css",
                      "~/Content/Footer-with-logo.css",
                      "~/Content/site.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.min.css"));
        }
    }
}
