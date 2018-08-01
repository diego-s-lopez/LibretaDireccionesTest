function Post(controller, method, data, callback) {
    $.post(controller + "/" + method,
        data,
        callback
    );
}