using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        public int StudentId { get; set; }
        public String firstName { get; set; }
        public String secondName { get; set; }   
        public String lastName { get; set; }
        public String faculty { get; set; }
        public String program { get; set; }
        public String degree { get; set; }
        public String status { get; set; }
        public String facultyNumber { get; set; }
        public int course { get; set; }
        public int flow { get; set; }
        public int group { get; set; }
        public byte[] Photo { get; set; }
       

        public Student() { }
        
        public Student(int Id, String firstName, String secondName, String lastName, String faculty, String program,
            String degree, String status, String facultyNumber, int course, int flow, int group)
        {
            this.StudentId = Id;
            this.firstName = firstName;
            this.secondName = secondName;
            this.lastName = lastName;
            this.faculty = faculty;
            this.program = program;
            this.degree = degree;
            this.status = status;
            this.facultyNumber = facultyNumber;
            this.course = course;
            this.flow = flow;
            this.group = group;
        }

    }
}
