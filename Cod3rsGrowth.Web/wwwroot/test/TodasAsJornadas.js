sap.ui.define([
    "sap/ui/test/Opa5",
    "ui5/wwwroot/test/integration/Startup",
    "ui5/wwwroot/test/integration/JornadaMarca"
], function (Opa5) {
    "use strict";
    
    Opa5.extendConfig({
        arrangements: new Startup(),
        viewNamespace: "ui5.wwwroot.app",
        autoWait: true
    });
});