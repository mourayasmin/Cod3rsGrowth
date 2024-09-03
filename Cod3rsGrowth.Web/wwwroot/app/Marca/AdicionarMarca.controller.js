sap.ui.define([
    "ui5/wwwroot/app/BaseController",
    "sap/m/MessageBox"
], function (BaseController, MessageBox) {
    "use strict";
    return BaseController.extend("ui5.wwwroot.app.Marca.AdicionarMarca", {
        onInit: function () {
			this.getOwnerComponent().getModel("modelMarcas");
            this.criarModeloParaEntrada();
       },

       criarModeloParaEntrada: function() {
        let modeloEntrada = {
            nome: "",
            email: "",
            cnpj: "",
            telefone: "", 
            dataDeCriacao: ""
        }
        this.getView().setModel(new sap.ui.model.json.JSONModel(modeloEntrada), "modelMarcas");
       },

       aoClicarNoBotaoSalvarNaTelaDeAdicionar: function() {
        let modeloAdicao = this.getView().getModel("modelMarcas").getData();
        let corpoRequisicaoAdicao = JSON.stringify(modeloAdicao);
        
        fetch("/api/Marca", {  
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: corpoRequisicaoAdicao
        })
        .then(response => {
            if (response.status === 201) {
                //this.aoClicarNaMensagemDeSucessoAdicionar();
                this.aoSalvarAdicaoComSucesso();
                aoClicarNaMensagemDeSucessoAdicionar();
            } else {
                const erro = "Erro na resposta do servidor";
                MessageBox.error(erro);
            }
            return response.json();
        })        
        },

        limparCamposDeEntrada: function() {
           this.getView().getModel("modelMarcas").setData({});
        },

        aoClicarNaMensagemDeSucessoAdicionar: function () {
			MessageBox.success("Marca criada com sucesso.");
		}
    });
 });