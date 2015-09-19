<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Image_seo.aspx.cs" Inherits="falcons.Image_seo" MasterPageFile="~/Falcons.Master" EnableEventValidation="false" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript">
        //<![CDATA[
        Sys.Application.add_load(function set_cursor() {
            $find("Editor1").get_editPanel().set_startEnd(false);
        });
        //]]>
    </script>
    <%--<div class="panel panel-default" style="width: 100%;">--%>
    <div class="row" style="padding-bottom: 10px">


        <form class="form-inline" id="Form2" method="post"  enctype="multipart/form-data">
            <div class="col-md-9">
                <div class="form-group">
                    <input type="file" id="filUpload" name="filUpload" runat="server">
                </div>
            </div>
            <div class="col-md-3 nopadding">
                <asp:Button ID="btnUpload" type="submit" class="btn btn-primary" Text="Search" runat="server"></asp:Button>
            </div>
        </form>
        
    </div>
    <div class="row" style="padding-bottom: 10px">
     <asp:Label id="lblOutput" class="help-block" runat="server" ></asp:Label>
        <asp:Image id="imgPicture" CssClass="img-rounded" Width="160px" Height="120px" runat="server"></asp:Image>
        <asp:Label CssClass="alert alert-info" runat="server" id="imgPictureBestKnowas"></asp:Label>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <img src="images/loader.gif" runat="server" />
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="row">
                <div class="col-md-12 ">
                    <div class="panel panel-primary">
                        <div class="panel-heading">Available Keywords</div>
                        <div class="panel-body">
                            <asp:ListBox ID="TitleListBox" runat="server" CssClass="form-control" Style="height: 150px"></asp:ListBox>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
        </Triggers>--%>
    </asp:UpdatePanel>
    <%--    </div>--%>
</asp:Content>


<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                <ProgressTemplate>
                    <img src="images/loader.gif" runat="server" />
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="row">
                <div class="col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">Available Content</div>
                        <div class="panel-body">
                            <asp:ListBox ID="ContentListBox" runat="server" CssClass="form-control" Style="height: 150px"></asp:ListBox>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 ">
                    <div class="panel panel-primary">
                        <div class="panel-heading">Available URLs</div>
                        <div class="panel-body">
                            <asp:ListBox ID="UrlListBox" runat="server" CssClass="form-control" Style="height: 150px"></asp:ListBox>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
        </Triggers>--%>
    </asp:UpdatePanel>
</asp:Content>
