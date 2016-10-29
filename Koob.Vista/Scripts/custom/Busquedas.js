function BuscarTitulo() {
    var nombre = $('#buscar').val();
    $.ajax({
        type: "GET",
        url: "/Busqueda/PorTitulo?titulo="+nombre,
        success: function (resultado) {
            window.location = '/Busqueda/PorTitulo?titulo='+nombre;
        },
        error: function () {
            alert('El libro no existe');
        }
    });
}