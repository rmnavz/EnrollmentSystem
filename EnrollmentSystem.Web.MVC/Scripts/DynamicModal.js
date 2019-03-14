$(function () {
    $(".loadDynamicModal").click(function (e) {
        e.preventDefault();
        debugger;
        var $buttonClicked = $(this);
        var destinationURL = $buttonClicked.attr("href");
        $.ajax({
            type: "GET",
            url: destinationURL,
            contentType: "application/json; charset=utf-8",
            data: null,
            datatype: "json",
            success: OnModalSuccess,
            error: OnModalFailure
        });
    });
});

function OnModalSuccess(response) {
    debugger;
    var options = { "backdrop": "static", keyboard: true };
    $('#dynamicModalContent').html(response);
    $('#dynamicModal').modal(options);
    $('#dynamicModal').modal('show');

    $('#dynamicModal').on('hidden.bs.modal', function () {
        location.reload();
    })

    ModalInjectForm();
}

function OnModalFailure() {
    alert("Dynamic content load failed.");
    $('#dynamicModal').modal('hide');
}

function OnModalLoading() {
    $('#dynamicModalContent .modal-body').html('<div class="row"><div class="col w-100 d-flex justify-content-center align-items-center"><div class="spinner-border"></div></div></div>');
    $('#dynamicModalContent .modal-footer').remove();
}

function ModalInjectForm() {
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
        OnModalLoading();
        $.ajax({
            type: "POST",
            url: $("#dynamicModalContent form").attr("action"),
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            datatype: "json",
            success: OnModalSuccess,
            error: OnModalFailure
        });
    });
}