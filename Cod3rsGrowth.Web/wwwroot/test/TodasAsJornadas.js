sap.ui.define([
    "sap/ui/test/Opa5",
    "ui5/wwwroot/test/integration/arrangements/Startup",
    "ui5/wwwroot/test/integration/JornadaListaMarca",
    "ui5/wwwroot/test/integration/JornadaAdicionarEditarMarca",
    "ui5/wwwroot/test/integration/JornadaDetalhesDaMarca"
], function (Opa5, Startup, JornadaListaMarca, JornadaAdicionarMarca, JornadaDetalhesDaMarca) {
    "use strict";
    
    Opa5.extendConfig({
        arrangements: new Startup(),
        viewNamespace: "ui5.wwwroot.app",
        autoWait: true
    });
});