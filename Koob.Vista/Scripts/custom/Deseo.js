function EnviarDatos(lib_codigo) {
    var codigo = lib_codigo;
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

            if (resultado == 1) {
                $('.boton-deseo').css("background-color", "#d2021f")
                $('#cuerpoMensaje').text(resultado.Data.mensaje);
            }
            else {
                $('.boton-deseo').css("background-color", "#ffffff")
                $('#cuerpoMensaje').text(resultado.Data.mensaje);
            }
        },
        error: function () {
            alert('Ocurrió un error al agregar el libro a su lista de deseos');
        }
    });
}
function verifyDe(lib_codigo) {
    var codigo = lib_codigo;
    var email = $('#usu_email').val();

    var Deseo = {
        lib_codigo: codigo,
        usu_email: email,
    };

    $.ajax({
        type: "POST",
        url: "/Deseo/verifyDeseo",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(Deseo),
        success: function (resultado) {

            if (resultado == 1) {
                $this.css("background-color", "#d2021f")
                $this.text(resultado.Data.mensaje);
            }
            else {
                $this.css("background-color", "#ffffff")
                $('#cuerpoMensaje').text(resultado.Data.mensaje);
            }
        },
        error: function () {
            alert('Ocurrió un error al agregar el libro a su lista de deseos');
        }
    });
}