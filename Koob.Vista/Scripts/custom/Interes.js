function EnviarInteres(libCodigo) {
    var codigo = libCodigo;
    var interesado = $('#interesado_usu_email').val();
    var dueno = $('#dueno_usu_email').val();

    var Intereses = {
        lib_codigo: codigo,
        usu_email_interesado: interesado,
        usu_email_dueño: dueno
    };

    $.ajax({
        type: "POST",
        url: "/Intereses/ingresarInteres",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(Intereses),
        success: function () {
            $('.glyphicon glyphicon-heart').css("color", "red")
            $('#cuerpoMensaje').text(resultado.Data.mensaje);
        },
        error: function () {
            alert('Ocurrió un error al agregar el libro a su lista de interes');
        }
    });
}