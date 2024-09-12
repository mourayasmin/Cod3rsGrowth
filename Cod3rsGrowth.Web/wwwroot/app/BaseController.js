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
			const rotaPaginaDeListaDeMarcas = "paginaInicial";

			historico = History.getInstance();
			hashAnterior = historico.getPreviousHash();

			if (hashAnterior !== undefined) {
				window.history.go(voltaHash);
			} else {
				this.getOwnerComponent().getRouter().navTo(rotaPaginaDeListaDeMarcas, {}, true);
			}
		},

		aoClicarNoBotaoAdicionar: function () {
			const rotaPaginaDeAdicionarMarca = "AdicionarMarca";
			const rotaAdicionarMarca = this.getOwnerComponent().getRouter();
			rotaAdicionarMarca.navTo(rotaPaginaDeAdicionarMarca);
		},

		aoClicarNoBotaoDeVoltarNaTelaDeAdicionarMarca: function() {
			this.limparCamposDeEntradaEValueState();
			this.getOwnerComponent().getRouter().navTo(rotaPaginaDeListaDeMarcas, {}, true);
		}, 

		aoClicarNaMarca: function() {
			const rotaPaginaDeDetalhesDaMarca = "DetalhesMarca";
			this.getOwnerComponent().getRouter().navTo(rotaPaginaDeDetalhesDaMarca, {}, true);
		},

		aoClicarNoBotaoDeVoltarNaTelaDeDetalhesDaMarca: function() {
			const rotaPaginaDeListaDeMarcas = "paginaInicial";
			this.getOwnerComponent().getRouter().navTo(rotaPaginaDeListaDeMarcas, {}, true);
		},

		aoSalvarAdicaoComSucesso: function() {
			const url = "https://localhost:7172/api/Marca";
			const rotaPaginaDeListaDeMarcas = "paginaInicial";
			this.getOwnerComponent().getRouter().navTo(rotaPaginaDeListaDeMarcas, {}, true);
		},

		aoClicarNoBotaoCancelarNaTelaDeAdicionar: function() {
			const rotaPaginaDeListaDeMarcas = "paginaInicial";
			this.limparCamposDeEntradaEValueState();
			this.getOwnerComponent().getRouter().navTo(rotaPaginaDeListaDeMarcas, {}, true);
		},

		vincularRota: function(rota, funcaoInicial) {
			const oRouter = this.getOwnerComponent().getRouter();
			oRouter.getRoute(rota).attachPatternMatched(funcaoInicial, this);
		}
	});
});