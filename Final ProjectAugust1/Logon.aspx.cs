using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.Entity;

namespace Final_ProjectAugust1
{
    public partial class Logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }
        //Create dbcon
        UserDatabaseEntities dbcon = new UserDatabaseEntities();

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

            string name = Login1.UserName.Trim();
            string pass = Login1.Password.Trim();
            //Label1.Text = name + " " + pass;
            // look for user in the Database
            dbcon.UserTBs.Load();
            /*
            CustomerTable myUser = (from x in dbcon.CustomerTables.Local
                                    where x.UserName.Trim().Equals(name) //UserName.StartsWith("ABC") or name
                                    && x.UserPass.Trim().Equals(pass)  //UserPass.StartsWith("ABC") or pass
                                    select x).First();
                                    */
            try
            {
                UserTB myUser = (from x in dbcon.UserTBs.Local
                                 where x.UserName.Trim().Equals(name)
                                 && x.UserPassword.Trim().Equals(pass)
                                 select x).First();
                /*
                            UserTB myUser = (from x in dbcon.UserTBs.Local
                                             where x.UserName.Trim().Equals("Oksana") //UserName.StartsWith("ABC") or name
                                             && x.UserPassword.Trim().Equals("1234")  //UserPass.StartsWith("ABC") or pass
                                             select x).First();
                                             */

                if (myUser != null)
                {
                    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, true);
                }
                //Label1.Text = myUser.UserName + " " + myUser.UserPass;
                else
                {
                    Label1.Text = "Your login attempt was not successful. Please try again.";
                }
            }

            catch (Exception)
            {
                Label1.Text = "Your login attempt was not successful. Please try again.";
            }
        }
    }
}