/// <reference path="JsRegistroPqr.js" />
/*COLLAPSA LOS PANELES */

$(document).on('click', '.panel-heading span.clickable', function (e) {
    var $this = $(this);
    if (!$this.hasClass('panel-collapsed')) {
        $this.parents('.panel').find('.panel-body').slideUp();
        $this.addClass('panel-collapsed');
        $this.find('i').removeClass('fas fa-chevron-up').addClass('fas fa-chevron-down');
    } else {
        $this.parents('.panel').find('.panel-body').slideDown();
        $this.removeClass('panel-collapsed');
        $this.find('i').removeClass('fas fa-chevron-down').addClass('fas fa-chevron-up');
    }
})

/*CSS WEB CAM y FORMATO*/

Webcam.set({
    width: 270,
    height: 220,
    image_format: 'jpeg',
    jpeg_quality: 90,
    force_flash: true
});

/*FUNCION ENCIENDE LA CAMARA */
function setup() {
    Webcam.reset();
    Webcam.attach('#my_camera');
}
/*FUNCION TOMA LA FOTO LA MUESTRA EN PANTALLA Y LA GUARDA EN EL SERVIDOR*/
var n = 0;
function take_snapshot() {
    Webcam.snap(function (data_uri) {
        var imgFoto1 = document.getElementById('imgFoto1').src;
        var imgFoto2 = document.getElementById('imgFoto2').src;
        var imgFoto3 = document.getElementById('imgFoto3').src;

        if (imgFoto1 == "https://dummyimage.com/270x220/666666/ffffff") {
            document.getElementById('imgFoto1').src = data_uri;
            document.getElementById("lblsrcImg").innerHTML = data_uri;
            enviarDataUri();
        } else if (imgFoto2 == "https://dummyimage.com/270x220/666666/ffffff") {
            document.getElementById('imgFoto2').src = data_uri;
            document.getElementById("lblsrcImg").innerHTML = data_uri;
            enviarDataUri();
        } else if (imgFoto3 == "https://dummyimage.com/270x220/666666/ffffff") {
            document.getElementById('imgFoto3').src = data_uri;
            document.getElementById("lblsrcImg").innerHTML = data_uri;
            enviarDataUri();
        }
    });
}

function enviarDataUri() {
    var DataUriSrc = document.getElementById("lblsrcImg").innerHTML;
    var NombreArchivo = document.getElementById('Main_TxtRemitentePqr').value;
    var resultado = PageMethods.GuardarFoto(DataUriSrc, NombreArchivo, OnSuccessCAM);
}

function OnSuccessCAM(resultado) {
    n = n + 1;
    var node = document.createElement("LI");
    var textnode = document.createTextNode(resultado);
    node.id = "lis" + n;
    node.appendChild(textnode);
    document.getElementById("myListSrc").appendChild(node);
    LblRutaImagen.innerHTML = resultado;
    $('#divContenidoCamara').css('display', 'block');
    $('#divContenidoCamara').removeClass("classFalse", "");
}

function mouseHover() {
    $(document).ready(function () {

        /*FUNCION MUESTRA EL DIV  PARA LA CAMARA*/
        $('#imgCamera').mouseover(function () {
            $('#divAlertaInformacion').css("display", "block");
            $('#divAlertaInformacion').removeClass("alert-message-default");
            $('#divAlertaInformacion').addClass("alert-message-info");
            document.getElementById("LblMensaje").innerText = "en este espacio podra tomar una o varias fotos, recuerde que el equipo donde ejecutara el proceso debe tener una camara.";
            document.getElementById("TituloInformacion").innerHTML = "Información camara";
        });

        /*FUNCION OCULTA DIV PARA LA CAMARA */
        $('#imgCamera').mouseout(function () {
            $('#divAlertaInformacion').css("display", "none");
            document.getElementById("LblMensaje").innerHTML = "";
        });

        /*FUNCION MUESTRA DIV PARA EL ARCHIVO ADJUNTO*/
        $('#imgArchivo').mouseover(function () {
            $('#divAlertaInformacion').css("display", "block");
            $('#divAlertaInformacion').removeClass("alert-message-info");
            $('#divAlertaInformacion').removeClass("alert-message-default");
            $('#divAlertaInformacion').addClass("alert-message-warning");
            document.getElementById("LblMensaje").innerText = "En este espacio podra subir  o varias archivos adjuntos, recuerde el tipo de archivo perimitido sera WORD,EXCEL,PDF,PNG,JPEG,GIF.";
            document.getElementById("TituloInformacion").innerHTML = "Información archivo adjunto";
        });

        /*FUNCION OCULTA DIV PARA EL ARCHIVO ADJUNTO*/
        $('#imgArchivo').mouseout(function () {
            $('#divAlertaInformacion').css("display", "none");
            document.getElementById("LblMensaje").innerHTML = "";
        });

        /*FUNCION MUESTRA DIV PARA EL LIMPIAR*/
        $('#ctl00_Main_imgEraser').mouseover(function () {
            $('#divAlertaInformacion').css("display", "block");
            $('#divAlertaInformacion').removeClass("alert-message-warning");
            $('#divAlertaInformacion').removeClass("alert-message-default");
            $('#divAlertaInformacion').addClass("alert-message-danger");
            document.getElementById("LblMensaje").innerText = "Limpiara todos los datos del formulario para crear uno nuevo";
            document.getElementById("TituloInformacion").innerHTML = "Información limpiar formulario";
        });

        /*FUNCION OCULTA DIV PARA EL LIMPIAR*/
        $('#ctl00_Main_imgEraser').mouseout(function () {
            $('#divAlertaInformacion').css("display", "none");
            document.getElementById("LblMensaje").innerHTML = "";
        });

        /*FUNCION MUESTRA DIV PARA EL BOTON ENVIAR*/
        $('#imgDeleteFile').mouseover(function () {
            $('#divAlertaInformacion').css("display", "block");
            $('#divAlertaInformacion').removeClass("alert-message-danger");
            $('#divAlertaInformacion').removeClass("alert-message-default");
            $('#divAlertaInformacion').addClass("alert-message-success");
            document.getElementById("LblMensaje").innerText = "Esta opcion le permitira eliminar todos los archivos adjuntos.";
            document.getElementById("TituloInformacion").innerHTML = "Información eliminar";
        });

        /*FUNCION OCULTA DIV PARA EL BOTON ENVIAR*/
        $('#imgDeleteFile').mouseout(function () {
            $('#divAlertaInformacion').css("display", "none");
            document.getElementById("LblMensaje").innerHTML = "";
        });

    });

}
/*FUNCION MUESTRA DIV ARCHIVOS*/
function mostrarDivAAFile() {
    $("#divFileAA").css("display", "block");
}

/*FUNCION ELIMINAR FOTO*/
function Eliminarfoto() {
    var Ruta = "";
    var n = 0;
    var idCorreo = document.getElementById('ctl00_Main_HiddenIdCorreo').value;
    $('#myListSrc li').each(function () {
        var idLista = $(this).attr('id');
        n = n + 1;
        Ruta = document.getElementById(idLista).innerHTML;
        PageMethods.EliminarFoto(Ruta, idCorreo, OnSuccessDEL);
    });
    if (n == 0) {
        PageMethods.EliminarFoto(Ruta, idCorreo, OnSuccessDEL);
    }
}
function OnSuccessDEL() {
    document.getElementById('imgFoto1').src = "https://dummyimage.com/270x220/666666/ffffff";
    document.getElementById('imgFoto2').src = "https://dummyimage.com/270x220/666666/ffffff";
    document.getElementById('imgFoto3').src = "https://dummyimage.com/270x220/666666/ffffff";

    var list = document.getElementById("myListSrc");
    while (list.hasChildNodes()) {
        list.removeChild(list.firstChild);
    }
}

/*FUNCION CONTADOR DE CARACTERES*/

function ContadorLetras(idCaja, MaximoCaracteres, idDiv) {
    var max_chars = MaximoCaracteres;

    $('#max').html(max_chars);

    var chars = $('#' + idCaja).val().length;
    var diff = max_chars - chars;
    var id = idDiv.id;
    $('#' + id).html(diff);

    var Contador = document.getElementById(id).innerHTML;
    if (Contador <= 0) {
        $('#' + id).removeClass('text-succees');
        $('#' + id).addClass('text-danger');

    } else {
        $('#' + id).removeClass('text-danger');
        $('#' + id).addClass('text-succees');

    }

}
/*js carousel*/
$(".carousel.zoom").carousel().on("slide.bs.carousel", function (data) {
    var n = $(data.target).find(".item").length;
    var active = data.relatedTarget;
    if (active === undefined) {
        active = $(data.target).find(".item.active");
    } else {
        active = $(data.relatedTarget);
    }
    console.log(active);
    $(data.target).find(".item.next").removeClass("next");
    var next = $(data.target).find(".item").eq(active.index() - n + 1);
    next.addClass("next");
    $(data.target).find(".item.prev").removeClass("prev");
    var prev = $(data.target).find(".item").eq(active.index() - 1);
    prev.addClass("prev");
}).trigger("slide.bs.carousel");



/*js visbilidad true x elemento*/
function Hablitar() {
    $('#divContenidoCamara').removeClass("classFalse", "");
}

