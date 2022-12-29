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

document.getElementById('current').textContent = 'Live';

updateLockSelectorValue();

function onTriggerModalLock() {
    const modalStyle = document.getElementById("ModalLock").style.display;

    if (modalStyle !== 'flex') {
        return document.getElementById("ModalLock").style.display = 'flex';
    };

    if (modalStyle === 'flex') {
        return document.getElementById("ModalLock").style.display = 'none';
    };
}

function onSuccessModalLock() {
    document.getElementById("ModalLock").style.display = 'none';
    document.getElementById('current').textContent = 'Locked';
    document.getElementById('access').style.display = 'block';
    document.getElementById('information').style.display = 'flex';
    document.getElementById('button').style.display = 'none';
}

function onTriggerModalUpdate() {
    const modalStyle = document.getElementById("ModalUpdate").style.display;

    if (modalStyle !== 'flex') {
        return document.getElementById("ModalUpdate").style.display = 'flex';
    };

    if (modalStyle === 'flex') {
        return document.getElementById("ModalUpdate").style.display = 'none';
    };
}

function onSuccessModalUpdate() {
    document.getElementById("ModalUpdate").style.display = 'none';
    document.getElementById('buttons').style.display = 'flex';
}

function onTriggerModalConfirm() {
    const modalStyle = document.getElementById("ModalConfirm").style.display;

    if (modalStyle !== 'flex') {
        return document.getElementById("ModalConfirm").style.display = 'flex';
    };

    if (modalStyle === 'flex') {
        return document.getElementById("ModalConfirm").style.display = 'none';
    };
}

function onTriggerModalArchive() {
    const modalStyle = document.getElementById("ModalArchive").style.display;

    if (modalStyle !== 'flex') {
        return document.getElementById("ModalArchive").style.display = 'flex';
    };

    if (modalStyle === 'flex') {
        return document.getElementById("ModalArchive").style.display = 'none';
    };
}