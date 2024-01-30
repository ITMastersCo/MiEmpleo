
function escribirLinkDimen(direcc, h, w, label) {


    var src = direcc;
    $.modal('<iframe src="' + src + '" height=" ' + h + '" width="' + w + '"style="border:1; padding=0; spacing=0 " id="Prueba" name="Prueba">', {
        //closeHTML: "<table bgcolor='RED' style='height:10px; border:5px'><tr><td></td></tr></table>",
        containerCss: {
            backgroundColor: "#FFFFFF",
            borderColor: "#FFFFFF",
            height: h,
            padding: 0,
            spacing: 0,
            width: w
        },
        onClose: OSX.close
    });


}


function escribirLink(direcc,label) {

    var src = direcc;
    $.modal('<iframe src="' + src + '" height="450" width="830" style="border:0" id="Prueba" name="Prueba">', {
    //closeHTML: "<table width='100%' style='background-image: url(../images/fondoModal1.gif)'> <tr> <td style='width: 24px'> <img src='../Images/VentanaModal.gif' style='float: left;' /> </td> <td style='color: #FFFFFF'> <b> " + label + " </b> </td><td> <img src='../Images/cancelar.gif' style='float: right; cursor:pointer; height:20px' /></td></tr></table>",
        containerCss: {
            backgroundColor: "#F7F7F7", /* Color fondo ventana emergente*/
            borderColor: "Silver",
            height: 466,
            padding: 0,
            width: 830
        },
        onClose: OSX.close
    });

}

function escribirLinkDimenDatosBasicos(direcc, h, w, label) {

    var src = direcc;
    $.modal('<iframe src="' + src + '" height=" ' + h + '" width="' + w + '" style="border:1;" id="Prueba" name="Prueba">', {
        closeHTML: "<table width='100%' style='background-image: url(../images/fondoModal1.gif)'> <tr> <td style='width: 24px'> <img src='../Images/VentanaModal2.gif' style='float: left;' /> </td> <td style='color: #266884'> <b> " + label + " </b> </td><td> <img src='../Images/Error_small.png' style='float: right; cursor:pointer;' /></td></tr></table>",
        containerCss: {
            backgroundColor: "#FFFFFF",
            borderColor: "000000",
            height: h+40,
            padding: 0,
            spacing: 0,            
            width: w
        },
        onClose: OSX.close
    });

}


var OSX =
{
    container: null,
    close: function(d) {
        var self = this;
        self.close();
        /*
        d.container.animate(
        { top: "-" + (d.container.height() + 20) }, 500, function() { self.close(); } // or $.modal.close();	
        ); */
    }
}

function CargaCombos(destino) {

    var dd = document.getElementById("Main_" + destino);
    
    dd.options.length = 0;
    dd.options[0] = new Option("Cargando...");
    dd.selectedIndex = 0;    
    
}

function ocultarGrilla() {

    $('#grilla').css('display', 'none');
    $('#datos').css('display', 'block');
}

function ocultarDetalle(){
    $('#grilla').css('display', 'block');
    $('#datos').css('display', 'none');
}

function ocultarPantalla(e){
    $('#'+e).bind('click', function(){
        var cont = document.getElementById('simplemodal-container');
        document.body.removeChild(cont);
        $('#simplemodal-container').remove();
        $('#simplemodal-overlay').remove();
    })
}


function numFormat(dec, miles, valor) {
    var num = valor, signo = 3, expr;
    var cad = "" + valor;
    var ceros = "", pos, pdec, i;
    for (i = 0; i < dec; i++)
        ceros += '0';
    pos = cad.indexOf('.')
    if (pos < 0)
        cad = cad + "." + ceros;
    else {
        pdec = cad.length - pos - 1;
        if (pdec <= dec) {
            for (i = 0; i < (dec - pdec); i++)
                cad += '0';
        }
        else {
            num = num * Math.pow(10, dec);
            num = Math.round(num);
            num = num / Math.pow(10, dec);
            cad = new String(num);
        }
    }

    pos = cad.indexOf('.')

    if (pos < 0)
        pos = cad.lentgh
    if (cad.substr(0, 1) == '-' || cad.substr(0, 1) == '+')
        signo = 4;
    if (miles && pos > signo)
        do {
        expr = /([+-]?\d)(\d{3}[\.\,]\d*)/
        cad.match(expr)
        cad = cad.replace(expr, RegExp.$1 + ',' + RegExp.$2)
    }
    while (cad.indexOf(',') > signo)

    if (dec < 0)
        cad = cad.replace(/\./, '');

    cad = cad.replace('.', 'x');
    cad = cad.replace(',', 'y');
    cad = cad.replace('x', ',');
    cad = cad.replace('y', '.');
    return cad;
}

function pintarToolTipGrupo(objeto, texto) {
    $(objeto).qtip({
        content: texto,
        position: {
            corner: {
                target: 'bottomLeft',
                tooltip: 'leftTop'
            }
        },
        style: {
            border: {
                width: 3,
                radius: 5,
                color: '#6699CC'
            },
            width: 300,
            tip: {
                corner: 'topLeft',
                color: '#6699CC',
                size: {
                    x: 20,
                    y: 8
                }
            }
        }
    });
}

function Formato(Objeto) {
    
}