sap.ui.define([], function () {
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

            if(entradaNome === null || entradaNome === "") {
                view.byId("campoNome").setValueState(statusDeErro);
            } else {
                view.byId("campoNome").setValueState(statusCorreto);
            }

            if(entradaEmail === null || entradaEmail === "" || !entradaEmail.match(re)) {
                view.byId("campoEmail").setValueState(statusDeErro)
            } else {
                view.byId("campoEmail").setValueState(statusCorreto);
            }

            if(entradaCNPJ === null || entradaCNPJ === "" || entradaCNPJ.length != 14) {
                view.byId("campoCNPJ").setValueState(statusDeErro);
            } else {
                view.byId("campoCNPJ").setValueState(statusCorreto);
            }

            if(entradaTelefone === null || entradaTelefone === "" || entradaTelefone.length != 11) {
                view.byId("campoTelefone").setValueState(statusDeErro);
            } else {
                view.byId("campoTelefone").setValueState(statusCorreto);
            }

            if(entradaDataDeCriacao === null || entradaDataDeCriacao === "" || entradaDataDeCriacao > diaHoje) {
                view.byId("campoDataDeCriacao").setValueState(statusDeErro);
            } else {
                view.byId("campoDataDeCriacao").setValueState(statusCorreto);
            }
        }
    }
})