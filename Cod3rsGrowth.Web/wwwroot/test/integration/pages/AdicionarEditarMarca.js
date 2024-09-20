sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/Properties",
    "sap/ui/test/matchers/PropertyStrictEquals",
    "sap/ui/test/actions/EnterText"
], (Opa5, Press, Properties, PropertyStrictEquals, EnterText) => {
    "use strict";

    const nomeDaViewAdicionarEditarMarca = ".Marca.AdicionarEditarMarca";

    Opa5.createPageObjects({
        naPaginaAdicionarEditarMarca: {
            actions: {
                oBotaoVoltarDeveSerPressionado: function() {
                    return this.waitFor({
                        matchers: [
                            new Properties({
                                type: "Back"
                            })
                        ],
                        actions: new Press(),
                        viewName: nomeDaViewAdicionarEditarMarca,
                        success: () => Opa5.assert.ok(true, "O botão de voltar na tela de adicionar foi pressionado"),
                        errorMessage: "O botão de voltar na tela de adicionar não foi pressionado"
                    });
                },

                oBotaoSalvarDeveSerPressionado: function() {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        viewName: nomeDaViewAdicionarEditarMarca,
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
                        viewName: nomeDaViewAdicionarEditarMarca,
                        id: id,
                        actions: new EnterText({text: valor}),
                        success: () => Opa5.assert.ok(true, "O campo foi preenchido"),
                        errorMessage: "O campo não foi preenchido"
                    });
                },

                oCampoDeTelefoneDeveMudar: function(id, telefone) {
                    return this.waitFor({
                        viewName: nomeDaViewAdicionarEditarMarca,
                        id: id,
                        actions: new EnterText({text: telefone}),
                        success: () => Opa5.assert.ok(true, "O campo telefone foi preenchido"),
                        errorMessage: "O campo telefone não foi preenchido"
                    })
                }
            },

            assertions: {
                aTelaAdicionarMarcaDeveSerCarregadaCorretamente: function() {
                    return this.waitFor({
                        viewName: nomeDaViewAdicionarEditarMarca,
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
                            viewName: nomeDaViewAdicionarEditarMarca,
                            actions: new Press(),
                            success: () => Opa5.assert.ok(true, "A mensagem de erro foi exibida e fechada"),
                            errorMessage: "A mensagem de erro não foi exibida e fechada"
                    })
                },

                aMensagemDeSucessoNaEdicaoDeveSerExibida: function() {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        searchOpenDialogs: true, 
                        viewName: nomeDaViewAdicionarEditarMarca,
                        matchers: [
                            new PropertyStrictEquals({
                                name: "text",
                                value: "Ok"
                            })
                        ],
                        actions: new Press(),
                        success: () => Opa5.assert.ok(true, "A mensagem de sucesso na edição foi exibida e fechada"),
                        errorMessage: "A mensagem de sucesso na edição não foi exibida ou fechada"
                    })
                }
            }
        }
    })
}
)