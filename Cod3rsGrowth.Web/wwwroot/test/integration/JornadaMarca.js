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

    QUnit.module("AdicionarMarcas", () => {
        opaTest("Deve exibir a tela de adicionar marcas", function(Given, When, Then) {
    
            Given.iStartMyUIComponent({
                    componentConfig: {
                    name: "ui5.wwwroot",
                    manifest: true
                }
                }),
            When.naPaginaInicial.oBotaoAdicionarDeveSerPressionado();    
            Then.naPaginaAdicionarMarca.aTelaAdicionarMarcaDeveSerCarregadaCorretamente();
        }),

        opaTest("Deve exibir uma mensagem de erro ao tentar salvar uma marca com campos vazios", function(Given, When, Then){
            When.naPaginaAdicionarMarca.oBotaoSalvarDeveSerPressionado();
            Then.naPaginaAdicionarMarca.aMensagemDeErroDeveSerExibida();
        }),

        opaTest("Deve adicionar uma marca com dados corretos", function(Given, When, Then){
            //When.naPaginaAdicionarMarca.osCamposDaMarcaDevemSerPreenchidosCorretamente();
            When.naPaginaAdicionarMarca.oCampoNomeDeveSerPreenchidoCorretamente();
            When.naPaginaAdicionarMarca.oCampoEmailDeveSerPreenchidoCorretamente();
            When.naPaginaAdicionarMarca.oBotaoSalvarDeveSerPressionado();
            Then.naPaginaInicial.aMarcaAdicionadaDeveEstarNaListaDeMarcas();
        })
    });
})