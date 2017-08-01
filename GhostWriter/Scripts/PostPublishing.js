$(function () {
    var publish = new Publisher(_url);
    publish.init("#publishButton");
});

function Publisher(url)
{
    var _self = this;
    var _url = url;
    var _publishButton = null;

    this.init = function (publishButtonId) {
        _publishButton = $(publishButtonId);
        _publishButton.on("click", this._onPublish);
    };

    this._onPublish = function (e) {
        e.preventDefault;
        var _postId = $("#PostId").val();

        $.ajax(
            {
                type: "POST",
                url: _url + "/" + _postId,
                success: function (data) { _self._onSuccess(data); },
                error: function (data) { _self._onError(data); }
            });
    };

    this._onSuccess = function (data) {
        if (data) {
            _publishButton.text(data.IsPublished ? "Unpublish" : "Publish");
        }
        else {
            alert("Could not publish this post");
        }
    };

    this._onError = function (data) {
        alert("Could not publish this post");
    };

}