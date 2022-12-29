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

function onTriggerModalSave() {
    const modalStyle = document.getElementById("ModalSave").style.display;

    if (modalStyle !== 'flex') {
        return document.getElementById("ModalSave").style.display = 'flex';
    };

    if (modalStyle === 'flex') {
        return document.getElementById("ModalSave").style.display = 'none';
    };
}