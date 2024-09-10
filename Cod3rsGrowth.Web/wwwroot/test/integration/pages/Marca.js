sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/Properties",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/actions/EnterText"
], (Opa5, Press, Properties, PropertyStrictEquals, EnterText) => {
    "use strict";

    const nomeDaView = ".Marca.ListaDeMarcas";
    const nomeDaViewAdicionarMarca = ".Marca.AdicionarMarca";
    const nomeDaViewDetalhesDaMarca = ".Marca.DetalhesDaMarca";

    Opa5.createPageObjects({
        naPaginaInicial: {
            actions: {
                oBotaoAdicionarDeveSerPressionado: function() {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        matchers: [
                            new PropertyStrictEquals({
                                name: "text",
                                value: "Adicionar"
                            })
                        ],
                        viewName: nomeDaView,
                        actions: new Press(),
                        success: () => Opa5.assert.ok(true, "O botão de adicionar foi pressionado"),
                        errorMessage: "O botão de adicionar não foi pressionado"
                    });
                },
                
                aMarcaDeveSerPressionada: function() {
                    return this.waitFor({
                        controlType: "sap.m.Link",
                        viewName: nomeDaView,
                        actions: new Press(),
                        success: () => Opa5.assert.ok(true, "A marca foi pressionada"),
                        errorMessage: "A marca não foi pressionada"
                    })
                },

                oTextoDoCampoDePesquisaDeveMudar: function() {
                    return this.waitFor({
                        controlType: "sap.m.SearchField",
                        viewName: nomeDaView,
                        actions: [
                            new EnterText({text: "nike", pressEnterKey: true})
                        ],
                        success: () => Opa5.assert.ok(true, "O campo de pesquisa mudou"),
                        errorMessage: "O campo de pesquisa não mudou"
                    });
                },

                asDatasDoCampoDeDataDevemMudar: function() {
                    return this.waitFor({
                        viewName: nomeDaView,
                        controlType: "sap.m.DateRangeSelection",
                        actions: [
                            new EnterText({text: "25 de jan. de 1964 - 25 de jan. de 1970", pressEnterKey: true})
                        ],
                        success: () => Opa5.assert.ok(true, "As datas do campo de data mudaram"),
                        errorMessage: "As datas do campo de data não mudaram"
                    })
                }
            },

            assertions: {
                aTelaDeveSerCarregadaCorretamente: function() {
                    return this.waitFor({
                        viewName: nomeDaView,
                        success: () => Opa5.assert.ok(true, "A tela inicial foi carregada corretamente"),
                        errorMessage: "A tela inicial não foi carregada corretamente"
                    });
                },

                oResultadoDoCampoDePesquisaDeveSerCorreto: function() {
                    return this.waitFor({
                        viewName: nomeDaView,
                        controlType: "sap.m.Link",
                        matchers: [
                            new PropertyStrictEquals({
                                name: "text",
                                value: "Nike do Brasil LTDA"
                            })
                        ],
                        success: () => Opa5.assert.ok(true, "O resultado do campo de pesquisa está correto"),
                        errorMessage: "O resultado do campo de pesquisa não está correto"
                    })
                },

                oResultadoDoCampoDeDataDeveSerCorreto: function() {
                    return this.waitFor({
                        viewName: nomeDaView,
                        controlType: "sap.m.Link",
                        matchers: [
                            new PropertyStrictEquals({
                                name: "text",
                                value: "Nike do Brasil LTDA"
                            },
                            new PropertyStrictEquals({
                                name: "text",
                                value: "Vans Do Brasil LTDA"
                            })
                        )
                        ],
                        success: () => Opa5.assert.ok(true, "O resultado do campo de data está correto"),
                        errorMessage: "O resultado do campo de data não está correto"
                    })
                },

                aMarcaAdicionadaDeveEstarNaListaDeMarcas: function() {
                    return this.waitFor({
                        viewName: nomeDaView,
                        controlType: "sap.m.Link",
                        matchers: [
                            new PropertyStrictEquals({
                                name:"text",
                                value: "Marca OPA"
                            })
                        ],
                        success: () => Opa5.assert.ok(true, "A marca adicionada está na lista de marcas"),
                        errorMessage: "A marca adicionada não está na lista de marcas"
                    })
                }
            }
        },

        naPaginaAdicionarMarca: {
            actions: {
                oBotaoVoltarDeveSerPressionado: function() {
                    return this.waitFor({
                        matchers: [
                            new Properties({
                                type: "Back"
                            })
                        ],
                        actions: new Press(),
                        viewName: nomeDaViewAdicionarMarca,
                        success: () => Opa5.assert.ok(true, "O botão de voltar na tela de adicionar foi pressionado"),
                        errorMessage: "O botão de voltar na tela de adicionar não foi pressionado"
                    });
                },

                oBotaoSalvarDeveSerPressionado: function() {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        matchers: [
                            new PropertyStrictEquals({
                                name: "text",
                                value: "Salvar"
                            })
                        ],
                        viewName: nomeDaViewAdicionarMarca,
                        actions: new Press(),
                        success: () => Opa5.assert.ok(true, "O botão de salvar foi pressionado"),
                        errorMessage: "O botão de salvar não foi pressionado"
                    })
                },

                osCamposDaMarcaDevemSerPreenchidosCorretamente: function(id, valor) {
                    return this.waitFor({
                        viewName: nomeDaViewAdicionarMarca,
                        success: () => {
                            this.waitFor({
                                viewName: nomeDaViewAdicionarMarca,
                                id: id,
                                actions: new EnterText({text: valor, pressEnterKey: true}),
                                success: () => Opa5.assert.ok(true, "O campo foi preenchido"),
                                errorMessage: "O campo não foi preenchido"
                            });
                        },
                        errorMessage: "Os campos da marca não foram preenchidos corretamente"
                    })
                }
            },

            assertions: {
                aTelaAdicionarMarcaDeveSerCarregadaCorretamente: function() {
                    return this.waitFor({
                        viewName: nomeDaViewAdicionarMarca,
                        success: () => Opa5.assert.ok(true, "A tela de adicionar foi carregada corretamente"),
                        errorMessage: "A tela de adicionar não foi carregada corretamente"
                    });
                },

                aMensagemDeErroDeveSerExibidaEFechada: function() {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                            matchers: [
                                new PropertyStrictEquals({
                                    name:"text",
                                    value: "Fechar"
                                })
                            ],
                            viewName: nomeDaViewAdicionarMarca,
                            actions: new Press(),
                            success: () => Opa5.assert.ok(true, "A mensagem de erro foi exibida e fechada"),
                            errorMessage: "A mensagem de erro não foi exibida e fechada"
                    })
                }
            }
        },

        naPaginaDeDetalhesDaMarca: {
            actions: {
                oBotaoVoltarDeveSerPressionado: function() {
                    return this.waitFor({
                        matchers: [
                            new Properties({
                                type: "Back"
                            })
                        ],
                        actions: new Press(),
                        viewName: nomeDaViewDetalhesDaMarca,
                        success: () => Opa5.assert.ok(true, "O botão de voltar na tela de detalhes foi pressionado"),
                        errorMessage: "O botão de voltar na tela de detalhes não foi pressionado"
                    })
                }
            },

            assertions: {
                aTelaDeDetalhesDaMarcaDeveSerCarregadaCorretamente: function() {
                    return this.waitFor({
                        viewName: nomeDaViewDetalhesDaMarca,
                        success: () => Opa5.assert.ok(true, "A tela de detalhes foi carregada corretamente"),
                        errorMessage: "A tela de detalhes não foi carregada corretamente"
                    });
                },
            }
        }
    })
}
)