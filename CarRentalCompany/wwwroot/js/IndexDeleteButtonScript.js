
$(function () {

    $('#deleteBtn').click(function (e) {
        swal({
            title: "Are you sure?",
            buttons: true,
            dangerMode: flase
        }).then((confirm) => {
            if (confirm) {
                var btn = $(this);
                var id = btn.data("id");
                $('#recordid').val(id);
                $('#deleteFrom').submit();
            }
        });
    });
});
