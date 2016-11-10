$(document).ready(function () {

    var codigo = $('#libro_codigo').val();
    var interesado = $('#interesado_usu_email').val();
    var dueno = $('#dueno_usu_email').val();

    var Deseo = {
        lib_codigo: codigo,
        usu_email: interesado,
    };

    $.ajax({
        type: "POST",
        url: "/Deseo/verifyDeseo",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(Deseo),
        success: function (resultado) {
            if (resultado == "1") {
                $('.boton-deseo').addClass("interesSi").removeClass("interesNo")
            }
            else {
                $('.boton-deseo').addClass("interesNo").removeClass("interesSi")

            }

            var Intereses = {
                lib_codigo: codigo,
                usu_email_interesado: interesado,
                usu_email_dueño: dueno
            };

            $.ajax({
                type: "POST",
                url: "/Intereses/verifyInteres",
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
                    alert('Error verificacion ajax interes');
                }
            });

        },
        error: function () {
            alert('Error verificacion ajax deseo');
        }
    });

});