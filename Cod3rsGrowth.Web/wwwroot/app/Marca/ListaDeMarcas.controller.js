sap.ui.define([
	"ui5/wwwroot/app/BaseController",
	"sap/m/MessageBox"
], function (BaseController, MessageBox, JSONModel) {
	"use strict";
	return BaseController.extend("ui5.wwwroot.app.Marca.ListaDeMarcas", {
		onInit: function () {
			this.obterListaDeMarcas("https://localhost:7172/api/Marca");
		},

		obterListaDeMarcas: function(url) {
			
 			fetch(url) 
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

		onSearch: function(oModel) {

			let modeloFiltro = oModel.getSource().getValue("nome");
			let url = "api/Marca?";
			let params = new URLSearchParams(url.search); 

			if(modeloFiltro != null) {
				params.append("nome", modeloFiltro); 
				url += params.toString(); 
			}

			this.obterListaDeMarcas(url);
		},

		naMensagemDeErro: function(mensagemDeErro) {
			mensagemDeErro.Title = "Erro na requisição";
			MessageBox.error(mensagemDeErro);
		}
	});
});