var dispositivo = function () {


    var confirma = function (usuarioId) {
        let modal = document.getElementById('deleteModal');
        let confirmLink = modal.querySelector('.confirm-delete');
        confirmLink.href = '/dispositivo/delete?id=' + usuarioId;
        modal.showModal();
    };

    return {
        confirma: confirma,
    }
}();
