sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/Properties"
], (Opa5, Press, Properties) => {
    "use strict";

    const nomeDaViewDetalhesDaMarca = ".Marca.DetalhesDaMarca";
    
    Opa5.createPageObjects({
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
                        errorMessage: "O botão de edição foi pressionado"
                    });
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
})