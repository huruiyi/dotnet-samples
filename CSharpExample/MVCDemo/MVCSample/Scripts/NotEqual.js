$.validator.addMethod('notequal', function (value, element, params) {
    return value != params['value'];
});

$.validator.unobtrusive.adapters.add("notequal", ['value'], function (options) {
    options.rules["notequal"] = {
        value: options.params.value
    };
    options.messages["notequal"] = options.message;
});