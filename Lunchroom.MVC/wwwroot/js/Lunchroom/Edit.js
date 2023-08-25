$(document).ready(function () {

    

    LoadCarWorkshopServices()


    $("#createStudentModal form").submit(function (event) {
        event.preventDefault();

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (data) {
                toastr["success"]("Created student")
                LoadCarWorkshopServices()
            },
            error: function () {
                toastr["error"]("Something went wrong")
            }
        })
    });
    
});