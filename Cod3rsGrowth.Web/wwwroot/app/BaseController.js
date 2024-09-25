sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/core/UIComponent",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/BusyIndicator",
	"sap/m/MessageBox",
], function (Controller, History, UIComponent, JSONModel, BusyIndicator, MessageBox) {
	"use strict";

	return Controller.extend("ui5.wwwroot.app.BaseController", {

		obterRota: function () {
			return UIComponent.getRouterFor(this);
		},

		statusDeCarregamentoDaTela: function (func) {
			try {
				BusyIndicator.show(0)
				return Promise.resolve()
					.then(() => func())
					.then(() => BusyIndicator.hide())
					.catch(e => {
						BusyIndicator.hide();
						MessageBox.error(e.message)
					})
			} catch (error) {
				BusyIndicator.hide();
				MessageBox.error(error.message)
			}
		},

		aoClicarNoBotaoDeVoltarNaTelaDeNotFound: function () {
			var historico, hashAnterior;
			const voltaHash = -1;
			const rotaPaginaDeListaDeMarcas = "paginaInicial";

			historico = History.getInstance();
			hashAnterior = historico.getPreviousHash();
			if (hashAnterior !== undefined) {
				window.history.go(voltaHash);
			}
			else {
				this.navegarPara(rotaPaginaDeListaDeMarcas, {}, true);
			}
		},

		vincularRota: function (rota, funcaoInicial) {
			const oRouter = this.getOwnerComponent().getRouter();
			oRouter.getRoute(rota).attachPatternMatched(funcaoInicial, this);
		},

		navegarPara: function (rota, parametros = {}) {
			this.getOwnerComponent().getRouter().navTo(rota, parametros, true);
		}
	});
});