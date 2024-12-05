using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace WebAppNEE.Helpers
{
    public static class BreadcrumbHelper
    {
        public static List<BreadcrumbItem> GenerateBreadcrumb(HttpContext httpContext, string controllerName, string actionName)
        {
            var breadcrumbItems = new List<BreadcrumbItem>
            {
                new BreadcrumbItem { Name = "Home", Url = "/" }
            };

            // Ajoutez des cas spécifiques pour chaque contrôleur/action
            if (controllerName == "Energy" && actionName == "ColumnView")
            {
                breadcrumbItems.Add(new BreadcrumbItem { Name = "Energy", Url = "/Energy" });
                breadcrumbItems.Add(new BreadcrumbItem { Name = "Column View", Url = httpContext.Request.Path });
            }
            else if (controllerName == "Home" && actionName == "Privacy")
            {
                breadcrumbItems.Add(new BreadcrumbItem { Name = "Privacy Policy", Url = "/Home/Privacy" });
            }
            else if (controllerName == "Home" && actionName == "NERDetail")
            {
                breadcrumbItems.Add(new BreadcrumbItem { Name = "Privacy Policy", Url = "/Home/NERDetail" });
            }

            return breadcrumbItems;
        }
    }

    public class BreadcrumbItem
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}