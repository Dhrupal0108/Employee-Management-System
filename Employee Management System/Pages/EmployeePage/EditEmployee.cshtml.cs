using Employee_Management_System.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Employee_Management_System.Pages.EmployeePage
{
    public class EditEmployeeModel : PageModel
    {
        public List<EmployeeModel> employeeModel { get; set; }


        public void OnGet(int employeeId, List<EmployeeModel> results)
        {
            //Fetch the JSON string from URL.
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault;
            string json = (new WebClient()).DownloadString("ApiUrl");

            //binding the data with model
            employeeModel = JsonConvert.DeserializeObject<List<EmployeeModel>>(json);
            var result = new List<EmployeeModel>();
            result = (List<EmployeeModel>)employeeModel.Where(u => u.Id == employeeId);
            employeeModel = result;

        }

        public void OnPost(EditEmployeeModel employeeModel)
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
            string json1 = client.UploadString("Api Path Here", json);

            //Redirecting to List Page
            Response.Redirect("/Employee_Page/GetAll");
        }
    }
}
