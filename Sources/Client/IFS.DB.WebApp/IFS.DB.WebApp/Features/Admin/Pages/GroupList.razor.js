function onTriggerModalDelete() {
    const modalStyle = document.getElementById("ModalDelete").style.display;

    if (modalStyle !== 'flex') {
        return document.getElementById("ModalDelete").style.display = 'flex';
    };

    if (modalStyle === 'flex') {
        return document.getElementById("ModalDelete").style.display = 'none';
    };
}