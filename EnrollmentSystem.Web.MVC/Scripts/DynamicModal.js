$(function () {
    $(".loadDynamicModal").click(function (e) {
        e.preventDefault();
        debugger;
        var $buttonClicked = $(this);
        var model = $buttonClicked.attr('data-model');
        var options = { "backdrop": "static", keyboard: true };
        var destinationURL = $buttonClicked.attr("href");
        $.ajax({
            type: "GET",
            url: destinationURL,
            contentType: "application/json; charset=utf-8",
            data: model,
            datatype: "json",
            success: function (data) {
                debugger;
                $('#dynamicModalContent').html(data);
                $('#dynamicModal').modal(options);
                $('#dynamicModal').modal('show');

                $("#dynamicModalContent form").on("submit", function (e) {
                    e.preventDefault();
                    debugger;
                    var formData = new FormData($("#dynamicModalContent form")[0]);
                    var fileInputs = $('input[type="file"]');
                    //Iterating through each files selected in fileInput
                    fileInputs.each(function () {
                        for (i = 0; i < this.files.length; i++) {
                            //Appending each file to FormData object
                            formData.append(this.files[i].name, this.files[i]);
                        }
                    });
                    
                    $('#dynamicModalContent .modal-body').html('<div class="row"><div class="col w-100 d-flex justify-content-center align-items-center"><div class="spinner-border"></div></div></div>');
                    $('#dynamicModalContent .modal-footer').remove();
                    $.ajax({
                        type: "POST",
                        url: $("#dynamicModalContent form").attr("action"),
                        cache: false,
                        contentType: false,
                        processData: false,
                        data: formData,
                        datatype: "json",
                        success: function (data) {
                            debugger;
                            $('#dynamicModalContent').html(data);
                            $('#dynamicModal').on('hidden.bs.modal', function () {
                                location.reload();
                            })
                        },
                        error: function () {
                            alert("Dynamic content load failed.");
                            $('#dynamicModal').modal('hide');
                        }
                    });
                });

            },
            error: function () {
                alert("Dynamic content load failed.");
                $('#dynamicModal').modal('hide');
            }
        });
    });
});

function OnModalSuccess(response) {
    $('#dynamicModalContent').html(response);
    $('#dynamicModal').on('hidden.bs.modal', function () {
        location.reload();
    })
}

function OnModalFailure() {
    alert("Dynamic content load failed.");
    $('#dynamicModal').modal('hide');
}