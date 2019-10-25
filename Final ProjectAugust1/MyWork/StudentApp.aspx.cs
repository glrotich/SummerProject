using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Final_ProjectAugust1.MyWork
{
    public partial class StudentApp : System.Web.UI.Page
    {
        UserDatabaseEntities dbcontext = new UserDatabaseEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            ReloadAppointments();
        }

        private void ReloadAppointments() //create a method for loading the appt. table
        {
            NewDBCON();  //not used
            //dbcontext.AppointmentTBs.OrderBy(item => item.AppointmentDate).Load();
            // GridView3.DataSource = dbcontext.AppointmentTBs.Local;
            //GridView3.DataBind();

            Label3.Text = User.Identity.Name.ToString(); //display the user name

            //add data to the dbcon using these two tables
            dbcontext.AppointmentTBs.Load();
            dbcontext.StudentTBs.Load();
            /*
            var studentIDQuery = from student in dbcontext.StudentTBs.Local
                      //           where student.StudentID == 2
                                 //.Equals(User.Identity.Name.ToString())
                                 select student.StudentID;
                                 */

            DateTime now = DateTime.Now;  //create a variable for the current time
            var result = from student in dbcontext.StudentTBs.Local  //join the tables
                         join appointment in dbcontext.AppointmentTBs.Local
                         on student.StudentID equals appointment.StudentID //Student IDs are =
                         where student.StudentUserName  //grabs the user name (...are =)
                         .Equals(User.Identity.Name.ToString())
                         && now.Date < appointment.AppointmentDate //appt day is in the future
                         || (now.Date == appointment.AppointmentDate //appt day is today
                         && now.TimeOfDay <= appointment.AppointmentTime) //appt day is in the future
                         select appointment;

            // add data to the Gridview
            GridView4.DataSource = result.ToList();
            string[] datakeynames = new string[1]; //create an array
            datakeynames[0] = "AppointmentID";
            GridView4.DataKeyNames = datakeynames;
            GridView4.DataBind();
        }

        public void NewDBCON()
        {/*
            if (dbcontext != null)
            {
                dbcontext.Dispose();
            }
            dbcontext = new UserDatabaseEntities();
        */}

        protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
        {
            Label2.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                //using (UserDatabaseEntities dbcon = new UserDatabaseEntities())
                //{

                AppointmentTB myStudent = new AppointmentTB();// create a new row
                                                              //query for student user name
                StudentTB student = (from x in dbcontext.StudentTBs.Local
                                     where x.StudentUserName.Equals(User.Identity.Name.ToString())
                                     select x).First();

                myStudent.StudentID = student.StudentID;        //take studentID from StudentTB
                myStudent.AdvisorID = student.StudentAdvisorID; //take advisorID from StudentTB

                myStudent.AppointmentDate = Convert.ToDateTime(Label2.Text);// add date

                int hour =                                      //take hour from dropdown2
                Convert.ToInt32(DropDownList2.SelectedValue.ToString());
                int min =                                       //take minute from dropdown3
                Convert.ToInt32(DropDownList3.SelectedValue.ToString());
                //add hour & min from above
                myStudent.AppointmentTime = new TimeSpan(hour, min, 0);
                myStudent.AppointmentReason = TextBox2.Text;    //add reason from textbox2
                                                                /*
                                                                AppointmentTB existingAppt = (from x in dbcontext.AppointmentTBs.Local //this only works for displaying the...
                                                                                             where x.AppointmentDate == myStudent.AppointmentDate //else statement when there...
                                                                                             && x.AppointmentTime == myStudent.AppointmentTime //is another appointment
                                                                                             && x.AdvisorID == myStudent.AdvisorID
                                                                                             && x.StudentID == myStudent.StudentID
                                                                                             select x).First();
                                                                            // add row to the table
                                                                            if ( existingAppt == null) //will have to take out the if else statement until we figure it out?????
                                                                            {
                                                                                dbcontext.AppointmentTBs.Add(myStudent);
                                                                                dbcontext.SaveChanges();
                                                                            }
                                                                            else
                                                                            {
                                                                                Label4.Text = "Sorry, this time has already been reserved.";
                                                                            }*/

                try
                {
                    AppointmentTB existingAppt = (from x in dbcontext.AppointmentTBs.Local //this only works for displaying the...
                                                  where x.AppointmentDate == myStudent.AppointmentDate //else statement when there...
                                                  && x.AppointmentTime == myStudent.AppointmentTime //is another appointment
                                                  && x.AdvisorID == myStudent.AdvisorID
                                                  && x.StudentID == myStudent.StudentID
                                                  select x).First();
                    // add row to the table
                    if (existingAppt == null) //will have to take out the if else statement until we figure it out?????
                    {              //this works now, but I'm just going to leave this if section in to show what it is supposed to do
                        dbcontext.AppointmentTBs.Add(myStudent);
                        dbcontext.SaveChanges();
                    }
                    else
                    {
                        //dbcontext.AppointmentTBs.Add(myStudent);
                        //dbcontext.SaveChanges();
                        Label4.Text = "Sorry, this time has already been reserved.";
                    }
                }

                catch (Exception)
                {
                    //MessageBox.Show(ex.Message);
                    dbcontext.AppointmentTBs.Add(myStudent);
                    dbcontext.SaveChanges();
                    Label4.Text = "";
                }

                //dbcontext.AppointmentTBs.Add(myStudent);
                //dbcontext.SaveChanges();
                //clear data
                //TextBox1.Text = "";
                //TextBox2.Text = "";

                //show new data in the gridview
                //dbcontext.AppointmentTBs.Load();
                //var result = from x in dbcontext.AppointmentTBs.Local
                //            select x;

                //show data in the Gridview1
                //GridView4.DataSource = result.ToList();
                //GridView4.DataBind();
                ReloadAppointments();
            }
            catch
            {
                Label4.Text = "Please select a date from the calendar.";
            }
            //}// add time
        }

        protected void btnSelectDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //read ID from the DataKey - GridView1
                int? id = Convert.ToInt32(GridView4.SelectedDataKey?[0]);

                //add data to the dbcontext
                dbcontext.AppointmentTBs.Load();
                //look for the row with id
                AppointmentTB appointments =
                    (from x in dbcontext.AppointmentTBs.Local
                     where x.AppointmentID == id
                     select x).First();
                //delete row from the table
                dbcontext.AppointmentTBs.Remove(appointments);
                dbcontext.SaveChanges();
                //show the result in the Gridview
                ReloadAppointments();
                Label4.Text = "";
            }
            catch
            {
                Label4.Text = "Click on the desired 'Select' icon above, THEN select the 'Select & Delete' button.";
            }
        }
    }
}