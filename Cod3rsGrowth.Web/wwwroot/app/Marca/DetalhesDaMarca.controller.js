sap.ui.define([
    "ui5/wwwroot/app/BaseController",
    "ui5/wwwroot/app/model/formatter",
	"sap/ui/model/json/JSONModel",
    "ui5/wwwroot/app/model/RepositorioBase"
], function (BaseController, formatter, JSONModel, RepositorioBase) {
    "use strict";
    const ROTA_PAGINA_DE_LISTA_DE_MARCAS = "paginaInicial";
    const ROTA_PAGINA_DE_ADICIONAR_MARCA = "AdicionarMarca";
    const ROTA_PAGINA_DE_EDITAR_MARCA = "EditarMarca"
    const ITENS_DA_LISTA_DE_MARCAS = "modelMarcas";
    var idModeloDetalhado = "";

    return BaseController.extend("ui5.wwwroot.app.Marca.DetalhesDaMarca", {
        formatter: formatter,
        onInit: function () {
            this.vincularRota("DetalhesDaMarca", this._aoCoincidirRotaDaTelaDeDetalhes);
        },

        _aoCoincidirRotaDaTelaDeDetalhes: function (evento) {
            this.statusDeCarregamentoDaTela(() => {
                let id = evento.getParameter("arguments").id
                debugger
                return RepositorioBase.obterPorId(id)
                    .then(marca => {
                        this.getView().setModel(new JSONModel(marca), ITENS_DA_LISTA_DE_MARCAS);
                    });
            });
        },

        aoClicarNoBotaoDeVoltarNaTelaDeDetalhesDaMarca: function () {
            this.getOwnerComponent().getRouter().navTo(ROTA_PAGINA_DE_LISTA_DE_MARCAS, {}, true);
        },

        aoClicarNoBotaoEditar: function () {
            let id = this.getView().getModel(ITENS_DA_LISTA_DE_MARCAS).getProperty("/id");
            this.navegarPara(ROTA_PAGINA_DE_EDITAR_MARCA, { id });
        }
    });
});