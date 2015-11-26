
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
