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
            this.vincularRota(ROTA_PAGINA_DE_ADICIONAR_MARCA, this.aoCoincidirRotaDaTelaDeAdicionarMarca);
            this.vincularRota(ROTA_PAGINA_DE_EDITAR_MARCA, this.aoCoincidirRotaDaTelaDeEditarMarca);
        },

        aoCoincidirRotaDaTelaDeAdicionarMarca: function () {
            this.criarModeloParaEntrada();
            this.criarModeloParaControleDeTela();
            this.criarModeloParaControleDeTelaCNPJ();
        },

        aoCoincidirRotaDaTelaDeEditarMarca: async function (eventoURL) {
            this.statusDeCarregamentoDaTela(async () => {
                this.id = eventoURL.getParameters().arguments.id

                let parametrosDaURL = eventoURL.getParameter("arguments");
                let idMarcaParaEditar = parametrosDaURL.id;

                await RepositorioBase.obterMarcaParaEditar(idMarcaParaEditar, this.getView());

                this.criarModeloParaControleDeTela();
                this.criarModeloParaControleDeTelaCNPJ();
                this.getView().getModel("controleDeTela").setProperty("/ehEditavel", "Display");
                this.getView().getModel("controleDeTelaCNPJ").setProperty("/ehEditavelCNPJ", false);
            });
        },

        // obterMarcaParaEditar: async function (id) {
        //     let url = `/api/Marca/${id}`;
        //     await fetch(url)
        //         .then(response => response.json())
        //         .then(response => {
        //             let modeloParaEditar = new JSONModel();
        //             response.telefone = this.formatter.formatadorDeTelefone(response.telefone);
        //             response.cnpj = this.formatter.formatadorDeCNPJ(response.cnpj);
        //             this.getView().setModel(modeloParaEditar, MODELO_DE_MARCAS);
        //             modeloParaEditar.setData(response);
        //         })
        // },

        criarModeloParaControleDeTela: function () {
            let controle = {
                ehEditavel: "Editable"
            }
            this.getView().setModel(new JSONModel(controle), "controleDeTela");
        },

        criarModeloParaControleDeTelaCNPJ: function () {
            let controle = {
                ehEditavelCNPJ: true
            }
            this.getView().setModel(new JSONModel(controle), "controleDeTelaCNPJ");
        },

        criarModeloParaEntrada: function () {
            let modeloEntrada = {
                nome: "",
                email: "",
                cnpj: "",
                telefone: "",
                dataDeCriacao: ""
            }

            this.getView().setModel(new JSONModel(modeloEntrada), MODELO_DE_MARCAS);
        },

        aoClicarNoBotaoSalvar: function () {
            debugger
            let modeloAdicao = this.getView().getModel(MODELO_DE_MARCAS).getData();
            let view = this.getView();

            modeloAdicao.cnpj = modeloAdicao.cnpj.replace(/[^\w\s]/gi, '');
            modeloAdicao.telefone = modeloAdicao.telefone.replace(/[^\w\s]/gi, '');

            
            var ehMarcaValida = validacoesDeEntrada.validadorDeEntradas(modeloAdicao, view);
            let marca = JSON.stringify(modeloAdicao);

            if (ehMarcaValida) {
                if (this.id) {
                    this.editarMarca(marca);
                    this.navegar();
                } else {
                    this.criarMarca(marca);
                }
            }
        },

        navegar: function () {
            if (this.id)
                return this.navegarPara(ROTA_PAGINA_DE_DETALHES_MARCA, { id: this.id }, true);

            return this.navegarPara(ROTA_PAGINA_DE_LISTA);
        },

        limparCamposDeEntradaEValueState: function () {
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

        aoClicarNaMensagemDeSucessoAdicionar: function () {
            const mensagemDeSucessoAoAdicionarMarca = "Marca criada com sucesso.";
            MessageBox.success(mensagemDeSucessoAoAdicionarMarca);
        },

        _exibirMensagemDeSucesso: function(){
            MessageBox.success("Operação realizada com sucesso", {
                actions: [MessageBox.Action.OK],
                emphasizedAction: MessageBox.Action.OK,
                onClose: ()=> this._aoSalvarAdicaoComSucesso(id),
                dependentOn: this.getView()
            });
        },

        salvarMarca: async function () {
            return RepositorioBase.salvarMarca(marca)
                .then(() => this._exibirMensagemDeSucesso());
        },

        // salvarEdicaoDeMarca: async function(marca) {
        //     return fetch("/api/Marca", {
        //         method: "PATCH",
        //         headers: {
        //             "Content-Type": "application/json"
        //         },
        //         body: marca
        //     })
        //         .then(async response => {
        //             if (response.ok) {
        //                 let id = this.getView().getModel("modelMarcas").getProperty("/id");
        //                 this.aoClicarNaMensagemDeSucessoEditar(id, this);
        //             }
        //             else {
        //                 let erro = Object.values(response.errors).join(",").split(",").join("\n");
        //                 MessageBox.error(erro);
        //             }
        //         })
        // },

        exibirErro: function (response) {
            const detalhes = "Detalhes:";
            const titulo = "Erro";
            let erros = Object.values(response.Extensions.Erro).join(",").split(",").join("\n");
            let view = this.getView();

            MessageBox.error(`${response.Title} \n \n ${erros}`, {
                title: titulo,
                details:
                    `<p> <strong>${detalhes}` + `${response.Detail}`,
                styleClass: "sResponsivePaddingClasses",
                dependentOn: view
            })
        },

        aoClicarNoBotaoDeVoltarNaTelaDeAdicionarEditarMarca: function () {
            this.limparCamposDeEntradaEValueState();
            this.navegar()
        },

        aoClicarNoBotaoCancelarNaTelaDeAdicionar: function () {
            this.limparCamposDeEntradaEValueState();
            this.getOwnerComponent().getRouter().navTo(ROTA_PAGINA_DE_LISTA, {});
            this.navegarPara(ROTA_PAGINA_DE_LISTA);
        },

        _aoSalvarAdicaoComSucesso: async function (idMarcaAdicionada) {
            this.navegarPara(ROTA_PAGINA_DE_DETALHES_MARCA, { id: idMarcaAdicionada });
        },

        aoClicarNaMensagemDeSucessoEditar: function (id) {
            const mensagemDeSucessoAoEditarMarca = "Marca editada com sucesso.";
            MessageBox.success(mensagemDeSucessoAoEditarMarca, {
                actions: [MessageBox.Action.OK],
                emphasizedAction: MessageBox.Action.OK,
                onClose: function () {
                    this._aoSalvarAdicaoComSucesso(id);
                },
                dependentOn: this.getView()
            });
        },

        editarMarca: function (marca) {
            let response = RepositorioBase.salvarEdicaoDeMarca(marca, this.getView());
            this.aoClicarNaMensagemDeSucessoEditar(this.id);
        },

        criarMarca: async function (marca) {
            let response = await RepositorioBase.salvarMarca(marca);
            if (response.ok) {
                this.limparCamposDeEntradaEValueState();
                this.aoClicarNaMensagemDeSucessoAdicionar();
                response.json()
                    .then(async response =>
                        await this.aoSalvarAdicaoComSucesso(response.id),
                    )
            } else {
                response.json().then(response => {
                    this.exibirErro(response);
                })
            }
        }
    });
});