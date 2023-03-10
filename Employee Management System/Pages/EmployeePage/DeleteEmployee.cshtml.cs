using Employee_Management_System.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace Employee_Management_System.Pages.EmployeePage
{
    public class DeleteEmployeeModel : PageModel
    {
        public EmployeeModel employeeModel { get; set; }
        public void OnPost(int empId)
        {

            //Fetch the JSON string from URL.
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault;

            //Sending the data
            WebClient client = new WebClient();
            string json1 = client.DownloadString("Api Call Here" + empId);

            //Redirecting to List Page
            Response.Redirect("/EmployeePage/GetAll");
        }
    }
}
