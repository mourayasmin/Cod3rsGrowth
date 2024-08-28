sap.ui.define([
    "sap/ui/Opa5"
], (Opa5) => {
    "use strict";

    const nomeDaView = "ui5.wwwroot.app.Marca.ListaDeMarcas";

    Opa5.createPageObjects({
        naPaginaInicial: {
            actions: {
                hash: ""
            },
            assertions: {
                aTelaDeveSerCarregadaCorretamente: function () {
                    return this.waitFor({
                        viewName: nomeDaView,
                        success: () => Opa5.assert.ok(true, "A tela inicial foi carregada corretamente"),
                        errorMessage: "A tela inicial não foi carregada corretamente"
                    })
                }
            }
        }
    })
}
)