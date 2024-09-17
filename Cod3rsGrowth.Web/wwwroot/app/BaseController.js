sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/core/UIComponent",
	"sap/ui/model/json/JSONModel"
], function(Controller, History, UIComponent, JSONModel) {
	"use strict";
	const itensDaListaDeMarcas = "modelMarcas";

	return Controller.extend("ui5.wwwroot.app.BaseController", {

		obterRota: function () {
			return UIComponent.getRouterFor(this);
		},

		aoClicarNoBotaoDeVoltarNaTelaDeNotFound: function () {
			var historico, hashAnterior;
			const voltaHash = -1;
			const rotaPaginaDeListaDeMarcas = "paginaInicial";

			historico = History.getInstance();
			hashAnterior = historico.getPreviousHash();

			if (hashAnterior !== undefined) {
				window.history.go(voltaHash);
			} else {
				this.getOwnerComponent().getRouter().navTo(rotaPaginaDeListaDeMarcas, {}, true);
			}
		},

		vincularRota: function(rota, funcaoInicial) {
			const oRouter = this.getOwnerComponent().getRouter();
			oRouter.getRoute(rota).attachPatternMatched(funcaoInicial, this);
		},

		obterDetalhesDaMarca: async function(idModeloDetalhado) {
            let url = `/api/Marca/${idModeloDetalhado}`;

            return fetch(url) 
            .then(response => response.json())
            .then(response => {
                const modeloDetalhado = new JSONModel();
                modeloDetalhado.setData(response);
				this.getView().setModel(modeloDetalhado, itensDaListaDeMarcas);
            })
        }
	});
});