$(function () {

    $('tr').click(function(e) {

        var id = $(this).attr('data-id');

        var url = "/home/edit/";

        location.href = url + id;
    });

    $('button#delete').click(function() {

        $('span.loader').removeClass('d-none');
    });

    $('button#delete').click(function() {

        $('span.loader').removeClass('d-none');

        var id = $('input#Id').val();

        var result = confirm("Are you sure you want to delete this?");

        if(result) {
            $.post("/home/delete",
                {
                    id: id
                }, function(data) {
                    location.href = "/home";
                });
        }
    });

})