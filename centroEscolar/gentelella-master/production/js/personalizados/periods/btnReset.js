function buttonReset() {        
    document.getElementById("form1").reset();
    document.getElementById('fechaInicio').value = currentDate(document.getElementById("fechaInicio").value);
    document.getElementById('fechaFinal').value = currentDate(document.getElementById("fechaFinal").value);
       
}