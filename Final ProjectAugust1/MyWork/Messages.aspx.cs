using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Timers;

namespace Final_ProjectAugust1.MyWork
{
    public partial class Messages : System.Web.UI.Page
    {
        UserDatabaseEntities dbcontext = new UserDatabaseEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            ReloadMessages();
            
            ReloadSent();
        }

        private void ReloadMessages()
        {
            //NewDBCON();
            //dbcontext.AppointmentTBs.OrderBy(item => item.AppointmentDate).Load();
            // GridView3.DataSource = dbcontext.AppointmentTBs.Local;
            //GridView3.DataBind();

            Label1.Text = User.Identity.Name.ToString();

            //add data to the dbcon
            dbcontext.MessageTBs.Load();
            dbcontext.UserTBs.Load();
            /*
            var studentIDQuery = from student in dbcontext.StudentTBs.Local
                      //           where student.StudentID == 2
                                 //.Equals(User.Identity.Name.ToString())
                                 select student.StudentID;
                                 */

            DateTime now = DateTime.Now;
            var result = from user in dbcontext.UserTBs.Local
                         join message in dbcontext.MessageTBs.Local
                         on user.UserEmail equals message.EmailTo
                         where user.UserName
                         .Equals(User.Identity.Name.ToString())
                         select message;

            // add data to the Gridview
            GridView1.DataSource = result.ToList();
            string[] datakeynames = new string[1];
            datakeynames[0] = "EmailID";
            GridView1.DataKeyNames = datakeynames;
            GridView1.DataBind();
        }

        protected void btnSubmitM_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != null) //will have to take out the if else statement until we figure it out?????
            {              //this works now, but I'm just going to leave this if section in to show what it is supposed to do
                //using (UserDatabaseEntities dbcon = new UserDatabaseEntities())
                //{
                MessageTB myMsg = new MessageTB();
                //UserTB myUser = new UserTB();
                //query for student user name
                UserTB myUser = (from x in dbcontext.UserTBs.Local
                                 where x.UserName.Equals(User.Identity.Name.ToString())
                                 select x).First();

                //AdvisorTB myAdvisor = new AdvisorTB();
                //add data to the myMsg
                myMsg.EmailDate = DateTime.Now.Date;
                //time
                myMsg.EmailTime = DateTime.Now.TimeOfDay;// System.TimeSpan.Now.ToShortString();
                myMsg.EmailTo = txtEmail.Text;
                // myMsg.EmailFrom = myUser.UserName.ToString();
                myMsg.EmailFrom = myUser.UserEmail;
                //myMsg.EmailFrom = TextBox1.Text;
                myMsg.EmailText = txtMessage.Text;

                //add data to the Database table
                dbcontext.MessageTBs.Add(myMsg);
                dbcontext.SaveChanges();
                //clear data
                txtEmail.Text = "";
                txtMessage.Text = "";
                Label2.Text = "";
                Label3.Text = "";
                //reload tables
                ReloadMessages();
                ReloadSent();
                //}
            }
            else
            {
                Label2.Text = "Please enter an email address and message before selecting the 'Send' button.";
            }
        }

    

        protected void btnSelectDeleteM_Click(object sender, EventArgs e)
        {
            try
            {
                int? id = Convert.ToInt32(GridView1.SelectedDataKey?[0]);
                //may have to change dbcontext2 to dbcontext?????????????
                //UserDatabaseEntities dbcontext2 = new UserDatabaseEntities();
                //add data to the dbcontext
                dbcontext.MessageTBs.Load();
                //look for the row with id

                MessageTB message =
                    (from x in dbcontext.MessageTBs.Local
                     where x.EmailId == id
                     select x).First();
                //delete row from the table
                dbcontext.MessageTBs.Remove(message);
                dbcontext.SaveChanges();
                //show the result in the Gridview
                //GridView1.DataBind();
                ReloadMessages();
                Label2.Text = "";
                Label3.Text = "";
            }
            catch
            {
                Label2.Text = "Click on the desired 'Select' icon above, THEN select the 'Select & Delete' button.";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ReloadSent()
        {
            //NewDBCON();
            //dbcontext.AppointmentTBs.OrderBy(item => item.AppointmentDate).Load();
            // GridView3.DataSource = dbcontext.AppointmentTBs.Local;
            //GridView3.DataBind();

            //Label1.Text = User.Identity.Name.ToString();

            //add data to the dbcon
            dbcontext.MessageTBs.Load();
            dbcontext.UserTBs.Load();
            /*
            var studentIDQuery = from student in dbcontext.StudentTBs.Local
                      //           where student.StudentID == 2
                                 //.Equals(User.Identity.Name.ToString())
                                 select student.StudentID;
                                 */

            DateTime now = DateTime.Now;
            var resultz = from user in dbcontext.UserTBs.Local
                          join message in dbcontext.MessageTBs.Local
                          on user.UserEmail equals message.EmailFrom
                          where user.UserName
                          .Equals(User.Identity.Name.ToString())
                          select message;

            // add data to the Gridview
            GridView2.DataSource = resultz.ToList();
            string[] datakeynamesz = new string[1];
            datakeynamesz[0] = "EmailID";
            GridView2.DataKeyNames = datakeynamesz;
            GridView2.DataBind();
        }



        protected void btnSelectDeleteS_Click(object sender, EventArgs e)
        {
            try
            {
                int? idz = Convert.ToInt32(GridView2.SelectedDataKey?[0]);
                //may have to change dbcontext2 to dbcontext?????????????
                //UserDatabaseEntities dbcontext2 = new UserDatabaseEntities();
                //add data to the dbcontext
                dbcontext.MessageTBs.Load();
                //look for the row with id

                MessageTB message =
                    (from x in dbcontext.MessageTBs.Local
                     where x.EmailId == idz
                     select x).First();
                //delete row from the table
                dbcontext.MessageTBs.Remove(message);
                dbcontext.SaveChanges();
                //show the result in the Gridview
                //GridView1.DataBind();
                ReloadSent();
                Label2.Text = "";
                Label3.Text = "";
            }
            catch
            {
                Label3.Text = "Click on the desired 'Select' icon above, THEN select the 'Select & Delete' button.";
            }
        }

        protected void btnClearM_Click(object sender, EventArgs e)
        {
            //clear data
            txtEmail.Text = "";
            txtMessage.Text = "";
            Label2.Text = "";
            Label3.Text = "";
        }
    }
}