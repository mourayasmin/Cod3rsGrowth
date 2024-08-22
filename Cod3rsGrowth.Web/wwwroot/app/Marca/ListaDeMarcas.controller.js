sap.ui.define([
	"ui5/wwwroot/app/BaseController"
], function (BaseController) {
	"use strict";
	return BaseController.extend("ui5.wwwroot.app.Marca.ListaDeMarcas", {
		onInit: function () {
			this.obterListaDeMarcas()
		},

		obterListaDeMarcas: function() {
			var oModel = new sap.ui.model.json.JSONModel({
			});
		oModel.loadData("/api/Marca");
		this.getView().setModel(oModel, "modelMarcas");
		},

		onSearch: function(oModel) {
			//let modeloFiltro = oModel.getProperty("/nome");
			//let modeloFiltro = oModel.getSource().getValue("nome");
			//let nomePesquisado = this._modeloFiltro().getProperty("/nome");
			debugger
			let modeloFiltro = oModel.getSource().getValue("nome");

			let url = "https://localhost:7172/api/Marca?";
			//SE NOME PESQUISADO VAZIO NÃO DEVE FAZER:
			let params = new URLSearchParams(url.search);

			if(!modeloFiltro == null) {
				params.append("nome", modeloFiltro);
			}

			url += params.toString();
			fetch(url)
			.then(response => response.json()) 
			.then(Marca => console.log(Marca));
			//oModel.loadData("/api/Marca?nome=${sQuery}");
		}
	});
});