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
	});
}); 