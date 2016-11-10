
function EnviarInteres() {
    var codigo = $('#libro_codigo').val();
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
        success: function (resultado) {
            if (resultado == "1") {
                $('.boton-interesa').addClass("interesSi").removeClass("interesNo")
            }
            else {
                $('.boton-interesa').addClass("interesNo").removeClass("interesSi")
           
            }
        },
        error: function () {
            alert('Ocurrió un error al agregar el libro a su lista de interes');
        }
    });
}