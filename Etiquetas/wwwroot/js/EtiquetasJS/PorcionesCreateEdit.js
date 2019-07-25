function changeTipoValor() {
    
    if($("#Modal-Create-Requedido-Admin-Porcion").val() == "noRequerido"){

        $("#Modal-Create-Porcion-Admin-Anotacion-Porcion").removeClass("col-6");
        $("#Modal-Create-Porcion-Admin-Anotacion-Porcion").addClass("d-none");
        $("#Modal-Create-Porcion-Admin-Anotacion-Porcion").attr('required', false);
         $("#Modal-Create-Porcion-Admin-Anotacion-Porcion").val("");
        $("#Modal-Create-Porcion-Admin-Anotacion-Porcion-Input").removeClass("col-5");
        $("#Modal-Create-Porcion-Admin-Anotacion-Porcion-Input").addClass("d-none");

        $("#Modal-Create-Porcion-Admin-Cantidad-Porcion-input").removeClass("d-none");
        $("#Modal-Create-Porcion-Admin-Cantidad-Porcion-input").addClass("col-5");
        $("#Modal-Create-Porcion-Admin-Cantidad-Porcion").removeClass("d-none");
        $("#Modal-Create-Porcion-Admin-Cantidad-Porcion").addClass("col-3");
        $("#Modal-Create-Porcion-Admin-Cantidad-Porcion").attr('required', true);
        $("#Modal-Create-Porcion-Admin-Unidad-Porcion").removeClass("d-none");
        $("#Modal-Create-Porcion-Admin-Unidad-Porcion").addClass("col-3");
        
        
    }else if($("#Modal-Create-Requedido-Admin-Porcion").val() == "Requerido") {
       
        $("#Modal-Create-Porcion-Admin-Cantidad-Porcion-input").removeClass("col-5");
        $("#Modal-Create-Porcion-Admin-Cantidad-Porcion-input").addClass("d-none");

        $("#Modal-Create-Porcion-Admin-Cantidad-Porcion").removeClass("col-3");
        $("#Modal-Create-Porcion-Admin-Cantidad-Porcion").addClass("d-none");
        
        $("#Modal-Create-Porcion-Admin-Cantidad-Porcion").attr('required', false);
        $("#Modal-Create-Porcion-Admin-Cantidad-Porcion").val("");
        $("#Modal-Create-Porcion-Admin-Unidad-Porcion").addClass("d-none");
        $("#Modal-Create-Porcion-Admin-Unidad-Porcion").removeClass("col-3");

        $("#Modal-Create-Porcion-Admin-Anotacion-Porcion").addClass("col-6");
        $("#Modal-Create-Porcion-Admin-Anotacion-Porcion").removeClass("d-none");
        $("#Modal-Create-Porcion-Admin-Anotacion-Porcion").attr('required', true);
        $("#Modal-Create-Porcion-Admin-Anotacion-Porcion-Input").addClass("col-5");
        $("#Modal-Create-Porcion-Admin-Anotacion-Porcion-Input").removeClass("d-none");
    }  
}


    function savePorcion() {
        var url ="/Porcion/save";
        var id = document.getElementById("idPorcion").value;
       
        if (id != "") {
            url = "/Porcion/edit";;
        }
        
                form = $('#Modal-Create-Porcion-Admin-Form-Porcion');
                if (validateForms("Modal-Create-Porcion-Admin-Form-Porcion")) {
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
                        window.location.href = "/Porcion/all";
    
    
                });
                } else {
                    alertModal("Error", "Existen campos invalidos o sin llenar");              
                }
    
    } 
        

function editPorcion(id) {

        $.ajax({
            url: "/Porcion/getByid?id=" + id,
            type: "GET",
            success: function (data) {
                $('#idPorcion').val(data["id"]);
                $('#Modal-Create-Admin-User-Name-Porcion').val(data["name"]);
                $('#Modal-Create-Porcion-Admin-Category-Porcion').val(data["category"]);

                if (data["cantidad"] != null) {
                    $('#Modal-Create-Requedido-Admin-Porcion').val("noRequerido");
                    $('#Modal-Create-Porcion-Admin-Cantidad-Porcion').val(data["cantidad"]);
                    $('#Modal-Create-Porcion-Admin-Unidad-Porcion').val(data["unidad"]);
                } else {
                    $('#Modal-Create-Requedido-Admin-Porcion').val("Requerido");
                    $('#Modal-Create-Porcion-Admin-Anotacion-Porcion').val(data["annotation"]);
                }
                changeTipoValor();
                $('#Modal-Create-Porcion-Admin-Porcion').modal('show');

            }

        });
}


function newPorcion() {

       
     $('#Modal-Create-Porcion-Admin-Form-Porcion').get(0).reset();
     changeTipoValor();          
     $('#Modal-Create-Porcion-Admin-Porcion').modal('show');

         
}
