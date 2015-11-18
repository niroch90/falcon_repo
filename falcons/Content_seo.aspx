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
   
   <%-- <script type="text/javascript">
        var editorControl = document.getElementById('<%=Master.FindControl("Editor1").ClientID %>');
        $(document).ready(function () {
            $('#WordCountBtn').click(function(){
                var content = editorContorl.get_content();
            $.ajax({
                url: 'Content_seo.aspx/CountWords',
                method: 'post',
                conentType: 'application/json',
                data: JSON.stringify({ strText: content, stripTags: 'true' }),
                dataType: 'json',
                success:function(data)
                {
                    $('#<%= wordRResult.ClientID %>').text(data.d.countedWords);
                   
                },
                error:function(error)
                {
                    alert(Error);
                }
            });

            });
        });
    </script>--%>
   
<div>
        <div class="row">
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
                </asp:UpdatePanel>
                </div>
                </div>
                </div>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <div class="container">
        <div class="row">
            
            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                <div class="row">
                <div class="iconbox">
                <div class="iconbox-icon">
                <span class="glyphicon glyphicon-wrench"></span>
                </div>
                <div class="featureinfo">
                <h4 class="text-center">Title</h4>
                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Corrupti atque, tenetur quam aspernatur corporis at explicabo nulla dolore necessitatibus doloremque exercitationem sequi dolorem architecto perferendis quas aperiam debitis dolor soluta!</p>
                <asp:Button ID="html_fix_button" runat="server" Text="Fix Html Tags Errors"  CssClass="btn btn-primary" OnClick="html_fix_button_Click"/>
                </div>
                </div>
                </div>

                <div class="row">
                
                <div class="iconbox">
                <div class="iconbox-icon">
                <span class="glyphicon glyphicon-search"></span>
                </div>
                <div class="featureinfo">
                <h4 class="text-center">Title</h4>
                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Corrupti atque, tenetur quam aspernatur corporis at explicabo nulla dolore necessitatibus doloremque exercitationem sequi dolorem architecto perferendis quas aperiam debitis dolor soluta!</p>
                <div class="panel panel-info">
                    <div class="panel-body">
                    <table class="table table-condensed">
                 <tr>
                     <td>Url:</td><td> <asp:TextBox ID="url_tbox" runat="server" CssClass="form-control"></asp:TextBox></td>
                     </tr>
                    <tr>
                     <td>Search Term:</td><td><asp:TextBox ID="search_term" runat="server" CssClass="form-control"></asp:TextBox></td>
                 </tr>
                    <tr>
                        <td></td><td><asp:Button ID="url_search_btn" runat="server" Text="Search" OnClick="url_search_btn_Click" CssClass="btn btn-primary"/></td>
                    </tr>
                    <tr>
                          <td></td><td><textarea id="url_search_result" cols="40" rows="2" runat="server" class="form-control"></textarea></td>
                    </tr>
                </table>
                        </div>
                    </div>
                    
                
                
                 
                </div>
                </div>
          
                  
            </div>
            </div>
        
            
            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                <div class="iconbox">
                <div class="iconbox-icon">
                <span class="glyphicon glyphicon-open-file"></span>
                </div>
                <div class="featureinfo">
                <h4 class="text-center">Title</h4>
                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Corrupti atque, tenetur quam aspernatur corporis at explicabo nulla dolore necessitatibus doloremque exercitationem sequi dolorem architecto perferendis quas aperiam debitis dolor soluta!</p>
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
                            <asp:Button ID="metatagbtn" runat="server" Text="Generate Meta Tags"  OnClick="metatagbtn_Click" CssClass="btn btn-primary"/></td><td></td></tr>
                        <tr><td></td><td>
                            <asp:TextBox ID="metaresulttbox" runat="server" CssClass="form-control" Rows="5" TextMode="MultiLine"></asp:TextBox></td><td></td></tr>
                    </table>
                </div>
                </div>
                </div>
                </div>
            </div>
	    </div>
    </div>
    
   
      
        <div class="row">
                <div class="col-md-6">
                    <ajaxToolkit:Accordion ID="Accordion2" runat="server" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent">
                    <Panes>
                    <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server">
                    <Header>What Search Engines Are Looking For</Header>
                    <Content>Search engines want to do their jobs as best as possible by referring users to websites and content that is the most relevant to what the user is looking for. So how is relevancy determined?
                    <ul>
                        <li>
                        <b>Content:</b> Is determined by the theme that is being given, the text on the page, and the titles and descriptions that are given.
                        </li>
                        <li>
                        <b>Performance:</b> How fast is your site and does it work properly?
                        </li>
                        <li>
                        <b>Authority:</b> Does your site have good enough content to link to or do other authoritative sites use your website as a reference or cite the information that's available?
                        </li>
                        <li>
                        <b> Experience:</b> How does the site look? Is it easy to navigate around? Does it look safe? Does it have a high bounce rate?
                        </li>
                    </ul>
                    </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                    <Header>What Search Engines Are NOT Looking For</Header>
                    <Content>Search engine spiders only have a certain amount of data storage, so if you're performing shady tactics or trying to trick them, chances are you're going to hurt yourself in the long run. Items the search engines don't want are:
                    <ul>
                        <li>
                        <b>Keyword Stuffing:</b> Overuse of keywords on your pages.
                        </li>
                        <li>
                        <b>Purchased Links:</b> Buying links will get you nowhere when it comes to SEO, so be warned.
                        </li>
                        <li>
                        <b>Poor User Experience:</b> Make it easy for the user to get around. Too many ads and making it too difficult for people to find content they're looking for will only increase your bounce rate. If you know your bounce rate it will help determine other information about your site. For example, if it's 80 percent or higher and you have content on your website, chances are something is wrong.
                        </li>
                    </ul>
                    </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                    <Header>Keywords in URL</Header>
                    <Content>Having keywords you're trying to rank for in your domain will only help your overall efforts.</Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
                    <Header>Focus on Your Meta Data</Header>
                    <Content>
                        Your content on your site should have title tags and meta descriptions.
                    <ul>
                        <li>
                        Meta keywords are pretty much ignored by search engines nowadays, but if you still use them, make sure it talks specifically to that page and that it is also formatted correctly.
                        </li>
                        <li>
                        Your meta description should be unique and also speak to that specific page. Duplicate meta descriptions from page to page will not get you anywhere.
                        </li>
                    </ul>
                    Title tags should also be unique! Think your title as a 4-8 word ad, so do your best to entice the reader so they want to click and read more.
                    </Content>
                    </ajaxToolkit:AccordionPane>
                    </Panes>
                    </ajaxToolkit:Accordion>
                </div>
                <div class="col-md-6">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <asp:Button ID="WordCountBtn" runat="server" Text="Click To Count Words" OnClick="countwords_btnclick"/>
                    <asp:Label ID="wordResult" runat="server" ></asp:Label>
                    <div>
                    <div id="progress_block" class="progress" runat="server" style="display:none;" >
                    <div id="word_percentage_div" class="progress-bar" role="progressbar" aria-valuemin="0" aria-valuemax="100" runat="server">
                    <div>
                    <div id="progress_text" runat="server" ><%= WordCountText%></div>
                    </div>
                    </div>
                    </div>
                    </div>
                    </ContentTemplate>
                    <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="WordCountBtn" EventName="Click"/>
                    </Triggers>
                    </asp:UpdatePanel>
                    </div>
        </div>
</asp:Content>