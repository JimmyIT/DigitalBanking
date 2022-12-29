function onTriggerModalSignOff() {
    const modalStyle = document.getElementById("ModalSignOff").style.display;

    if (modalStyle !== 'flex') {
        return document.getElementById("ModalSignOff").style.display = 'flex';
    };

    if (modalStyle === 'flex') {
        return document.getElementById("ModalSignOff").style.display = 'none';
    };
}

function onSuccessModalSignOff() {
    let passwordValue = document.getElementById("passwordSignOff").value;

    if (passwordValue === '1234') {
        document.getElementById('passwordSignOff').className = "input input--success";
        document.getElementById('passwordIconSignOff').style.display = "flex";
        document.getElementById('passwordIconSignOff').src = "/img/icons/eyeGreenIcon.svg";
        document.getElementById("inputAlertSignOff").style.display = 'flex';
        document.getElementById('inputAlertSignOff').className = "input-alert input-alert--success";
        document.getElementById("passwordSignOff").type = 'password'; 

        setTimeout(() => { 
            document.getElementById('passwordIconSignOff').src = "/img/icons/closeEyeIcon.svg";
            document.getElementById("passwordSignOff").className = 'input', 
            document.getElementById("inputAlertSignOff").style.display = 'none',
            document.getElementById("ModalSignOff").style.display = 'none',
            document.getElementById("passwordSignOff").value = '',

            onTriggerModalSignOffConfirm()
        }, 2000)
        
    } else {
        document.getElementById('passwordIconSignOff').style.display = "flex";
        document.getElementById('passwordSignOff').className = "input input--error";
        document.getElementById("inputAlertSignOff").style.display = 'flex';
        document.getElementById('inputAlertSignOff').className = "input-alert input-alert--error";
        document.getElementById('passwordIconSignOff').src = "/img/icons/eyeRedIcon.svg";
        document.getElementById("passwordSignOff").type = 'password'; 
    }
}

function onClickVisiblePasswordSignOff() {
    if (document.getElementById('passwordSignOff').className !== "input input--error") {

        if (document.getElementById('passwordSignOff').type === "password") {
                document.getElementById('passwordIconSignOff').src = "/img/icons/eyeIcon.svg";
                return document.getElementById("passwordSignOff").type = 'text';
        }

        if (document.getElementById('passwordSignOff').type === "text") {
            document.getElementById('passwordIconSignOff').src = "/img/icons/closeEyeIcon.svg";
            return document.getElementById("passwordSignOff").type = 'password';
        }
    } else {
        if (document.getElementById('passwordSignOff').type === "password") {
                document.getElementById('passwordIconSignOff').src = "/img/icons/openEyeRedIcon.svg";
                return document.getElementById("passwordSignOff").type = 'text';
        }

        if (document.getElementById('passwordSignOff').type === "text") {
            document.getElementById('passwordIconSignOff').src = "/img/icons/eyeRedIcon.svg";
            return document.getElementById("passwordSignOff").type = 'password';
        }
    }
}

function onTriggerModalSignOffConfirm() {
    const modalStyle = document.getElementById("ModalSignOffConfirm").style.display;

    if (modalStyle !== 'flex') {
        return document.getElementById("ModalSignOffConfirm").style.display = 'flex';
    };

    if (modalStyle === 'flex') {
        return document.getElementById("ModalSignOffConfirm").style.display = 'none';
    };
}

function onTriggerModalReject() {
    const modalStyle = document.getElementById("ModalReject").style.display;

    if (modalStyle !== 'flex') {
        return document.getElementById("ModalReject").style.display = 'flex';
    };

    if (modalStyle === 'flex') {
        return document.getElementById("ModalReject").style.display = 'none';
    };
}

function onSuccessModalReject() {
    let passwordValue = document.getElementById("passwordReject").value;

    if (passwordValue === '1234') {
        document.getElementById('passwordReject').className = "input input--success";
        document.getElementById('passwordIconReject').style.display = "flex";
        document.getElementById('passwordIconReject').src = "/img/icons/eyeGreenIcon.svg";
        document.getElementById("inputAlertReject").style.display = 'flex';
        document.getElementById('inputAlertReject').className = "input-alert input-alert--success";
        document.getElementById("passwordReject").type = 'password'; 

        setTimeout(() => { 
            document.getElementById('passwordIconReject').src = "/img/icons/closeEyeIcon.svg";
            document.getElementById("passwordReject").className = 'input', 
            document.getElementById("inputAlertReject").style.display = 'none',
            document.getElementById("ModalReject").style.display = 'none',
            document.getElementById("passwordReject").value = '',

            onTriggerModalRejectConfirm()
        }, 2000)
        
    } else {
        document.getElementById('passwordIconReject').style.display = "flex";
        document.getElementById('passwordReject').className = "input input--error";
        document.getElementById("inputAlertReject").style.display = 'flex';
        document.getElementById('inputAlertReject').className = "input-alert input-alert--error";
        document.getElementById('passwordIconReject').src = "/img/icons/eyeRedIcon.svg";
        document.getElementById("passwordReject").type = 'password'; 
    }
}

function onClickVisiblePasswordReject() {
    if (document.getElementById('passwordReject').className !== "input input--error") {

        if (document.getElementById('passwordReject').type === "password") {
                document.getElementById('passwordIconReject').src = "/img/icons/eyeIcon.svg";
                return document.getElementById("passwordReject").type = 'text';
        }

        if (document.getElementById('passwordReject').type === "text") {
            document.getElementById('passwordIconReject').src = "/img/icons/closeEyeIcon.svg";
            return document.getElementById("passwordReject").type = 'password';
        }
    } else {
        if (document.getElementById('passwordReject').type === "password") {
                document.getElementById('passwordIconReject').src = "/img/icons/openEyeRedIcon.svg";
                return document.getElementById("passwordReject").type = 'text';
        }

        if (document.getElementById('passwordReject').type === "text") {
            document.getElementById('passwordIconReject').src = "/img/icons/eyeRedIcon.svg";
            return document.getElementById("passwordReject").type = 'password';
        }
    }
}

function onTriggerModalRejectConfirm() {
    const modalStyle = document.getElementById("ModalRejectConfirm").style.display;

    if (modalStyle !== 'flex') {
        return document.getElementById("ModalRejectConfirm").style.display = 'flex';
    };

    if (modalStyle === 'flex') {
        return document.getElementById("ModalRejectConfirm").style.display = 'none';
    };
}