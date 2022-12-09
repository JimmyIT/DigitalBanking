function onTriggerPhoneSelector() {
    const filterStyle = document.getElementById("types").style.display;

    if (filterStyle !== 'inline') {
        document.getElementById("typesSelector").style.borderRadius = '8px 0 0 0';
        return document.getElementById("types").style.display = 'inline';
    };

    if (filterStyle === 'inline') {
        document.getElementById("typesSelector").style.borderRadius = '8px 0 0 8px';
        return document.getElementById("types").style.display = 'none';
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