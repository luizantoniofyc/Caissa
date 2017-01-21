function VisualizarControle(controlID, titulo, descricao, resultadoEsperado) {
    
    if (titulo === "")
        titulo = "None.";
    if (descricao === "")
        descricao = "None.";
    if (resultadoEsperado === "")
        resultadoEsperado = "None.";

    bootbox.dialog({
        title: titulo,
        message: '<div class="row">' +
                    '<div class="col-md-12">' +
                        '<div class="form-group">' +
                            '<h4>Description</h4>' +
                            '<p class="justified">' + descricao + '</p>' +
                        '</div>' +
                        '<div class="form-group">' +
                            '<h4>Expected Result</h4>' +
                            '<p class="justified">' + resultadoEsperado + '</p>' +
                        '</div>' +
                    '</div>' +
                '</div>',
        buttons: {
            'ok': {
                label: 'Ok',
                className: 'btn-primary'
            }
        },
    });
}