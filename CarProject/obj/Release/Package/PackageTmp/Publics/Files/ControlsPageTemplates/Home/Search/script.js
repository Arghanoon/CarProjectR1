function GoToPage(intpage) {
    frm = document.getElementById("Webiste_Search_Control");

    inp = document.createElement("input");
    inp.type = "hidden";
    inp.value = intpage;
    inp.name = "page";

    frm.appendChild(inp);
    frm.submit();
}