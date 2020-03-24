$("tr").click(function(){
    $(this).toggleClass("selected");
});

function emailSelected() {
    let mailToUrl = "mailto:";
    let count = 0;
    $("tr.selected").each(function() {
        mailToUrl += $(this).attr('email') + ",";
        count++;
    });
    if (count>0) {
        let mail = document.createElement("a");
        mail.href = mailToUrl;
        mail.click();
    }
}

function deselect() {
    $("tr").each(function() {
        $(this).removeClass('selected');
    });
}

