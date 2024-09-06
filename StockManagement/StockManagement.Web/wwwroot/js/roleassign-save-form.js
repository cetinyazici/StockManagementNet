document.addEventListener('DOMContentLoaded', function () {
    const form = document.querySelector('#assignRoleForm');

    form.addEventListener('submit', function (event) {
        event.preventDefault(); // Formun varsayılan şekilde gönderilmesini durdur

        Swal.fire({
            title: 'Are you sure?',
            text: 'Do you want to save these role assignments?',
            icon: 'question',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, save it!',
            cancelButtonText: 'No, cancel!'
        }).then((result) => {
            if (result.isConfirmed) {
                form.submit(); // Formu gerçek anlamda gönder
            } else {
                Swal.fire(
                    'Cancelled',
                    'The role assignments have not been saved.',
                    'error'
                );
            }
        });
    });
});