function onClickSubmitDropdown() {
    const dropdownStyle = document.getElementById("SubmitDropdown").style.display;

    if (dropdownStyle !== "block") {
        return (document.getElementById("SubmitDropdown").style.display = "block");
    }

    if (dropdownStyle === "block") {
        return (document.getElementById("SubmitDropdown").style.display = "none");
    }
}

function onClickSignDropdown() {
    const dropdownStyle = document.getElementById("SignDropdown").style.display;

    if (dropdownStyle !== "block") {
        return (document.getElementById("SignDropdown").style.display = "block");
    }

    if (dropdownStyle === "block") {
        return (document.getElementById("SignDropdown").style.display = "none");
    }
}

function onClickSubmittedDropdown() {
    const dropdownStyle = document.getElementById("SubmittedDropdown").style.display;

    if (dropdownStyle !== "block") {
        return (document.getElementById("SubmittedDropdown").style.display = "block");
    }

    if (dropdownStyle === "block") {
        return (document.getElementById("SubmittedDropdown").style.display = "none");
    }
}

function onTriggerModalDelete() {
    const modalStyle = document.getElementById("ModalSuccess").style.display;

    if (modalStyle !== "flex") {
        return (document.getElementById("ModalSuccess").style.display = "flex");
    }

    if (modalStyle === "flex") {
        return (document.getElementById("ModalSuccess").style.display = "none");
    }
}
