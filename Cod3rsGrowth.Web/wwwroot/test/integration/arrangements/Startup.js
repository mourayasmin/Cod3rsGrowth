sap.ui.define([
    "sap/ui/test/Opa5",
    "ui5/wwwroot/test/integration/Startup",
], function (Opa5, Startup) {
    "use strict";
 
    Opa5.extendConfig({
        arrangements: new Startup(),
        viewNamespace: "ui5.wwwroot",
        autoWait: true
    });
});