sap.ui.define([
    "ui5/wwwroot/app/BaseController",
    "sap/m/MessageBox",
    "ui5/wwwroot/app/Marca/Validacoes/validacoesDeEntrada"
], function (BaseController, MessageBox, validacoesDeEntrada, ListaDeMarcas) {
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
        modeloAdicao.cnpj = modeloAdicao.cnpj.replace(/[^\w\s]/gi, '');
        modeloAdicao.telefone = modeloAdicao.telefone.replace(/[^\w\s]/gi, '');
        var view = this.getView();
        let corpoRequisicaoAdicao = JSON.stringify(modeloAdicao);

        validacoesDeEntrada.validadorDeEntradas(modeloAdicao, view);
    
        this.salvarMarca(corpoRequisicaoAdicao);
        },

        limparCamposDeEntrada: function() {
           this.getView().getModel("modelMarcas").setData({});
        },

        aoClicarNaMensagemDeSucessoAdicionar: function () {
			MessageBox.success("Marca criada com sucesso.");
		},

        salvarMarca(corpoRequisicaoAdicao) {
            fetch("/api/Marca", {  
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: corpoRequisicaoAdicao
            })
            .then(response => {
                if (response.status === 201) {
                    this.limparCamposDeEntrada();
                    this.aoClicarNaMensagemDeSucessoAdicionar();
                    this.aoSalvarAdicaoComSucesso();
                } else if(response.status === 400){
                    MessageBox.error("Erro na requisição. Preencha os campos corretamente.")
                } else {
                    response.text().then(function (text) {
                        MessageBox.error("Erro no servidor", text);
                    });
                }
                return response.json();
            }) 
        }
    });
 });