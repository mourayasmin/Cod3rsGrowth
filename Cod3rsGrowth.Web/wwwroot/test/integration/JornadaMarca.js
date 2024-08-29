sap.ui.define([
    "sap/ui/test/opaQunit",
    "./pages/Marca"
], function (opaQunit, Marca) {
        "use strict";
        QUnit.module("ListaDeMarcas", () =>  {
            opaTest("Deve exibir a tela de lista de marcas", function(Given, When, Then) {
        

                Given.iStartMyUIComponent({
                        componentConfig: {
                        name: "ui5.wwwroot",
                        manifest: true
                    }
                    }),
                Then.naPaginaInicial.aTelaDeveSerCarregadaCorretamente();
            }),
            
            opaTest("Botão adicionar deve ir para a tela de adicionar", function(Given, When, Then){
                When.naPaginaInicial.oBotaoAdicionarDeveSerPressionado();
                Then.naPaginaAdicionarMarca.aTelaAdicionarMarcaDeveSerCarregadaCorretamente();
            }),

            opaTest("Botão voltar na tela de adicionar marcas deve voltar para a tela de lista de marcas", function(Given, When, Then){
                When.naPaginaAdicionarMarca.oBotaoVoltarDeveSerPressionado();
                Then.naPaginaInicial.aTelaDeveSerCarregadaCorretamente();
            })
    });
})