<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Image_seo.aspx.cs" Inherits="falcons.Image_seo" MasterPageFile="~/Falcons.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript">
        //<![CDATA[
       Sys.Application.add_load(function set_cursor () {
            $find("Editor1").get_editPanel().set_startEnd(false);
        });
        //]]>
</script>
    <div>
     <!-- Image SEO Tab-->
                    <div class="row">
                        <div>
                           <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                                <div class="panel panel-default">
                                <div class="panel-heading">Check Image tags
                                    <div>
                                        <asp:Button ID="ImageCheckBtn" runat="server" Text="Button" OnClick="ImageCheckBtn_Click" CssClass="btn btn-default"/></div></div>
                                <div class="panel-body">
                                    <asp:ListBox ID="Imagelbox" runat="server" CssClass="form-control" OnSelectedIndexChanged="Imagelbox_SelectedIndexChanged" AutoPostBack="true"  ></asp:ListBox>
                                </div>
                            </div>
                                     <div id="imgDetailspanel" class="panel panel-default" runat="server">
                                <div class="panel-body" runat="server">
                                 <table runat="server">
                                     <tr><td>Src Link</td><td>
                                         <asp:Label ID="srclabel" runat="server" ></asp:Label></td></tr>
                                     <tr><td>Alter Description</td><td>
                                         <asp:Label ID="altlabel" runat="server" ></asp:Label></td></tr>
                                     <tr><td>Image Width</td><td>
                                         <asp:Label ID="imgwidthlabel" runat="server" ></asp:Label></td></tr>
                                     <tr><td>Image Height</td><td>
                                         <asp:Label ID="imgheightlabel" runat="server" ></asp:Label></td></tr>
                                 </table>   
                                </div>
                             </div>
                                <%--</ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ImageCheckBtn" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="Imagelbox" EventName="SelectedIndexChanged"  />
                                </Triggers>
                            </asp:UpdatePanel>--%>
                           
                         </div>
                    </div>
    </div>
</asp:Content>
