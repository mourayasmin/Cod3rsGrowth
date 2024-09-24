sap.ui.define([
    "ui5/wwwroot/app/BaseController",
    "sap/m/MessageBox",
    "ui5/wwwroot/app/Marca/Validacoes/validacoesDeEntrada",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/routing/History",
    "ui5/wwwroot/app/model/formatter",
    "ui5/wwwroot/app/model/RepositorioBase"
], function (BaseController, MessageBox, validacoesDeEntrada, JSONModel, History, formatter, RepositorioBase) {
    "use strict";
    const ROTA_PAGINA_DE_LISTA = "paginaInicial";
    const ROTA_PAGINA_DE_ADICIONAR_MARCA = "AdicionarMarca";
    const ROTA_PAGINA_DE_DETALHES_MARCA = "DetalhesDaMarca";
    const MODELO_DE_MARCAS = "modelMarcas";
    const ROTA_PAGINA_DE_EDITAR_MARCA = "EditarMarca";

    return BaseController.extend("ui5.wwwroot.app.Marca.AdicionarEditarMarca", {
        formatter: formatter,
        id: null,

        onInit: function () {
            this.getOwnerComponent().getModel(MODELO_DE_MARCAS);
            this.vincularRota(ROTA_PAGINA_DE_ADICIONAR_MARCA, this._aoCoincidirRotaCriacao);
            this.vincularRota(ROTA_PAGINA_DE_EDITAR_MARCA, this._aoCoincidirRotaDaTelaDeEditarMarca);
        },

        _inicializarModelos: function(ehEditavel, ehEditavelCNPJ) {
            this.getView().setModel(new JSONModel({
                nome: "",
                email: "",
                cnpj: "",
                telefone: "",
                dataDeCriacao: ""
            }), MODELO_DE_MARCAS);

            this.getView().setModel(new JSONModel({
                ehEditavel: ehEditavel
            }), "controleDeTela");
            
            this.getView().setModel(new JSONModel({
                ehEditavelCNPJ: ehEditavelCNPJ
            }), "controleDeTelaCNPJ");
        },

        _limparCamposDeEntradaEValueState: function () {
            const statusCorreto = "None";
            const idCampoNomeDaMarca = "campoNome";
            const idCampoEmailDaMarca = "campoEmail";
            const idCampoCNPJDaMarca = "campoCNPJ";
            const idCampoTelefoneDaMarca = "campoTelefone";
            const idCampoDataDeCriacaoDaMarca = "campoDataDeCriacao";

            this.getView().getModel(MODELO_DE_MARCAS).setData({});
            this.getView().byId(idCampoNomeDaMarca).setValueState(statusCorreto);
            this.getView().byId(idCampoEmailDaMarca).setValueState(statusCorreto);
            this.getView().byId(idCampoCNPJDaMarca).setValueState(statusCorreto);
            this.getView().byId(idCampoTelefoneDaMarca).setValueState(statusCorreto);
            this.getView().byId(idCampoDataDeCriacaoDaMarca).setValueState(statusCorreto);
        },

        _exibirMensagemDeSucesso: function(mensagem, id){
            MessageBox.success(mensagem, {
                actions: [MessageBox.Action.OK],
                emphasizedAction: MessageBox.Action.OK,
                onClose: ()=> this._aoSalvarAdicaoComSucesso(id),
                dependentOn: this.getView()
            });
        },

        _obterMarcaPorId: function(id){
            return RepositorioBase.obterPorId(id)
                .then(response => {
                    response.telefone = this.formatter.formatadorDeTelefone(response.telefone);
                    response.cnpj = this.formatter.formatadorDeCNPJ(response.cnpj);
                    this.getView().setModel(new JSONModel(response), MODELO_DE_MARCAS);
                });
        },

        _editarMarca: function (marca) {
            return RepositorioBase.atualizar(marca)
                .then(response => {
                    const mensagem = "Marca editada com sucesso";
                    this._limparCamposDeEntradaEValueState();
                    this._exibirMensagemDeSucesso(mensagem, marca.id);
                });
        },

        _criarMarca: async function (modelo) {
            return RepositorioBase.criar(modelo)
                .then(response => {
                    const mensagem = "Marca criada com sucesso"
                    this._limparCamposDeEntradaEValueState();
                    this._exibirMensagemDeSucesso(mensagem, response.id);
                });
        },

        _navegar: function (id) {
            if (id)
                return this.navegarPara(ROTA_PAGINA_DE_DETALHES_MARCA, { id }, true);

            return this.navegarPara(ROTA_PAGINA_DE_LISTA);
        },

        _aoCoincidirRotaCriacao: function () {
            this.statusDeCarregamentoDaTela(() => {
                this._inicializarModelos("Editable", true);
            });
        },

        _aoCoincidirRotaDaTelaDeEditarMarca: async function (evento) {
            this.statusDeCarregamentoDaTela(async () => {
                let id = evento.getParameter("arguments").id;
                this._inicializarModelos("Display", false);
                await this._obterMarcaPorId(id);
            });
        },

        _obterMarca: function(){
            let modelo = this.getView().getModel(MODELO_DE_MARCAS).getData();
            modelo.cnpj = modelo.cnpj.replace(/[^\w\s]/gi, '');
            modelo.telefone = modelo.telefone.replace(/[^\w\s]/gi, '');

            validacoesDeEntrada.validadorDeEntradas(modelo, this.getView());
            return modelo;
        },

        _salvar: function(marca){
            if (marca.id)
                return this._editarMarca(marca);

            return this._criarMarca(marca);
        },

        aoClicarNoBotaoSalvar: function () {
            this.statusDeCarregamentoDaTela(() => {
                let marca = this._obterMarca();
                return this._salvar(marca);
            });
        },

        aoClicarNoBotaoDeVoltarNaTelaDeAdicionarEditarMarca: function () {
            let modelo = this.getView().getModel(MODELO_DE_MARCAS).getData();
            this._limparCamposDeEntradaEValueState();
            this._navegar(modelo.id);
        },

        aoClicarNoBotaoCancelarNaTelaDeAdicionar: function () {
            this._limparCamposDeEntradaEValueState();
            this.getOwnerComponent().getRouter().navTo(ROTA_PAGINA_DE_LISTA, {});
            this.navegarPara(ROTA_PAGINA_DE_LISTA);
        },

        _aoSalvarAdicaoComSucesso: function (id) {
            this.navegarPara(ROTA_PAGINA_DE_DETALHES_MARCA, { id });
        },
    });
});