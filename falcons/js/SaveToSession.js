

setInterval(function SaveSession() {
    //var varcont = $("#Editor1_ctl02_ctl00");
    var content = document.getElementById('Editor1_ctl02_ctl00').contentWindow.document.body.innerHTML;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "FalconsService.asmx/SaveToSession",
        dataType: "json",
        data: "{'editorContent':'" + content + "','title':'" + $('#ContentTitle').val() + "'}",
        //success: OnSuccess,
        //error: ErrorFound
    });
},5000);
//function OnSuccess(response) {

//    alert(response.d);


//}
//function ErrorFound(response) {
//    alert("error");
//}
