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