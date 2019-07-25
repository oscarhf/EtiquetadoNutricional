    
    
    
    var modalShowIngredientesApp;
    var IngredientesApp;
    var ingredienteID = 0;
    var porcentaje = 0;
    
    var porcentajeVue = new Vue({
        el: '#porcentaje',
        data: { "porcentaje": porcentaje }
    });
    
    $(document).ready(function () {
        FormulacionDropGet();
        CreateIngredientsModals();
        BindControls();
    });
    
    function FormulacionDropGet(){
        $.ajax({
            method: "POST",
            url: "/Porcion/get",
            async: false,
            contentType: 'application/json',
            success: function (result) {
                var select = $("#porcionesFormulacion");
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
                changeDropDownFormulacion()
            }

            });

        $("#porcionesFormulacion").on("change", function(event) { 
            changeDropDownFormulacion(this);
        });
    }


    function FormulacionDropGetSet(data){
        $.ajax({
            method: "POST",
            url: "/Porcion/get",

            contentType: 'application/json',
            success: function (result) {
                var select = $("#porcionesFormulacion");
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
                $('#porcionesFormulacion').val(data);
                changeDropDownFormulacion()
            }

            });

    }


    function changeDropDownFormulacion(){
        
        var seleccionada =  $("#porcionesFormulacion").find(":selected")[0]
        if (seleccionada.dataset.unidad!= undefined){
            if (isMasa(seleccionada.dataset.unidad)){
                $('#SelectUnidadFormulacion').empty();
                $('#SelectUnidadFormulacion')[0].dataset.unidad = "g";
                $('<option />').html("hg - Hectogramos").attr('value', "hg").appendTo($('#SelectUnidadFormulacion'));
                $('<option />').html("dag - Decagramos").attr('value', "dag").appendTo($('#SelectUnidadFormulacion'));
                $('<option />').html("g - Gramos").attr('value', "g").attr('selected', true).appendTo($('#SelectUnidadFormulacion'));
                $('<option />').html("dg - Decigramos").attr('value', "dg").appendTo($('#SelectUnidadFormulacion'));
                $('<option />').html("cg - Decigramos").attr('value', "cg").appendTo($('#SelectUnidadFormulacion'));
                $('<option />').html("mg - Miligramos").attr('value', "mg").appendTo($('#SelectUnidadFormulacion'));
                $('<option />').html("µg - Microgramos").attr('value', "ug").appendTo($('#SelectUnidadFormulacion'));
                $('#inputDencidadFormulacion').attr('disabled', true);
                $('#SelectDencidadFormulacion').attr('disabled', true);
                $('#inputDencidadFormulacion').attr('required', false);
                $('#inputUnidadFormulacion').attr('min', seleccionada.dataset.cantidad);
                $('#inputUnidadFormulacion').attr('step',"0.1");
                $('#inputUnidadFormulacion').val(seleccionada.dataset.cantidad);
                
                $('#inputDensidadFormulacion').val("");
                $('#PorcionRemplazoFormulacion').val("");
            }else if (isLiquid(seleccionada.dataset.unidad)){
                $('#SelectUnidadFormulacion').empty();
                $('#SelectUnidadFormulacion')[0].dataset.unidad = "ml";
                $('<option />').html("ml - Mililitros").attr('value', "ml").attr('selected', true).appendTo($('#SelectUnidadFormulacion'));
                $('<option />').html("l - Litros").attr('value', "l").appendTo($('#SelectUnidadFormulacion'));
                $('#inputDencidadFormulacion').attr('disabled', false);
                $('#SelectDencidadFormulacion').attr('disabled', false);
                $('#inputDencidadFormulacion').attr('required', true);
                $('#inputUnidadFormulacion').attr('step',"0.1");
                $('#inputUnidadFormulacion').attr('min', seleccionada.dataset.cantidad);
                $('#inputUnidadFormulacion').val(seleccionada.dataset.cantidad);
                $('#PorcionRemplazoFormulacion').val("");
            }else if (isCasera(seleccionada.dataset.unidad)){
                if (isCaseraMasa(seleccionada.dataset.unidad)){
                    $('#SelectUnidadFormulacion').empty();
                    $('#SelectUnidadFormulacion')[0].dataset.unidad = "g";
                    $('<option />').html("Oz - Onza").attr('value', "Oz").appendTo($('#SelectUnidadFormulacion'));
                    $('#inputDencidadFormulacion').attr('disabled', true);
                    $('#SelectDencidadFormulacion').attr('disabled', true);
                    $('#inputDencidadFormulacion').attr('required', false);
                    $('#inputUnidadFormulacion').attr('min', seleccionada.dataset.cantidad);
                    $('#inputUnidadFormulacion').attr('step',"1");
                    $('#inputUnidadFormulacion').val(seleccionada.dataset.cantidad);
                }else if (isCaseraLiquid(seleccionada.dataset.unidad)){
                    $('#SelectUnidadFormulacion').empty();
                    $('#SelectUnidadFormulacion')[0].dataset.unidad = "ml";
                    if (isCaseraCucharada(seleccionada.dataset.unidad)){
                        $('<option />').html("cda - Cucharada").attr('value', "cdta").appendTo($('#SelectUnidadFormulacion'));
                        $('#inputUnidadFormulacion').attr('step',"0.25");
                    }else if (isCaseraCucharita(seleccionada.dataset.unidad)){
                        $('<option />').html("cdta - Cucharadita").attr('value', "cda").appendTo($('#SelectUnidadFormulacion'));
                        $('#inputUnidadFormulacion').attr('step',"0.25");
                    }else if (isCaseraTaza(seleccionada.dataset.unidad)){
                        $('<option />').html("Taza por 240ml").attr('value', "t240").appendTo($('#SelectUnidadFormulacion'));
                        $('<option />').html("Taza por 200ml").attr('value', "t200").appendTo($('#SelectUnidadFormulacion'));
                        $('#inputUnidadFormulacion').attr('step',"0.1");
                    }else if (isCaseraVaso(seleccionada.dataset.unidad)){
                        $('<option />').html("Vaso por 240ml").attr('value', "v240").appendTo($('#SelectUnidadFormulacion'));
                        $('<option />').html("Vaso por 200ml").attr('value', "v200").appendTo($('#SelectUnidadFormulacion'));
                        $('#inputUnidadFormulacion').attr('step',"0.1");
                    }else if (isCaseraOnzaFluida(seleccionada.dataset.unidad)){
                        $('<option />').html("Oz fl - Onza Fluida").attr('value', "OzFl").appendTo($('#SelectUnidadFormulacion'));
                        $('#inputUnidadFormulacion').attr('step',"0.1");
                    }
                    $('#inputDencidadFormulacion').attr('disabled', false);
                    $('#SelectDencidadFormulacion').attr('disabled', false);
                    $('#inputDencidadFormulacion').attr('required', true);
                    $('#inputUnidadFormulacion').attr('min', seleccionada.dataset.cantidad);
                    $('#inputUnidadFormulacion').val(seleccionada.dataset.cantidad);
                    
                }
            }
        }else{
                showRequestFormulacion(seleccionada.dataset.name,seleccionada.dataset.anotacion);
                $('#SelectUnidadFormulacion').empty();
                $('#SelectUnidadFormulacion')[0].dataset.unidad = "g";
                $('<option />').html("hg - Hectogramos").attr('value', "hg").appendTo($('#SelectUnidadFormulacion'));
                $('<option />').html("dag - Decagramos").attr('value', "dag").appendTo($('#SelectUnidadFormulacion'));
                $('<option />').html("g - Gramos").attr('value', "g").attr('selected', true).appendTo($('#SelectUnidadFormulacion'));
                $('<option />').html("dg - Decigramos").attr('value', "dg").appendTo($('#SelectUnidadFormulacion'));
                $('<option />').html("cg - Decigramos").attr('value', "cg").appendTo($('#SelectUnidadFormulacion'));
                $('<option />').html("mg - Miligramos").attr('value', "mg").appendTo($('#SelectUnidadFormulacion'));
                $('<option />').html("µg - Microgramos").attr('value', "ug").appendTo($('#SelectUnidadFormulacion'));
                $('#inputDencidadFormulacion').attr('disabled', true);
                $('#SelectDencidadFormulacion').attr('disabled', true);
                $('#inputDencidadFormulacion').attr('required', false);
                $('#inputUnidadFormulacion').val(seleccionada.dataset.cantidad);
        }

    }

    function processTotalPorcionFormulacion(){
        var select = $("#SelectUnidadFormulacion")[0];
        var input = $("#inputUnidadFormulacion")[0];
        var unidadOrigen = select.value;
        var unidadDestino = select.dataset.unidad
        var valorOrigen = input.value;
        if (unidadOrigen != unidadDestino){
            input.value = conversor(valorOrigen, unidadOrigen, unidadDestino);
            select.value = unidadDestino;
            console.log(valorOrigen +" "+ unidadOrigen + " =  " +this.value + " "+ unidadDestino  );
            }
    }

    function posProcesarFormulacion(json){

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

        
    function ModalCreatePorcionUserlValidateFormulacion(){
        var valor = document.getElementById("Modal-Create-Porcion-User-Cantidad-Formulacion");
        var nombre = document.getElementById("Modal-Create-Porcion-User-Name-Formulacion");
        var unidad = document.getElementById("Modal-Create-Porcion-User-Unidad-Formulacion");
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
                $('#Modal-Create-Porcion-User-Formulacion').modal('toggle');
                document.getElementById("Modal-Create-Porcion-User-Name-Formulacion").value = "";
                document.getElementById("Modal-Create-Porcion-User-Cantidad-Formulacion").value = "";
                $('#porcionesFormulacion').empty();
                FormulacionDropGetSet(data);
                //window.location.href = "/etiqueta?id=" + data;
            });
        }else{
            alert("Campos invalidos");
        }
    }

    function CreateIngredientsModals() {
        IngredientesApp = new Vue({
            el: '#ingredientes-Vue',
            methods: {
                add() {
                    this.children.push(Welcome);
                },edit: function () {
                                editingredienteVue(data);
                            }
            }
        });
    }



function addIngrediente(name,idingrediente,val) {
    if (val == undefined){
        val = 0;
    }

        if (!existIngrediente("ingredientes-Vue",idingrediente)){
            var template  = '<div class="row ingrediente align-items-center">'
                        +     '<span class="col-7">'+name+'</span>'
                        +     '<input class="col-3 inputCustom inputIngrediente" type="number" step="0.1" onchange="updatePogressBar();" min="0" value="'+val+ '"  data-id="'+idingrediente+'" data-name="'+name+'" required>'
                        +     '<div class ="col-2">'
                        +     '<button onclick="removeIngrediente(this);" type="button" rel="tooltip" title="" class="btn btn-danger btn-link btn-sm" data-original-title="Eliminar">'
                        +         '<i class="material-icons">close</i>'
                        +     '</button>'
                        +     '</div>'
                        + '</div>';
            $("#listIngredientes").append(template);
        }else{
            alertModal("Error", "El ingrediente ya fue agrargado");
        }
        
    }


    function removeIngrediente(e) {
        $(e).parents().eq(1).remove()
        updatePogressBar();
    }



    function updatePogressBar() {
        var value = 0;
        $(".inputIngrediente").each(function () {
            value += parseInt(this.value);
        });
        porcentajeVue.porcentaje = value;

    }



    function BindControls() {
        var f = $("#search");
        $("#search").autocomplete({
            source: function (request, response) {

                var val = request.term;

                $.ajax({
                    url: "/Ingredientes/getByName?name=" + val,
                    type: "GET",
                    success: function (data) {
                        response($.map(data, function (item) {
                            return { data: item.id, value: item.name + " (" + item.provedor + ")" }
                        }))
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(textStatus);
                    }
                });
            },
            minLength: 1,
            select: function (event, ui) {

                $(this).val("");


                $.ajax({
                    url: "/Ingredientes/getByid?id=" + ui.item.data,
                    type: "GET",
                    success: function (data) {
                        if (modalShowIngredientesApp == undefined){
                            modalShowIngredientesApp = new Vue({
                                el: '#ModalIngredientes',
                                data: data,
                                methods:{

                                    add: function () {
                                        addIngrediente(this.name + " - " + this.provedor,this.id);    
                                        $("#ModalIngredientes").modal('toggle');
                                    },
                                    edit: function () {
                                editingredienteVue(data);
                            },
                                    changeData: function (e) {
                                        var vm = this;
                        
                                        Object.keys(e).forEach(function (key) {
                                            vm._data[key]=e[key];
                                         });
                                        
                                        console.log(e);
                                    }
                                }
                            });
                        }else{
                            modalShowIngredientesApp.changeData( data);
                        }

                        $('#ModalIngredientes').modal('show');
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(textStatus);
                    }

                });


                return false;
            }
        });
    }

    function formulaPreProcess(){
        var v = validateFormula("ingredientes-Vue");
        if (v == ""){
            if ( porcentajeVue.porcentaje < 100){
                ModalQuestFormlacion("Confirmacion", "Esta apunto de guardar una formulacion que no es del 100%, el porcentaje faltante no aportara nada / ni sumara  a los datos nutricionales generados");
            }else{
                saveFormula();
            }
        }else{
            alertModal("Error", v);
        }
    }

    function ModalQuestFormlacion(title, quest) {
        // Display error message to the user in a modal
        $('#ModalQuestFormlacion-title').html(title);
        $('#ModalQuestFormlacion-quest').html(quest);
        $('#ModalQuestFormlacion').modal('show');
      }
      

function saveFormula(){
        var url = "/Formulacion/Save";

        if ($("#idFormula").val() != "") {
             url = "/Formulacion/Edit";
        }
        var v = validateFormula("ingredientes-Vue");
        if (v == ""){
            var json =  new Object();
            var json = processOtherData();
            json.Ingredientes = processIngredientes("ingredientes-Vue");
            json =  posProcesarModalProximal(json);
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
        }else{
            alertModal("Error", v);
        }

    }

    function validateFormula(div){
        var resultado = "";
        $("#" + div + " input").each(function () {
            if (this.value == 0){
                resultado = resultado +  " " + this.dataset.name + " no puede ser 0 <br>" ;
            }
        });
        if (!validateInput("nameFormula")){
            resultado = resultado +  "Ingrese el nombre de la Formulacion <br>" ;
        }

        if (!validateInput("inputUnidadFormulacion")){
            resultado = resultado +  "Especifique la Cantidad Total de las posiones por producto <br>" ;
        }

        if (!validateInput("inputDencidadFormulacion")){
            resultado = resultado +  "Debe ingresar la densidad del producto para esta formulacion <br>" ;
        }

        if (numIngredientes("ingredientes-Vue") <= 0){
            resultado = resultado +  "Debe Agregar almenos un ingrediente <br>" ;
        }

        if (porcentajeVue.porcentaje  > 100){
            resultado = resultado +  "El porcentaje de la formula es de mas del 100% <br>" ;
        }

        return resultado;
    }

    function processIngredientes(div){
        var resultado = [];
        $("#" + div + " input").each(function () {
            var o = new Object();
            o.id = this.dataset.id;
            o.val = this.value;
            resultado.push(o);
        });
        return resultado;
    }

    function existIngrediente(div,id){
        var resultado = false;
        $("#" + div + " input").each(function () {
            if (this.dataset.id == id){
                resultado = true;
            }
        });
        return resultado;
    }

    function processOtherData(){
        var result = serializeForm($("#Form-porcion-Formualcion"));
        result.Name = $("#nameFormula").val();
        result.id = $("#idFormula").val();
        return result;
    }

    function ModalCreatePorcionUserlValidate(){
        var valor = document.getElementById("Modal-Create-Porcion-User-Cantidad-Formulacion");
        var nombre = document.getElementById("Modal-Create-Porcion-User-Name-Formulacion");
        var unidad = document.getElementById("Modal-Create-Porcion-User-Unidad-Formulacion");
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
                document.getElementById("Modal-Create-Porcion-User-Name-Formulacion").value = "";
                document.getElementById("Modal-Create-Porcion-User-Cantidad-Formulacion").value = "";
                $('#porcionesModal').empty();
                modalDropGetSet(data);
                //window.location.href = "/etiqueta?id=" + data;
            });
        }else{
            alert("Campos invalidos");
        }
    }


    function RequestFormulacionValidate(){
        var valor = document.getElementById("request-Formulacion-quest-input")
        if (valor.validity.valid && !valor.validity.valueMissing){
            $('#inputUnidadFormulacion').val(valor.value);
            $('#inputUnidadFormulacion').attr('min', valor.value);
            $('#request-Formulacion').modal('toggle');
        }else{
            alert("Campos invalidos");
        }
    }
    
    function numIngredientes(div){
        var i = 0 ;
        $("#" + div + " input").each(function () {
            i = i+1;
        });
        return i;
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


    function editingrediente(id) {

        $.ajax({
            url: "/Ingredientes/getByid?id=" + id,
            type: "GET",
            success: function (data) {

                editingredienteVue(data)

            },

        });
    }

    function editingredienteVue(data) {

        console.log(Object.keys(data));

        Object.keys(data)
            .forEach(function eachKey(key) {
                if (data[key] != null) {

                    var input = $('#ingredienteForm input[name = ' + key + ']');

                    if (input.size() >= 1) {
                        input.get(0).value = data[key];
                    }

                };
            });

        document.getElementById("idIngrediente").value = "";

        $('#ModalIngredientes').modal('hide');
        $('#Crearingrediente').modal('show');
    }

    function newingrediente() {
            $('#ingredienteForm').get(0).reset()
            $('#Crearingrediente').modal('show');
        }