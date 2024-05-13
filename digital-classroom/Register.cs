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
    public partial class Register : Form
    {
        //SQl commands and connection strings.
        SqlCommand cmd;
        SqlConnection conn;
        string connectionString = "data source = LENOVO-PC\\SQLEXPRESS;database = Code_School;integrated security =SSPI";
        //creating a stream reader variable.
        StreamWriter write;
        RegisterUsers register;
        public Register()
        {
            InitializeComponent();
      
        }
        //register onlick button
        private void lblRegister_Click(object sender, EventArgs e)
        {
            //calling database method.
            databaseConnection();
      
        }


        private void txtDateOF_MouseEnter(object sender, EventArgs e)
        {
            if (txtDateOF.Text == "Day / Month / Year") 
            {
                txtDateOF.Text = "";
            }
        }

        private void txtDateOF_MouseLeave(object sender, EventArgs e)
        {
            if (txtDateOF.Text == "")
            {
                txtDateOF.Text = "Day / Month / Year";
            }
        }

        private void txtEmailAddress_MouseEnter(object sender, EventArgs e)
        {
            if (txtEmailAddress.Text == "someone@example.com")
            {
                txtEmailAddress.Text = "";
            }
        }

        private void txtEmailAddress_MouseLeave(object sender, EventArgs e)
        {
            if (txtEmailAddress.Text == "")
            {
                txtEmailAddress.Text = "someone@example.com";
                
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //calling database method.
            databaseConnection();
        }

        public void registerButton() 
        {
            //try and catch to open the file and write to it and close it.
            try
            {
                register = new RegisterUsers();
                //settign all the controls to my back-end class
                register.setUsername(txtUsername.Text.ToLower());
                register.setPassword(txtPassword.Text);
                register.setFirstName(txtFirstName.Text);
                register.setLastName(txtLastName.Text);
                register.setDateOfBirth(txtDateOF.Text);
                register.setEmail(txtEmailAddress.Text.ToLower());

                string students =
                    register.getUsername() + "," +
                    register.getPassword() + "," +
                    register.getFirstName()+ "," +
                    register.getLastName() + "," +
                    register.getDateOfBirth()+ "," +
                    register.getEmail() + "\n";
                //creating the file.
                write = new StreamWriter("studentDetails.txt", true);

                //if statements to filter the inputs. 
                if (txtUsername.Text != "" && txtPassword.Text != "" && txtFirstName.Text != "" && txtLastName.Text != "" && txtDateOF.Text != "" && txtEmailAddress.Text != "")
                {
                    if (txtDateOF.Text != "Day / Month / Year" && txtEmailAddress.Text != "someone@example.com")
                    {
                        if (txtEmailAddress.Text.Contains("@") && txtEmailAddress.Text.Contains(".com"))
                        {
                            write.Write(students);
                            //displaying to the user that registration was successful.
                            MessageBox.Show("Registration was sucessful", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtUsername.Clear();
                            txtPassword.Clear();
                            txtFirstName.Clear();
                            txtLastName.Clear();
                            txtDateOF.Clear();
                            txtDateOF.Text = "Day / Month / Year";
                            txtEmailAddress.Clear();
                            txtEmailAddress.Text = "someone@example.com";
                        }
                        else
                        {
                            MessageBox.Show("Your email format is not correct please enter correct email \n e.g someone@example.com", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please fill in all the required fields", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all the required fields", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            //catching all exceptions
            catch(FormatException format)
            {
                MessageBox.Show(format.Message);
            }
            catch (ArgumentOutOfRangeException AoR)
            {
                MessageBox.Show(AoR.Message);
            }
            catch (PathTooLongException path)
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
            finally
            {
                //closing my file.
                write.Close();
            }
        }
        //creating a database connection.
        public void databaseConnection() 
        {
                    try
                    {
                        if (txtUsername.Text != "" && txtPassword.Text != "" && txtFirstName.Text != "" && txtLastName.Text != "" && txtDateOF.Text != "" && txtEmailAddress.Text != "")
                        {
                            if (txtDateOF.Text != "Day / Month / Year" && txtEmailAddress.Text != "someone@example.com")
                            {
                                if (txtEmailAddress.Text.Contains("@") && txtEmailAddress.Text.Contains(".com"))
                                {


                                    conn = new SqlConnection(connectionString);
                                    bool login = false;
                                    conn.Open();
                                    string sql = "SELECT * from Users where userName='" + txtUsername.Text.ToLower() + "'";

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
                                        MessageBox.Show("username is already taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    }
                                    else
                                    {



                                        Cursor cursor = Cursors.WaitCursor;

                                        using (conn = new SqlConnection(connectionString))
                                        {
                                            conn.Open();
                                            using (cmd = new SqlCommand("INSERT INTO Users(userName,userPassword) values (@userName,@userPassword)", conn))
                                            {
                                                cmd.Parameters.AddWithValue("@userName", txtUsername.Text.ToLower());
                                                cmd.Parameters.AddWithValue("@userPassword", txtPassword.Text);
                                                cmd.ExecuteNonQuery();

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Your email format is not correct please enter correct email \n e.g someone@example.com", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please fill in all the required fields", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please fill in all the required fields", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                    }
                    catch (Exception)
                    {
                        //calling method.
                        registerButton();
                        //displaying error message
                        ErrorReport report = new ErrorReport();
                        report.ShowDialog();

                    }
            
        }

     
    }
}
