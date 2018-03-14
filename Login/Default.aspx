<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Login.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" class="container"  runat="server">
            <div align="right" class="bg-dark">
                <asp:Image runat="server" class="img-circle" ID="userImage" style="width: 50px; height: 50px"/>
                <label style="color: white" runat="server" id="userLabel"></label>&nbsp; 
            <asp:Button runat="server" class="btn btn-danger" Text="Log-out" OnClick="LogOutOnClick"/>
            </div>
        <div>
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
                Create new User
            </button>
            <asp:GridView ID="gridUsuarios" runat="server" AutoGenerateColumns="False" GridLines=None class="table" OnRowCommand="gridUsuarios_OnRowCommand">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="False" Visible="False" />
                    <asp:ImageField DataImageUrlField="Image" HeaderText="User">
                        <ControlStyle Height="40px" Width="40px" />
                    </asp:ImageField>
                    <asp:BoundField DataField="Login" />
                    <asp:BoundField DataField="Created" HeaderText="Created" />
                    <asp:BoundField DataField="Login" HeaderText="Login" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:ButtonField Text="Remover">
                    <ControlStyle CssClass="btn btn-danger" />
                    </asp:ButtonField>
                </Columns>
            </asp:GridView>


            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Create New User</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <input type="text" class="form-control" id="NewUser" runat="server" placeholder="User"/>
                            </div>
                            <div class="form-group">
                                <input type="password" class="form-control" id="NewPassword" runat="server" placeholder="Password"/>
                            </div>
                            <div class="form-group">
                                <input type="email" class="form-control" id="NewEmail" runat="server" placeholder="email@email.com"/>
                            </div>
                            <div class="form-group">
                                <div class="custom-file">
                                    <input type="file" class="custom-file-input" id="NewImage" runat="server"/>
                                    <label class="custom-file-label" for="NewImage">Choose file</label>
                                </div>
                            </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <asp:Button runat="server" class="btn btn-primary" Text="Create" OnClick="OnClick"/>
                    </div>
                </div>
            </div>
        </div>

        </div>

        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    </form>
</body>
</html>
