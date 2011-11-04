/// <reference path="jquery-1.6.4.js" />
$(document).ready(function () {
    $(".date").datepicker({ changeMonth: true, changeYear: true });


    $("#dialog:ui-dialog").dialog("destroy");
    $("#movie-picker-menu").removeAttr("style");
    $("#dialog-movie-picker").dialog({
        autoOpen: false,
        modal: true,
        resizable: false,
        buttons: {
            Done: function () {
                $(this).dialog("close");
            }
        }
    });

    $("#movie-picker").click(function () {
        $.ajax({
            url: rootURL("MovieAjax/GetRandomMovies"),
            type: 'POST',
            contentType: 'application/json',
            success: function (result) {
                if (result.Successful == true) {
                    $("#selected_movie").html(result.Movies[1].Name);
                    $("#dialog-movie-picker").dialog("open");
                }
                else { alert('Function: Movie Picker (Click) \r\rMessage: Unable to get movie. ' + result.Message); }
            },
            error: function () { alert('Function: Movie Picker (Click) \r\rMessage: AJAX Error, unable to complete task.'); }
        });
        return false;
    });

});

function rootURL(url) {
    var i = 4; var path = '';
    for (i = 4; i <= window.location.pathname.split('/').length; i++) { path += '../'; }
    return path += url;
};