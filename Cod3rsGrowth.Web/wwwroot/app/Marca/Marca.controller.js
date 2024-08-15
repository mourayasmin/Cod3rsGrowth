sap.ui.define([
	"ui5/wwwroot/app/BaseController"
], function (BaseController) {
	"use strict";
	return BaseController.extend("ui5.wwwroot.app.Marca.Marca", {
        onInit: function() {
          
            var that = this;
            window.setTimeout(function() {
                that.byId("pressMeButton").setVisible(true);
            }, Math.random() * 10000);
        },

        onPress: function() {
            this.byId("pressMeButton").setText("I got pressed");
      }
	});
});