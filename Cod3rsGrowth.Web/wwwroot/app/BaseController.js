sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/core/UIComponent",
], function(Controller, History, UIComponent) {
	"use strict";

	return Controller.extend("ui5.wwwroot.app.BaseController", {

		obterRota: function () {
			return UIComponent.getRouterFor(this);
		},

		aoClicarNoBotaoDeVoltarNaTelaDeNotFound: function () {
			var historico, hashAnterior;
			const voltaHash = -1;

			historico = History.getInstance();
			hashAnterior = historico.getPreviousHash();

			if (hashAnterior !== undefined) {
				window.history.go(voltaHash);
			} else {
				this.getOwnerComponent().getRouter().navTo("paginaInicial", {}, true);
			}
		},

		aoClicarNoBotaoAdicionar: function () {
			const rotaAdicionarMarca = this.getOwnerComponent().getRouter();
			rotaAdicionarMarca.navTo("AdicionarMarca");
		},

		aoClicarNoBotaoDeVoltarNaTelaDeAdicionarMarca: function() {
			this.limparCamposDeEntradaEValueState();
			this.getOwnerComponent().getRouter().navTo("paginaInicial", {}, true);
		}, 

		aoClicarNaMarca: function() {
			this.getOwnerComponent().getRouter().navTo("DetalhesDaMarca", {}, true);
		},

		aoClicarNoBotaoDeVoltarNaTelaDeDetalhesDaMarca: function() {
			this.getOwnerComponent().getRouter().navTo("paginaInicial", {}, true);
		},

		aoSalvarAdicaoComSucesso: function() {
			const url = "https://localhost:7172/api/Marca";
			this.getOwnerComponent().getRouter().navTo("paginaInicial", {}, true);
			window.location.reload();
		},

		aoClicarNoBotaoCancelarNaTelaDeAdicionar: function() {
			this.limparCamposDeEntradaEValueState();
			this.getOwnerComponent().getRouter().navTo("paginaInicial", {}, true);
		}
	});
});