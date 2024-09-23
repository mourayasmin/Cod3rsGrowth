sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History",
    "sap/ui/core/UIComponent",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/BusyIndicator",
    "ui5/wwwroot/app/model/formatter",
    "sap/m/MessageBox",
], (Controller, History, UIComponent, JSONModel, BusyIndicator, formatter, MessageBox) => {
    "use strict";
    const MODELO_DE_MARCAS = "modelMarcas";

    return {
        formatter: formatter,

        obterPorId: async function (id) {
            let url = `/api/Marca/${id}`;

            return fetch(url)
                .then(response => response.json())
                .then(response => this._ehErro(response));
        },

        salvarMarca: async function (corpoRequisicaoAdicaoEdicao) {
            return fetch("/api/Marca", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: corpoRequisicaoAdicaoEdicao
            })
            .then(response => response.json())
            .then(response => this._ehErro(response));
        },

        obterMarcaParaEditar: async function (id, view) {
            let url = `/api/Marca/${id}`;
            await fetch(url)
                .then(response => response.json())
                .then(response => {
                    let modeloParaEditar = new JSONModel();
                    response.telefone = this.formatter.formatadorDeTelefone(response.telefone);
                    response.cnpj = this.formatter.formatadorDeCNPJ(response.cnpj);
                    view.setModel(modeloParaEditar, MODELO_DE_MARCAS);
                    modeloParaEditar.setData(response);
                })
        },

        salvarEdicaoDeMarca: async function(marca, view) {
            return fetch("/api/Marca", {
                method: "PATCH",
                headers: {
                    "Content-Type": "application/json"
                },
                body: marca
            })
            .then(response => response.ok ? {} : response.json())
            .then(response => this._ehErro(response));


            // return fetch("/api/Marca", {
            //     method: "PATCH",
            //     headers: {
            //         "Content-Type": "application/json"
            //     },
            //     body: marca
            // })
            //     .then(async response => {
            //         if (response.ok) {
            //             let id = view.getModel("modelMarcas").getProperty("/id");
            //             this.aoClicarNaMensagemDeSucessoEditar(id, this);
            //         }
            //         else {
            //             let erro = Object.values(response.errors).join(",").split(",").join("\n");
            //             MessageBox.error(erro);
            //         }
            //     })
        },

        _ehErro(retorno) {
            let status = ( retorno || { Status : 200 });
            debugger
            if (retorno.Status >= 400 || retorno.Status <= 599) {
                throw new Error(retorno.Extensions);
            }

            return retorno;
        },
    }
});