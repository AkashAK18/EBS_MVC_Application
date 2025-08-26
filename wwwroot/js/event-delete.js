$(document).ready(function () {
    $(".delete-btn").on("click", function (e) {
        e.preventDefault();

        var eventId = $(this).data("id");
        var $modal = $("#deleteModal");
        var $modalContent = $("#deleteModalContent");

        $.ajax({
            url: "/Admin/Event/DeletePartial/" + eventId,
            type: "GET",
            success: function (response) {
                $modalContent.html(response);
                var modalInstance = bootstrap.Modal.getOrCreateInstance($modal[0]);
                modalInstance.show();
            },
            error: function (xhr, status, error) {
                console.error("Error loading delete modal:", error);
                $modalContent.html(
                    '<div class="modal-body text-danger">' +
                    '<p><strong>Error:</strong> Unable to load delete confirmation.</p>' +
                    '</div>'
                );
                var modalInstance = bootstrap.Modal.getOrCreateInstance($modal[0]);
                modalInstance.show();
            }
        });
    });
});
