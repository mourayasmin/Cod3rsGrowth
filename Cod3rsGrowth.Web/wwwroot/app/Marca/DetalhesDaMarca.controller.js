sap.ui.define([
    "ui5/wwwroot/app/BaseController",
    "ui5/wwwroot/app/model/formatter"
], function (BaseController, formatter) {
    "use strict";
    const rotaPaginaDeListaDeMarcas = "paginaInicial";
    const rotaPaginaDeAdicionarMarca = "AdicionarMarca";
    const itensDaListaDeMarcas = "modelMarcas";
    var idModeloDetalhado = "";
    const rotaPaginaDeEditarMarca = "EditarMarca"
    return BaseController.extend("ui5.wwwroot.app.Marca.DetalhesDaMarca", {
        formatter: formatter,
        onInit: function () {
            this.vincularRota("DetalhesDaMarca", this.aoCoincidirRotaDaTelaDeDetalhes);
        },

        aoCoincidirRotaDaTelaDeDetalhes: async function (eventoURL) {
            idModeloDetalhado = eventoURL.getParameters().arguments.id
            return this.obterDetalhesDaMarca(idModeloDetalhado);
        },

        aoClicarNoBotaoDeVoltarNaTelaDeDetalhesDaMarca: function () {
            this.getOwnerComponent().getRouter().navTo(rotaPaginaDeListaDeMarcas, {}, true);
        },

        aoClicarNoBotaoEditar: function () {
            this.navegarParaEditarMarca(idModeloDetalhado);
		}
    });
});