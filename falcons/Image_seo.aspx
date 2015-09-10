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
                    <div role="tabpanel" class="tab-pane" id="imageseo">
                        <div class="row">
                           
                        </div>
                    </div>
    </div>
</asp:Content>
