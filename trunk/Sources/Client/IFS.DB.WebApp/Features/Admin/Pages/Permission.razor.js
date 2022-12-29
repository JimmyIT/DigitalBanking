function onClickTab(evt, radioName) {
    let i, tabcontent, tablinks;

    tabcontent = document.getElementsByClassName("check");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    tablinks = document.getElementsByClassName("admin-permission-box-selections-radio__item");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace("admin-permission-box-selections-radio__item active", "admin-permission-box-selections-radio__item");
    }

    document.getElementById(radioName).style.display = "flex";
    evt.currentTarget.className += " active";
}