sap.ui.define([
    "sap/ui/test/opaQunit",
    "./pages/ListaDeMarcas",
    "./pages/DetalhesRemocaoDaMarca",
    "./pages/AdicionarEditarMarca",
    "ui5/wwwroot/test/integration/JornadaAdicionarMarca",
    "ui5/wwwroot/test/integration/JornadaEditarMarca"
], function (opaQunit, ListaDeMarcas, DetalhesRemocaoDaMarca, AdicionarEditarMarca, JornadaAdicionarMarca, JornadaEditarMarca) {
    "use strict";
    QUnit.module("ListaDeMarcas", () =>  {
        opaTest("Deve exibir a tela de lista de marcas", function(Given, When, Then) {
    
            Given.iStartMyUIComponent({
                    componentConfig: {
                    name: "ui5.wwwroot",
                    manifest: true
                    }
            }),
            Then
                .naPaginaInicial    
                .aTelaDeveSerCarregadaCorretamente();
        }),
        
        opaTest("Botão adicionar deve ir para a tela de adicionar", function(Given, When, Then){
            When    
                .naPaginaInicial
                .oBotaoAdicionarDeveSerPressionado();
            Then
                .naPaginaAdicionarEditarMarca
                .aTelaAdicionarMarcaDeveSerCarregadaCorretamente();
        }),

        opaTest("Botão voltar na tela de adicionar marcas deve voltar para a tela de lista de marcas", function(Given, When, Then){
            When
                .naPaginaAdicionarEditarMarca
                .oBotaoVoltarDeveSerPressionado();
            Then
                .naPaginaInicial
                .aTelaDeveSerCarregadaCorretamente();
        }),

        opaTest("Ao clicar em uma marca, deve ir para a tela de detalhes", function (Given, When, Then){
            When
                .naPaginaInicial
                .aMarcaDeveSerPressionada();
            Then
                .naPaginaDeDetalhesDaMarca
                .aTelaDeDetalhesDaMarcaDeveSerCarregadaCorretamente();
        }),

        opaTest("Botão voltar na tela de detalhes das marcas deve voltar para a tela de lista de marcas", function(Given, When, Then){
            When
                .naPaginaDeDetalhesDaMarca
                .oBotaoVoltarDeveSerPressionado();
            Then
                .naPaginaInicial
                .aTelaDeveSerCarregadaCorretamente();
        }),

        opaTest("O filtro de pesquisa deve funcionar corretamente", function(Given, When, Then){
            When
                .naPaginaInicial
                .oTextoDoCampoDePesquisaDeveMudar();
            Then
                .naPaginaInicial
                .oResultadoDoCampoDePesquisaDeveSerCorreto();
        }),

        opaTest("O filtro de data deve funcionar corretamente", function(Given, When, Then){
            When
                .naPaginaInicial
                .asDatasDoCampoDeDataDevemMudar();
            Then
                .naPaginaInicial
                .oResultadoDoCampoDeDataDeveSerCorreto();
            Then
                .iTeardownMyApp();
        })
    });
})