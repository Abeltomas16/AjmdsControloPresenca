$.validator.setDefaults({

    highlight: function (element) {

        $(element)
            .closest()
            .find('input,label,select,textarea,span')
            .addClass('is-invalid')
    },
    unhighlight: function (element) {

        $(element)
            .closest()
            .find('input,label,select,textarea,span')
            .removeClass('is-invalid')
    }
})