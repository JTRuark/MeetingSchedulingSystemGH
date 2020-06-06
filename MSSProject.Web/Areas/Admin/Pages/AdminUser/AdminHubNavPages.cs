using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace MSSProject.Web.Areas.Admin.Pages.AdminUser
{
    public static class AdminHubNavPages
    {
        public static string Index => "Index";
        public static string MeetingManagement => "MeetingManagement";
        public static string ComplaintManagement => "ComplaintManagement";
        public static string UserManagement => "UserManagement";
        public static string RoomManagement => "RoomManagement";
        public static string CoreFunctions => "CoreFunctions";

        public static string IndexNavClass(ViewContext viewContext) =>
            AdminPageNavClass(viewContext, Index);
        public static string MeetingManagementNavClass(ViewContext viewContext) =>
            AdminPageNavClass(viewContext, MeetingManagement);
        public static string ComplaintManagementNavClass(ViewContext viewContext) =>
            AdminPageNavClass(viewContext, ComplaintManagement);
        public static string UserManagementNavClass(ViewContext viewContext) =>
            AdminPageNavClass(viewContext, UserManagement);
        public static string RoomManagementNavClass(ViewContext viewContext) =>
            AdminPageNavClass(viewContext, RoomManagement);
        public static string CoreFunctionNavClass(ViewContext viewContext) =>
            AdminPageNavClass(viewContext, CoreFunctions);

        private static string AdminPageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
