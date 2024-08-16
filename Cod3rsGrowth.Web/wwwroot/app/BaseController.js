sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/core/UIComponent"
], function(Controller, History, UIComponent) {
	"use strict";

	return Controller.extend("ui5.wwwroot.app.BaseController", {

		obterRota : function () {
			return UIComponent.getRouterFor(this);
		},

		aoClicarNoBotaoDeVoltar: function () {
			var historico, hashAnterior;
			const int voltaHash = -1;

			historico = History.getInstance();
			hashAnterior = historico.getPreviousHash();

			if (hashAnterior !== undefined) {
				window.history.go(voltaHash);
			} else {
				this.obterRota().navTo("paginaInicial", {}, true);
			}
		}
	});
});