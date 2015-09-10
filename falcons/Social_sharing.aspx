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

        <div role="tabpanel" class="tab-pane" id="socialmedia">
            <div class="row">
               
            </div>
        </div>
    </div>
 </asp:Content>
