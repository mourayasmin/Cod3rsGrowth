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
            const numeroDeDigitosCNPJ = 14;
            const numeroDeDigitosTelefone = 11;
            const idCampoNomeDaMarca = "campoNome";
            const idCampoEmailDaMarca = "campoEmail";
            const idCampoCNPJDaMarca = "campoCNPJ";
            const idCampoTelefoneDaMarca = "campoTelefone";
            const idCampoDataDeCriacaoDaMarca = "campoDataDeCriacao";
            var ehValido = true;

            if(entradaNome) {
                view.byId(idCampoNomeDaMarca).setValueState(statusCorreto);
            } else {
                ehValido = false;
                view.byId(idCampoNomeDaMarca).setValueState(statusDeErro);
            }

            if(entradaEmail.match(re)) {
                view.byId(idCampoEmailDaMarca).setValueState(statusCorreto);
            } else {
                ehValido = false;
                view.byId(idCampoEmailDaMarca).setValueState(statusDeErro)
            }

            if(entradaCNPJ.length != numeroDeDigitosCNPJ) {
                ehValido = false;
                view.byId(idCampoCNPJDaMarca).setValueState(statusDeErro);
            } else {
                view.byId(idCampoCNPJDaMarca).setValueState(statusCorreto);
            }

            if(entradaTelefone.length != numeroDeDigitosTelefone) {
                ehValido = false;
                view.byId(idCampoTelefoneDaMarca).setValueState(statusDeErro);
            } else {
                view.byId(idCampoTelefoneDaMarca).setValueState(statusCorreto);
            }

            if(entradaDataDeCriacao > diaHoje) {
                ehValido = false;
                view.byId(idCampoDataDeCriacaoDaMarca).setValueState(statusDeErro);
            } else {
                view.byId(idCampoDataDeCriacaoDaMarca).setValueState(statusCorreto);
            }

            if(!ehValido) {
                this._mostrarMessageBoxDeErroDePreenchimento();
            }
        }, 

        _mostrarMessageBoxDeErroDePreenchimento: function() {
            const mensagem = "Preencha todos os campos corretamente.";
            throw new Error(mensagem);
        }
    }
})