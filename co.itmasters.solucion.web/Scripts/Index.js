const MainMenu = document.getElementById('main-menu')
const ChkMenu = document.getElementById('chkOpenMenu')
const LblMenu = document.getElementById('LblMenu')
document.addEventListener('click', function (event) {
    if (!MainMenu.contains(event.target) && ChkMenu.checked && !LblMenu.contains(event.target)) {
        ChkMenu.click()
    }
});

