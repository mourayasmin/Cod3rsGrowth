sap.ui.define([
    "sap/ui/test/opaQunit",
    "ui5/wwwroot/test/integration/JornadaListaMarca",
    "./pages/AdicionarEditarMarca",
    "./pages/ListaDeMarcas",
    "./pages/DetalhesRemocaoDaMarca",
    "ui5/wwwroot/app/model/formatter"
], function (opaQunit, JornadaListaMarca, AdicionarEditarMarca, ListaDeMarcas, DetalhesRemocaoDaMarca, formatter) {
    "use strict";

    QUnit.module("RemoverMarcas", () => {
        opaTest("Deve exibir a tela de detalhes de marcas", function (Given, When, Then) {
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

            opaTest("A marca deve ser removida corretamente", function (Given, When, Then) {
                When
                    .naPaginaDeDetalhesDaMarca
                    .oBotaoRemoverDeveSerPressionado();

                Then
                    .naPaginaDeDetalhesDaMarca
                    .oBotaoDeConfirmarARemocaoDeveSerPressionado();

                Then
                    .naPaginaDeDetalhesDaMarca
                    .aMensagemDeSucessoNaRemocaoDeveSerExibidaEFechada();

                Then
                    .naPaginaInicial
                    .aTelaDeveSerCarregadaCorretamente();

                Then
                    .iTeardownMyApp();
            })
    })
})