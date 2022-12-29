function showCardsLayout() {
    document.getElementById("payeeTable").style.display = 'none';
    document.getElementById("payeeCards").style.display = 'flex';
    document.getElementById("payeeRowsButton").style.display = 'block';
    document.getElementById("payeeCardsButton").style.display = 'none';
}

function showRowsLayout() {
    document.getElementById("payeeTable").style.display = 'block';
    document.getElementById("payeeCards").style.display = 'none';
    document.getElementById("payeeRowsButton").style.display = 'none';
    document.getElementById("payeeCardsButton").style.display = 'block';
}

function onShowModalNewPayee() {
    document.getElementById("modalNewPayee").style.display = 'block';
}

function onCloseModalNewPayee() {
    document.getElementById("modalNewPayee").style.display = 'none';
}