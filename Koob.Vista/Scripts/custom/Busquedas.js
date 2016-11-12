function BuscarTitulo() {
    var titulo = $('#titulo').val();
    if (titulo === '') {
        alert('Debe ingresar un valor en el campo de busqueda por titulo');
    }
    else {
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
    
}
function BuscarAutor() {
    var autor = $('#autor').val();    
    if (autor === '') {
        alert('Debe ingresar un valor en el campo de busqueda por autor');
    }
    else {
        $.ajax({
            type: "GET",
            url: "/Busqueda/PorAutor?autor=" + autor,
            success: function (resultado) {
                window.location = '/Busqueda/PorAutor?autor=' + autor;
            },
            error: function () {
                alert('El libro no existe');
            }
        });
    }

}
function BuscarCategoria() {
    var categoria = $('#categoria').val();    
    $.ajax({
        type: "GET",
        url: "/Busqueda/PorCategoria?categoria=" + categoria,
        success: function (resultado) {
            window.location = '/Busqueda/PorCategoria?categoria=' + categoria;            
        },
        error: function () {
            alert('El libro no existe');
        }
    });
}
