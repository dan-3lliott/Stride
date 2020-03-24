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

function selectAll() {
    let tr = document.getElementById("studenttable").getElementsByTagName("tr");
    for (let i = 1; i < tr.length; i++) {
        if (tr[i].style.display !== "none") {
            tr[i].classList.add('selected');
        }
    }
}
function deselect() {
    $("tr").each(function() {
        $(this).removeClass('selected');
    });
}

function search() {
    let input, filter, table, tr, td, i, txtValue, searchby;
    input = document.getElementById("search");
    filter = input.value.toUpperCase();
    table = document.getElementById("studenttable");
    tr = table.getElementsByTagName("tr");
    searchby = document.getElementById("searchby");
    let matchingrows = [];
    for (i = 1; i < tr.length; i++) {
        tr[i].classList.remove("last-row");
        td = tr[i].getElementsByTagName("td")[searchby.options[searchby.selectedIndex].value];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
                matchingrows.push(i);
            } else {
                tr[i].style.display = "none";
            }
        }
    }
    tr[matchingrows[matchingrows.length - 1]].classList.add("last-row");
}
