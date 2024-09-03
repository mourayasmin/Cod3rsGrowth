sap.ui.define([
    "sap/ui/core/UIComponent"
 ], (UIComponent) => {
    "use strict";
 
    return UIComponent.extend("ui5.wwwroot.Component", {
       metadata : {
          interfaces: ["sap.ui.core.IAsyncContentCreation"],
          manifest: "json"
       },
 
       init: function() {
          UIComponent.prototype.init.apply(this, arguments);
          this.getRouter().initialize();
       }
    });
 });