
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Integration.Pages
{

      public class ModifyStudentModel : PageModel
    {
        Student modify = new Student("", "", "", "");
        [BindProperty]
        public string studentid
        {
            get { return modify.StudentID; }
            set { modify.StudentID = value; }
        }
        [BindProperty]
        public string firstname
        {
            get { return modify.FirstName; }
            set { modify.FirstName = value; }
        }
        [BindProperty]
        public string lastname
        {
            get { return modify.LastName; }
            set { modify.LastName = value; }
        }
        [BindProperty]
        public string email
        {
            get { return modify.Email; }
            set { modify.Email = value; }
        }


        [BindProperty]
        public string errorMessage { get; set; }
        public string successMessage { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (BCS.ModifyStudent(modify))
            {
                successMessage = "The request to modify the student was succesfull.";
            }
            else
            {
                errorMessage = "There was an error, please check you input.";
            }
        }
    }
}
