document.getElementById("defaultOpen").click();

function onClickTab(evt, radioName) {
    let i, tabcontent, tablinks;

    tabcontent = document.getElementsByClassName("mandates-value-item-first-point");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    tablinks = document.getElementsByClassName("mandates-value-item-first-pick__item");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace("mandates-value-item-first-pick__item active", "mandates-value-item-first-pick__item");
    }

    document.getElementById(radioName).style.display = "flex";
    evt.currentTarget.className += " active";
}


function onClickFilterIcon() {
    const filterStyle = document.getElementById("filters").style.display;

    if (filterStyle !== 'inline') {
        document.getElementById("filtersSelector").style.borderRadius = '8px 8px 0 0';
        return document.getElementById("filters").style.display = 'inline';
    };

    if (filterStyle === 'inline') {
        document.getElementById("filtersSelector").style.borderRadius = '8px';
        return document.getElementById("filters").style.display = 'none';
    };

}

function onClickTypesIcon() {
    const filterStyle = document.getElementById("types").style.display;

    if (filterStyle !== 'inline') {
        document.getElementById("typesSelector").style.borderRadius = '8px 8px 0 0';
        return document.getElementById("types").style.display = 'inline';
    };

    if (filterStyle === 'inline') {
        document.getElementById("typesSelector").style.borderRadius = '8px';
        return document.getElementById("types").style.display = 'none';
    };

}