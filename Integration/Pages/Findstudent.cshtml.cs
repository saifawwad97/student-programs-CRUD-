

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
    public class FindstudentModel : PageModel
    {
        public Student finds= new Student("", "", "", "");
        [BindProperty]
        public string studentid
        {
            get { return finds.StudentID; }
            set { finds.StudentID = value; }
        }
        [BindProperty]
        public string successMessage { get; set; }
        public string errorMessage { get; set; }
        public void OnGet()
        {
        }

        public void Onpost()
        {
            finds = BCS.FindStudent(studentid);
            if (finds.StudentID != "")
            {
                successMessage = "succesed";
            }
            else
            {
                errorMessage = " error";
            }
        }
    }
}
