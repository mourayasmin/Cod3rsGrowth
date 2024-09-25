sap.ui.define([
    "sap/ui/test/opaQunit",
    "ui5/wwwroot/test/integration/JornadaListaMarca",
    "./pages/AdicionarEditarMarca",
    "./pages/ListaDeMarcas",
    "./pages/DetalhesDaMarca",
    "ui5/wwwroot/app/model/formatter"
], function (opaQunit, JornadaListaMarca, AdicionarEditarMarca, ListaDeMarcas, DetalhesDaMarca, formatter) {
    "use strict";

    QUnit.module("EditarMarcas", () => {
        opaTest("Deve exibir a tela de edição de marcas", function(Given, When, Then) {
            Given.iStartMyUIComponent({
                componentConfig: {
                    name: "ui5.wwwroot",
                    manifest: true
                }
            }),
            When 
                .naPaginaInicial
                .aMarcaASerEditadaDeveSerPressionada();
            
            When    
                .naPaginaDeDetalhesDaMarca
                .oBotaoEditarDeveSerPressionado();

            Then
                .naPaginaAdicionarEditarMarca
                .aTelaAdicionarMarcaDeveSerCarregadaCorretamente();
        }),

        opaTest("Deve editar uma marca corretamente", function(Given, When, Then) {
            When
                .naPaginaAdicionarEditarMarca
                .oBotaoVoltarDeveSerPressionado();
        
            When
                .naPaginaDeDetalhesDaMarca
                .oBotaoVoltarDeveSerPressionado();

            When 
                .naPaginaInicial
                .aMarcaASerEditadaDeveSerPressionada();

            When
                .naPaginaDeDetalhesDaMarca
                .oBotaoEditarDeveSerPressionado();

            When  
                .naPaginaAdicionarEditarMarca
                .oCampoDeTelefoneDeveMudar("campoTelefone", "11933334444");
            
            When    
                .naPaginaAdicionarEditarMarca
                .oBotaoSalvarDeveSerPressionado();
            
            Then    
                .naPaginaAdicionarEditarMarca
                .aMensagemDeSucessoNaAdicaoEdicaoDeveSerExibida();
            
            Then 
                .naPaginaDeDetalhesDaMarca
                .aTelaDeDetalhesDaMarcaDeveSerCarregadaCorretamente();

            When 
                .naPaginaDeDetalhesDaMarca
                .oBotaoEditarDeveSerPressionado();
                
            Then 
                .iTeardownMyApp();
        })
    })
})