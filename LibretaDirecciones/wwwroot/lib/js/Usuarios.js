

$(document).ready(function () {

    $("#usuario_Activo").change(function() {
        if (this.checked) {
            ChangeUserActivo(1, false);
        } else {
            ChangeUserActivo(1, true);
        }
    });
});


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