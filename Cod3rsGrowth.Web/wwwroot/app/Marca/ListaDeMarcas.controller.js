sap.ui.define([
	"ui5/wwwroot/app/BaseController",
	"sap/m/MessageBox",
	"sap/ui/core/format/DateFormat",
	"ui5/wwwroot/app/model/formatter",
	"sap/ui/core/mvc/View",
	"ui5/wwwroot/app/model/RepositorioBase",
	"sap/ui/model/json/JSONModel"
], function (BaseController, MessageBox, DateFormat, formatter, View, RepositorioBase, JSONModel) {
	"use strict";
	const rotaPaginaDeAdicionarMarca = "AdicionarMarca";
	const rotaPaginaDeDetalhesDaMarca = "DetalhesDaMarca";
	const itensDaListaDeMarcas = "modelMarcas";
	const propriedadeIdDaMarcaDetalhada = "id";

	return BaseController.extend("ui5.wwwroot.app.Marca.ListaDeMarcas", {
		formatter: formatter,

		onInit: function () {
			this.vincularRota("paginaInicial", this._aoCoincidirRotaDaTelaDeListaMarca);
		},

		_aoCoincidirRotaDaTelaDeListaMarca: function () {
			this.statusDeCarregamentoDaTela(() => {
				return this._obterListaDeMarcas("https://localhost:7172/api/Marca");
			})
		},

		_obterListaDeMarcas: async function (url) {
			const listaDeMarcas = await RepositorioBase.obterTodas(url)
			this.getView().setModel(new JSONModel(listaDeMarcas), "modelMarcas");
		},

		aoPesquisarFiltroDeNome: async function (oModel) {

			let modeloFiltro = oModel.getSource().getValue("nome");
			let url = "/api/Marca?";
			let params = new URLSearchParams(url.search);

			if (modeloFiltro != null) {
				params.append("nome", modeloFiltro);
				url += params.toString();
			}

			await this._obterListaDeMarcas(url);
		},

		_naMensagemDeErro: function (mensagemDeErro) {
			MessageBox.error(mensagemDeErro.Detail, { title: "Erro na requisição" });
		},

		aoMudarFiltroDeData: async function (oModel) {
			let modeloFiltro = oModel.getSource();
			let inicio = modeloFiltro.getProperty("dateValue");
			let fim = modeloFiltro.getProperty("secondDateValue");
			inicio = DateFormat.getDateInstance({ pattern: "yyyy-MM-ddTHH:mm:ss" }).format(inicio);
			fim = DateFormat.getDateInstance({ pattern: "yyyy-MM-ddTHH:mm:ss" }).format(fim);
			let urlComFiltro = "/api/Marca?";
			let params = new URLSearchParams(urlComFiltro.search);

			if ((inicio != null) && (fim != null)) {
				params.append("dataDeInicio", inicio);
				params.append("dataDeFim", fim);
				urlComFiltro += params.toString();
			}

			await this._obterListaDeMarcas(urlComFiltro);
		},

		aoClicarNaMarca: function (oEvent) {
			this.getOwnerComponent().getRouter().navTo(rotaPaginaDeDetalhesDaMarca,
				{ id: oEvent.getSource().getBindingContext(itensDaListaDeMarcas).getProperty(propriedadeIdDaMarcaDetalhada) },
				true);
		},

		aoClicarNoBotaoAdicionar: function () {
			const rotaAdicionarMarca = this.getOwnerComponent().getRouter();
			rotaAdicionarMarca.navTo(rotaPaginaDeAdicionarMarca);
		}
	});
});