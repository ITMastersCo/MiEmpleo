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

/*js para lista y tabla del historial*/
$(document).ready(function () {
    $('#list').click(function (event) { event.preventDefault(); $('#products .item').addClass('list-group-item'); });
    $('#grid').click(function (event) { event.preventDefault(); $('#products .item').removeClass('list-group-item'); $('#products .item').addClass('grid-group-item'); });
});

/*JS PARA LOS DIFERENES ESTADOS DE LOS TABS*/
$(document).ready(function () {

    $(".filter-button").click(function () {
        var value = $(this).attr('data-filter');

        if (value == "all") {
            //$('.filter').removeClass('hidden');
            $('.filter').show('1000');
        }
        else {
            //            $('.filter[filter-item="'+value+'"]').removeClass('hidden');
            //            $(".filter").not('.filter[filter-item="'+value+'"]').addClass('hidden');
            $(".filter").not('.' + value).hide('3000');
            $('.filter').filter('.' + value).show('3000');

        }
    });

    if ($(".filter-button").removeClass("active")) {
        $(this).removeClass("active");
    }
    $(this).addClass("active");

});

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
/*Funcion para confirmar en el boton enviar*/
function EnviarConfirm() {
    var txtRespuesta = document.getElementById('ctl00_Main_txtRespuesta').value;
    if (txtRespuesta != "") {
        alert("Recuerde que despues de digitar el mensaje de respuesta se cerrara la correspondencia.");
    }
}

