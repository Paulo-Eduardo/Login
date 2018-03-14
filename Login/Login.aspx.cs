using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Login.Models;

namespace Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void OnClick(object sender, EventArgs e)
        {
            var user = Usuario.Get(this.user.Value, this.password.Value);
            if (user != null)
            {
                Session["USER"] = user;
                Response.Redirect("Default.aspx");
            }
            else
            {
               Response.Write("User or Password doens`t match.");
            }
        }
    }
}