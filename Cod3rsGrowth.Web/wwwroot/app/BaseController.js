sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/core/UIComponent"
], function(Controller, History, UIComponent) {
	"use strict";

	return Controller.extend("ui5.wwwroot.app.BaseController", {

		obterRota: function () {
			return UIComponent.getRouterFor(this);
		},

		aoClicarNoBotaoDeVoltar: function () {
			var historico, hashAnterior;
			const voltaHash = -1;

			historico = History.getInstance();
			hashAnterior = historico.getPreviousHash();

			if (hashAnterior !== undefined) {
				window.history.go(voltaHash);
			} else {
				this.getRouterFor().navTo("paginaInicial", {}, true);
			}
		},

		aoClicarNoBotaoAdicionar: function () {
			const rotaAdicionarMarca = this.getOwnerComponent().getRouter();
			rotaAdicionarMarca.navTo("AdicionarMarca");
			//this.getRouterFor().navTo("AdicionarMarca", {}, true);
		}
	});
});