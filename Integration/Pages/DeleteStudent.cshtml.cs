
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Integration.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Integration.Pages
{
    public class DeleteStudentModel : PageModel
    {

        [BindProperty]
        public string studentid { get; set; }
 
        [BindProperty]
        public string successMessage { get; set; }
        public string errorMessage { get; set; }


        public void OnGet()
        {
        }

        public void Onpost()
        {
            if (BCS.DeleteStudent(studentid))
            {
                successMessage = "The student has been deleted successfully";
            }
            else
            {
                errorMessage = "Error";
            }
        }
    }
}
