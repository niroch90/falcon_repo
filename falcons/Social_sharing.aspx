<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Social_sharing.aspx.cs" Inherits="falcons.Social_sharing" MasterPageFile="~/Falcons.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="css/Collapse.css" rel="stylesheet" />
  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
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

     <script type="text/javascript">
         $(function () {
             $('#ogSubmitBtn').click(function () {
                 $.ajax({
                     type: "POST",
                     contentType: "application/json; charset=utf-8",
                     url: "Social_sharing.aspx/GenerateOGTags",
                     dataType: "json",
                     data: "{'title':'" + $('#og-title').val() + "','type':'" + $('#og-type').val() + "','url':'" + $('#og-url').val() + "','image':'" + $('#og-image').val() + "'}",
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
    </script>   
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
   

<div class="row ">
    <div class="col-md-12">

	
        <div id="filter-panel" class="collapse filter-panel">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="form-group">
                    <label for="og-title">Og:Title</label>
                    
                        <input id="og-title" name="full-name" type="text" placeholder="full name"
                        class="form-control"/>
                        
                    
                </div>

                    <div class="form-group">
                    <label for="og-type">Og:Type</label>
                    
                        <input id="og-type" name="full-name" type="text" placeholder="full name"
                        class="form-control"/>
                       
                </div>

                    <div class="form-group">
                    <label for="og-url">Og:Url</label>
                  
                        <input id="og-url" name="full-name" type="text" placeholder="full name"
                        class="form-control"/>
                        
                </div>

                    <div class="form-group">
                    <label for="og-image">Og:Image</label>
                    
                        <input id="og-image" name="full-name" type="text" placeholder="full name"
                        class="form-control"/>
                        
                </div>
                    <div class="form-group">
                       <label ></label>
                       
                            <button type="button" id ="ogSubmitBtn"  >Submit</button>
                        
                        
                    </div>

                    <div class="form-group">
                       <label >Og Tags</label>
                        <textarea id="ogtags" cols="20" rows="2" class="form-control"></textarea>
                            
                        
                        
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
