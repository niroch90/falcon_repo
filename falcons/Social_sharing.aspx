<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Social_sharing.aspx.cs" Inherits="falcons.Social_sharing" MasterPageFile="~/Falcons.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript">
        //<![CDATA[
       Sys.Application.add_load(function set_cursor () {
            $find("Editor1").get_editPanel().set_startEnd(false);
        });
        //]]>
</script>
  
     <!-- Social Media Sharing Tab-->

        
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-primary">
                <div class="panel-heading ">
                    <span class="col-md-9 pull-left ">Generate Social Media Tags</span>
                    <div>
                        <asp:Button ID="SocialBtn" runat="server" Text="Button" OnClick="SocialBtn_Click" CssClass="btn btn-danger" />
                    </div>
                </div>
                <div class="panel-body">
                    <asp:ListBox ID="socialLbox" runat="server" CssClass="form-control"></asp:ListBox>
                </div>
            </div>
        </div>
    </div>
 </asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <script type="text/javascript">
        //<![CDATA[
        Sys.Application.add_load(function set_cursor() {
            $find("Editor1").get_editPanel().set_startEnd(false);
        });
        //]]>
</script>

      
                           
               
   
</asp:Content>

