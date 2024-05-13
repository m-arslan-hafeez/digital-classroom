using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoice
{
  class Students
    {
        //Declaring variables 
        private string student_id;
        private string firstName;
        private string lastName;


        //setter for name
        public void setFirstName(string name)
        {
            if (name.Length == 0 || name == "")
            {
                throw new Exception("Error: please enter name");
            }
            else
            {

                firstName = name;
            }
        }

        //getter for name
        public string getFirstName()
        {
            return firstName;
        }

        //setter for last name
        public void setLastName(string surname)
        {
            if (surname.Length == 0 || surname == "")
            {
                throw new Exception("Error: please enter last name");
            }
            else
            {

                lastName = surname;
            }
        }

        //getter for last name
        public string getLastName()
        {
            return lastName;
        }
        //setter for my student id
        public  void setStudenID(string id)
        {
            student_id = id;
        }
        //getter for my student id
        public string getStudentID()
        {
            return student_id;
        }
        //creating random student numberds. 
        public string StudentID()
        {
            Random userid = new Random();
            int id = userid.Next(111111, 999999);
            return "CSQ" + id.ToString();

        }

    }
}
