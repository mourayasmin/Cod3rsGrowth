sap.ui.define([
    "ui5/wwwroot/app/BaseController",
    "sap/m/MessageBox",
    "ui5/wwwroot/app/Marca/Validacoes/validacoesDeEntrada"
], function (BaseController, MessageBox, validacoesDeEntrada) {
    "use strict";
    return BaseController.extend("ui5.wwwroot.app.Marca.AdicionarMarca", {
        onInit: function () {
			this.getOwnerComponent().getModel("modelMarcas");
            this.criarModeloParaEntrada();

            // const rotaTelaDeAdicionar = "AdicionarMarca";
            // this.getOwnerComponent().getRouter().getRoute(rotaTelaDeAdicionar).attachMatched(this.aoCarregarTelaDeAdicionar, this);
       },
//onpageshow
       

    //    aoCarregarTelaDeAdicionar: function(rotaTelaDeAdicionar) {
    //         rotaAtual = this.getRouter();
    //         if(rotaAtual === rotaTelaDeAdicionar) {
    //             this.limparCamposDeEntrada();
    //         }
    //     },

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
                    this.limparCamposDeEntrada();
                    const erroServidor = "Erro na resposta do servidor";
                    MessageBox.error(erroServidor);
                } else {
                    const erroCadastro = "Erro no cadastro."
                    MessageBox.error(erroCadastro);
                }
                return response.json();
            }) 
        }
    });
 });