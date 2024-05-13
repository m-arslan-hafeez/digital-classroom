using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.Sql;

namespace MultipleChoice
{
    public partial class MultipleChoice : Form
    {
        //declaring variables and objects.
        private Students student;
        //craeting a 2D array
        private string[,] resultsAndMemo;
        private string[] question1;
        private string[] question2;
        private string[] question3;
        private string[] question4;
        private int number = 0;
        private int totalNumber = 0;
        private string studentMark = "";
        private int studentNo = 0;
        private int numberOpen = 0;
        private string line = "";
        private int num = 0;
        private int count = 0;
        private bool check =false;
        private string username = "", password = "", firstname = "", surname = "", dateOf = "", email = "";
        private StreamWriter write;
        private StreamReader read;
        //SQl commands and connection strings.
        SqlCommand cmd;
        SqlConnection conn;
        string connectionString = "data source = LENOVO-PC\\SQLEXPRESS;database = Code_School;integrated security =SSPI";
       

        public MultipleChoice()
        {
            InitializeComponent();
            //invoking my student ID method.
            setUserID();
            //starting my timer.
            timerUpdateTime.Start();
            //showing my clock.
            lblTime.Visible = true;


        }
        //hiding a pnale when the user clicks sign in
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = false;
        }
        //hiding a panel when the user clicks button
        private void btnStudentCenter_Click(object sender, EventArgs e)
        {
            panelStudentCenter.Visible = false;
            lblRegister.Visible = true;
            btnRegsiter.Visible = true;

        }
        //hiding panel when user clicks button
        private void btnSignOut_Click(object sender, EventArgs e)
        {
            loginPanel.Visible = true;
        }
        //setting action for my sign in button
        private void lblSignIn_Click(object sender, EventArgs e)
        {
            //caling database in method
            databseConnection();
        }
        //setting action for my sign in button
        private void btnSignIn_Click_1(object sender, EventArgs e)
        {
            //caling database in method
            databseConnection();
        }

        //hidding setting when usersigns out
        private void btnSignOut_Click_1(object sender, EventArgs e)
        {


            txtUserId.Clear();
            txtName.Clear();
            txtSurname.Clear();

            txtUserId.Text = student.StudentID().ToString();
            panelLogin.Visible = true;
            lblNameSign.Visible = false;
            btnSignOut.Visible = false;
            btnPastPaper.Visible = false;
            lblSignedIn.Visible = false;
            //hiding user's text box
            txtUserAnswer1.Visible = false;
            txtUserAnswer2.Visible = false;
            txtUserAnswer3.Visible = false;
            txtUserAnswer4.Visible = false;
            //Clearing the questions and possible answers
            lblQuestion1.Text = "";
            lblQuestion2.Text = "";
            lblQuestion3.Text = "";
            lblQuestion4.Text = "";
            lblQuestion1Possible.Text = "";
            lblQuestion2Possible.Text = "";
            lblQuestion3Possible.Text = "";
            lblQuestion4Possible.Text = "";
            txtUserAnswer1.Clear();
            txtUserAnswer2.Clear();
            txtUserAnswer3.Clear();
            txtUserAnswer4.Clear();
            numberOpen = 0;
            panelLecture.Visible = true;


        }

        //Setting my random student ID
        public void setUserID()
        {

            student = new Students();
            txtUserId.Text = student.StudentID().ToString();
        }

        //starting my timer
        private void timerUpdateTime_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            lblTime.Text = time.ToLocalTime().ToString();

        }
        //hide panel if lecture button is clicked
        private void btnHideLecture_Click(object sender, EventArgs e)
        {
            //hiding the login button and the button.
            if (numberOpen == 1)
            {
                panelLecture.Visible = false;
                btnPastPaper.Visible = true;
            }
               
            else
            {
                MessageBox.Show("Please click student and login then return here!!!!", "Student login is required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //creating action for onlick
        private void btnSetTest_Click(object sender, EventArgs e)
        {
            //calling my possible anser method
            possibleAnswersAndQuestion();

        }
        //populating my arrays
        public void possibleAnswersAndQuestion()
        {
            question1 = new string[5]
               
                {
                txtQuestion1.Text,
                txtQuestion1Possible1.Text,
                txtQuestion1Possible2.Text,
                txtQuestion1Possible3.Text,
                txtQuestion1Possible4.Text
                };


            //adding text into array for question 1
            question1 = new string[5]
               
                {
                txtQuestion1.Text,
                txtQuestion1Possible1.Text,
                txtQuestion1Possible2.Text,
                txtQuestion1Possible3.Text,
                txtQuestion1Possible4.Text
                };

            //adding text into array for question 2
            question2 = new string[5]
                {
                txtQuestion2.Text,
                txtQuestion2Possible1.Text,
                txtQuestion2Possible2.Text,
                txtQuestion2Possible3.Text,
                txtQuestion2Possible4.Text
                };

            //adding text into array for question 3
            question3 = new string[5]
                {
                txtQuestion3.Text,
                txtQuestion3Possible1.Text,
                txtQuestion3Possible2.Text,
                txtQuestion3Possible3.Text,
                txtQuestion3Possible4.Text
                };
            //adding text into array for question 4
            question4 = new string[5]
                {
                txtQuestion4.Text,
                txtQuestion4Possible1.Text,
                txtQuestion4Possible2.Text,
                txtQuestion4Possible3.Text,
                txtQuestion4Possible4.Text
                };

            //Setting questions and possible answers
            lblQuestion1.Text = question1[0];
            lblQuestion1Possible.Text = "";
            //populationg Array
            for (int x = 1; x < question1.Length; x++)
            {
                lblQuestion1Possible.Text += question1[x] + "\n";
            }

            //Setting questions and possible answers
            lblQuestion2.Text = question2[0];
            lblQuestion2Possible.Text = "";
            //populationg Array
            for (int x = 1; x < question2.Length; x++)
            {
                lblQuestion2Possible.Text += question2[x] + "\n";
            }

            //Setting questions and possible answers
            lblQuestion3.Text = question3[0];
            lblQuestion3Possible.Text = "";
            //populationg Array 
            for (int x = 1; x < question3.Length; x++)
            {
                lblQuestion3Possible.Text += question3[x] + "\n";
            }

            //Setting questions and possible answers
            lblQuestion4.Text = question4[0];
            lblQuestion4Possible.Text = "";
            //populationg Array
            for (int x = 1; x < question4.Length; x++)
            {
                lblQuestion4Possible.Text += question4[x] + "\n";
            }

            //calling my method here.
            checkQuestions();
        }

        //enabling user input textboxes.
        public void checkQuestions()
        {
            if (txtQuestion1.Text != "" & txtQuestion2.Text != "" & txtQuestion3.Text != "" & txtQuestion4.Text != "")
            {
                //Enabling user's text box
                txtUserAnswer1.Visible = true;
                txtUserAnswer2.Visible = true;
                txtUserAnswer3.Visible = true;
                txtUserAnswer4.Visible = true;
                check = true;

                try
                {
                    //saving the lectures answers and questions onto a string so i can save them to a file later on.
                    string pastPaper = "";

                    pastPaper = "\tPast Paper" + "\n\n1. " + txtQuestion1.Text
                        + "\n  " + txtQuestion1Possible1.Text
                        + "\n  " + txtQuestion1Possible2.Text
                        + "\n  " + txtQuestion1Possible3.Text
                        + "\n  " + txtQuestion1Possible4.Text
                        + "\n\n  " + txtQuestion1Correct1.Text + " ✔"
                        + "\n\n2. " + txtQuestion2.Text
                        + "\n  " + txtQuestion2Possible1.Text
                        + "\n  " + txtQuestion2Possible2.Text
                        + "\n  " + txtQuestion2Possible3.Text
                        + "\n  " + txtQuestion2Possible4.Text
                        + "\n\n  " + txtQuestion2Correct2.Text + " ✔"
                        + "\n\n3. " + txtQuestion3.Text
                        + "\n  " + txtQuestion3Possible1.Text
                        + "\n  " + txtQuestion3Possible2.Text
                        + "\n  " + txtQuestion3Possible3.Text
                        + "\n  " + txtQuestion3Possible4.Text
                        + "\n\n  " + txtQuestion3Correct3.Text + " ✔"
                        + "\n\n4. " + txtQuestion4.Text
                        + "\n  " + txtQuestion4Possible1.Text
                        + "\n  " + txtQuestion4Possible2.Text
                        + "\n  " + txtQuestion4Possible3.Text
                        + "\n  " + txtQuestion4Possible4.Text
                        + "\n\n  " + txtQuestion4Correct4.Text + " ✔";

                    /*creating the file.
                      writting to a file and closing the file
                     */

                    write = new StreamWriter("Past Paper.txt");
                    write.WriteLine(pastPaper);
                    write.Close();
                }
                    //throwing all exception which might occure.
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                MessageBox.Show("Test has been successfully set and saved.", "setting completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelLecture.Visible = true;
                btnPastPaper.Visible = false;
            }
            else
            {
                MessageBox.Show("Please fill-in all questions and answers.", "Ooops", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //creating my SQL connection
        public void sqlMemorandum() 
        {
            //displaying errors to the screen.
            ErrorReport report = new ErrorReport();
            report.ShowDialog();
            try
            {
                /*
                    This is the SQL connection which connects the app to the database.
                 */
                conn = new SqlConnection(connectionString);
                conn.Open();
                string sql = "SELECT * from Users where userName='" + email + "' and userPassword='" + password + "'";
                Boolean login = false;
                cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    login = true;

                }

                dr.Close();
                conn.Close();

            }
            catch (SqlException) 
            {
                try
                {

                    //reading name from file
                    read = new StreamReader("Test Results.txt");
                    MessageBox.Show(read.ReadToEnd());
                    read.Close();

                } //catching all exceptions
                catch (FormatException format)
                {
                    MessageBox.Show(format.Message);
                }
                catch (ArgumentOutOfRangeException AoR)
                {
                    MessageBox.Show(AoR.Message);
                }
                catch (System.IO.PathTooLongException path)
                {
                    MessageBox.Show(path.Message);

                }
                catch (IOException io)
                {
                    MessageBox.Show(io.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch(Exception)
            {
                try
                {

                    //reading name from file
                    read = new StreamReader("Test Results.txt");
                    MessageBox.Show(read.ReadToEnd());
                    read.Close();

                } //catching all exceptions
                catch (FormatException format)
                {
                    MessageBox.Show(format.Message);
                }
                catch (ArgumentOutOfRangeException AoR)
                {
                    MessageBox.Show(AoR.Message);
                }
                catch (System.IO.PathTooLongException path)
                {
                    MessageBox.Show(path.Message);

                }
                catch (IOException io)
                {
                    MessageBox.Show(io.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        
        }

        //Button memo to view memo
        private void btnMemo_Click(object sender, EventArgs e)
        {

            sqlMemorandum();
        }

        private void btnTakeTest_Click(object sender, EventArgs e)
        {
            //Chicking if the lecture set the test or not
            if (check == true)
            {
                try
                {

                    studentNo++;

                    //restarting captured details...
                    number = 0;
                    totalNumber = 0;

                    //initializing and populating 2D array
                    resultsAndMemo = new string[2, 4]
            {
               
            {
                //lecture's correct answers
             txtQuestion1Correct1.Text, 
             txtQuestion2Correct2.Text,
             txtQuestion3Correct3.Text, 
             txtQuestion4Correct4.Text,
            
            },

            {
                //user answers.
                txtUserAnswer1.Text,
                txtUserAnswer2.Text,
                txtUserAnswer3.Text,
                txtUserAnswer4.Text
            }
            };

                    /*
                          student total mark calculation using a for loop.
                     */

                    for (int x = 0; x < 1; x++)
                    {

                        for (int y = 0; y <= 3; y++)
                        {
                            number++;

                            if (resultsAndMemo[0, y].ToLower() == resultsAndMemo[1, y].ToLower())
                            {

                                studentMark += number.ToString() + ". ✔\n";
                                totalNumber++;
                            }
                            else
                            {
                                studentMark += number.ToString() + ". ✖\n";
                            }
                        }
                    }


                    if (studentMark != "")
                    {

                        //getting user's users and lectures memo.
                        string outcomes = "";
                        outcomes = "Name: " + firstname + " \nSurname: " + surname + "\n\nYour answers\t\tMemo\n"
                               + "1. " + txtUserAnswer1.Text.ToUpper() + "\t\t\t1. " + txtQuestion1Correct1.Text.ToUpper() + "\n"
                               + "2. " + txtUserAnswer2.Text.ToUpper() + "\t\t\t2. " + txtQuestion2Correct2.Text.ToUpper() + "\n"
                               + "3. " + txtUserAnswer3.Text.ToUpper() + "\t\t\t3. " + txtQuestion3Correct3.Text.ToUpper() + "\n"
                               + "4. " + txtUserAnswer4.Text.ToUpper() + "\t\t\t4. " + txtQuestion4Correct4.Text.ToUpper() + "\n\n"
                               + "Marking\n" + studentMark +
                               "\n\n" + "_____________________________________________________________________\n" +
                            "\n Total: " + totalNumber + "/4\n"
                            + "______________________________________________________________________";

                        string clasList = "ID: " + student.getStudentID() + "\nName: " + firstname + "\nSurname: " + surname + "\nMarks: " + totalNumber + "/4\n_________________________________________________________________\n";
                        MessageBox.Show("Test was successfully completed and marked, please check the results and memo. The test and memo were successfully saved.", "Test completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //writing for class list.
                        write = new StreamWriter("Class List.txt", true);
                        write.Write(clasList);
                        write.Close();

                        //creating the file.
                        write = new StreamWriter("Test Results.txt");
                        write.Write(outcomes);
                        write.Close();
                        studentMark = null;

                    }
                    else
                    {

                        MessageBox.Show("please answer questions first!!!!!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //catching all exceptions
                catch (FormatException format)
                {
                    MessageBox.Show(format.Message);
                }
                catch (ArgumentOutOfRangeException AoR)
                {
                    MessageBox.Show(AoR.Message);
                }
                catch (System.IO.PathTooLongException path)
                {
                    MessageBox.Show(path.Message);

                }
                catch (IOException io)
                {
                    MessageBox.Show(io.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else 
            {
                MessageBox.Show("Please wait for lecture to set the the","Please wait.....",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }

        }
        //creating SQL commands and also fetching data from it.
        public void getClassList() 
        {

            try
            {

                conn = new SqlConnection(connectionString);
                bool login = false;
                string line = "";
                conn.Open();
                string sql = "SELECT * from Users where userName='" + email + "' and userPassword='" + password + "'";

                cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    line = dr.Read() + "\n";

                }

                dr.Close();
                conn.Close();
                //displaying student class list
                MessageBox.Show(line, "Avaible students", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (SqlException )
            {
                ErrorReport report = new ErrorReport();
                report.ShowDialog();
                loadStudents();
            }
            catch (Exception)
            {
                ErrorReport report = new ErrorReport();
                report.ShowDialog();
                loadStudents();
            }
         }

        public void loadStudents() 
        {
            try
            {
                read = new StreamReader("Class List.txt");
                MessageBox.Show("\t\t__Code School Class List__\n\n" + read.ReadToEnd());
                read.Close();
            }//catching all exceptions
            catch (FormatException format)
            {
                MessageBox.Show(format.Message);
            }
            catch (ArgumentOutOfRangeException AoR)
            {
                MessageBox.Show(AoR.Message);
            }
            catch (System.IO.PathTooLongException path)
            {
                MessageBox.Show(path.Message);

            }
            catch (IOException io)
            {
                MessageBox.Show(io.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }
        
        private void btnViewClass_Click(object sender, EventArgs e)
        {
            //calling my get method.
            getClassList();
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }

        private void btnRegsiter_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }
        public void signIn()
        {
            StreamReader read;
            string details = "";


            //creating a try and catch, to catch thrown students exception 
            try
            {
                ErrorReport report = new ErrorReport();
                report.ShowDialog();

                student = new Students();
                student.setStudenID(txtUserId.Text);
                student.setFirstName(txtName.Text.ToLower());
                student.setLastName(txtSurname.Text);


                //reading name from file
                read = new StreamReader("studentDetails.txt");

                while ((line = read.ReadLine()) != null)
                {
                    if (line.Contains(student.getFirstName()) && line.Contains(student.getLastName()))
                    {
                        num = 1;
                        details = line;

                    }
                }
                //creating an array to fliter system details and storing them in variables.
                string[] words = details.Split(',');
                foreach (string word in words)
                {
                    if (count == 0)
                    {
                        username = word;
                    }
                    else if (count == 1)
                    {
                        password = word;
                    }
                    else if (count == 2)
                    {
                        firstname = word;
                    }
                    else if (count == 3)
                    {
                        surname = word;
                    }
                    else if (count == 4)
                    {
                        dateOf = word;
                    }
                    else if (count == 5)
                    {
                        email = word;
                        count = -1;
                        break;
                    }
                    count++;
                }
                //checking if username and password matched any inside the file.
                if (num == 1)
                {

                    count = 0;
                    num = 0;
                    if (username == student.getFirstName() && password == student.getLastName())
                    {
                        //hiding panel and show my home screen.
                        panelLogin.Visible = false;
                        lblNameSign.Visible = true;
                        lblNameSign.Text = email.ToLower();
                        lblSignedIn.Visible = true;
                        btnSignOut.Visible = true;

                        numberOpen = 1;
                    }
                    else
                    {
                        MessageBox.Show("Invalid username and password", "login failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                else
                {
                    MessageBox.Show("Invalid username and password", "login failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                read.Close();
            } 
                //Throwing exceptions.
            catch (FormatException format)
            {
                MessageBox.Show(format.Message);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found please register before trying to login...", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnPastPaper_Click(object sender, EventArgs e)
        {
            try
            {
                //reading name from file
                read = new StreamReader("Past Paper.txt");
                MessageBox.Show(read.ReadToEnd());
                read.Close();

            }
            //catching all exceptions
            catch (FormatException format)
            {
                MessageBox.Show(format.Message);
            }
            catch (ArgumentOutOfRangeException AoR) 
            {
                MessageBox.Show(AoR.Message);
            }
            catch (System.IO.PathTooLongException path)
            {
                MessageBox.Show(path.Message);

            }
            catch (IOException io)
            {
                MessageBox.Show(io.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtQuestion1Correct1_TextChanged(object sender, EventArgs e)
        {
            
            if (!(txtQuestion1Correct1.Text.Contains("A") || txtQuestion1Correct1.Text.Contains("B") || txtQuestion1Correct1.Text.Contains("C") || txtQuestion1Correct1.Text.Contains("D") || txtQuestion1Correct1.Text==null || txtQuestion1Correct1.Text.Contains("a") || txtQuestion1Correct1.Text.Contains("b") || txtQuestion1Correct1.Text.Contains("c") || txtQuestion1Correct1.Text.Contains("d") || txtQuestion1Correct1.Text==""))
            {
                txtQuestion1Correct1.Text="";
                MessageBox.Show("Please enter only A - D", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
                
        }

        private void txtQuestion2Correct2_TextChanged(object sender, EventArgs e)
        {
            if (!(txtQuestion2Correct2.Text.Contains("A") || txtQuestion2Correct2.Text.Contains("B") || txtQuestion2Correct2.Text.Contains("C") || txtQuestion2Correct2.Text.Contains("D") || txtQuestion2Correct2.Text == null || txtQuestion2Correct2.Text.Contains("a") || txtQuestion2Correct2.Text.Contains("b") || txtQuestion2Correct2.Text.Contains("c") || txtQuestion2Correct2.Text.Contains("d") || txtQuestion2Correct2.Text == ""))
            {
                txtQuestion2Correct2.Text = "";
                MessageBox.Show("Please enter only A - D", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtQuestion3Correct3_TextChanged(object sender, EventArgs e)
        {
            if (!(txtQuestion3Correct3.Text.Contains("A") || txtQuestion3Correct3.Text.Contains("B") || txtQuestion3Correct3.Text.Contains("C") || txtQuestion3Correct3.Text.Contains("D") || txtQuestion3Correct3.Text == null || txtQuestion3Correct3.Text.Contains("a") || txtQuestion3Correct3.Text.Contains("b") || txtQuestion3Correct3.Text.Contains("c") || txtQuestion3Correct3.Text.Contains("d") || txtQuestion3Correct3.Text == ""))
            {
                txtQuestion3Correct3.Text = "";
                MessageBox.Show("Please enter only A - D", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtQuestion4Correct4_TextChanged(object sender, EventArgs e)
        {
            if (!(txtQuestion4Correct4.Text.Contains("A") || txtQuestion4Correct4.Text.Contains("B") || txtQuestion4Correct4.Text.Contains("C") || txtQuestion4Correct4.Text.Contains("D") || txtQuestion4Correct4.Text == null || txtQuestion4Correct4.Text.Contains("a") || txtQuestion4Correct4.Text.Contains("b") || txtQuestion4Correct4.Text.Contains("c") || txtQuestion4Correct4.Text.Contains("d") || txtQuestion4Correct4.Text == ""))
            {
                txtQuestion4Correct4.Text = "";
                MessageBox.Show("Please enter only A - D", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void databseConnection() 
        {

            try
            {
                conn = new SqlConnection(connectionString);
                bool login = false;
                conn.Open();
                string sql = "SELECT * from Users where userName='" + txtName.Text.ToLower() + "' and userPassword='" + txtSurname.Text + "'";

                cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    login = true;

                }

                dr.Close();
                conn.Close();

                if (login == true)
                {
                    DateTime time = DateTime.Now;

                    /*update the last sign in*/
                    conn = new SqlConnection(connectionString);
                    string command = "UPDATE Users SET lastLogin='" + time.ToString() + "' where userName='" + txtName.Text.ToLower() + "'";
                    conn = new SqlConnection(connectionString);
                    conn.Open();
                    cmd = new SqlCommand(command, conn);
                    cmd.ExecuteNonQuery();

                }
                else
                {

                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (SqlException )
            {
              
                signIn();
            }
            catch (Exception ) 
            {
                signIn();
            }
        }
       
        
    }
}
