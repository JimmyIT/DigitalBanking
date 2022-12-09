function updateBatchSelectorValue() {
    var select = document.getElementById('batchSelector');
    var option = select.options[select.selectedIndex];

    document.getElementById('current').textContent = option.text;

    console.log(option.value)

    if (!option.value || option.value === 'clear') {
        document.getElementById('locked').style.display = 'none'
        document.getElementById('current').textContent = '-';
        document.getElementById('access').textContent = '-';
        document.getElementById('process').textContent = '-';
        document.getElementById('saved').style.display = 'none';
        document.getElementById('default').textContent = 'Unlock batch';
        document.getElementById('default').className = "security-main-content-footer-button";
        document.getElementById('currentBody').className = "security-main-content-info-item-body";

    }

    if (option.value && option.value !== 'clear') {
        document.getElementById('locked').style.display = 'flex'

        document.getElementById('current').textContent = 'Locked';

        document.getElementById('access').textContent = 'Admin 1';

        document.getElementById('process').textContent = 'Locking';

        return document.getElementById('currentBody').className += " security-main-content-info-item-body--locked ";
    }
}

updateBatchSelectorValue();

function onTriggerModalUnlock() {
    const modalStyle = document.getElementById("ModalUnlock").style.display;

    if (modalStyle !== 'flex') {
        return document.getElementById("ModalUnlock").style.display = 'flex';
    };

    if (modalStyle === 'flex') {
        return document.getElementById("ModalUnlock").style.display = 'none';
    };
}

function onSuccessModalUnlock() {
    let passwordValue = document.getElementById("passwordUnlock").value;

    if (passwordValue === '1234') {
        document.getElementById('passwordUnlock').className = "input input--success";
        document.getElementById('passwordIconUnlock').style.display = "flex";
        document.getElementById('passwordIconUnlock').src = "/img/icons/eyeGreenIcon.svg";
        document.getElementById("inputAlertUnlock").style.display = 'flex';
        document.getElementById('inputAlertUnlock').className = "input-alert input-alert--success";
        document.getElementById("passwordUnlock").type = 'password'; 

        setTimeout(() => { 
            document.getElementById('passwordIconUnlock').src = "/img/icons/closeEyeIcon.svg";
            document.getElementById("passwordUnlock").className = 'input', 
            document.getElementById("inputAlertUnlock").style.display = 'none',
            document.getElementById("ModalUnlock").style.display = 'none',
            document.getElementById("passwordUnlock").value = '',

            successBatchSelectorValue()
        }, 2000)
        
    } else {
        document.getElementById('passwordIconUnlock').style.display = "flex";
        document.getElementById('passwordUnlock').className = "input input--error";
        document.getElementById("inputAlertUnlock").style.display = 'flex';
        document.getElementById('inputAlertUnlock').className = "input-alert input-alert--error";
        document.getElementById('passwordIconUnlock').src = "/img/icons/eyeRedIcon.svg";
        document.getElementById("passwordUnlock").type = 'password'; 
    }
}

function onClickVisiblePassword() {
    if (document.getElementById('passwordUnlock').className !== "input input--error") {

        if (document.getElementById('passwordUnlock').type === "password") {
                document.getElementById('passwordIconUnlock').src = "/img/icons/eyeIcon.svg";
                return document.getElementById("passwordUnlock").type = 'text';
        }

        if (document.getElementById('passwordUnlock').type === "text") {
            document.getElementById('passwordIconUnlock').src = "/img/icons/closeEyeIcon.svg";
            return document.getElementById("passwordUnlock").type = 'password';
        }
    } else {
        if (document.getElementById('passwordUnlock').type === "password") {
                document.getElementById('passwordIconUnlock').src = "/img/icons/openEyeRedIcon.svg";
                return document.getElementById("passwordUnlock").type = 'text';
        }

        if (document.getElementById('passwordUnlock').type === "text") {
            document.getElementById('passwordIconUnlock').src = "/img/icons/eyeRedIcon.svg";
            return document.getElementById("passwordUnlock").type = 'password';
        }
    }
}

function successBatchSelectorValue() {

        document.getElementById('locked').style.display = 'flex'

        document.getElementById('locked').src = '/img/security/unlockedIcon.svg'

        document.getElementById('current').textContent = 'Locked';

        document.getElementById('access').textContent = 'Admin 1';

        document.getElementById('process').textContent = 'Locking';

        document.getElementById('saved').style.display = 'flex';

        document.getElementById('default').textContent = 'Lock batch';

        document.getElementById('default').className += ' security-main-content-footer-button--inactive';

        return document.getElementById('currentBody').className += " security-main-content-info-item-body--success ";
}

document.getElementById("defaultOpen");

function onClickTab(evt, radioName) {
    let i, tabcontent, tablinks;

    tabcontent = document.getElementsByClassName("check");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    tablinks = document.getElementsByClassName("security-main-menu-item");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace("security-main-menu-item active", "security-main-menu-item");
    }

    document.getElementById(radioName).style.display = "block";
    evt.currentTarget.className = "security-main-menu-item active";
}

function onTriggerModalSubmit() {
    const modalStyle = document.getElementById("ModalSubmit").style.display;

    if (modalStyle !== 'flex') {
        return document.getElementById("ModalSubmit").style.display = 'flex';
    };

    if (modalStyle === 'flex') {
        return document.getElementById("ModalSubmit").style.display = 'none';
    };
}

function onSuccessModalSubmit() {
    let passwordValue = document.getElementById("passwordSubmit").value;

    if (passwordValue === '1234') {
        document.getElementById('passwordSubmit').className = "input input--success";
        document.getElementById('passwordIconSubmit').style.display = "flex";
        document.getElementById('passwordIconSubmit').src = "/img/icons/eyeGreenIcon.svg";
        document.getElementById("inputAlertSubmit").style.display = 'flex';
        document.getElementById('inputAlertSubmit').className = "input-alert input-alert--success";
        document.getElementById("passwordSubmit").type = 'password'; 

        setTimeout(() => { 
            document.getElementById('passwordIconSubmit').src = "/img/icons/closeEyeIcon.svg";
            document.getElementById("passwordSubmit").className = 'input', 
            document.getElementById("inputAlertSubmit").style.display = 'none',
            document.getElementById("ModalSubmit").style.display = 'none',
            document.getElementById("passwordSubmit").value = '',

            successSubmitValue()
        }, 2000)
        
    } else {
        document.getElementById('passwordIconSubmit').style.display = "flex";
        document.getElementById('passwordSubmit').className = "input input--error";
        document.getElementById("inputAlertSubmit").style.display = 'flex';
        document.getElementById('inputAlertSubmit').className = "input-alert input-alert--error";
        document.getElementById('passwordIconSubmit').src = "/img/icons/eyeRedIcon.svg";
        document.getElementById("passwordSubmit").type = 'password'; 
    }
}


function onClickVisiblePasswordSubmit() {
    if (document.getElementById('passwordSubmit').className !== "input input--error") {

        if (document.getElementById('passwordSubmit').type === "password") {
                document.getElementById('passwordIconSubmit').src = "/img/icons/eyeIcon.svg";
                return document.getElementById("passwordSubmit").type = 'text';
        }

        if (document.getElementById('passwordSubmit').type === "text") {
            document.getElementById('passwordIconSubmit').src = "/img/icons/closeEyeIcon.svg";
            return document.getElementById("passwordSubmit").type = 'password';
        }
    } else {
        if (document.getElementById('passwordSubmit').type === "password") {
                document.getElementById('passwordIconSubmit').src = "/img/icons/openEyeRedIcon.svg";
                return document.getElementById("passwordSubmit").type = 'text';
        }

        if (document.getElementById('passwordSubmit').type === "text") {
            document.getElementById('passwordIconSubmit').src = "/img/icons/eyeRedIcon.svg";
            return document.getElementById("passwordSubmit").type = 'password';
        }
    }
}

function successSubmitValue() {

    document.getElementById('update').style.display = 'flex'
    
    document.getElementById('input').style.display = 'none'

    document.getElementById('submit').style.display = 'none'

    document.getElementById('buttons').style.display = 'flex'

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

            successSubmitValue()
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
    let passwordValue = document.getElementById("passwordConfirm").value;

    if (passwordValue === '1234') {
        document.getElementById('passwordConfirm').className = "input input--success";
        document.getElementById('passwordIconConfirm').style.display = "flex";
        document.getElementById('passwordIconConfirm').src = "/img/icons/eyeGreenIcon.svg";
        document.getElementById("inputAlertConfirm").style.display = 'flex';
        document.getElementById('inputAlertConfirm').className = "input-alert input-alert--success";
        document.getElementById("passwordConfirm").type = 'password'; 

        setTimeout(() => { 
            document.getElementById('passwordIconConfirm').src = "/img/icons/closeEyeIcon.svg";
            document.getElementById("passwordConfirm").className = 'input', 
            document.getElementById("inputAlertConfirm").style.display = 'none',
            document.getElementById("ModalConfirm").style.display = 'none',
            document.getElementById("passwordConfirm").value = '',

            successConfirmValue()
        }, 2000)
        
    } else {
        document.getElementById('passwordIconConfirm').style.display = "flex";
        document.getElementById('passwordConfirm').className = "input input--error";
        document.getElementById("inputAlertConfirm").style.display = 'flex';
        document.getElementById('inputAlertConfirm').className = "input-alert input-alert--error";
        document.getElementById('passwordIconConfirm').src = "/img/icons/eyeRedIcon.svg";
        document.getElementById("passwordConfirm").type = 'password'; 
    }
}


function onClickVisiblePasswordConfirm() {
    if (document.getElementById('passwordConfirm').className !== "input input--error") {

        if (document.getElementById('passwordConfirm').type === "password") {
                document.getElementById('passwordIconConfirm').src = "/img/icons/eyeIcon.svg";
                return document.getElementById("passwordConfirm").type = 'text';
        }

        if (document.getElementById('passwordConfirm').type === "text") {
            document.getElementById('passwordIconConfirm').src = "/img/icons/closeEyeIcon.svg";
            return document.getElementById("passwordConfirm").type = 'password';
        }
    } else {
        if (document.getElementById('passwordConfirm').type === "password") {
                document.getElementById('passwordIconConfirm').src = "/img/icons/openEyeRedIcon.svg";
                return document.getElementById("passwordConfirm").type = 'text';
        }

        if (document.getElementById('passwordConfirm').type === "text") {
            document.getElementById('passwordIconConfirm').src = "/img/icons/eyeRedIcon.svg";
            return document.getElementById("passwordConfirm").type = 'password';
        }
    }
}

function successConfirmValue() {

    document.getElementById('send').style.display = 'block'

    document.getElementById('submit').style.display = 'none'

    document.getElementById('buttons').style.display = 'none'

    document.getElementById('confirmdata').style.display = 'block'

    document.getElementById('compled').style.display = 'none'
    
}