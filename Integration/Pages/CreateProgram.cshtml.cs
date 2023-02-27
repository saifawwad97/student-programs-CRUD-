
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
    public class CreateProgramModel : PageModel
    {

        [BindProperty]
        public string programcode { get; set; }
        [BindProperty]
        public string description { get; set; }
        [BindProperty]
        public string successMessage { get; set; }
        public string errorMessage { get; set; }

     
        public void OnGet()
        {
        }

        public void Onpost()
        {
            if (BCS.CreateProgram(programcode, description))
            {
                successMessage = "The Program has been added successfully";
            }
            else
            {
                errorMessage = "Error";
            }
        }
    }
}
