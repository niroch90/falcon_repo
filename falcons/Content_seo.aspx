<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Content_seo.aspx.cs" Inherits="falcons.Content_seo" MasterPageFile="~/Falcons.Master" %>
<%@ MasterType VirtualPath="~/Falcons.Master" %>


<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
      <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
   <link rel="stylesheet" type="text/css" href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.5/themes/redmond/jquery-ui.css" />
    
   <script type="text/javascript">
        //<![CDATA[
       Sys.Application.add_load(function set_cursor () {
            $find("Editor1").get_editPanel().set_startEnd(false);
        });
        //]]>
</script>

      <script type="text/javascript">
          $(function () {
              $("#<% =accordion_1.ClientID %>").accordion({
                  //active: false, collapsible: true, heightStyle: "content", alwaysOpen: false
              });
          });
  </script>

    
    <div>
     <div class="row">
           <%--<div class="col-md-12">
                 </div>--%>
                       <div class="col-md-12">
                            
                           <asp:UpdatePanel ID="content_upanel" runat="server">
                               <ContentTemplate>
                                   <div>
                                       <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true">
                                          <ProgressTemplate>
                                              <img src="images/loader.gif" runat="server"/>

                                          </ProgressTemplate>
                                           
                                       </asp:UpdateProgress>
                                       
                                    
                                       <div class="panel panel-info" style="height:330px;" >
               <div class="panel-heading">Click To Validate 
                                 <asp:Button ID="Button1" runat="server" Text="Check Links"  OnClick="Button1_Click" CssClass="btn btn-danger"/>
                               <%--  <asp:Label ID="content_lable" runat="server" Text="Label"></asp:Label>--%>
                                 </div>
               <div class="panel-body" >
                   <table class="table table-condensed">
                       <tr><td>Available Links:</td><td>
                           <asp:TextBox ID="Aval_links_Tbox" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox></td></tr>
                       <tr><td>Available Headings</td><td>
                           <asp:TextBox ID="Aval_Heading_Tbox" runat="server" CssClass="form-control" Rows="3" TextMode="MultiLine"></asp:TextBox></td></tr>
                       <tr><td>Paragraphs</td><td>
                           <asp:TextBox ID="Aval_Para_Tbox" runat="server" CssClass="form-control" Rows="3" TextMode="MultiLine"></asp:TextBox></td></tr>
                     </table>
               </div>
           </div>
                                   </div>
                               </ContentTemplate>
                               <Triggers>
                                   <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                               </Triggers>
                           </asp:UpdatePanel>
                               
                            </div>
                        </div>
                    </div>
   
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <div class="row">
        <div class="col-md-6">
<asp:Button ID="html_fix_button" runat="server" Text="Fix Html Tags Errors"  CssClass="btn-default" OnClick="html_fix_button_Click"/>
        </div>
        <div class="col-md-6" >
           <div class="panel panel-info" >
               <div class="panel-heading">Generate Meta Tags</div>
               <div class="panel-body" >
                   <table class="table table-condensed">
                       <tr><td>Title</td><td>
                           <asp:TextBox ID="titletbox" CssClass="form-control" runat="server"></asp:TextBox></td></tr>
                       <tr><td>Description</td><td>
                           <asp:TextBox ID="descriptiontbox" runat="server" CssClass="form-control" Rows="4" TextMode="MultiLine"></asp:TextBox></td></tr>
                       <tr><td>Keywords</td><td>
                           <asp:TextBox ID="keywordstbox" runat="server" CssClass="form-control"></asp:TextBox></td></tr>
                       <tr><td></td><td>
                           <asp:Button ID="metatagbtn" runat="server" Text="Generate Meta Tags"  OnClick="metatagbtn_Click"/></td><td></td></tr>
                       <tr><td></td><td>
                           <asp:TextBox ID="metaresulttbox" runat="server" CssClass="form-control" Rows="5" TextMode="MultiLine"></asp:TextBox></td><td></td></tr>
                   </table>
               </div>
           </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
           Url: <asp:TextBox ID="url_tbox" runat="server"></asp:TextBox> Search Term:<asp:TextBox ID="search_term" runat="server"></asp:TextBox><asp:Button ID="url_search_btn" runat="server" Text="Search" OnClick="url_search_btn_Click" /><br />
            <textarea id="url_search_result" cols="40" rows="2" runat="server"></textarea>
        </div>

    </div>
    
        
           <div class="row">
               <div class="col-md-6">
       <div id="accordion_1" runat="server">

  <h3>Section 1</h3>

  <div>

    <p>

    Mauris mauris ante, blandit et, ultrices a, suscipit eget, quam. Integer

    ut neque. Vivamus nisi metus, molestie vel, gravida in, condimentum sit

    amet, nunc. Nam a nibh. Donec suscipit eros. Nam mi. Proin viverra leo ut

    odio. Curabitur malesuada. Vestibulum a velit eu ante scelerisque vulputate.

    </p>

  </div>

  <h3>Section 2</h3>

  <div>

    <p>

    Sed non urna. Donec et ante. Phasellus eu ligula. Vestibulum sit amet

    purus. Vivamus hendrerit, dolor at aliquet laoreet, mauris turpis porttitor

    velit, faucibus interdum tellus libero ac justo. Vivamus non quam. In

    suscipit faucibus urna.

    </p>

  </div>

  <h3>Section 3</h3>

  <div>

    <p>

    Nam enim risus, molestie et, porta ac, aliquam ac, risus. Quisque lobortis.

    Phasellus pellentesque purus in massa. Aenean in pede. Phasellus ac libero

    ac tellus pellentesque semper. Sed ac felis. Sed commodo, magna quis

    lacinia ornare, quam ante aliquam nisi, eu iaculis leo purus venenatis dui.

    </p>

    <ul>

      <li>List item one</li>

      <li>List item two</li>

      <li>List item three</li>

    </ul>

  </div>

  <h3>Section 4</h3>

  <div>

    <p>

    Cras dictum. Pellentesque habitant morbi tristique senectus et netus

    et malesuada fames ac turpis egestas. Vestibulum ante ipsum primis in

    faucibus orci luctus et ultrices posuere cubilia Curae; Aenean lacinia

    mauris vel est.

    </p>

    <p>

    Suspendisse eu nisl. Nullam ut libero. Integer dignissim consequat lectus.

    Class aptent taciti sociosqu ad litora torquent per conubia nostra, per

    inceptos himenaeos.

    </p>

  </div>

</div>
</div>
</div>

      

    
 
</asp:Content>