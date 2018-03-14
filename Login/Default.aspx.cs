using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Login.Models;

namespace Login
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = (Usuario)Session["USER"];
            if (user == null)
            {
                Response.Redirect("Login.aspx");
            }

            userLabel.InnerText = user.Login;
            userImage.ImageUrl = user.Image;
            userImage.DataBind();
            gridUsuarios.DataSource = Usuario.Get();
            gridUsuarios.DataBind();
        }

        protected void OnClick(object sender, EventArgs e)
        {
            var path = Server.MapPath(@"~\TempImage\" + this.NewUser.Value + ".jpeg");
            this.NewImage.PostedFile.SaveAs(path);
            Usuario.Create(this.NewUser.Value, this.NewPassword.Value, this.NewEmail.Value, @"\TempImage\" + this.NewUser.Value + ".jpeg");
            Response.Redirect(Request.RawUrl);
        }

        protected void LogOutOnClick(object sender, EventArgs e)
        {
            Session["USER"] = null;
            Response.Redirect(Request.RawUrl);
        }

        protected void gridUsuarios_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            var id = Guid.Parse(gridUsuarios.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);
            if (id == ((Usuario) Session["USER"]).Id)
            {
                Response.Write("You cant remove your own User");
                return;
            }
            Usuario.Remove(id);
            Response.Redirect(Request.RawUrl);
        }
    }
}