function EnviarDatos(libCodigo) {
    var codigo = libCodigo;
    var email = $('#usu_email').val();

    var Deseo = {
        lib_codigo: codigo,
        usu_email: email,
    };

    $.ajax({
        type: "POST",
        url: "/Deseo/ingresarDeseo",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(Deseo),
        success: function (resultado) {
            $('.glyphicon glyphicon-heart').css("color", "red")
            $('#cuerpoMensaje').text(resultado.mensaje);
            $('#mensaje').show();
        },
        error: function () {
            alert('Ocurrió un error al agregar el libro a su lista de deseos');
        }
    });
}