$(document).ready(function () {
    $('#myTable').DataTable({
        language: {
            info: "_TOTAL_ records from _START_ - _END_ are shown.",
            infoEmpty: "No records to show.",
            loadingRecords: "Loading records...",
            lengthMenu: "Show _MENU_ records per page",
            zeroRecords: "No matching records found",
            search: "Search:",
            infoFiltered: "(filtered from _MAX_ total records)",
            buttons: {
                copyTitle: "Copied to clipboard.",
                copySuccess: {
                    1: "1 row copied to clipboard",
                    _: "%d rows copied to clipboard"
                },
                copy: "Copy",
                print: "Print",
            },
            paginate: {
                first: "First",
                previous: "Previous",
                next: "Next",
                last: "Last"
            },
        }
    });
});
