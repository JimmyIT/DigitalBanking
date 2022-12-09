function onClickTooltip() {
    const tooltipStyle = document.getElementById("tooltip").style.display;

    if (tooltipStyle !== 'block') {
        document.getElementById("tooltipIcon").style.display = 'block';
        return document.getElementById("tooltip").style.display = 'block';
    };

    if (tooltipStyle === 'block') {
        document.getElementById("tooltipIcon").style.display = 'none';
        return document.getElementById("tooltip").style.display = 'none';
    };
}
