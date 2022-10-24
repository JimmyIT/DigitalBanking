function onTriggerModalConfirm() {
    const modalStyle = document.getElementById("ModalConfirm").style.display;

    if (modalStyle !== 'flex') {
        return document.getElementById("ModalConfirm").style.display = 'flex';
    };

    if (modalStyle === 'flex') {
        return document.getElementById("ModalConfirm").style.display = 'none';
    };
}

function onSuccessModalConfirm() {
    let passwordValue = document.getElementById("password").value;

    if (passwordValue === '1234') {
        document.getElementById('password').className = "input input--success";
        document.getElementById('passwordIcon').style.display = "flex";
        document.getElementById('passwordIcon').src = "/img/icons/eyeGreenIcon.svg";
        document.getElementById("inputAlert").style.display = 'flex';
        document.getElementById('inputAlert').className = "input-alert input-alert--success";
        document.getElementById("password").type = 'password'; 

        setTimeout(() => { 
            document.getElementById('passwordIcon').src = "/img/icons/closeEyeIcon.svg";
            document.getElementById("password").className = 'input', 
            document.getElementById("inputAlert").style.display = 'none',
            document.getElementById("ModalConfirm").style.display = 'none',
            document.getElementById("password").value = '',

            onTriggerModalSuccess()
        }, 2000)
        
    } else {
        document.getElementById('passwordIcon').style.display = "flex";
        document.getElementById('password').className = "input input--error";
        document.getElementById("inputAlert").style.display = 'flex';
        document.getElementById('inputAlert').className = "input-alert input-alert--error";
        document.getElementById('passwordIcon').src = "/img/icons/eyeRedIcon.svg";
        document.getElementById("password").type = 'password'; 
    }
}

function onClickVisiblePassword() {
    if (document.getElementById('password').className !== "input input--error") {

        if (document.getElementById('password').type === "password") {
                document.getElementById('passwordIcon').src = "/img/icons/eyeIcon.svg";
                return document.getElementById("password").type = 'text';
        }

        if (document.getElementById('password').type === "text") {
            document.getElementById('passwordIcon').src = "/img/icons/closeEyeIcon.svg";
            return document.getElementById("password").type = 'password';
        }
    } else {
        if (document.getElementById('password').type === "password") {
                document.getElementById('passwordIcon').src = "/img/icons/openEyeRedIcon.svg";
                return document.getElementById("password").type = 'text';
        }

        if (document.getElementById('password').type === "text") {
            document.getElementById('passwordIcon').src = "/img/icons/eyeRedIcon.svg";
            return document.getElementById("password").type = 'password';
        }
    }
}

function onTriggerModalSuccess() {
    const modalStyle = document.getElementById("ModalSuccess").style.display;

    if (modalStyle !== 'flex') {
        return document.getElementById("ModalSuccess").style.display = 'flex';
    };

    if (modalStyle === 'flex') {
        return document.getElementById("ModalSuccess").style.display = 'none';
    };
}