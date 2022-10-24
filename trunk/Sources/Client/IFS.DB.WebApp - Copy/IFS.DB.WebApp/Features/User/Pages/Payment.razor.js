function onTriggerModalNewPayee() {
    const modalStyle = document.getElementById("ModalNewPayee").style.display;

    if (modalStyle !== 'flex') {
        return document.getElementById("ModalNewPayee").style.display = 'flex';
    };

    if (modalStyle === 'flex') {
        return document.getElementById("ModalNewPayee").style.display = 'none';
    };
}

function onSuccessModalNewPayee() {
    document.getElementById("ModalNewPayee").style.display = 'none';
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

            onTriggerModalConfirm2FA()
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

function onTriggerModalConfirm2FA() {
    const modalStyle = document.getElementById("ModalConfirm2FA").style.display;

    if (modalStyle !== 'flex') {
        return document.getElementById("ModalConfirm2FA").style.display = 'flex';
    };

    if (modalStyle === 'flex') {
        return document.getElementById("ModalConfirm2FA").style.display = 'none';
    };
}

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

function onSuccessModalConfirm2FA() {
    document.getElementById("ModalConfirm2FA").style.display = 'none';

    onTriggerModalSuccess()
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

document.getElementById("defaultOpen");

function onClickTab(evt, radioName) {
    let i, tabcontent, tablinks;

    tabcontent = document.getElementsByClassName("check");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    tablinks = document.getElementsByClassName("payments-history-header__item");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace("payments-history-header__item active", "payments-history-header__item");
    }

    document.getElementById(radioName).style.display = "flex";
    evt.currentTarget.className += " active";
}

function updatePayeeSelectorValue() {
    var select = document.getElementById('payeeSelector');
    var option = select.options[select.selectedIndex];

    document.getElementById('text').textContent = option.text;

    if (!option.value || option.value === 'clear') {
        document.getElementById('text').textContent = '-';
        document.getElementById('type').textContent = '-';
        document.getElementById('account').textContent = '-';
        document.getElementById('method').textContent = '-';
        document.getElementById('method').className = "payments-details-item__body";

        document.getElementById("details").style.display = 'flex';
        return document.getElementById("detailsSelector").style.display = 'none';
    }

    if (option.value && option.value !== 'clear') {
        document.getElementById('type').textContent = 'Domestic';

        document.getElementById('account').textContent = 'Account No.: 00256001';

        document.getElementById("details").style.display = 'none';

        document.getElementById('method').textContent = 'What does it mean?';

        document.getElementById("detailsSelector").style.display = 'flex';

        return document.getElementById('method').className += " payments-details-item__body--additional";
    }
}

updatePayeeSelectorValue();