using System;
using System.Collections.Generic;


namespace ConsoleApp3
{
    internal class Program
    {
        
        /* first table*/
        public class Student
        {
            public int StudentId { get; private set; }
            public string FirstName { get; private set; }
            public string LastName { get; private set; }
            public string Email { get; private set; }
            public string PhoneNumber { get; private set; }
            public Address address { get; private set; }

            public Dictionary< Rating, string> SubjectAndRating;
            public override string ToString()
            {
                return StudentId + " " + FirstName + " " + LastName;
            }
            public Student GetStudentById(int StudentId,List<Student> student)
            {
                foreach (var item in student)
                {
                    if(item.StudentId == StudentId)
                    {
                        return item;
                    }
                }
                return null;
            }

            public Student(int StudentId, string FirstName, string LastName, string Email, string PhoneNumber, Address address,List<Student> student,Dictionary<Rating, string> SubjectsAndRating)
            {
                this.SubjectAndRating = SubjectsAndRating;
                this.StudentId = StudentId;
                this.FirstName = FirstName;
                this.LastName = LastName;
                this.Email = Email;
                this.address = address;
                this.PhoneNumber = PhoneNumber;
                student.Add(this);
            }
            public void PrintStudentById(List<Student> student,int studentId)
            {
                foreach (var item in student)
                {
                    if (item.StudentId == studentId)
                    {
                        Console.WriteLine($"Id_{item.StudentId} FirstName_{item.FirstName} LastName_{item.LastName} Email_{item.Email} PhoneNumber_{item.PhoneNumber}");
                        Console.WriteLine();
                        Console.WriteLine($"Address( Region_{item.address.Region} City_{item.address.City} PostalCode_{item.address.PostalCode} )");
                    }
                }
            }

            public void DeleteStudentById(List<Student> student,List<Rating> ratings,Dictionary<Student,Course> StudentsAndCourses,int studentId)
            {
                foreach (var item in student)
                {
                    if(item.StudentId == studentId)
                    {
                        student.Remove(item);
                        break;
                    }
                }
                foreach (var item in StudentsAndCourses)
                {
                    if(item.Key.StudentId == studentId)
                    {
                        StudentsAndCourses.Remove(item.Key);
                        break;
                    }
                }
            }
            public void GiveRating()
            {

            }
        }
        public class Address
        {
            public string Region { get; private set; }
            public string City { get; private set; }
            public int PostalCode { get; private set; }
            public Address(string Region,string City,int PostalCode)
            {
                this.Region = Region;
                this.City = City;
                this.PostalCode = PostalCode;
            }
        }

        /* second table*/
        public class Course
        {
            public int CourseId { get; private set; }
            public string Title { get; private set; }
            public Course(int CourseId, string Title,List<Course> course)
            {
                this.CourseId = CourseId;
                this.Title = Title;
                course.Add(this);
            }
            public Course GetCourseById(int CourseId,List<Course> course)
            {
                foreach (var item in course)
                {
                    if(item.CourseId == CourseId)
                    {
                        return item;
                    }
                }
                return null;
            }
            public void CourseAddStudent(Dictionary<Student, Course> Courses, List<Student> student, List<Course> course, int StudentId, int CourseId)
            {
                var getStudent = student[0];
                var getCourse = course[0];
                foreach (var item in student)
                {
                    if (item.GetStudentById(StudentId, student).StudentId == item.StudentId)
                    {
                        getStudent = item;
                        break;
                    }
                }
                foreach (var item in course)
                {
                    if (item.GetCourseById(CourseId, course).CourseId == item.CourseId)
                    {
                        getCourse = item;
                        break;
                    }
                }
                Courses.Add(getStudent, getCourse);
            }
            public override string ToString()
            {
                return Title;
            } 
        }

        /*third table*/
        public class Rating
        {
            public int CourseId;
            public int StudentId;
            public string Subject;
            public int Rate;
            public Rating(int CourseId,int StudentId,string Subject,int Rate)
            {
                this.Subject = Subject;
                this.CourseId = CourseId;
                this.StudentId = StudentId;
                this.Rate = Rate;
            }
            
        }
        public class Subjects
        {

        }
        
        static void Main(string[] args)
        {

            Random random = new Random();
            Dictionary<Student, Course> CoursesAndStudents = new Dictionary<Student, Course>();
            Dictionary< Rating, string> SubjectAndRate = new Dictionary<Rating, string>();
            List<string> SubjectsOfComputreScience = new List<string> { "Algorithms", "Data Structures", "Artificial Intelligence", "Machine Learning"};
            List<string> SubjectsOfMathematics = new List<string> { "Calculus", "Linear Algebra", "Statistics", "Discrete Mathematics"};
            List<string> SubjectsOfPhysics = new List<string> { "Electrostatics", "Magnetostatics", "Electrodynamics", "Maxwell's Equations"};
            List<Student> Students = new List<Student>();
            List<Course> Courses = new List<Course>();
            Dictionary<string, string> SubjectOfCourses = new Dictionary<string, string>();

            List<string> firstNames = new List<string> { "John", "Jane", "Michael", "Sarah", "David", "Emily", "Chris", "Jessica", "Daniel", "Laura", "James", "Emma", "Robert", "Olivia", "William", "Sophia", "Charles", "Isabella", "Joseph", "Mia" };
            List<string> lastNames = new List<string> { "Smith", "Johnson", "Brown", "Williams", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin" };
            List<string> regions = new List<string> { "California", "Texas", "New York", "Florida", "Illinois", "Pennsylvania", "Ohio", "Georgia", "North Carolina", "Michigan", "California", "Texas", "New York", "Florida", "Illinois", "Pennsylvania", "Ohio", "Georgia", "North Carolina", "Michigan" };
            List<string> cities = new List<string> { "Los Angeles", "Houston", "Chicago", "Miami", "Philadelphia", "Dallas", "Atlanta", "Phoenix", "San Antonio", "San Diego", "Los Angeles", "Houston", "Chicago", "Miami", "Philadelphia", "Dallas", "Atlanta", "Phoenix", "San Antonio", "San Diego" };
            List<string> courseTitles = new List<string> { "Computer Science", "Mathematics", "Physics" };
            
            foreach (var item in SubjectsOfPhysics)
            {
                SubjectOfCourses.Add(item, courseTitles[courseTitles.Count - 1]);
            }
            foreach (var item in SubjectsOfMathematics)
            {
                SubjectOfCourses.Add(item, courseTitles[courseTitles.Count - 2]);
            }
            foreach (var item in SubjectsOfComputreScience)
            {
                SubjectOfCourses.Add(item, courseTitles[courseTitles.Count - 3]);
            }
            for (int i = 0; i < 20; i++)
            {
                //students
                int StudentId = i;
                string FirstName = firstNames[i];
                string LastName = lastNames[i];
                string Email = (FirstName + LastName) + "@gmail.com";
                string Phone = random.Next(100000000, 999999999).ToString();
                //Address
                string Region = regions[i];
                string City = cities[i];
                int PostalCode = random.Next(100000, 999999);
                Address address = new Address(Region,City,PostalCode);
                 new Student(StudentId, FirstName, LastName, Email, Phone, address, Students,SubjectAndRate);
                //Courses
                if (i < 3)
                {

                    Course course = new Course(i, courseTitles[i],Courses);
                }
            }
            int CountTtem = 0;
            foreach (var item in Students)
            {
                int CoursesId = random.Next(0, 3);
                
                Courses[CoursesId].CourseAddStudent(CoursesAndStudents, Students, Courses,CountTtem,CoursesId);
                CountTtem++;
            }
            foreach (var item in CoursesAndStudents)
            {
                foreach (var item1 in SubjectOfCourses)
                {
                    if(item.Value.Title == item1.Value)
                    {
                        int Rate = random.Next(1, 100);
                        Rating rating = new Rating(item.Value.CourseId,item.Key.StudentId,item1.Value,Rate);
                        item.Key.SubjectAndRating.Add(rating, item1.Key);//item1.value course.title  item1.key subject
                    }
                }
            }


            //All students Names subjects Rates   
            foreach (var item in Students)
            {
                Console.Write(item.StudentId + "  " + item.FirstName + "|");
                foreach (var item1 in SubjectAndRate)
                {
                    if (item.StudentId == item1.Key.StudentId)
                    {
                        Console.Write(" " + item1.Value + " " + item1.Key.Rate);
                    }
                }
                Console.WriteLine();
            }



            //All students Names subjects Rates what i want
            foreach (var item1 in SubjectAndRate)
            {
                if (item1.Key.CourseId == 2)
                {
                    foreach (var item in Students)
                    {
                        if(item.StudentId == item1.Key.StudentId)
                        {
                            Console.Write(item.FirstName + " ");
                        }
                    }
                    Console.Write(item1.Value + " " + item1.Key.Rate);
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }
    }
}
