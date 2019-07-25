function processDivRule3(div){
        var nivel = $("#nivel")[0].value;
        $("#" + div + " input").each(function () {
            if (this.value!=""){
                var select = $("#" + div + " select[name='"+this.name +"Unidad']")[0];

              

                var unidadOrigen = select.value;
                var unidadDestino = select.dataset.unidad;
                var valorOrigen = this.value;
                if (unidadOrigen != unidadDestino){
                    this.value = conversor(valorOrigen, unidadOrigen, unidadDestino);

                    this.value = (this.value*nivel)/100;


                    select.value = unidadDestino;
                    console.log(valorOrigen +" "+ unidadOrigen + " =  " +this.value + " "+ unidadDestino );
                } else {


                    this.value = (this.value*100/nivel);

                   
                }
            }
        });
}

function saveIngrediente() {
    var url ="/Ingredientes/save";
    var id = document.getElementById("idIngrediente").value;
   
    if (id != "") {
        url = "/Ingredientes/edit";
    }
    
            form = $('#ingredienteForm');
            if (validateForms("ingredienteForm")) {
                processDivRule3("profile");
                processDivRule3("settings");
                processDivRule3("min");
                var json = serializeForm(form)
                json = posProcesarModalProximal(json);
                $.ajax({
                    method: "POST",
                    url: url,
                    data: JSON.stringify(json),
                    dataType: "json",
                    contentType: 'application/json',
                    error:function () {
                        alertModal("Error", "Error al procesar la solicitud");
                }
                    }).done(function (data) {
                    window.location.href = "/Ingredientes/all";


            });
            } else {
                alertModal("Error", "Existen campos invalidos o sin llenar");
                
            }


}
