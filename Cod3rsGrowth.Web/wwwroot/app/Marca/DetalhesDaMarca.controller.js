sap.ui.define([
    "ui5/wwwroot/app/BaseController"
], function (BaseController) {
    "use strict";
    return BaseController.extend("ui5.wwwroot.app.Marca.DetalhesDaMarca", {
        onInit: function () {
            this.obterDetalhesDaMarca("https://localhost:7172/api/Marca");
       },

       obterDetalhesDaMarca: function(url) {
            let oModel = new sap.ui.model.json.JSONModel();
            this.getView().getModel(oModel, "modelMarcas");
            //let modeloDetalhado = this.getModel("modelMarcas").getValue("id");
            let idModeloDetalhado = oModel.getSource().getValue("id");
            debugger
            let url = "/api/Marca";
            let params = new URLSearchParams(url.search);
            if(modeloDetalhado != null) {
                debugger
                params.append(idModeloDetalhado);
                url += params.toString();
            }
            fetch(url);
        },
    });
 });