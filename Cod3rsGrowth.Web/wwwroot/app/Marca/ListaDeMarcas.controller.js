sap.ui.define([
	"ui5/wwwroot/app/BaseController",
	"sap/m/MessageBox",
	"sap/ui/core/format/DateFormat",
	"ui5/wwwroot/app/model/formatter",
	"sap/ui/core/mvc/View"
], function (BaseController, MessageBox, DateFormat, formatter, View) {
	"use strict";
	const rotaPaginaDeAdicionarMarca = "AdicionarMarca";
	const rotaPaginaDeDetalhesDaMarca = "DetalhesDaMarca";
	const itensDaListaDeMarcas = "modelMarcas";
	const propriedadeIdDaMarcaDetalhada = "id";

	return BaseController.extend("ui5.wwwroot.app.Marca.ListaDeMarcas", {
		formatter: formatter,

		onInit: function () {
            this.vincularRota("paginaInicial", this.aoCoincidirRotaDaTelaDeListaMarca);
		},

		aoCoincidirRotaDaTelaDeListaMarca: function() {
			return this.obterListaDeMarcas("https://localhost:7172/api/Marca");
		},

		obterListaDeMarcas: async function(url) {
 			return fetch(url) 
			.then(response => response.json())
			.then(responseJSON => {
				  if(responseJSON.Title) { 
				  	this.naMensagemDeErro(responseJSON);
				 } else {
					let oModel = new sap.ui.model.json.JSONModel(responseJSON);
					this.getView().setModel(oModel, "modelMarcas")
				}
			})
			.catch(erro => {
			this.naMensagemDeErro(erro)})
		},

		aoPesquisarFiltroDeNome: async function(oModel) {

			let modeloFiltro = oModel.getSource().getValue("nome");
			let url = "/api/Marca?";
			let params = new URLSearchParams(url.search); 

			if(modeloFiltro != null) {
				params.append("nome", modeloFiltro); 
				url += params.toString(); 
			}

			return this.obterListaDeMarcas(url);
		},

		naMensagemDeErro: function(mensagemDeErro) {
			MessageBox.error(mensagemDeErro.Detail, {title: "Erro na requisição"});
		},

		aoMudarFiltroDeData: async function (oModel) {
			let modeloFiltro = oModel.getSource();
			let inicio = modeloFiltro.getProperty("dateValue");
			let fim = modeloFiltro.getProperty("secondDateValue");
			inicio = DateFormat.getDateInstance({pattern:"yyyy-MM-ddTHH:mm:ss"}).format(inicio);
			fim = DateFormat.getDateInstance({pattern:"yyyy-MM-ddTHH:mm:ss"}).format(fim);
			let url = "/api/Marca?";
			let params = new URLSearchParams(url.search); 

			if((inicio != null)&&(fim != null)) {
				params.append("dataDeInicio", inicio); 
				params.append("dataDeFim", fim);
				url += params.toString(); 
			}

			return this.obterListaDeMarcas(url);
		},

		aoClicarNaMarca: function(oEvent) {
			this.getOwnerComponent().getRouter().navTo(rotaPaginaDeDetalhesDaMarca, 
				{id: oEvent.getSource().getBindingContext(itensDaListaDeMarcas).getProperty(propriedadeIdDaMarcaDetalhada)}, 
				true);
		},

		aoClicarNoBotaoAdicionar: function () {
			const rotaAdicionarMarca = this.getOwnerComponent().getRouter();
			rotaAdicionarMarca.navTo(rotaPaginaDeAdicionarMarca);
		}
	});
});