using GeneratePDFWithiTextSharp.Models;
using GeneratePDFWithiTextSharp.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneratePDFWithiTextSharp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Report(Student student)
        {
            StudentReport studentReport = new StudentReport();
            byte[] abytes = studentReport.PrepareReport(GetStudents());
            return File(abytes,"application/pdf");
        }

        public List<Student> GetStudents() 
        { 
            
            List<Student> students = new List<Student>();
            Student student = new Student();

            for (int i = 0; i <= 7; i++)
            {
                student = new Student();
                student.Id = i;
                student.Name = "Student " + i;
                student.Roll = "Roll " + i;
                students.Add(student);
            }

            return students;
        }
    }
}