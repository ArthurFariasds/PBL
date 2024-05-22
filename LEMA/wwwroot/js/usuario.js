$(document).ready(function () {
    
});

var usuario = function () {

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