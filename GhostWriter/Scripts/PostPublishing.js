$(function () {
    var publish = new Publisher(_url);
    publish.init("#publishButton");
});


function Publisher(url)
{
    var _self = this;
    var _url = url;
    var _publishButton = null;

    function _onSuccess (data) {
        if (data) {
            _publishButton.text(data.IsPublished ? "Unpublish" : "Publish");
        }
        else {
            alert("Could not publish this post");
        }
    }

    function _onError (data) {
        alert("Could not publish this post");
    }


    this._onPublish = function (e) {
        e.preventDefault;
        var _postId = $("#PostId").val();

        $.ajax(
            {
                type: "POST",
                url: _url + "/" + _postId,
                success: function (data) { _onSuccess(data); },
                error: function (data) { _onError(data); }
            });
    };

    this.init = function (publishButtonId) {
        _publishButton = $(publishButtonId);
        _publishButton.on("click", this._onPublish);
    };
}