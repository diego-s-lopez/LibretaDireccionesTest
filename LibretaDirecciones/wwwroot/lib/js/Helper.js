function Post(controller, method, data, callback) {
    $.post(controller + "/" + method,
        data,
        callback
    );
}

function Get(controller, method, data, callback) {
        $.get(controller + "/" + method,
            data,
            callback
        );
}