$(function () {
    var postId = $("#PostId").val();
    var $publishButton = $("#publishButton");

    $publishButton.on("click", function (e) {
        e.preventDefault;
        $.ajax({
            type: "POST",
            url: "/Posts/Publish/" + postId
        })
            .done(function (response) {
                if (response === "True") {
                    $publishButton.text("Unpublish");
                }
                else {
                    $publishButton.text("Publish");
                }
            });
    });
});