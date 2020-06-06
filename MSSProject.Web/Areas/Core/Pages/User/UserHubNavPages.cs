using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace MSSProject.Web.Areas.Core.Pages.User
{
    public static class UserHubNavPages
    {
        public static string Index => "Index";
        public static string Meetings => "Meetings";
        public static string EditMeeting => "EditMeeting";
        //add/remove attendees sub group here
        public static string Complaints => "Complaints";
        public static string PaymentInfo => "PaymentInfo";
        public static string AdminFunctions => "AdminFunctions";
        public static string CreatePayment => "CreatePayment";
        public static string CreateMeeting => "CreateMeeting";
        public static string IndexNavClass(ViewContext viewContext) => CorePageNavClass(viewContext, Index);
        public static string MeetingsNavClass(ViewContext viewContext) => CorePageNavClass(viewContext, Meetings);
        public static string EditMeetingNavClass(ViewContext viewContext) => CorePageNavClass(viewContext, EditMeeting);
        public static string ComplaintsNavClass(ViewContext viewContext) => CorePageNavClass(viewContext, Complaints);
        public static string PaymentInfoNavClass(ViewContext viewContext) => CorePageNavClass(viewContext, PaymentInfo);
        public static string CreatePaymentNavClass(ViewContext viewContext) => CorePageNavClass(viewContext, CreatePayment);
        public static string CreateMeetingNavClass(ViewContext viewContext) => CorePageNavClass(viewContext, CreateMeeting);

        [Authorize(Roles = "Administrator")]
        public static string AdminFunctionsNavClass(ViewContext viewContext) => CorePageNavClass(viewContext, AdminFunctions);

        private static string CorePageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
