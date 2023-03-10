using Employee_Management_System.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net;

namespace Employee_Management_System.Pages.EmployeePage
{
    public class GetAllModel : PageModel
    {

        public List<EmployeeModel> employeeModel { get; set; }
        public void OnGet()
        {

            //Fetch the JSON string from URL.
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault;


            string json = (new WebClient()).DownloadString("API Path Here");

            //binding the data with model
            employeeModel = JsonConvert.DeserializeObject<List<EmployeeModel>>(json);

        }
    }

}
