sap.ui.define([
    "sap/ui/test/opaQunit",
    "ui5/wwwroot/test/integration/JornadaListaMarca",
    "./pages/AdicionarEditarMarca",
    "./pages/ListaDeMarcas",
    "./pages/DetalhesDaMarca",
    "ui5/wwwroot/app/model/formatter"

], function (opaQunit, JornadaListaMarca, AdicionarEditarMarca, ListaDeMarcas, DetalhesDaMarca, formatter) { 
    "use strict";

    function gerarCnpj() {
        let create_array = (total, numero) => Array.from(Array(total), () => number_random(numero));
        let number_random = (number) => (Math.round(Math.random() * number));
        let mod = (dividendo, divisor) => Math.round(dividendo - (Math.floor(dividendo / divisor) * divisor));

        let total_array = 8;
        let n = 9;
        let [n1, n2, n3, n4, n5, n6, n7, n8] = create_array(total_array, n);
        let n9 = 0;
        let n10 = 0;
        let n11 = 0;
        let n12 = 1;

        let d1 = n12 * 2 + n11 * 3 + n10 * 4 + n9 * 5 + n8 * 6 + n7 * 7 + n6 * 8 + n5 * 9 + n4 * 2 + n3 * 3 + n2 * 4 + n1 * 5;
        d1 = 11 - (mod(d1, 11));
        if (d1 >= 10) d1 = 0;

        let d2 = d1 * 2 + n12 * 3 + n11 * 4 + n10 * 5 + n9 * 6 + n8 * 7 + n7 * 8 + n6 * 9 + n5 * 2 + n4 * 3 + n3 * 4 + n2 * 5 + n1 * 6;
        d2 = 11 - (mod(d2, 11));
        if (d2 >= 10) d2 = 0;
        return `${n1}${n2}${n3}${n4}${n5}${n6}${n7}${n8}${n9}${n10}${n11}${n12}${d1}${d2}`;
    }

    QUnit.module("AdicionarMarcas", () => {
        opaTest("Deve exibir a tela de adicionar marcas", function(Given, When, Then) {

            Given.iStartMyUIComponent({
                componentConfig: {
                    name: "ui5.wwwroot",
                    manifest: true
                }
            }),
            When
                .naPaginaInicial
                .oBotaoAdicionarDeveSerPressionado();    

            Then
                .naPaginaAdicionarMarca
                .aTelaAdicionarMarcaDeveSerCarregadaCorretamente();
        }),

        opaTest("Deve adicionar uma marca com dados corretos", function(Given, When, Then) {
            let cnpjGerado = gerarCnpj();
            let cnpjFormatado = "CNPJ: " + formatter.formatadorDeCNPJ(cnpjGerado);

            When
                .naPaginaAdicionarMarca
                .osCamposDaMarcaDevemSerPreenchidosCorretamente("campoNome", "Marca Teste OPA")
                .osCamposDaMarcaDevemSerPreenchidosCorretamente("campoEmail", "teste@opa.com")
                .osCamposDaMarcaDevemSerPreenchidosCorretamente("campoCNPJ", cnpjGerado)
                .osCamposDaMarcaDevemSerPreenchidosCorretamente("campoTelefone", "11965258741")
                .osCamposDaMarcaDevemSerPreenchidosCorretamente("campoDataDeCriacao", "1 de set. de 2022");

           When
                .naPaginaAdicionarMarca
                .oBotaoSalvarDeveSerPressionado();

            Then
                .naPaginaDeDetalhesDaMarca
                .aTelaDeDetalhesDaMarcaDeveSerCarregadaCorretamente();

            When 
                .naPaginaDeDetalhesDaMarca
                .oBotaoVoltarDeveSerPressionado();

            Then
                .naPaginaInicial    
                .aMarcaAdicionadaDeveEstarNaListaDeMarcas(cnpjFormatado);
            
            When
                .naPaginaInicial
                .oBotaoAdicionarDeveSerPressionado(); 

            Then
                .naPaginaAdicionarMarca
                .aTelaAdicionarMarcaDeveSerCarregadaCorretamente();

            Then 
                .iTeardownMyApp();
        })
    }),
})