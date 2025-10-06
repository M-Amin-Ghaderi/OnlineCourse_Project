$(function () {
    $("#createVideoForm").on("submit", function (e) {
        e.preventDefault();

        var form = $(this);

        $.ajax({
            url: "/Videos/Create",
            type: "POST",
            data: new FormData(this),
            contentType: false,
            processData: false,
            success: function (result) {
                form[0].reset();
                location.reload();
            },
            error: function () {
                alert("خطا در افزودن ویدیو!");
            }
        });
    });
});
