document.addEventListener('DOMContentLoaded', function () {
    const form = document.querySelector('#productForm'); // Formun ID'sini güncelledik

    form.addEventListener('submit', function (event) {
        event.preventDefault(); // Formun varsayılan şekilde gönderilmesini durdur

        // Form alanlarının değerlerini kontrol et
        const productName = form.querySelector('[name="Product.Name"]').value.trim();
        const productPrice = form.querySelector('[name="Product.Price"]').value.trim();
        const productStockQuantity = form.querySelector('[name="Product.StockQuantity"]').value.trim();

        if (productName === "") {
            Swal.fire({
                title: 'Warning',
                text: 'Please fill in the Product Name before submitting!',
                icon: 'warning',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'OK'
            });
            return; // Formu gönderme
        }

        if (productPrice === "") {
            Swal.fire({
                title: 'Warning',
                text: 'Please fill in the Product Price before submitting!',
                icon: 'warning',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'OK'
            });
            return; // Formu gönderme
        }

        if (productStockQuantity === "") {
            Swal.fire({
                title: 'Warning',
                text: 'Please fill in the Product Stock Quantity before submitting!',
                icon: 'warning',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'OK'
            });
            return; // Formu gönderme
        }

        // Kullanıcıdan onay al
        Swal.fire({
            title: 'Are you sure?',
            text: 'Do you want to save this product?',
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
                    'Your product has not been saved.',
                    'error'
                );
            }
        });
    });
});
