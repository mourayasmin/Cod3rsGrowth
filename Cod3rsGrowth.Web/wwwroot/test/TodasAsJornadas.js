sap.ui.define([
    "sap/ui/test/Opa5",
    "ui5/wwwroot/test/integration/arrangements/Startup",
    "ui5/wwwroot/test/integration/JornadaMarca",
    "ui5/wwwroot/test/integration/pages/Marca"
], function (Opa5, Startup, JornadaMarca, Marca) {
    "use strict";
    
    Opa5.extendConfig({
        arrangements: new Startup(),
        viewNamespace: "ui5.wwwroot.app",
        autoWait: true
    });
});