// Declaracion de los combos existenes
function TipoCombo(tipo, filtro) {
    this.tipo = tipo
    this.filtro = filtro
}

var cmbdestino;

function CargarCombos(destino, origen, tipo) {
    cmbdestino = destino;
    var p = $("#" + origen).val();
    var con = tipo.filtro;
    PageMethods.GetLista(tipo.tipo, (con + p), CreaCombos);
}

var valFilSelec;
var valMensa;

function CargarComboSolo(destino, tipo, filtro, itemSelec, despMensa) {
    valFilSelec = itemSelec;
    valMensa = despMensa;
    cmbdestino = destino;
    var p = filtro;
    var con = tipo.filtro;
    PageMethods.GetLista(tipo.tipo, (con + p), SeleccionaCombos);
}

function SeleccionaCombos(resultado) {

    var dd = document.getElementById(cmbdestino);
    dd.options.length = 0;
    var banSelec = 0;

    if (resultado.length > 0) {

        dd.options[0] = new Option(valMensa, "-1");
        dd.selectedIndex = 0;
        dd.disabled = true;

        for (var x = 1; x < resultado.length + 1; x++) {
            if (resultado[x - 1].Id == valFilSelec) {
                $("#" + cmbdestino).append($("<option></option>").val(resultado[x - 1].Id).html(resultado[x - 1].Nombre).attr("selected", true));
            }
            else
                $("#" + cmbdestino).append($("<option></option>").val(resultado[x - 1].Id).html(resultado[x - 1].Nombre));
        }
        dd.disabled = false;
    }
    else {
        dd.options[0] = new Option("No existen registros", "-1");
        dd.selectedIndex = 0;
        dd.disabled = true;
    }
}

function CreaCombos(resultado) {
    
    var dd = document.getElementById(cmbdestino);
    dd.options.length = 0;
    
    if (resultado.length > 0) {
        
        dd.options[0] = new Option("Seleccione un elemento", "-1");
        dd.selectedIndex = 0;
        dd.disabled = true;
        
        for (var x = 1; x < resultado.length+1; x++) {
            //dd.options[x] = new Option(resultado[x-1].Nombre, resultado[x-1].Id);
            $("#" + cmbdestino).append($("<option></option>").val(resultado[x-1].Id).html(resultado[x-1].Nombre));
        }
        dd.disabled = false;
    }
    else {
        dd.options[0] = new Option("No existen registros", "-1");
        dd.selectedIndex = 0;
        dd.disabled = true;
    }
}

function LimpiaCombos(nombre) {
    var dd = document.getElementById(nombre);
    dd.options.length = 0;
    dd.options[0] = new Option("Seleccione un elemento", "-1");
    dd.selectedIndex = 0;
    dd.disabled = true;
}

function SituarPosicionInicial(nombre) {
    var dd = document.getElementById(nombre);
    dd.selectedIndex = 0;
}

function ClearCombos(nombre) {
    var dd = document.getElementById(nombre);
    dd.options.length = 0;
    dd.options[0] = new Option("Seleccione un elemento", "-1");
    dd.selectedIndex = 0;
}