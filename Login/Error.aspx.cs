using System;
using Login.Models;

namespace Login
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LogError.SavingLog(((Usuario)Session["User"]).Id, "An unhandle error occurred");
        }
    }
}