function onClickFilterIcon() {
    const filterStyle = document.getElementById("filters").style.display;

    if (filterStyle !== 'flex') {
        document.getElementById('filterIcon').className += ' activeFilter'
        return document.getElementById("filters").style.display = 'flex';
    };

    if (filterStyle === 'flex') {
        document.getElementById('filterIcon').className = 'maintenance-search-icons__filterIcon'
        return document.getElementById("filters").style.display = 'none';
    };
}