function BuscarTitulo() {
    var titulo = $('#titulo').val();
    $.ajax({
        type: "GET",
        url: "/Busqueda/PorTitulo?titulo=" + titulo,
        success: function (resultado) {
            window.location = '/Busqueda/PorTitulo?titulo=' + titulo;
        },
        error: function () {
            alert('El libro no existe');
        }
    });
}
function BuscarAutor() {
    var autor = $('#autor').val();
    $.ajax({
        type: "GET",
        url: "/Busqueda/PorAutor?autor="+autor,
        success: function (resultado) {
            window.location = '/Busqueda/PorAutor?autor='+autor;
        },
        error: function () {
            alert('El libro no existe');
        }
    });
}