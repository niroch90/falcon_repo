<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Keyword_research.aspx.cs" Inherits="falcons.Keyword_research" MasterPageFile="~/Falcons.Master" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
     <script type="text/javascript">
        //<![CDATA[
       Sys.Application.add_load(function set_cursor () {
            $find("Editor1").get_editPanel().set_startEnd(false);
        });
        //]]>
</script>
<%--<div class="panel panel-default" style="width: 100%;">--%>
            <div class="row" style="padding-bottom:10px">
                 
                    <div class="col-md-9">
                        <div class="input-group">
                            <asp:TextBox ID="TextBox2" runat="server" placeholder="Enter Text To Search Keywords" CssClass="form-control"></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Keyword_research_button" CssClass="btn btn-primary" /></span>
                        </div>
                    </div>
                    <div class="col-md-3 nopadding">
                        
                        <asp:DropDownList ID="searchEngineDW" runat="server" CssClass="selectpicker" data-style="btn-danger" OnSelectedIndexChanged="Keyword_research_button" AutoPostBack="true" >
                            <asp:ListItem Value="1">Google</asp:ListItem>
                            <asp:ListItem Value="2">Bing</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                     </div>
      
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <img src="images/loader.gif" runat="server"/>
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
                    <img src="images/loader.gif" runat="server"/>
                </ProgressTemplate>
                </asp:UpdateProgress>
             <div class="row">
                    <div class="col-md-6">
                        <div class="panel panel-primary">
                            <div class="panel-heading">Available Content</div>
                            <div class="panel-body">
                                <asp:ListBox ID="ContentListBox" runat="server" CssClass="form-control" Style="height: 150px" ></asp:ListBox>
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

    
        
 
