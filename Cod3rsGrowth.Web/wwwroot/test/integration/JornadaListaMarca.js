sap.ui.define([
    "sap/ui/test/opaQunit",
    "./pages/ListaDeMarcas",
    "./pages/DetalhesDaMarca",
    "./pages/AdicionarMarca",
    "ui5/wwwroot/test/integration/JornadaAdicionarMarca"
], function (opaQunit, ListaDeMarcas, DetalhesDaMarca, AdicionarMarca, JornadaAdicionarMarca) {
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
        }),

        opaTest("Ao clicar em uma marca, deve ir para a tela de detalhes", function (Given, When, Then){
            When.naPaginaInicial.aMarcaDeveSerPressionada();
            Then.naPaginaDeDetalhesDaMarca.aTelaDeDetalhesDaMarcaDeveSerCarregadaCorretamente();
        }),

        opaTest("Botão voltar na tela de detalhes das marcas deve voltar para a tela de lista de marcas", function(Given, When, Then){
            When.naPaginaDeDetalhesDaMarca.oBotaoVoltarDeveSerPressionado();
            Then.naPaginaInicial.aTelaDeveSerCarregadaCorretamente();
        }),

        opaTest("O filtro de pesquisa deve funcionar corretamente", function(Given, When, Then){
            When.naPaginaInicial.oTextoDoCampoDePesquisaDeveMudar();
            Then.naPaginaInicial.oResultadoDoCampoDePesquisaDeveSerCorreto();
        }),

        opaTest("O filtro de data deve funcionar corretamente", function(Given, When, Then){
            When.naPaginaInicial.asDatasDoCampoDeDataDevemMudar();
            Then.naPaginaInicial.oResultadoDoCampoDeDataDeveSerCorreto();
            Then.iTeardownMyApp();
        })
    });
})