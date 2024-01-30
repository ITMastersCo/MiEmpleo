/*VARIABLES GLOBALES LISTA CONTACTOS PROFESOR*/
var iCnt = 0;
var container = document.createElement("DIV");

container.setAttribute("id", "DivPrueba");
container.setAttribute("runat", "server");


/*VAIABLES GLOBALES LISTA CONTACTOS PDF*/
var iCntPdf = 0;
var containerPdf = document.createElement("DIV");
containerPdf.setAttribute("id", "DivPruebaPDF");
containerPdf.setAttribute("runat", "server");


//****************************METODO ANIMACIÓN BOTON NUEVO MENSAJE **********************************//
$(function () {
    $('.demo').click(function (e) {
        var button = $(this);
        button.addClass(button.data('animation') + ' animated');
        setTimeout(function () {
            button.removeClass(button.data('animation') + ' animated');
        }, 1000);
    })
});

$(function () {
    $('.demo').hover(function (e) {
        var button = $(this);
        button.addClass(button.data('animation') + ' animated');
        setTimeout(function () {
            button.removeClass(button.data('animation') + ' animated');
        }, 1000);
    })
});

//*************METODO PARA EL CONTADOR DE LETRAS *****************//
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
//*******************METODOS PARA COLLAPSAR LISTA DE CONTACTOS PDF**************************************//
function listaContactosMostrar() {
    document.getElementById("divListaPDF").className = "wrapper2 list-mode";
}

function listaContactosOcultar() {
    document.getElementById("divListaPDF").className = "wrapper2";
}

//*************************************FUNCION PARA COLLAPSAR PANELES DE CONTACTOS****************************//
$(document).on('click', '.panel-heading span.clickable', function (e) {
    var $this = $(this);
    if (!$this.hasClass('panel-collapsed')) {
        $this.parents('.panel').find('.panel-body').slideUp();
        $this.addClass('panel-collapsed');
        $this.find('i').removeClass('fa fa-chevron-up').addClass('fa fa-chevron-down');
        $this.find('i').attr("title", "Mostrar");

    } else {
        $this.parents('.panel').find('.panel-body').slideDown();
        $this.removeClass('panel-collapsed');
        $this.find('i').removeClass('fa fa-chevron-down').addClass('fa fa-chevron-up');
        $this.find('i').attr("title", "Ocultar");
    }
})

/********************AUTO COMPLETE PROFESOR*********************/

var ResAlumno = [""];
$(document).ready(function () {
    $('#ctl00_Main_TxtPara').autocomplete({
        minLength: 3,
        autoFocus: true,
        source: function (request, response) {
            $.ajax({
                type: "POST",
                async: false,
                url: 'Mensaje.aspx/AlumnosProfesorAutocomplete',
                data: "{Nombre:'" + request.term + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    ResAlumno = data.d;

                    response(data.d);
                }
            });
        }
    });

});

var parameter = Sys.WebForms.PageRequestManager.getInstance();

function AlumnoPro() {
    var autor = $('#ctl00_Main_TxtPara').val();
    var i = 0;
    $.each(ResAlumno, function (index, contenido) {
        if (autor == contenido) {
            i = 1;
        }
    });
    if (i != 1 && $('#ctl00_Main_TxtPara').val() != "") {
        $('#ctl00_Main_TxtPara').val(ResAlumno[0]);
        document.getElementById("btAdd").style.display = "block";
        document.getElementById("btRemove").style.display = "block";
        document.getElementById("btRemoveAll").style.display = "block";
    }
}

parameter.add_endRequest(function () {
    $('#ctl00_Main_TxtPara').autocomplete({
        minLength: 3,
        autoFocus: true,
        source: function (request, response) {
            $.ajax({
                type: "POST",
                async: false,
                url: 'Mensaje.aspx/AlumnosProfesorAutocomplete',
                data: "{Nombre:'" + request.term + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    ResAlumno = data.d;
                    response(data.d);
                }
            });
        }
    });

});

/*FUNCION ADD CONTACTOS PARA ADD BOTON PROFESOR**/
function AddContactPro() {

    var txtPara = document.getElementById('ctl00_Main_TxtPara');
    if (txtPara.value != "") {
        if (iCnt <= 100) {

            iCnt = iCnt + 1;

            $(container).append('<Label  class="input text-primary form-control"  id=tb' + iCnt + ' ' + '>' + iCnt + ' - ' + $('#ctl00_Main_TxtPara').val() + '</Label>');

            txtPara.value = "";
            document.getElementById('Titulo').style.display = "block";

            if (iCnt == 1) {
                var divSubmit = $(document.createElement('div'));
            }
            document.getElementById("main").style.display = "block";
            $('#main').append(container, divSubmit);
        }
        else {

            $(container).append('<label>Limite Alcanzado</label>');
            $('#btAdd').attr('class', 'bt-disable');
            $('#btAdd').attr('disabled', 'disabled');

        }
    }


}
/*BOTON ELIMINAR CONTACTOS PROFESOR*/
function DelContactPro() {
    if (iCnt != 0) { $('#tb' + iCnt).remove(); iCnt = iCnt - 1; }

    if (iCnt == 0) {
        $(container).empty();

        $(container).remove();
        $('#btSubmit').remove();
        $('#btAdd').removeAttr('disabled');
    }
}
/*BOTON ELIMINAR CONTACTOS PROFESOR ALL*/
function DeleteContactProAll() {

    $(container).empty();
    $(container).remove();
    $('#btSubmit').remove(); iCnt = 0;
    $('#btAdd').removeAttr('disabled');
}
/*AUTOCOMPLETE PDF*/
var ResPdf = [""];

$(document).ready(function () {
    $('#ctl00_Main_TxtParaPDF').autocomplete({
        minLength: 3,
        autoFocus: true,
        source: function (request, response) {
            $.ajax({
                type: "POST",
                async: false,
                url: 'Mensaje.aspx/MensajeAutocompletePDF',
                data: "{Nombre:'" + request.term + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    ResPdf = data.d;
                    //                            response((data.d).slice(0, 10));
                    response(data.d);
                }
            });
        }
    });

});

var parameter = Sys.WebForms.PageRequestManager.getInstance();

function AlumnoPDF() {
    var autor = $('#ctl00_Main_TxtParaPDF').val();
    var i = 0;
    $.each(ResPdf, function (index, contenido) {
        if (autor == contenido) {
            i = 1;
        }
    });
    if (i != 1 && $('#ctl00_Main_TxtParaPDF').val() != "") {
        $('#ctl00_Main_TxtParaPDF').val(ResPdf[0]);
        document.getElementById("btAddPDF").style.display = "block";
        document.getElementById("btRemovePDF").style.display = "block";
        document.getElementById("btRemoveAllPDF").style.display = "block";

    }
}

parameter.add_endRequest(function () {
    $('#ctl00_Main_TxtParaPDF').autocomplete({
        minLength: 3,
        autoFocus: true,
        source: function (request, response) {
            $.ajax({
                type: "POST",
                async: false,
                url: 'Mensaje.aspx/MensajeAutocompletePDF',
                data: "{Nombre:'" + request.term + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    ResPdf = data.d;
                    response(data.d);
                }
            });
        }
    });

});

/**BOTON ADD PDF NUEVO CONTACTO*/
function AddContactPdf() {
    var txtParaPdf = document.getElementById('ctl00_Main_TxtParaPDF');
    if (txtParaPdf.value != "") {
        if (iCntPdf <= 100) {
            iCntPdf = iCntPdf + 1;
            // Añadir label con el nombre del profesor.
            $(containerPdf).append('<Label  class="input text-primary form-control"  id=tb' + iCntPdf + ' ' + '>' + iCntPdf + ' - ' + $('#ctl00_Main_TxtParaPDF').val() + '</Label>');
            txtParaPdf.value = "";
            document.getElementById('TituloPDF').style.display = "block";
            if (iCntPdf == 1) {
                var divSubmit = $(document.createElement('div'));
            }
            document.getElementById("mainPDF").style.display = "block";
            $('#mainPDF').append(containerPdf, divSubmit);
        }
        else { //se establece un limite para añadir elementos, 100 es el limite
            $(containerPdf).append('<label>Limite Alcanzado</label>');
        }
    }
}
/*BOTON ELIMINAR CONTACTO PDF*/
function DeleteContactPdf() { // Elimina un elemento por click
    if (iCntPdf != 0) { $('#tb' + iCntPdf).remove(); iCntPdf = iCntPdf - 1; }
    if (iCntPdf == 0) {
        $(containerPdf).empty();
        $(containerPdf).remove();
        $('#btSubmit').remove();
    }
}
/*BOTON ELIMINAR CONTACTOS PDF ALL*/
function DeleteContactPdfAll() { // Elimina todos los elementos del div prueba

    $(containerPdf).empty();
    $(containerPdf).remove();
    $('#btSubmit').remove(); iCntPdf = 0;
}
/*ALERTA PARA EL ARCHIVO ADJUNTO*/
function Advertencia() {
    alert('El nombre del archivo adjunto solo puede contener numeros y letras.');
}