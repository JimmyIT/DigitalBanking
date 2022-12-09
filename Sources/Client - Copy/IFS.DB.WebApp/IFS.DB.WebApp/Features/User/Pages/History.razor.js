function onClickFilterIcon() {
    const filterStyle = document.getElementById("filters").style.display;

    if (filterStyle !== 'flex') {
        return document.getElementById("filters").style.display = 'flex';
    };

    if (filterStyle === 'flex') {
        return document.getElementById("filters").style.display = 'none';
    };

}