sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals",
    
], (Opa5, Press, PropertyStrictEquals) => {
    "use strict";

    Opa5.createPageObjects({
        naTelaInicial: {
            actions: {
                iPressOnTheButton : function () {
                    return this.waitFor({
                        viewName : "ui5.wwwroot.app.App",
                        id : "pressMeButton",
                        actions : new Press(),
                        errorMessage : "did not find the Button"
                    });
                }
            },

            assertions: {
                theButtonShouldHaveADifferentText : function () {
                    return this.waitFor({
                        viewName : "ui5.wwwroot.app.App",
                        id : "pressMeButton",
                        matchers : new PropertyStrictEquals({
                            name : "text",
                            value : "I got pressed"
                        }),
                        success : function (oButton) {
                            Opa5.assert.ok(true, "The button's text changed to: " + oButton.getText());
                        },
                        errorMessage : "did not change the Button's text"
                    });
                }
            }
        }
    });
});