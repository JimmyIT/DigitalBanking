function onTriggerModalSignatories() {
    const modalStyle = document.getElementById("ModalSignatories").style.display;

    if (modalStyle !== 'block') {
        return document.getElementById("ModalSignatories").style.display = 'block';
    };

    if (modalStyle === 'block') {
        return document.getElementById("ModalSignatories").style.display = 'none';
    };
}

function onSuccessModalSignatories() {
    document.getElementById("ModalSignatories").style.display = 'none';
}