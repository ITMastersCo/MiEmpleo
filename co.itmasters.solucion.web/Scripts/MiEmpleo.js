function restar(n1, n2) {
    let resultado = parseInt(n2) - parseInt(n1);
    return resultado;
}
function OpenModal(nameForm,nameModal) {


    const modal = document.getElementById(nameModal)
    const bmodal = document.querySelector(".modal-body")
    document.body.style.overflow ='hidden'
    modal.style.display = 'flex';
    const form = document.querySelector("#" + nameForm)
    if (nameForm !== null)
        form.classList.remove("hidden")
    bmodal.appendChild(form);

}
function CloseModal(contentModal,nameModal) {
    const modal = document.getElementById(nameModal);
    const bmodal = modal.querySelector(".modal-body")
    const wrapperHidden = document.querySelector('#wrapperHidden');
    const ChildModal = document.getElementById(contentModal)
    ChildModal.classList.add("hidden")
    wrapperHidden.appendChild(bmodal.childNodes[0])
    document.body.style.overflow = ''
    modal.classList.add('hidden')
}
function contadorTexto(campo, cuentaCampos, limiteMaximo) {

    

    const getLengthCampo = () => {
        cuentaCampos.innerText = (`${campo.value.length < 1 ? 0 : campo.value.length } / ${limiteMaximo}`);
    }

    getLengthCampo()


    campo.addEventListener('input', e => {
        
        getLengthCampo()

        if (campo.value.length >= limiteMaximo) {
            campo.value = campo.value.slice(0, limiteMaximo)
            getLengthCampo()
        }
    })


}
    
function showNameFileUpload(input, nameFileContainer) {
    input.addEventListener('input', (e) => {
        if (input.files.length >= 0)
            nameFileContainer.innerText = e.target.files[0].name
        else
            nameFileContainer.innerText = "No has seleccionado ningun archivo"
    })
}
function eventFileUpload(input,img,func,container) {
    nput.addEventListener('input', (e) => {
        if (input.files.length >= 0)
            func(container)
            img.src = e.target.files[0].name
    })
}

function showContainer( btn , event, container){
    btn.addEventListener(event, e => {
        container.classList.remove("hidden")
    })
}

function closeModal(containerModal) {
    containerModal.remove()
}
function closeEmergente(containerEmergente) {
    const emergente = parent.document.getElementById(containerEmergente)
    console.log(emergente)
    emergente.remove();
    console.log("cerrado")

}

