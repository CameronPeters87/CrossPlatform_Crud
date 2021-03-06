﻿using System.Web.Optimization;

namespace CrossPlatform_Crud
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
                      "~/Content/Theme/vendor/bootstrap/js/bootstrap.bundle.min.js",
                      "~/Scripts/CreateCustomer.js",
                      "~/Scripts/Customer.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Theme/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/Theme/css/one-page-wonder.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/Table.css"));
        }
    }
}
