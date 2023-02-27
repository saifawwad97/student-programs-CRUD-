
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
    public class EnrollAStudentModel : PageModel
    {
        Student student = new Student("", "", "", "");
        [BindProperty]
        public string studentid
        {
            get { return student.StudentID; }
            set { student.StudentID = value; }
        }
        [BindProperty]
        public string firstname
        {
            get { return student.FirstName; }
            set { student.FirstName = value; }
        }
        [BindProperty]
        public string lastname
        {
            get { return student.LastName; }
            set { student.LastName = value; }
        }
        [BindProperty]
        public string email
        {
            get { return student.Email; }
            set { student.Email = value; }
        }
        [BindProperty]
        public string Programcode { get; set; }
        [BindProperty]
        public string successMessage { get; set; }
        public string errorMessage { get; set; }
        public void OnGet()
        {
        }

        public void Onpost()
        {
            if (BCS.EnrollStudent(student, Programcode))
            {
                successMessage = "The student has been added successfullt";
            }
            else
            {
                errorMessage = "Error";
            }
        }
    }
}