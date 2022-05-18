using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace StudentInfoSystem
{
    
    public partial class MainWindow : Window
    {
        public Student student1;
        public List<string> StudStatusChoices { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

        }

        private void clearFields()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Clear();
                }
            }
        }
        private Boolean isStudentDataCorrect(Student student)
        {
            return student != null 
                && !String.IsNullOrWhiteSpace(student.firstName) 
                && !String.IsNullOrWhiteSpace(student.secondName) 
                && !String.IsNullOrWhiteSpace(student.lastName)
                && !String.IsNullOrWhiteSpace(student.faculty) 
                && !String.IsNullOrWhiteSpace(student.program) 
                && !String.IsNullOrWhiteSpace(student.degree)
                && !String.IsNullOrWhiteSpace(student.status) 
                && !String.IsNullOrWhiteSpace(student.facultyNumber) 
                && student.course != 0
                && student.flow != 0 
                && student.group != 0;
        }
        private void setStudent(Student student)
        {
            if (isStudentDataCorrect(student))
            {
                enableFields();
                fillStudentInfo(student);
            }
            else
            {
                clearFields();
                disableFields();
            }
        }
        private void fillStudentInfo(Student student)
        {
            this.student1 = student;

            txtFirstName.Text = this.student1.firstName;
            txtSecondName.Text = this.student1.secondName;
            txtLastName.Text = this.student1.lastName;
            txtFaculty.Text = this.student1.faculty;
            txtSpeciality.Text = this.student1.program;
            txtDegree.Text = this.student1.degree;
            txtStatus.Text = this.student1.status;
            txtFacultyNumber.Text = this.student1.facultyNumber;
            txtCourse.Text = Convert.ToString(this.student1.course);
            txtFlow.Text = Convert.ToString(this.student1.flow);
            txtGroup.Text = Convert.ToString(this.student1.group);
        }
        
        private void enableFields()
        {
            txtFirstName.IsEnabled = true;
            txtSecondName.IsEnabled = true;
            txtLastName.IsEnabled = true;
            txtFaculty.IsEnabled = true;
            txtSpeciality.IsEnabled = true;
            txtDegree.IsEnabled = true;
            txtStatus.IsEnabled = true;
            txtFacultyNumber.IsEnabled = true;
            txtCourse.IsEnabled = true;
            txtFlow.IsEnabled = true;
            txtGroup.IsEnabled = true;
        }

        private void disableFields()
        {
            txtFirstName.IsEnabled = false;
            txtSecondName.IsEnabled = false;
            txtLastName.IsEnabled = false;
            txtFaculty.IsEnabled = false;
            txtSpeciality.IsEnabled = false;
            txtDegree.IsEnabled = false;
            txtStatus.IsEnabled = false;
            txtFacultyNumber.IsEnabled = false;
            txtCourse.IsEnabled = false;
            txtFlow.IsEnabled = false;
            txtGroup.IsEnabled = false;
        }

        private void btnDisableFields_Click(object sender, RoutedEventArgs e)
        {
            disableFields();
        }

        private void btnEnableFields_Click(object sender, RoutedEventArgs e)
        {
            enableFields();
        }

        private void btnFillStudent_Click(object sender, RoutedEventArgs e)
        {
            StudentInfoContext studentData = new StudentInfoContext();
            if (studentData.Students.FirstOrDefault() == null)
            {
                studentData.Students.Add(new Student(1,
                "Петър", "Иванов", "Петров",
                "ФКСТ", "КСИ", "бакалавър", "заверил",
                "121219000", 3, 1, 31));
                studentData.SaveChanges();
            }
            setStudent(studentData.Students.FirstOrDefault());
        }

        private void btnNull_Click(object sender, RoutedEventArgs e)
        {
            setStudent(null);
        }

        private Boolean TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();          
            IEnumerable<Student> queryStudents = context.Students;
           
            int countStudents = queryStudents.Count();
            if (queryStudents == null)
            {
                return true;
            }
            else
                return false;
        }
        private void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            StudentData studentData = new StudentData();
             foreach (Student st in studentData.getStudents())
            {
                context.Students.Add(st);
            }            
            context.SaveChanges();
        }
    }
}
