sap.ui.define([
	"ui5/wwwroot/app/BaseController",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator"
], function (BaseController, Filter, FilterOperator) {
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

		onSearch: function(oEvent) {
			 var aFilters = [];
			 var sQuery = oEvent.getSource().getValue();

			 if(sQuery && sQuery.length > 0) {
			 	var filter = new Filter("nome", FilterOperator.Contains, sQuery);
			 	aFilters.push(filter);
			}

			  var oList = this.byId("idListaDeMarcas");
			  var oBinding = oList.getBinding("items");
			  oBinding.filter(aFilters, "Application");
		}
	});
}); 