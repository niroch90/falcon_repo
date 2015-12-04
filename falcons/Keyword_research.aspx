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
            
    <div class="row">
        <div class="col-md-12">
            <div class="row" style="padding-bottom: 10px;">
                <div class="col-md-12">
                    <div class="text-warning ">
                        Search Important Words in Content
                         <asp:Button ID="kwExtractorbtn" runat="server" Text="Search" OnClick="kwExtractorbtn_Click" CssClass="btn btn-primary pull-right" />
                    </div>

                </div>

            </div>
            <div class="row">
                <div class="col-md-12">

                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Important Words in Content
                        </div>
                        <div class="panel-body">
                            <asp:ListBox ID="editorKeywordsLbox" runat="server" CssClass="form-control" Height="125px" OnSelectedIndexChanged="editorKeywordsLbox_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
                        </div>
                    </div>
                </div>


            </div>
        </div>
    </div>
    
    
    
    <%--<div class="row" style="padding-bottom:10px">
                 
                    
                     </div>--%>
      
   
                <div class="row">
                    <div class="col-md-12 ">
                        <div class="panel panel-primary">
                            <div class="panel-heading">Word Details</div>
                            <div class="panel-body">
                                <table>
                                    <tr><td>
                                        <asp:Label ID="keywrdnamelbl" runat="server" ></asp:Label></td></tr>
                                    <tr><td>
                                        <asp:Label ID="keywrdcountlbl" runat="server" ></asp:Label></td></tr>
                                    <tr><td>
                                        <asp:Label ID="keywordpos" runat="server" ></asp:Label></td></tr>
                                    <tr><td>
                                        <asp:Label ID="titleappeatlbl" runat="server" ></asp:Label></td></tr>
                                    <tr><td>
                                        <asp:Label ID="kwrdDensitylbl" runat="server" Text="Label"></asp:Label></td></tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
       </asp:Content>


<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <div class="row">
        <div class="col-md-12">
  <div class="panel panel-default">
            <div class="panel-body">
 
            <div class="col-md-10">
                <div class="input-group">
                    <asp:TextBox ID="TextBox2" runat="server" placeholder="Enter Text To Search Keywords" CssClass="form-control"></asp:TextBox>
                    <span class="input-group-btn">
                        <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Keyword_research_button" CssClass="btn btn-primary" /></span>
                </div>
            </div>
            <div class="col-md-2 nopadding">

                <asp:DropDownList ID="searchEngineDW" runat="server" CssClass="selectpicker" data-style="btn-danger" OnSelectedIndexChanged="Keyword_research_button" AutoPostBack="true">
                    <asp:ListItem Value="1">Google</asp:ListItem>
                    <asp:ListItem Value="2">Bing</asp:ListItem>
                </asp:DropDownList>
            </div>
        
            </div>
        </div>
        </div>
      
       
    </div>

    <div class="row">
                    <div class="col-md-6">
                      <div class="panel panel-primary">
                            <div class="panel-heading">Available Keywords</div>
                            <div class="panel-body">
                                <asp:ListBox ID="TitleListBox" runat="server" CssClass="form-control" Style="height: 150px"></asp:ListBox>
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
    <div class="row">
        <div class="col-md-12">
 <div class="panel panel-primary">
                            <div class="panel-heading">Available Content</div>
                            <div class="panel-body">
                                <asp:ListBox ID="ContentListBox" runat="server" CssClass="form-control" Style="height: 150px" ></asp:ListBox>
                            </div>
                        </div>
        </div>
    </div>
            <div class="row">
                
                   <div class="col-md-12">
                       <asp:Repeater ID="Repeater1" runat="server">
                           <HeaderTemplate>
                               <div class="panel panel-primary">
                                   <div class="panel-heading">Related Images</div>
                               <table class="table table-bordered">
                                   <tr>
                                       <th>Image</th>
                                       <th>Image Url</th>
                                   </tr>
                           </HeaderTemplate>
                           <ItemTemplate>
                               <tr>
                                   <td style="width:150px;height:150px;"><asp:Image ID="Image2" runat="server"  ImageUrl='<%#Eval("imageUrl")%>' Width="150px" Height="150px" CssClass="img-thumbnail"/></td>
                                   <td style="width:600px;height:150px;" ><%#Eval("imageUrl")%></td>
                               </tr>
                           </ItemTemplate>
                           <FooterTemplate>
                               </table>
                               </div>
                           </FooterTemplate>
                  </asp:Repeater>
               </div>
             </div>
       </asp:Content>

    
        
 
