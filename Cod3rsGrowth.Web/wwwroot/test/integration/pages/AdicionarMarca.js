sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/Properties",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/actions/EnterText"
], (Opa5, Press, Properties, PropertyStrictEquals, EnterText) => {
    "use strict";

    const nomeDaViewAdicionarMarca = ".Marca.AdicionarMarca";

    Opa5.createPageObjects({
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
                        viewName: nomeDaViewAdicionarMarca,
                        matchers: [
                            new PropertyStrictEquals({
                                name: "text",
                                value: "Salvar"
                            })
                        ],
                        actions: new Press(),
                        success: () => Opa5.assert.ok(true, "O botão de salvar foi pressionado"),
                        errorMessage: "O botão de salvar não foi pressionado"
                    })
                },

                osCamposDaMarcaDevemSerPreenchidosCorretamente: function(id, valor) {
                    return this.waitFor({
                        viewName: ".Marca.AdicionarMarca",
                        id: id,
                        actions: new EnterText({text: valor}),
                        success: () => Opa5.assert.ok(true, "O campo foi preenchido"),
                        errorMessage: "O campo não foi preenchido"
                    });
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
        }
    })
}
)