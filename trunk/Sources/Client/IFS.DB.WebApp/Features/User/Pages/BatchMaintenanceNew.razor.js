function onFilledForm() {
    if (document.getElementById('reference').value &&
        document.getElementById('account').value &&
        document.getElementById('account').value !== 'Select an Account' &&
        document.getElementById('amount').value &&
        document.getElementById('date').value &&
        document.getElementById('narrative').value &&
        document.getElementById('credit').value) {
            document.getElementById('detailsButton').disabled = false
            document.getElementById('detailsButton').className = 'batch-details-footer__button'
    } else {
            document.getElementById('detailsButton').disabled = true
            document.getElementById('detailsButton').className = 'batch-details-footer__button batch-details-footer__button--inactive'
    }
}

function onSubmitButton() {
    document.getElementById('left').className += ' batch-main__left--inactive'
    document.getElementById('right').className += ' batch-main__right--active'

    document.getElementById('step1').className += ' batch-details-header-step--inactive'
    document.getElementById('step2').className = 'batch-items-header-step'

    document.getElementById('itemsHeaderButton').className = 'batch-items-header__button'

    document.getElementById('headerDesctiption').style.display = 'none'
    document.getElementById('detailsButton').style.display = 'none'
    document.getElementById('itemsHeaderButton').style.display = 'block'
    document.getElementById('card').style.display = 'block'
    document.getElementById('editButton').style.display = 'block'

    document.getElementById('reference').style.display = 'none'
    document.getElementById('account').style.display = 'none'
    document.getElementById('amount').style.display = 'none'
    document.getElementById('date').style.display = 'none'
    document.getElementById('narrative').style.display = 'none'
    document.getElementById('credit').style.display = 'none'

    document.getElementById('referenceText').textContent = document.getElementById('reference').value
    document.getElementById('accountText').textContent = document.getElementById('account').value
    document.getElementById('amountText').textContent = document.getElementById('amount').value
    document.getElementById('dateText').textContent = document.getElementById('date').value
    document.getElementById('narrativeText').textContent = document.getElementById('narrative').value
    document.getElementById('creditText').textContent = document.getElementById('credit').value
}

function onEditButton() {
    document.getElementById('left').className = 'batch-main__left'
    document.getElementById('right').className = 'batch-main__right'

    document.getElementById('step2').className += ' batch-details-header-step--inactive'
    document.getElementById('step1').className = 'batch-items-header-step'

    document.getElementById('itemsHeaderButton').className += ' batch-items-header__button--inactive'

    document.getElementById('itemsHeaderButton').childNodes[0].src = '/img/icons/addInactiveIcon.svg'
    
    document.getElementById('saveButton').style.display = 'block'
    document.getElementById('editButton').style.display = 'none'

    document.getElementById('referenceText').style.display = 'none'
    document.getElementById('accountText').style.display = 'none'
    document.getElementById('amountText').style.display = 'none'
    document.getElementById('dateText').style.display = 'none'
    document.getElementById('narrativeText').style.display = 'none'
    document.getElementById('creditText').style.display = 'none'

    document.getElementById('reference').style.display = 'block'
    document.getElementById('account').style.display = 'block'
    document.getElementById('amount').style.display = 'block'
    document.getElementById('date').style.display = 'block'
    document.getElementById('narrative').style.display = 'block'
    document.getElementById('credit').style.display = 'block'

    document.getElementById('cardSum').className += ' batch-items-card-header__sum--inactive'
    document.getElementById('cardType').className += ' batch-items-card-header__type--inactive'
    document.getElementById('cardLabel').className += ' batch-items-card-header__label--inactive'
}

function onSaveButton() {
    document.getElementById('left').className += ' batch-main__left--inactive'
    document.getElementById('right').className += ' batch-main__right--active'

    document.getElementById('step1').className += ' batch-details-header-step--inactive'
    document.getElementById('step2').className = 'batch-items-header-step'

    document.getElementById('itemsHeaderButton').className = 'batch-items-header__button'

    document.getElementById('itemsHeaderButton').childNodes[0].src = '/img/icons/add.svg'

    document.getElementById('headerDesctiption').style.display = 'none'
    document.getElementById('itemsHeaderButton').style.display = 'block'
    document.getElementById('card').style.display = 'block'
    document.getElementById('saveButton').style.display = 'none'
    document.getElementById('editButton').style.display = 'block'

    document.getElementById('reference').style.display = 'none'
    document.getElementById('account').style.display = 'none'
    document.getElementById('amount').style.display = 'none'
    document.getElementById('date').style.display = 'none'
    document.getElementById('narrative').style.display = 'none'
    document.getElementById('credit').style.display = 'none'

    document.getElementById('referenceText').style.display = 'block'
    document.getElementById('accountText').style.display = 'block'
    document.getElementById('amountText').style.display = 'block'
    document.getElementById('dateText').style.display = 'block'
    document.getElementById('narrativeText').style.display = 'block'
    document.getElementById('creditText').style.display = 'block'

    document.getElementById('cardSum').className = 'batch-items-card-header__sum'
    document.getElementById('cardType').className = 'batch-items-card-header__type'
    document.getElementById('cardLabel').className = 'batch-items-card-header__label'
}

function onClickCard() {
    console.log(document.getElementById('card').childNodes)

    const cardStyle = document.getElementById("cardContent").style.display;

    if (cardStyle !== 'block' && cardStyle) {
        document.getElementById("cardHeaderIcon").style.display = 'block';
        document.getElementById("cardHeaderInfo").style.display = 'none';
        return document.getElementById("cardContent").style.display = 'block';
    };

    if (cardStyle === 'block' || !cardStyle) {
        document.getElementById("cardHeaderIcon").style.display = 'none';
        document.getElementById("cardHeaderInfo").style.display = 'flex';
        return document.getElementById("cardContent").style.display = 'none';
    };
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