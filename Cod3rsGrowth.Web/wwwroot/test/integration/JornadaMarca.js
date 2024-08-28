sap.ui.define([
    "sap/ui/test/opaQunit",
    "./pages/Marca"
], function (opaQunit,
    Marca) {
        "use strict";
        QUnit.module("ListaDeMarcas", () =>  {
            opaTest("Deve exibir a tela de lista de marcas", function(Given, Then) {
        
                Given.iStartMyApp({
                })

                Then.naPaginaInicial.aTelaDeveSerCarregadaCorretamente();

            });
    });
})