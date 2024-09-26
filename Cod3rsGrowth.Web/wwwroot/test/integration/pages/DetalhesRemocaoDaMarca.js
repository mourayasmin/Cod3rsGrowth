sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/Properties",
    "sap/ui/test/matchers/PropertyStrictEquals"
], (Opa5, Press, Properties, PropertyStrictEquals) => {
    "use strict";

    const nomeDaViewDetalhesDaMarca = ".Marca.DetalhesDaMarca";
    
    Opa5.createPageObjects({
        naPaginaDeDetalhesDaMarca: {
            actions: {
                oBotaoVoltarDeveSerPressionado: function() {
                    return this.waitFor({
                        viewName: nomeDaViewDetalhesDaMarca,
                        matchers: [
                            new Properties({
                                type: "Back"
                            })
                        ],
                        actions: new Press(),
                        success: () => Opa5.assert.ok(true, "O botão de voltar na tela de detalhes foi pressionado"),
                        errorMessage: "O botão de voltar na tela de detalhes não foi pressionado"
                    })
                },

                oBotaoEditarDeveSerPressionado: function() {
                    return this.waitFor({
                        viewName: nomeDaViewDetalhesDaMarca,
                        controlType: "sap.m.Button",
                        matchers: [
                            new PropertyStrictEquals({
                                name: "text",
                                value: "Editar"
                            })
                        ],
                        actions: new Press(),
                        success: () => Opa5.assert.ok(true, "O botão de edição foi pressionado"),
                        errorMessage: "O botão de edição não foi pressionado"
                    });
                },

                oBotaoRemoverDeveSerPressionado: function() {
                    return this.waitFor({
                        viewName: nomeDaViewDetalhesDaMarca,
                        controlType: "sap.m.Button",
                        matchers: [
                            new PropertyStrictEquals({
                                name: "text",
                                value: "Remover"
                            })
                        ],
                        actions: new Press(),
                        success: () => Opa5.assert.ok(true, "O botão de remoção foi pressionado"),
                        errorMessage: "O botão de remoção não foi pressionado"
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

                oBotaoDeConfirmarARemocaoDeveSerPressionado: function() {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        searchOpenDialogs: true, 
                        matchers: [
                            new PropertyStrictEquals({
                                name: "text",
                                value: "Sim"
                            })
                        ],
                        actions: new Press(),
                        success: () => Opa5.assert.ok(true, "O botão de confirmar a remoção foi pressionado"),
                        errorMessage: "O botão de confirmar a remoção foi pressionado"
                    })
                },

                aMensagemDeSucessoNaRemocaoDeveSerExibidaEFechada: function() {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        searchOpenDialogs: true, 
                        matchers: [
                            new PropertyStrictEquals({
                                name: "text",
                                value: "OK"
                            })
                        ],
                        actions: new Press(),
                        success: () => Opa5.assert.ok(true, "A mensagem de sucesso na remoção foi exibida e fechada"),
                        errorMessage: "A mensagem de sucesso na remoção não foi exibida ou fechada"
                    })
                }
            }
        }
    })
})