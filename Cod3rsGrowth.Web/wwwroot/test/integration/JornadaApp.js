sap.ui.define([
      "sap/ui/test/opaQunit",
      "ui5/wwwroot/test/integration/pages/App"
  ], function (opaQunit, App) {
    "use strict";

    QUnit.module("App");
     
      opaTest("Should press a Button", function (Given, When, Then){

        Given.iStartMyUIComponent({
          componentConfig: {
              name: "ui5.wwwroot"
          }
      });

        When.naTelaInicial.iPressOnTheButton();

        Then.naTelaInicial.theButtonShouldHaveADifferentText();
    });
    });