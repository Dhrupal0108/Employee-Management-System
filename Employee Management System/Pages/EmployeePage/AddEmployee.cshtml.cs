using Employee_Management_System.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Employee_Management_System.Pages.EmployeePage
{
    public class AddEmployeeModel : PageModel
    {
        public EmployeeModel employeeModel { get; set; }
        public void OnPost(EmployeeModel employeeModel)
        {

            //Fetch the JSON string from URL.
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault;

            //Converting data to JSON from
            string json = JsonConvert.SerializeObject(employeeModel);

            //Sending the data
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;

            //string result = client.UploadString("Add Api Here");

            //Redirecting to List Page
            Response.Redirect("/Employee_Page/GetAll");
        }
    }
}
