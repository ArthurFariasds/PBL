function formatarTelefone() {
    var telefoneInput = document.getElementById('Telefone');

    telefoneInput.addEventListener('input', function (e) {
        var input = e.target.value.replace(/\D/g, '');
        var length = input.length;
        var formattedInput = '';

        if (length > 11) {
            input = input.substring(0, 11);
            length = input.length;
        }

        if (length <= 2) {
            formattedInput = '(' + input;
        } else if (length <= 6) {
            formattedInput = '(' + input.substring(0, 2) + ') ' + input.substring(2);
        } else if (length <= 10) {
            formattedInput = '(' + input.substring(0, 2) + ') ' + input.substring(2, 6) + '-' + input.substring(6, 10);
        } else if (length <= 11) {
            formattedInput = '(' + input.substring(0, 2) + ') ' + input.substring(2, 7) + '-' + input.substring(7, 11);
        }

        e.target.value = formattedInput;
    });
}

var empresa = function () {
    var exibirImagem = function () {
        var oFReader = new FileReader();
        oFReader.readAsDataURL(document.getElementById("Imagem").files[0]);
        oFReader.onload = function (oFREvent) {
            document.getElementById("imgPreview").src = oFREvent.target.result;
        };
    }

    return {
        exibirImagem: exibirImagem,
    }
}();

document.addEventListener("DOMContentLoaded", function () {
    formatarTelefone();
});
