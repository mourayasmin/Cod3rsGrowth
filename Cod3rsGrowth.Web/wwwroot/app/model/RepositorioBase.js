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

        criar: async function (body) {
            return fetch("/api/Marca", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(body)
            })
                .then(response => response.json())
                .then(response => this._ehErro(response));
        },

        atualizar: async function (body) {
            return fetch("/api/Marca", {
                method: "PATCH",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(body)
            })
                .then(response => response.ok ? {} : response.json())
                .then(response => this._ehErro(response));
        },

        obterTodas: async function (url) {
            return fetch(url)
                .then(response => response.json())
                .then(response => this._ehErro(response))
        },

        remover: async function (id) {
            let url = `/api/Marca/${id}`;
            return fetch(url, {
                method: "DELETE",
                headers: {
                    "Content-Type": "application/json"
                },
            })
                .then(response => response.ok ? {} : response.json())
                .then(response => this._ehErro(response));
        },

        _ehErro(retorno) {
            let data = ({ status: retorno.Status || retorno.status });
            if (data.status >= 400 || data.status <= 599) {
                let mensagem = "";
                if (retorno?.errors) {
                    Object.entries(retorno.errors)[1][1].forEach(x => {
                        mensagem += `${x}\n`
                    })
                } else {
                    mensagem = retorno.Extensions.Erro;
                }
                let error = new Error(mensagem);
                error.stack = retorno.title
                throw error;
            }
            return retorno;
        },
    }
});