/// <reference path="../../../Scripts/jquery-2.0.3.js" />
/// <reference path="../../../Scripts/jquery-2.0.3.intellisense.js" />

$(document).ready(function () {
    $("a[data-post]").click(function (e) {
        e.preventDefault();
        var $this = $(this);
        var message = $this.data("post");

        if (message && !confirm(message))
            return;

        $("<form>")
            .attr("method", "post")
            .attr("action", $this.attr("href"))
            .appendTo(document.body)
            .submit();
    });
});