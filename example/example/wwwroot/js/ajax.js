$("#ajax_form").submit(function (event) {
    event.preventDefault();

    var formData = new FormData(document.getElementById("ajax_form"));

    var form = document.getElementById('ajax_form');
    var action = form.getAttribute("action");


    $.ajax({
        type: "POST",
        url: '' + `${action}` + '',
        data: formData,
        contentType: false,
        processData: false,
        success: function (data) {

            console.log(data);

            if (data.status == "Sucesso") {
                $.toast({
                    text: data.mensagem,
                    heading: data.status,
                    icon: 'success',
                    showHideTransition: 'slide',
                    allowToastClose: true,
                    hideAfter: 3000,
                    stack: 5,
                    position: 'bottom-center',



                    textAlign: 'left',
                    loader: true,
                    loaderBg: '#0055ff',
                    beforeShow: function () { },
                    afterShown: function () { },
                    beforeHide: function () { },
                    afterHidden: function () { }
                });

                if (data.reload == true) {
                    setTimeout(function () {
                        location.reload();
                    }, 3000);
                } else {
                    setTimeout(function () {
                        window.location.assign(data.redirect);
                    }, 3000);
                }

            }
            else if (data.status == "Warning") {
                $.toast({
                    text: data.mensagem,
                    heading: data.status,
                    icon: 'warning',
                    showHideTransition: 'slide',
                    allowToastClose: true,
                    hideAfter: 3000,
                    stack: 5,
                    position: 'bottom-center',



                    textAlign: 'left',
                    loader: true,
                    loaderBg: '#0055ff',
                    beforeShow: function () { },
                    afterShown: function () { },
                    beforeHide: function () { },
                    afterHidden: function () { }
                });

            }
            else if (data.status == "Erro") {
                $.toast({
                    text: data.mensagem,
                    heading: data.status,
                    icon: 'error',
                    showHideTransition: 'slide',
                    allowToastClose: true,
                    hideAfter: 3000,
                    stack: 5,
                    position: 'bottom-center',



                    textAlign: 'left',
                    loader: true,
                    loaderBg: '#0055ff',
                    beforeShow: function () { },
                    afterShown: function () { },
                    beforeHide: function () { },
                    afterHidden: function () { }
                });

            }
        },
        error: function () {

        }
    });

});