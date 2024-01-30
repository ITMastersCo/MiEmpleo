//*******************METODOS PARA COLLAPSAR LISTA DE CONTACTOS PDF**************************************//
function listaContactosMostrar() {
    document.getElementById("divListaPDF").className = "wrapper list-mode";
}

function listaContactosOcultar() {
    document.getElementById("divListaPDF").className = "wrapper";
}
/***************/
$(document).ready(function () {


    $(".readMore").click(function () {
        var This = $(this);
        $(this).next().toggle(function () {
            if (This.text() == "Read") {
                This.text("Hide")
            }
            else {
                This.text("Read")
            }
        })
    });
})