using GeneratePDFWithiTextSharp.Models;
using GeneratePDFWithiTextSharp.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneratePDFWithiTextSharp.Controllers
{
    public class UniversityController : Controller
    {
        // GET: University
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Report(University university)
        {
            university = new University();
            university.Name = "University X";
            university.PrincipalName = "AsMhA";
            university.PublishedDate = new DateTime(1985,6,18);
            university.Address = "Sakarya Kampüs";
            university.City = "Sakarya";
            university.Country = "Türkiye";
            university.Students = GetStudents();

            UniversityReport universityReport = new UniversityReport();
            byte[] abytes = universityReport.PrepareReport(university);
            return File(abytes, "application/pdf");
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