document.addEventListener('DOMContentLoaded', function () {
    const form = document.querySelector('#productForm2');

    form.addEventListener('submit', function (event) {
        event.preventDefault(); // Formun varsayılan şekilde gönderilmesini durdur

        // Form alanlarının değerlerini kontrol et
        const productName = form.querySelector('[name="Name"]').value.trim();
        const productPrice = form.querySelector('[name="Price"]').value.trim();
        const productStockQuantity = form.querySelector('[name="StockQuantity"]').value.trim();

        if (productName === "" || productPrice === "" || productStockQuantity === "") {
            Swal.fire({
                title: 'Warning',
                text: 'Please fill in all the required fields before submitting!',
                icon: 'warning',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'OK'
            });
            return; // Formu gönderme
        }

        // Kullanıcıdan onay al
        Swal.fire({
            title: 'Are you sure?',
            text: 'Do you want to save the changes to this product?',
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
