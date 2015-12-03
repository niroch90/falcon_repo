

setInterval(function SaveSession() {
    var content = document.getElementById('Editor1_ctl02_ctl00').contentWindow.document.body.innerHTML;
    
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "FalconsService.asmx/SaveToSession",
        dataType: "json",
        data: JSON.stringify({ 'editorContent': content, 'title': $('#ContentTitle').val() }),

        //"{'editorContent': '" + content + "','title':'" + $('#ContentTitle').val() + "'}"
       
    });
},3000);

