$(function () {
    $(".deleteVideo").on("click",function (e) {
        e.preventDefault();

        
        if (confirm("آیا از حذف این ویدیو مطمئن هستید؟")) {
            var button = $(this);
            var videoId = button.data("id");
            $.ajax({
                url: "/Videos/Delete/" + videoId,
                type: "POST",
                data: {
                    id: videoId,
                    __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
                },
                success: function (result) {
                    location.reload();
                },
                error: function () {
                    alert("خطا در حذف ویدیو!");
                }
            })
        };
    });
});
