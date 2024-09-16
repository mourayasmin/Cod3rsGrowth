sap.ui.define([
    "ui5/wwwroot/app/BaseController",
    "sap/ui/model/json/JSONModel",
    "ui5/wwwroot/app/model/formatter"
], function (BaseController, JSONModel, formatter) {
    "use strict";
	const rotaPaginaDeListaDeMarcas = "paginaInicial";
    const itensDaListaDeMarcas = "modelMarcas";

    return BaseController.extend("ui5.wwwroot.app.Marca.DetalhesDaMarca", {
        formatter: formatter,
        onInit: function () {
            this.vincularRota("DetalhesDaMarca", this.aoCoincidirRotaDaTelaDeDetalhes);
        },

        aoCoincidirRotaDaTelaDeDetalhes: function(eventoURL) {
            let idModeloDetalhado = eventoURL.getParameters().arguments.id
            this.obterDetalhesDaMarca(idModeloDetalhado);
        },

        aoClicarNoBotaoDeVoltarNaTelaDeDetalhesDaMarca: function() {
			this.getOwnerComponent().getRouter().navTo(rotaPaginaDeListaDeMarcas, {}, true);
		}
    });
});