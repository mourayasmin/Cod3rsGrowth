sap.ui.define([
    "sap/ui/test/opaQunit",
    "ui5/wwwroot/test/integration/JornadaListaMarca",
    "ui5/wwwroot/test/integration/JornadaAdicionarEditarMarca",
    "./pages/AdicionarEditarMarca",
    "./pages/ListaDeMarcas",
    "./pages/DetalhesDaMarca",
    "ui5/wwwroot/app/model/formatter"
], function (opaQunit, JornadaListaMarca, JornadaAdicionarEditarMarca, AdicionarEditarMarca, ListaDeMarcas, DetalhesDaMarca, formatter) {
    "use strict";

    QUnit.module("DetalhesDaMarca", () => {
        opaTest("Deve exibir a tela de detalhes", function (Given, When, Then){
            Given.iStartMyUIComponent({
                componentConfig: {
                    name: "ui5.wwwroot",
                    manifest: true,
                    hash: "DetalhesDaMarca"
                }
            }),
            When
                .naPaginaInicial
                .aMarcaDeveSerPressionada();
                
            Then 
                .naPaginaDeDetalhesDaMarca
                .aTelaDeDetalhesDaMarcaDeveSerCarregadaCorretamente();
        }),
        
        opaTest("Botão editar na tela de detalhes deve ir para a tela de edição", function (Given, When, Then) {
            When
                .naPaginaDeDetalhesDaMarca
                .oBotaoEditarDeveSerPressionado();

            Then
                .naPaginaAdicionarMarca
                .aTelaAdicionarMarcaDeveSerCarregadaCorretamente();

            When    
                .naPaginaAdicionarMarca
                .oBotaoVoltarDeveSerPressionado();

            Then
                .naPaginaInicial
                .aTelaDeveSerCarregadaCorretamente();

            When    
                .naPaginaInicial
                .aMarcaDeveSerPressionada();

            Then    
                .naPaginaDeDetalhesDaMarca
                .aTelaDeDetalhesDaMarcaDeveSerCarregadaCorretamente();
        }),

        opaTest("Botão voltar na tela de detalhes deve ir para a tela de lista", function(Given, When, Then) {
            When    
                .naPaginaDeDetalhesDaMarca
                .oBotaoVoltarDeveSerPressionado();

            Then
                .naPaginaInicial
                .aTelaDeveSerCarregadaCorretamente();
            
            Then
                .iTeardownMyApp();
        })
    })
})