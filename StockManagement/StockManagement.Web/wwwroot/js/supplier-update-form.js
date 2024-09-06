document.addEventListener('DOMContentLoaded', function () {
    const form = document.querySelector('#supplierForm2');

    form.addEventListener('submit', function (event) {
        event.preventDefault(); // Formun varsayılan şekilde gönderilmesini durdur

        // Form alanlarının değerlerini kontrol et
        const supplierName = form.querySelector('[name="Name"]').value.trim();
        const supplierContactInfo = form.querySelector('[name="ContactInfo"]').value.trim();

        if (supplierName === "" || supplierContactInfo === "") {
            Swal.fire({
                title: 'Warning',
                text: 'Please fill in both the Supplier Name and Contact Info before submitting!',
                icon: 'warning',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'OK'
            });
            return; // Formu gönderme
        }

        // Kullanıcıdan onay al
        Swal.fire({
            title: 'Are you sure?',
            text: 'Do you want to save the changes to this supplier?',
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
                    'Your changes have not been saved.',
                    'error'
                );
            }
        });
    });
});
