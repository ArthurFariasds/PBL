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

    var esconderSenha = function (element) {
        var passwordField = element.previousElementSibling;
        var hidden = passwordField.textContent === "*****";

        if (hidden) {
            passwordField.textContent = passwordField.getAttribute("data-password");
            element.classList.replace("bx-show", "bx-hide");
        } else {
            passwordField.textContent = "*****";
            element.classList.replace("bx-hide", "bx-show");
        }
    };

    var confirma = function (usuarioId) {
        let modal = document.getElementById('deleteModal');
        let confirmLink = modal.querySelector('.confirm-delete');
        confirmLink.href = '/usuario/delete?id=' + usuarioId;
        modal.showModal();
    };

    return {
        exibirImagem: exibirImagem,
        esconderSenha: esconderSenha,
        confirma: confirma,
    }
}();

