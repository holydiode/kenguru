$(document).ready(function () {
    var links = document.getElementsByClassName("ajax-link");
    for (var i = 0; i < links.length; i++) {
        links[i].onclick = function () {
            $('#loading').show();
            event.preventDefault();
            var url = $(this).attr('href');
            $('#ajax-content').load(url);
            return up();
        };
    }
    links = document.getElementsByClassName("parametr");
    for (i = 0; i < links.length; i++) {
        links[i].onclick = function () {
            $('#loading').show();
            event.preventDefault();
            var url = $(this).attr('href');
            $('#ajax-content').load(url);
            var oldSelect = document.getElementsByClassName("parametr select")[0];
            if (oldSelect === undefined || oldSelect != this) {
                if (oldSelect !== undefined) {
                    oldSelect.classList.remove("select");
                    oldSelect.textContent = oldSelect.textContent.substring(0, oldSelect.textContent.length - 2);
                }
                this.classList.add("select");
                this.textContent += " ▼";
            }
            else {
                if (oldSelect.textContent.split(" ").pop() == "▼") {
                    oldSelect.textContent = oldSelect.textContent.replace(" ▼", "");
                    oldSelect.textContent += " ▲";
                }
                else {
                    oldSelect.textContent = oldSelect.textContent.replace(" ▲", "");
                    oldSelect.textContent += " ▼";
                }
            }
            $(this).attr("href", replaceSortBy($(this).attr('href'), getNewSortBy(findSortBy($(this).attr('href')))));
        };
    }

    $('#ajax-content').ready(function () {
        $('#loading').hide();
    });

});


function findSortBy(query) {
    var words = query.split(/\?|=/);
    for (var i = 0; i < words.length; i++)
        if (words[i].indexOf('sortBy') != -1)
            return words[i + 1];
}

function getNewSortBy(oldSortBy) {
    if (oldSortBy < 10)
        return oldSortBy % 2 + 1;
    else if (oldSortBy < 20)
        return (oldSortBy % 10) % 2 + 11;
    else if (oldSortBy < 30)
        return (oldSortBy % 20) % 2 + 21;
    else if (oldSortBy < 40)
        return (oldSortBy % 30) % 2 + 31;
}

function replaceSortBy(query, newValue) {
    return query.replace('sortBy=' + findSortBy(query), 'sortBy=' + newValue);
}

function up() {
    $('html, body').animate({ scrollTop: 0 }, 200);
    return false;
}

 