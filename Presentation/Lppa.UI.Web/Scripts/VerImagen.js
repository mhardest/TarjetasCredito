function readURLDni(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        document.getElementById('Dni').style.display = 'block';

        reader.onload = function (e) {
            $('#Dni')
                .attr('src', e.target.result)
                .width(400)
                .height(200);
        };

        reader.readAsDataURL(input.files[0]);
    }
}

function readURLFirma(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        document.getElementById('Firma').style.display = 'block';

        reader.onload = function (e) {
            $('#Firma')
                .attr('src', e.target.result)
                .width(400)
                .height(200);
        };
        reader.readAsDataURL(input.files[0]);
    }
}