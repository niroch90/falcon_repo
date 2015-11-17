<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Social_sharing.aspx.cs" Inherits="falcons.Social_sharing" MasterPageFile="~/Falcons.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript">
        //<![CDATA[
       Sys.Application.add_load(function set_cursor () {
            $find("Editor1").get_editPanel().set_startEnd(false);
        });
        //]]>
</script>
    <div>
     <!-- Social Media Sharing Tab-->

        <div>
            <div class="panel panel-success">
                <div class="panel-heading">
                    View Social Media Tags:<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                </div>
               
                <div class="panel-body">
                    <asp:ListBox ID="OgtagLbox" runat="server" Height="164px" Width="217px"></asp:ListBox>
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

