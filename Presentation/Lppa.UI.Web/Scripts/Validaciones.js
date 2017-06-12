function validarSiNumero(numero) {
    if (!/^([0-9])*$/.test(numero))
        alert("El valor " + numero + " no es un número");
}

function validarCasado(texto) {
    var comparacion = "Casado"
    if (texto != comparacion)
        alert("Se puede agregar un Conyuge solo si el estado civil es Casado");
    else
        $(mostrarDatosConyuge).toggle();
}

function validarTitular() {
    $(mostrarDatosAdicional).toggle();
}