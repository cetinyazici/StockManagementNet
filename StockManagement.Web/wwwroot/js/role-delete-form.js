document.addEventListener('DOMContentLoaded', function () {
    const deleteButtons = document.querySelectorAll('.btn-role-delete');

    deleteButtons.forEach(button => {
        button.addEventListener('click', function (event) {
            event.preventDefault(); // Varsayılan link davranışını durdur

            const url = this.getAttribute('href');

            Swal.fire({
                title: 'Are you sure?',
                text: 'Do you want to delete this role?',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, delete it!',
                cancelButtonText: 'No, cancel!'
            }).then((result) => {
                if (result.isConfirmed) {
                    window.location.href = url; // Onaylandığında linki takip et
                } else {
                    Swal.fire(
                        'Cancelled',
                        'The role has not been deleted.',
                        'error'
                    );
                }
            });
        });
    });
});