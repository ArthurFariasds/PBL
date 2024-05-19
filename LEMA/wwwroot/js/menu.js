$(document).ready(function () {
    menu.init();
});

var menu = function () {

    var init = function () {
        let sidebar = $(".sidebar");
        let closeBtn = $("#btn");

        sidebar.addClass("open");
        menuBtnChange(sidebar, closeBtn);

        $("main").children().toggleClass("menu-aberto");
        closeBtn.on("click", function () {
            sidebar.toggleClass("open");
            menuBtnChange(sidebar, closeBtn);
            $("main").children().toggleClass("menu-aberto");
        });
    }

    var menuBtnChange = function (sidebar, closeBtn) {
        if (sidebar.hasClass("open")) {
            closeBtn.removeClass("bx-menu").addClass("bx-menu-alt-right");
        } else {
            closeBtn.removeClass("bx-menu-alt-right").addClass("bx-menu");
        }
    }

    var confirma = function () {

        let modal = document.getElementById("logoutModal");
        modal.showModal();
    }

    return {
        init: init,
        confirma: confirma,
    }
}();