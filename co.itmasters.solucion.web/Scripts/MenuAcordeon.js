const WrapperNav = document.getElementById('wrapper-navbar')
const IconOpenMenu = document.getElementById('IconOpenMenu');
const AccordionTitle = document.querySelectorAll('.AccordionTitle');
const AccordionTitleText = document.querySelectorAll('.AccordionTitle p');
const AccordionContent = document.querySelectorAll('.AccordionContent');
const ProfileInfo = document.getElementById('menu-profile-info')
const wrapper = document.getElementById('wrapper-menu')
const IconOpenMenuMobile = document.getElementById('OpenMenu-Mobile')
let isOpenMenu = false


IconOpenMenuMobile.addEventListener('click', () => {
    WrapperNav.classList.add('openMobile')
    IconOpenMenuMobile.classList.add('open')
    OpenMenu()
    isOpenMenu = true
})
const OpenMenu = () => {
    WrapperNav.classList.add('open')
    wrapper.classList.add('open-menu')
    AccordionTitleText.forEach(Item => {
        Item.style.display = 'block'
    })

    AccordionContent.forEach(Item => {
        Item.style.display = 'flex'
    })
    ProfileInfo.style.display = 'flex'
    return true
}
const CloseMenu = () => {

    WrapperNav.classList.remove('open')
    WrapperNav.classList.remove('openMobile')
    wrapper.classList.remove('open-menu')
    AccordionTitle.forEach(Item => {
        Item.classList.remove('open')
    })
    AccordionTitleText.forEach(Item => {
        Item.style.display = 'none'
    });
    AccordionContent.forEach(Item => {
        Item.style.display = 'none'
        Item.classList.remove('open')
    })

    ProfileInfo.style.display = 'none'
    IconOpenMenuMobile.classList.contains('open') && IconOpenMenuMobile.classList.remove('open')
    return false

}
const runAccordion = (id) => {
    const AccordionTitle = document.getElementById(`Accordion${id}Title`)
    const AccordionContent = document.getElementById(`Accordion${id}Content`);

    AccordionTitle.classList.contains('open')
        ? AccordionTitle.classList.remove('open')
        : AccordionTitle.classList.add('open')

    AccordionContent.classList.contains('open')
        ? AccordionContent.classList.remove('open')
        : AccordionContent.classList.add('open')

    !WrapperNav.classList.contains('open') && OpenMenu()

}
IconOpenMenu.addEventListener('click', () => {
    if (isOpenMenu) {
        isOpenMenu = CloseMenu(isOpenMenu)
    }
    else {
        isOpenMenu = OpenMenu(isOpenMenu)
    }
})
document.addEventListener('click', (event) => {
    if (!WrapperNav.contains(event.target)) {
        CloseMenu()
        isOpenMenu = false
    }
})