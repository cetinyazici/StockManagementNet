document.addEventListener('DOMContentLoaded', function () {
    const form = document.querySelector('#roleForm'); // Formun ID'sini güncelledik

    form.addEventListener('submit', function (event) {
        event.preventDefault(); // Formun varsayılan şekilde gönderilmesini durdur

        // Form alanlarının değerlerini kontrol et
        const roleName = form.querySelector('[name="RoleName"]').value.trim();

        if (roleName === "") {
            Swal.fire({
                title: 'Warning',
                text: 'Please fill in the Role Name before submitting!',
                icon: 'warning',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'OK'
            });
            return; // Formu gönderme
        }

        // Kullanıcıdan onay al
        Swal.fire({
            title: 'Are you sure?',
            text: 'Do you want to create this role?',
            icon: 'question',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, create it!',
            cancelButtonText: 'No, cancel!'
        }).then((result) => {
            if (result.isConfirmed) {
                form.submit(); // Formu gerçek anlamda gönder
            } else {
                Swal.fire(
                    'Cancelled',
                    'The role has not been created.',
                    'error'
                );
            }
        });
    });
});
