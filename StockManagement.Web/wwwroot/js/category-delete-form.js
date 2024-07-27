document.addEventListener('DOMContentLoaded', function () {
    // DELETE butonlarına tıklama olayı ekle
    document.querySelectorAll('.btn-delete').forEach(function (button) {
        button.addEventListener('click', function (event) {
            event.preventDefault(); // Varsayılan davranışı durdur

            const deleteUrl = button.getAttribute('href');

            Swal.fire({
                title: 'Are you sure?',
                text: 'Do you want to delete this category?',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, delete it!',
                cancelButtonText: 'No, cancel!'
            }).then((result) => {
                if (result.isConfirmed) {
                    // Kategoriyi silmek için sayfayı yönlendir
                    window.location.href = deleteUrl;
                } else {
                    Swal.fire(
                        'Cancelled',
                        'Your category is safe :)',
                        'error'
                    );
                }
            });
        });
    });
});
