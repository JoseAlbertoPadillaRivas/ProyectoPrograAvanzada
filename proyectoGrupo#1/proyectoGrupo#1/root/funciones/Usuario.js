function ConsultarIdentificacion() {

    let identificacion = $("#Cedula").val();

    if (identificacion.length >= 9) {
        $.ajax({
            type: 'GET',
            url: 'https://apis.gometa.org/cedulas/' + identificacion,
            dataType: 'json',
            success: function (data) {
                $("#Nombre").val(data.nombre);
            }
        });
    }
    else {
        $("#Nombre").val("");
    }
}