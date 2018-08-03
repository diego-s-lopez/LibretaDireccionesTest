

$(document).ready(function () {

    LoadUserGrid(1);
    SetBtnPageFun();
});

function SetBtnPageFun() {
    $("#btnPrevPage").click(function() {

        var page = $("#lblPage").text();
        var p = parseInt(page);
        if (p > 1) {
            LoadUserGrid(parseInt(page) - 1);
        }
    });
    $("#btnNextPage").click(function() {

        var page = $("#lblPage").text();
        LoadUserGrid(parseInt(page) + 1);
    });
}

function LoadUserGrid(pagina) {

    Get("Usuarios",
        "GetUsuarios",
        { page: pagina-1, cant: 10 },
        function(resp) {
            
            if (resp.success & resp.data.usuarios.length > 0) {

                var tabla = "<table class='table'><thead><tr>" +
                    "<th scope='col'>Nombre de Usuario</th>" +
                    "<th scope='col'>Nombre</th>" +
                    "<th scope='col'>Activo</th>" +
                    "<th scope='col'>Borrar</th>" +
                    "<th scope='col'>Editar</th>" +
                    "</tr></thead>" +
                    "<tbody>";

                for (var i = 0; i < resp.data.usuarios.length; i++) {

                    var usuario = resp.data.usuarios[i];
                    
                    var fila = "<tr><td>" + usuario.nombreUsuario + "</td>";
                    fila += "<td>" + usuario.nombre + "</td>";
                    fila += "<td>" + usuario.activo + "</td>";
                    fila += "<td> <button class='btn-danger' onclick='DeleteUsuario("+ usuario.id +", \""+ usuario.nombreUsuario +"\")'>Borrar</button> </td>";
                    fila += "<td> <button class='btn-warning'>Editar</button> </td>";
                    fila += "</tr>";

                    tabla += fila;
                }

                tabla += "</tbody></table>";

                $("#divTablaUsuarios").html(tabla);
                $("#lblPage").text(pagina);
            }
        });
}

function ChangeUserActivo(btn, idUsuario) {

    var activo = false;
    if (btn.dataset.activo === "1") {
        activo = true;
    }

    Post("Usuarios",
        "ChangeActiveUser",
        { id: idUsuario, activo: !activo },
        function(resp) {

            if (resp.success) {
                if (activo === true) {
                    btn.dataset.activo = "";
                } else {
                    btn.dataset.activo = "1";
                }


                if (activo === true) {
                    btn.innerHTML = "Activar";
                } else {
                    btn.innerHTML = "Desactivar";
                }
            } else {
                alert(resp.data);
            }
        });
}

function DeleteUsuario(idUsuario, nombre) {
    if (confirm("Desea borrar el usuario: '" + nombre+"'")) {
        Post("Usuarios", "DeleteUser", { id: idUsuario }, function(resp) {
            if (resp.success) {
                var page = $("#lblPage").text();
                LoadUserGrid(page);
            } else {
                alert(resp.data);
            }
        });
    }
}
