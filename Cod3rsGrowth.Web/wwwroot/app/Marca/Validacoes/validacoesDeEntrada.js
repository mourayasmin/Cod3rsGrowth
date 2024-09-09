sap.ui.define([
    "sap/m/MessageBox",
], function (MessageBox) {
    "use strict";
    return {
        validadorDeEntradas: function(marca, view) {
            let entradaNome = marca.nome;
            let entradaEmail = marca.email;
            let entradaCNPJ = marca.cnpj;
            let entradaTelefone = marca.telefone;
            let entradaDataDeCriacao = marca.dataDeCriacao;
            let diaHoje = new Date();
            const re =/^\S+@\S+\.\S+$/;
            const statusDeErro = "Error";
            const statusCorreto = "None";
            var ehValido = true;

            if(entradaNome) {
                view.byId("campoNome").setValueState(statusCorreto);
            } else {
                ehValido = false;
                view.byId("campoNome").setValueState(statusDeErro);
            }

            if(entradaEmail.match(re)) {
                view.byId("campoEmail").setValueState(statusCorreto);
            } else {
                ehValido = false;
                view.byId("campoEmail").setValueState(statusDeErro)
            }

            if(entradaCNPJ.length != 14) {
                ehValido = false;
                view.byId("campoCNPJ").setValueState(statusDeErro);
            } else {
                view.byId("campoCNPJ").setValueState(statusCorreto);
            }

            if(entradaTelefone.length != 11) {
                ehValido = false;
                view.byId("campoTelefone").setValueState(statusDeErro);
            } else {
                view.byId("campoTelefone").setValueState(statusCorreto);
            }

            if(entradaDataDeCriacao > diaHoje) {
                ehValido = false;
                view.byId("campoDataDeCriacao").setValueState(statusDeErro);
            } else {
                view.byId("campoDataDeCriacao").setValueState(statusCorreto);
            }

            if(!ehValido) {
                this.mostrarMessageBoxDeErroDePreenchimento();
            }
        }, 

        mostrarMessageBoxDeErroDePreenchimento: function() {
            MessageBox.error("Preencha todos os campos corretamente.");
        }
    }
})