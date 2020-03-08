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

            var sortBy = findSortBy(url);

            if (oldSelect === undefined)
                this.classList.add("select");
            else if (oldSelect != this) {
                oldSelect.classList.remove("select");
                this.classList.add("select");
                oldSelect.textContent = oldSelect.textContent.substring(0, oldSelect.textContent.length - 2);
                $(oldSelect).attr("href", replaceSortBy($(oldSelect).attr('href'), Math.floor(findSortBy($(oldSelect).attr('href')) / 10) * 10 + 1));
            }
            else
                this.textContent = this.textContent.substring(0, this.textContent.length - 2);
            $(this).attr("href", replaceSortBy(url, getNewSortBy(sortBy)));
            if (sortBy % 10 == 1)
                this.textContent += " ▼";
            else
                this.textContent += " ▲";

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
    if (oldSortBy % 10 == 2)
        return Math.floor(oldSortBy / 10) * 10 + 1;
    else
        return Math.floor(oldSortBy / 10) * 10 + 2;
}

function replaceSortBy(query, newValue) {
    return query.replace('sortBy=' + findSortBy(query), 'sortBy=' + newValue);
}

function up() {
    $('html, body').animate({ scrollTop: 0 }, 200);
    return false;
}

