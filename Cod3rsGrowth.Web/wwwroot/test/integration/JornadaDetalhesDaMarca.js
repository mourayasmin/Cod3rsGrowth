sap.ui.define([
    "sap/ui/test/opaQunit",
    "ui5/wwwroot/test/integration/JornadaListaMarca",
    "ui5/wwwroot/test/integration/JornadaAdicionarMarca",
    "ui5/wwwroot/test/integration/JornadaEditarMarca",
    "./pages/AdicionarEditarMarca",
    "./pages/ListaDeMarcas",
    "./pages/DetalhesRemocaoDaMarca",
    "ui5/wwwroot/app/model/formatter"
], function (opaQunit, JornadaListaMarca, JornadaAdicionarMarca, JornadaEditarMarca, AdicionarEditarMarca, ListaDeMarcas, DetalhesRemocaoDaMarca, formatter) {
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
                .naPaginaAdicionarEditarMarca
                .aTelaAdicionarMarcaDeveSerCarregadaCorretamente();

            When    
                .naPaginaAdicionarEditarMarca
                .oBotaoVoltarDeveSerPressionado();

            Then
                .naPaginaDeDetalhesDaMarca
                .aTelaDeDetalhesDaMarcaDeveSerCarregadaCorretamente();

            When
                .naPaginaDeDetalhesDaMarca
                .oBotaoVoltarDeveSerPressionado();

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