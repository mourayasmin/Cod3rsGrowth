sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals"
], (Opa5, Press, PropertyStrictEquals) => {
    "use strict";

    const nomeDaView = ".Marca.ListaDeMarcas";
    const nomeDaViewAdicionarMarca = ".Marca.AdicionarMarca"

    Opa5.createPageObjects({
        naPaginaInicial: {
            actions: {
                oBotaoAdicionarDeveSerPressionado: function() {
                    return this.waitFor({
                        id:"idBotaoAdicionar",
                        viewName: nomeDaView,
                        actions: new Press(),
                        success: () => Opa5.assert.ok(true, "O botão de adicionar foi pressionado"),
                        errorMessage: "O botão de adicionar não foi pressionado"
                    });
                }
            },
            assertions: {
                aTelaDeveSerCarregadaCorretamente: function() {
                    return this.waitFor({
                        viewName: nomeDaView,
                        success: () => Opa5.assert.ok(true, "A tela inicial foi carregada corretamente"),
                        errorMessage: "A tela inicial não foi carregada corretamente"
                    })
                },

            }
        },
        naPaginaAdicionarMarca: {
            actions: {
                oBotaoVoltarDeveSerPressionado: function() {
                    return this.waitFor({
                        id:"paginaAdicionar",
                        // matchers: [
                        //     new Properties({
                        //         type: "Back"
                        //     })
                        // ],
                        // matchers: new PropertyStrictEquals ({
                        //     name: "type", 
                        //     type: "Back"
                        // }),
                        actions: new Press(),
                        viewName: nomeDaViewAdicionarMarca,
                        success: () => Opa5.assert.ok(true, "O botão de voltar na tela de adicionar foi pressionado"),
                        errorMessage: "O botão de voltar na tela de adicionar não foi pressionado"
                    })
                }
            },
            assertions: {
                aTelaAdicionarMarcaDeveSerCarregadaCorretamente: function() {
                    return this.waitFor({
                        viewName: nomeDaViewAdicionarMarca,
                        success: () => Opa5.assert.ok(true, "A tela de adicionar foi carregada corretamente"),
                        errorMessage: "A tela de adicionar não foi carregada corretamente"
                    })
                },
            }
        }
    })
}
)