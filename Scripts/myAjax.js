$(document).ready(function () {
    var links = document.getElementsByClassName("ajax-link");
    for (var i = 0; i < links.length; i++) {
        links[i].onclick = function () {
            event.preventDefault();
            var url = $(this).attr('href');
            $('#ajax-content').load(url);
           return up();
        };
    }
    function up() {
        $('html, body').animate({ scrollTop: 0 }, 500);
        return false;
    }
});