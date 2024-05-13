using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoice
{
    class RegisterUsers
    {
        //D eclaring variables and creating access modifiers.
       private string username;
       private string password;
       private string firstName;
       private string lastName;
       private string datetOfBirth;
       private string email;

        //my setters.
       public void setUsername(string name) {
           username = name;
       }
       public void setPassword(string pass) {
           password = pass;
       }
       public void setFirstName(string first) {
           firstName = first;
       }
       public void setLastName(string last) {
           lastName = last;
       }
       public void setDateOfBirth(string date) {
           datetOfBirth = date;
       }
       public void setEmail(string email) {
           this.email = email;
       }

        //My getters.
       public string getUsername(){
           return username;
       }
       public string getPassword() {
           return password;
       }
       public string getFirstName() {
           return firstName;
       }
       public string getLastName() {
           return lastName;
       }
       public string getDateOfBirth() {
           return datetOfBirth;
       }
       public string getEmail() {
           return email;
       }
        
    }
}
