$(document).ready(function () {
    $("input[type='text']").each(function () {
        $(this).keydown(function (e) {
            if (e.keyCode == 39) {
                if ($(this).parent().next().length > 0)
                    $(this).parent().next().children()[0].focus();
            }
            else if (e.keyCode == 37) {
                if ($(this).parent().prev().length > 0)
                    $(this).parent().prev().children()[0].focus();
            }
        });
    });
});

function tabular(e, obj) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla != 13) return;
    frm = obj.form;
    for (i = 0; i < frm.elements.length; i++)
        if (frm.elements[i] == obj) {
            if (i == frm.elements.length - 1) i = -1;
            break
        }
    frm.elements[i + 1].focus();
    return false;
}

var keyCode;
function tecla(e) {
    if (window.event) keyCode = window.event.keyCode;
    else if (e) keyCode = e.which;
    alert(keyCode)
}

/****************validacion nota*****************/

function ValidacionNota(val, id) {
    var NotaValida = false;
    var NotaMax = parseInt(document.getElementById("ctl00_Main_LblNotaMaxNumero").value);
    var NotaMin = parseInt(document.getElementById("ctl00_Main_LblNotaMinNumero").value);

    if (val != "" && val != null) {
        if ((val >= NotaMin && val <= NotaMax)) {
            NotaValida = true;
        }
    }
    if (val == "") {
        NotaValida = true;
    }
    if (NotaValida == true)
        document.getElementById(id).value = val;
    else {
        document.getElementById(id).value = "";
        document.getElementById(id).focus();
    }
}

/*****************validacion solo numeros **************************/


function soloNumeros(e) {
    var key = window.Event ? e.which : e.keyCode
    return (key >= 48 && key <= 57)
}