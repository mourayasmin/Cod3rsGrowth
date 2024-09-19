sap.ui.define([
    "ui5/wwwroot/app/BaseController",
    "sap/m/MessageBox",
    "ui5/wwwroot/app/Marca/Validacoes/validacoesDeEntrada",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/format/DateFormat",
    "ui5/wwwroot/app/model/formatter"
], function (BaseController, MessageBox, validacoesDeEntrada, JSONModel, DateFormat, formatter) {
    "use strict";
    const rotaPaginaDeListaDeMarcas = "paginaInicial";
    const rotaPaginaDeAdicionarMarca = "AdicionarMarca";
    const rotaPaginaDeDetalhesDaMarca = "DetalhesDaMarca";
    const modeloDeMarcas = "modelMarcas";
    const rotaPaginaDeEditarMarca = "EditarMarca";

    return BaseController.extend("ui5.wwwroot.app.Marca.AdicionarEditarMarca", {
        formatter: formatter,

        onInit: function () {
            this.getOwnerComponent().getModel(modeloDeMarcas);
            this.vincularRota(rotaPaginaDeAdicionarMarca, this.aoCoincidirRotaDaTelaDeAdicionarMarca);
            this.vincularRota(rotaPaginaDeEditarMarca, this.aoCoincidirRotaDaTelaDeEditarMarca);
        },

        aoCoincidirRotaDaTelaDeAdicionarMarca: function () {
            this.criarModeloParaEntrada();
            this.criarModeloParaControleDeTela();
            this.criarModeloParaControleDeTelaCNPJ();
        },

        aoCoincidirRotaDaTelaDeEditarMarca: function (eventoURL) {
            let idModeloDetalhado = eventoURL.getParameters().arguments.id
            if (idModeloDetalhado) {
                let parametrosDaURL = eventoURL.getParameter("arguments");
                let idMarcaParaEditar = parametrosDaURL.id;
                if (idMarcaParaEditar) {
                    this.obterMarcaParaEditar(idMarcaParaEditar);
                }
            }
            this.criarModeloParaControleDeTela();
            this.criarModeloParaControleDeTelaCNPJ();
            this.getView().getModel("controleDeTela").setProperty("/ehEditavel", "Display");
            this.getView().getModel("controleDeTelaCNPJ").setProperty("/ehEditavelCNPJ", false);
        },

        obterMarcaParaEditar: async function (id) {
            let url = `/api/Marca/${id}`;
            await fetch(url)
                .then(response => response.json())
                .then(response => {
                    let modeloParaEditar = new JSONModel();
                    response.telefone = this.formatter.formatadorDeTelefone(response.telefone);
                    response.cnpj = this.formatter.formatadorDeCNPJ(response.cnpj);
                    response.dataDeCriacao = this.formatter.formatarDataDeCadastro(response.dataDeCriacao);

                    this.getView().setModel(modeloParaEditar, modeloDeMarcas);
                    modeloParaEditar.setData(response);
                })
        },

        criarModeloParaControleDeTela: function () {
            let controle = {
                ehEditavel: "Editable"
            }
            this.getView().setModel(new JSONModel(controle), "controleDeTela");
        },

        criarModeloParaControleDeTelaCNPJ: function() {
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

            this.getView().setModel(new JSONModel(modeloEntrada), modeloDeMarcas);
        },

        aoClicarNoBotaoSalvarNaTelaDeAdicionar: function () {
            let modeloAdicao = this.getView().getModel(modeloDeMarcas).getData();
            let idMarcaParaEditar = modeloAdicao.id;
            let view = this.getView();
debugger
            if (modeloAdicao.cnpj && modeloAdicao.telefone) {
                debugger
                modeloAdicao.cnpj = modeloAdicao.cnpj.replace(/[^\w\s]/gi, '');
                modeloAdicao.telefone = modeloAdicao.telefone.replace(/[^\w\s]/gi, '');
            }
            let corpoRequisicaoAdicaoEdicao = JSON.stringify(modeloAdicao);
            var ehMarcaValida = validacoesDeEntrada.validadorDeEntradas(modeloAdicao, view);
            debugger
            if (ehMarcaValida) {
                this.salvarMarca(corpoRequisicaoAdicaoEdicao, idMarcaParaEditar);
            }
        },

        limparCamposDeEntradaEValueState: function () {
            const statusCorreto = "None";
            const idCampoNomeDaMarca = "campoNome";
            const idCampoEmailDaMarca = "campoEmail";
            const idCampoCNPJDaMarca = "campoCNPJ";
            const idCampoTelefoneDaMarca = "campoTelefone";
            const idCampoDataDeCriacaoDaMarca = "campoDataDeCriacao";

            this.getView().getModel(modeloDeMarcas).setData({});
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

        salvarMarca: async function (corpoRequisicaoAdicaoEdicao, idMarcaParaEditar) {
            if (idMarcaParaEditar) {
                let url = `/api/Marca/`
                return fetch(url, {
                    method: "PATCH",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: corpoRequisicaoAdicaoEdicao
                })
                    .then(async response => {
                        if (response.ok) {
                            await this.aoSalvarAdicaoComSucesso(idMarcaParaEditar)
                        }
                        else {
                            response.json()
                                .then(response => {
                                    this.exibirErro(response);
                                })
                        }
                    })
            } else {
                return fetch("/api/Marca", {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: corpoRequisicaoAdicaoEdicao
                })
                    .then(async response => {
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
                    })
            }
        },

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

        aoClicarNoBotaoDeVoltarNaTelaDeAdicionarMarca: function () {
            this.limparCamposDeEntradaEValueState();
            this.getOwnerComponent().getRouter().navTo(rotaPaginaDeListaDeMarcas, {}, true);
        },

        aoClicarNoBotaoCancelarNaTelaDeAdicionar: function () {
            this.limparCamposDeEntradaEValueState();
            this.getOwnerComponent().getRouter().navTo(rotaPaginaDeListaDeMarcas, {}, true);
        },

        aoSalvarAdicaoComSucesso: async function (idMarcaAdicionada) {
            debugger
            await this.obterDetalhesDaMarca(idMarcaAdicionada);
            this.getOwnerComponent().getRouter().navTo(rotaPaginaDeDetalhesDaMarca, { id: idMarcaAdicionada }, true);
        }
    });
});