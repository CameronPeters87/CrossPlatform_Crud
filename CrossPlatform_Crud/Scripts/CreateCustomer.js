$(function() {

    $("button#create-cust").click(onCreateCustomerClick);

    function onCreateCustomerClick() {
        $("span.loader").removeClass("d-none");

        var firstname = $("input.customer-name").val();
        var surname = $("input.customer-surname").val();
        var age = $("input.customer-age").val();
        var date = $("input.customer-date").val();

        $.post("/home/add",
            {
                FirstName: firstname,
                Surname: surname,
                Hire_Date: date,
                Age: age
            }, function(data) {
                var parsed = $.parseHTML(data);

                var hasErrors = $(parsed).find('[data-valmsg-summary]')
                    .text().replace(/\n|\r/g, "").length > 0;

                if (hasErrors) {
                    $('.create-customer').html(data);
                    $("button#create-cust").click(onCreateCustomerClick);
                    $("span.loader").addClass("d-none");
                }
                else {
                    location.reload();
                }

            })
    }
})