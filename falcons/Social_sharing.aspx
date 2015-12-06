<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Social_sharing.aspx.cs" Inherits="falcons.Social_sharing" MasterPageFile="~/Falcons.Master" %>
 
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <%--<link href="css/Collapse.css" rel="stylesheet" />--%>
   <%-- <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js" type="text/javascript"></script>--%>
   <%-- <script type="text/javascript">
        function getogTag() {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Social_sharing.aspx/GenerateOGTags",
                dataType: "json",
                data: "{'title':'" + $('#ogtitle').val() + "','type':'" + $('#ogtype').val() + "','url':'" + $('#ogurl').val() + "','image':'" + $('#ogimage').val() + "'}",
                success: OnSuccess,
                error: ErrorFound
            });
        }
        function OnSuccess(response) {

            $('#ogtags').text(response.d);


        }
        function ErrorFound(response) {
            alert(response.d);
        }

    </script>
   --%>
    <%--<script type="text/javascript">
        $(function () {
            $('#ogSubmitBtn').click(function () {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "Social_sharing.aspx/GenerateOGTags",
                    dataType: "json",
                    data: "{'title':'" + $('#ogtitle').val() + "','type':'" + $('#ogtype').val() + "','url':'" + $('#ogurl').val() + "','image':'" + $('#ogimage').val() + "'}",
                    success: OnSuccess,
                    error: ErrorFound
                });
            });
            function OnSuccess(response) {

                $('#ogtags').text(response.d);


            }
            function ErrorFound(response) {
                alert(response.d);
            }
        });
    </script>--%>
  <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script> --%>
    <script type="text/javascript">
        //<![CDATA[
       Sys.Application.add_load(function set_cursor () {
            $find("Editor1").get_editPanel().set_startEnd(false);
        });
        //]]>
</script>
  <%--<script>
      $(document).on('click', function () {
          $('.collapse').collapse('hide');
      })
</script> --%>
     <!-- Social Media Sharing Tab-->

        
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-primary">
                <div class="panel-heading ">
                    <span class="col-md-9 pull-left ">Generate Social Media Tags</span>
                    <div>
                        <asp:Button ID="SocialBtn" runat="server" Text="check Tags" OnClick="SocialBtn_Click" CssClass="btn btn-default" />
                    </div>
                </div>
                <div class="panel-body">
                    <asp:ListBox ID="socialLbox" runat="server" CssClass="form-control"></asp:ListBox>
                </div>
            </div>
        </div>
    </div>
   

<div class="row ">
    <div class="col-md-12">

	
        <div id="filter-panel" class="collapse filter-panel">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="form-group">
                    <label for="og-title">Og:Title</label>
                        <asp:TextBox ID="ogtitle" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        
                        
                        
                    
                </div>

                    <div class="form-group">
                    <label for="og-type">Og:Type</label>
                        <asp:TextBox ID="ogtype" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        
                       
                </div>

                    <div class="form-group">
                    <label for="og-url">Og:Url</label>
                        <asp:TextBox ID="ogurl" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        
                        
                </div>

                    <div class="form-group">
                    <label for="og-image">Og:Image</label>
                        <asp:TextBox ID="ogimage" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                       
                </div>
                    <div class="form-group">
                       <label ></label>
                       
                            <button type="button" id ="ogSubmitBtn" onclick="getogTag()" class="btn btn-default" ><span class="glyphicon glyphicon-arrow-right"></span> Generate</button>
                        
                        
                    </div>

                    <div class="form-group">
                       <label >Og Tags</label>
                        <textarea id="ogtags" cols="20" rows="4" class="form-control"></textarea>
                            
                        
                        
                    </div>
                    
                </div>
            </div>
        </div>    
        <button type="button" class="btn btn-primary" data-toggle="collapse" data-target="#filter-panel">
            <span class="glyphicon glyphicon-cog"></span> Generate Og Tags
        </button>
	

    </div>

</div>
 

 </asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-md-12">
                        <div class="input-group">

                            <asp:TextBox ID="socialsearchtbox" runat="server" CssClass="form-control" placeholder=" Check content in Facebook and Twitter"></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:Button ID="socialSearch" runat="server" Text="Check" OnClick="socialSearch_Click" CssClass="btn btn-default" />
                            </span>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row" id="fbrow" runat="server">
        <div class="col-md-12">
<div class="panel panel-default">
    <div class="panel-heading">
        Facebook
    </div>
    <div class="panel-body">
       <%-- <asp:ListBox ID="facebookurllst" runat="server" CssClass="form-control"></asp:ListBox>--%>
                        <asp:Repeater ID="facebookrepeater" runat="server">
                            <HeaderTemplate>
                                <table class="table table-hover">
                                    <tr>
                                        <th class="text-primary">Facebook Name</th>
                                        <th class="text-primary">Facebook Url</th>

                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td class="text-warning">
                                       <%# Eval("fbname").ToString() %>
                                    </td>
                                    <td class="text-warning">
                                        <asp:HyperLink ID="fblink" runat="server" NavigateUrl='<%# Eval("fburl").ToString() %>' Text='<%# Eval("fburl").ToString() %>' Target="_blank"></asp:HyperLink>
                                        
                                    </td>

                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table><br />
                            </FooterTemplate>

                        </asp:Repeater>
    </div>
</div>
        </div>
        </div>
        <div class="row" id="twitterrow" runat="server">
<div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading">Twitter</div>
                <div class="panel-body">
                    <asp:Repeater ID="twitterrepeater" runat="server" >
                            <HeaderTemplate>
                                <table class="table table-hover">
                                    <tr>
                                        <th class="text-primary">Twitter Name</th>
                                        <th class="text-primary">Twitter Url</th>

                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td class="text-warning">
                                      <%# Eval("twittername").ToString() %>
                                    </td>
                                    <td class="text-warning">
                                        <asp:HyperLink ID="twiterlink" runat="server" NavigateUrl='<%# Eval("twitterurl").ToString() %>' Text='<%# Eval("twitterurl").ToString() %>' Target="_blank"></asp:HyperLink>
                                        
                                       
                                    </td>

                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table><br />
                            </FooterTemplate>

                        </asp:Repeater>
                   <%-- <asp:ListBox ID="twitterurllst" runat="server" CssClass="form-control"></asp:ListBox>--%>
                </div>
            </div>
        </div>
        </div>
         
   
    </asp:Content>
