sap.ui.define([
    "sap/ui/test/Opa5"
], function (Opa5) {
    "use strict";
 
    return Opa5.extend("ui5.wwwroot.test.integration.arrangements.Startup", {
        iStartMyApp: function () {
            const caminhoApp = "ui5.wwwroot";

            var opcoes = parametroOpcoes || {};
 
            opcoes.delay = opcoes.delay || 1;
 
            this.iStartMyUIComponent({
                componentConfig: {
                    name: caminhoApp,
                    manifest: true
                },
                hash: opcoes.hash,
                autoWait: opcoes.autoWait
            });
        },
    })
});
