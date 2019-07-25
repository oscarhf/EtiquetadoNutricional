
    $(document).ready(function () {
        modalDropGet();
    });
    

    function modalDropGet(){
        $.ajax({
            method: "POST",
            url: "/Porcion/get",
                    async: false,
            contentType: 'application/json',
            success: function (result) {
                var select = $("#porcionesModal");
                result.forEach(Category => {
                    var group = $('<optgroup label="' + Category.name + '" />');
                    Category.porciones.forEach(element => {
                        if (element.unidad != null){
                            $('<option />').html(element.name + " (" + element.cantidad + " "  + element.unidad + ")").attr("value", element.id).attr("data-unidad", element.unidad).attr("data-cantidad", element.cantidad).appendTo(group);
                        }else{
                            $('<option />').html(element.name + " (" + element.annotation + ")").attr("value", element.id).attr("data-anotacion", element.annotation ).attr("data-name", element.name).appendTo(group);                     
                        }
                        });
                    group.appendTo(select);
                });
                changeDropDown()
            }

            });

        $("#porcionesModal").on("change", function(event) { 
            changeDropDown(this);
        });
    }

    function modalDropGetSet(data){
        $.ajax({
            method: "POST",
            url: "/Porcion/get",
            async: false,
            contentType: 'application/json',
            success: function (result) {
                var select = $("#porcionesModal");
                result.forEach(Category => {
                    var group = $('<optgroup label="' + Category.name + '" />');
                    Category.porciones.forEach(element => {
                        if (element.unidad != null){
                            $('<option />').html(element.name + " (" + element.cantidad + " "  + element.unidad + ")").attr("value", element.id).attr("data-unidad", element.unidad).attr("data-cantidad", element.cantidad).appendTo(group);
                        }else{
                            $('<option />').html(element.name + " (" + element.annotation + ")").attr("value", element.id).attr("data-anotacion", element.annotation ).attr("data-name", element.name).appendTo(group);                     
                        }
                        });
                    group.appendTo(select);
                });
                $("#porcionesModal").val(data)
                changeDropDown()
            }

            });

       
    }

    function changeDropDown(){
        
        var seleccionada =  $("#porcionesModal").find(":selected")[0]
        if (seleccionada.dataset.unidad!= undefined){
            if (isMasa(seleccionada.dataset.unidad)){
                $('#SelectUnidadModal').empty();
                $('#SelectUnidadModal')[0].dataset.unidad = "g";
                $('<option />').html("hg - Hectogramos").attr('value', "hg").appendTo($('#SelectUnidadModal'));
                $('<option />').html("dag - Decagramos").attr('value', "dag").appendTo($('#SelectUnidadModal'));
                $('<option />').html("g - Gramos").attr('value', "g").attr('selected', true).appendTo($('#SelectUnidadModal'));
                $('<option />').html("dg - Decigramos").attr('value', "dg").appendTo($('#SelectUnidadModal'));
                $('<option />').html("cg - Decigramos").attr('value', "cg").appendTo($('#SelectUnidadModal'));
                $('<option />').html("mg - Miligramos").attr('value', "mg").appendTo($('#SelectUnidadModal'));
                $('<option />').html("µg - Microgramos").attr('value', "ug").appendTo($('#SelectUnidadModal'));
                $('#inputDencidadModal').attr('disabled', true);
                $('#SelectDencidadModal').attr('disabled', true);
                $('#inputDencidadModal').attr('required', false);
                $('#inputUnidadModal').attr('min', seleccionada.dataset.cantidad);
                $('#inputUnidadModal').attr('step',"0.1");
                $('#inputUnidadModal').val(seleccionada.dataset.cantidad);
                
                $('#inputDensidadModal').val("");
                $('#PorcionRemplazoModal').val("");
            }else if (isLiquid(seleccionada.dataset.unidad)){
                $('#SelectUnidadModal').empty();
                $('#SelectUnidadModal')[0].dataset.unidad = "ml";
                $('<option />').html("ml - Mililitros").attr('value', "ml").attr('selected', true).appendTo($('#SelectUnidadModal'));
                $('<option />').html("l - Litros").attr('value', "l").appendTo($('#SelectUnidadModal'));
                $('#inputDencidadModal').attr('disabled', false);
                $('#SelectDencidadModal').attr('disabled', false);
                $('#inputDencidadModal').attr('required', true);
                $('#inputUnidadModal').attr('step',"0.1");
                $('#inputUnidadModal').attr('min', seleccionada.dataset.cantidad);
                $('#inputUnidadModal').val(seleccionada.dataset.cantidad);
                $('#PorcionRemplazoModal').val("");
            }else if (isCasera(seleccionada.dataset.unidad)){
                if (isCaseraMasa(seleccionada.dataset.unidad)){
                    $('#SelectUnidadModal').empty();
                    $('#SelectUnidadModal')[0].dataset.unidad = "g";
                    $('<option />').html("Oz - Onza").attr('value', "Oz").appendTo($('#SelectUnidadModal'));
                    $('#inputDencidadModal').attr('disabled', true);
                    $('#SelectDencidadModal').attr('disabled', true);
                    $('#inputDencidadModal').attr('required', false);
                    $('#inputUnidadModal').attr('min', seleccionada.dataset.cantidad);
                    $('#inputUnidadModal').attr('step',"1");
                    $('#inputUnidadModal').val(seleccionada.dataset.cantidad);
                }else if (isCaseraLiquid(seleccionada.dataset.unidad)){
                    $('#SelectUnidadModal').empty();
                    $('#SelectUnidadModal')[0].dataset.unidad = "ml";
                    if (isCaseraCucharada(seleccionada.dataset.unidad)){
                        $('<option />').html("cda - Cucharada").attr('value', "cdta").appendTo($('#SelectUnidadModal'));
                        $('#inputUnidadModal').attr('step',"0.25");
                    }else if (isCaseraCucharita(seleccionada.dataset.unidad)){
                        $('<option />').html("cdta - Cucharadita").attr('value', "cda").appendTo($('#SelectUnidadModal'));
                        $('#inputUnidadModal').attr('step',"0.25");
                    }else if (isCaseraTaza(seleccionada.dataset.unidad)){
                        $('<option />').html("Taza por 240ml").attr('value', "t240").appendTo($('#SelectUnidadModal'));
                        $('<option />').html("Taza por 200ml").attr('value', "t200").appendTo($('#SelectUnidadModal'));
                        $('#inputUnidadModal').attr('step',"0.1");
                    }else if (isCaseraVaso(seleccionada.dataset.unidad)){
                        $('<option />').html("Vaso por 240ml").attr('value', "v240").appendTo($('#SelectUnidadModal'));
                        $('<option />').html("Vaso por 200ml").attr('value', "v200").appendTo($('#SelectUnidadModal'));
                        $('#inputUnidadModal').attr('step',"0.1");
                    }else if (isCaseraOnzaFluida(seleccionada.dataset.unidad)){
                        $('<option />').html("Oz fl - Onza Fluida").attr('value', "OzFl").appendTo($('#SelectUnidadModal'));
                        $('#inputUnidadModal').attr('step',"0.1");
                    }
                    $('#inputDencidadModal').attr('disabled', false);
                    $('#SelectDencidadModal').attr('disabled', false);
                    $('#inputDencidadModal').attr('required', true);
                    $('#inputUnidadModal').attr('min', seleccionada.dataset.cantidad);
                    $('#inputUnidadModal').val(seleccionada.dataset.cantidad);
                    
                }
            }
        }else{
            showRequest(seleccionada.dataset.name,seleccionada.dataset.anotacion);
                $('#SelectUnidadModal').empty();
                $('#SelectUnidadModal')[0].dataset.unidad = "g";
                $('<option />').html("hg - Hectogramos").attr('value', "hg").appendTo($('#SelectUnidadModal'));
                $('<option />').html("dag - Decagramos").attr('value', "dag").appendTo($('#SelectUnidadModal'));
                $('<option />').html("g - Gramos").attr('value', "g").attr('selected', true).appendTo($('#SelectUnidadModal'));
                $('<option />').html("dg - Decigramos").attr('value', "dg").appendTo($('#SelectUnidadModal'));
                $('<option />').html("cg - Decigramos").attr('value', "cg").appendTo($('#SelectUnidadModal'));
                $('<option />').html("mg - Miligramos").attr('value', "mg").appendTo($('#SelectUnidadModal'));
                $('<option />').html("µg - Microgramos").attr('value', "ug").appendTo($('#SelectUnidadModal'));
                $('#inputDencidadModal').attr('disabled', true);
                $('#SelectDencidadModal').attr('disabled', true);
                $('#inputDencidadModal').attr('required', false);
                $('#inputUnidadModal').val(seleccionada.dataset.cantidad);
        }

    }

function saveProximal() {
    var url = "/Proximal/Save";

        if ($("#idProximal").val() != "") {
             url = "/Proximal/Edit";
        }

        var form = $('#modalForm');
        if (validateForms("modalForm")) {
            processTotalPorcion();
            processDiv("profileI");
            processDiv("settingsI");
            processDiv("minI");
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
                $('#modalForm').empty();
                window.location.href = "/etiqueta?id=" + data;
            });
        } else {
            alertModal("Error", "Existen campos invalidos o sin llenar");
            
        }
    }

    function serializeForm(form) {
        var data = form.serializeArray();
        return _.object(_.pluck(data, 'name'), _.pluck(data, 'value'));
    }


    function validateForms(form) {
        var result = true;
        $("form#" + form + " input").each(function () {
            ; // This is the jquery object of the input, do what you will
            if (!this.validity.valid) {
                result = false;
            }
            if (this.validity.valueMissing) {
                result = false;
            }
        });

        return result;
    }

    function validateInput(inputId) {
        var result = true;
        $("#"+inputId).each(function () {
             // This is the jquery object of the input, do what you will
            if (!this.validity.valid) {
                result = false;
            }
            if (this.validity.valueMissing) {
                result = false;
            }
        });

        return result;
    }

    function RequestModalValidate(){
        var valor = document.getElementById("request-Modal-quest-input")
        if (valor.validity.valid && !valor.validity.valueMissing){
      
            $('#inputUnidadModal').val(valor.value);
            $('#inputUnidadModal').attr('min', valor.value);
            $('#request-Modal').modal('toggle');
        }else{
            alert("Campos invalidos");
        }
    }

    function processDiv(div){
        $("#" + div + " input").each(function () {
            if (this.value!=""){
                var select = $("#" + div + " select[name='"+this.name +"Unidad']")[0];
                var unidadOrigen = select.value;
                var unidadDestino = select.dataset.unidad;
                var valorOrigen = this.value;
                if (unidadOrigen != unidadDestino){
                    this.value = conversor(valorOrigen, unidadOrigen, unidadDestino);
                    select.value = unidadDestino;
                    console.log(valorOrigen +" "+ unidadOrigen + " =  " +this.value + " "+ unidadDestino  );
                }
            }
        });
    }


    function processTotalPorcion(){
        var select = $("#SelectUnidadModal")[0];
        var input = $("#inputUnidadModal")[0];
        var unidadOrigen = select.value;
        var unidadDestino = select.dataset.unidad
        var valorOrigen = input.value;
        if (unidadOrigen != unidadDestino){
            input.value = conversor(valorOrigen, unidadOrigen, unidadDestino);
            select.value = unidadDestino;
            console.log(valorOrigen +" "+ unidadOrigen + " =  " +this.value + " "+ unidadDestino  );
            }
    }

    function posProcesarModalProximal(json){

            if (isMasa(json["porcionUnidad"])|| isCaseraMasa(json["porcionUnidad"]) ){
                var g = conversor(json["porcionCantidad"],json["porcionUnidad"],"g");
                json["PorcionCantidadG"] = g;
            }else if (isLiquid(json["porcionUnidad"])||isCaseraLiquid(json["porcionUnidad"])){
                var ml = conversor(json["porcionCantidad"],json["porcionUnidad"],"ml");
                var g = conversor(ml,"ml","g",json["densidad"],json["densidadUnidad"]);
                json["PorcionCantidadG"] = g
            }
        console.log(json);
        return json;
    }

    function ModalCreatePorcionUserlValidate(){
        var valor = document.getElementById("Modal-Create-Porcion-User-Cantidad");
        var nombre = document.getElementById("Modal-Create-Porcion-User-Name");
        var unidad = document.getElementById("Modal-Create-Porcion-User-Unidad");
        if (valor.validity.valid && !valor.validity.valueMissing && nombre.validity.valid && !nombre.validity.valueMissing ){
            $.ajax({
                method: "POST",
                url: "/Porcion/save",
                data: JSON.stringify({"name":nombre.value,"cantidad":valor.value,"unidad":unidad.value}),
                dataType: "json",
                contentType: 'application/json',
                error:function () {
                    alert("Campos invalidos");
            }
            }).done(function (data) {
                $('#Modal-Create-Porcion-User').modal('toggle');;
                document.getElementById("Modal-Create-Porcion-User-Name").value = "";
                document.getElementById("Modal-Create-Porcion-User-Cantidad").value = "";
                $('#porcionesModal').empty();
                modalDropGetSet(data);
                //window.location.href = "/etiqueta?id=" + data;
            });
        }else{
            alert("Campos invalidos");
        }
    }




