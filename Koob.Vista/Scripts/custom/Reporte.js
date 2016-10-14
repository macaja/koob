function Reportar(libCodigo) {
    var codigo = libCodigo;
    var email = $('#propietario').val();

    var Reporte = {
        lib_codigo: codigo,
        usu_email: email,
    };

    $.ajax({
        type: "POST",
        url: "/Reporte/Reportar",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(Reporte),
        success: function (resultado) {
            $('#cuerpoMensaje').text(resultado.mensaje);
            $('#mensaje').show();
        },
        error: function () {
            alert('Ocurrió un error al reportar el libro');
        }
    });
}