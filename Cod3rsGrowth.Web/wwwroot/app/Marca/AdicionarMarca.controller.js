sap.ui.define([
    "ui5/wwwroot/app/BaseController",
    "sap/m/MessageBox",
    "ui5/wwwroot/app/Marca/Validacoes/validacoesDeEntrada",
    "sap/ui/model/json/JSONModel"
], function (BaseController, MessageBox, validacoesDeEntrada, JSONModel) {
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
                dataDeCriacao: "2090-01-29T14:23:14.057Z"
            }

            this.getView().setModel(new JSONModel(modeloEntrada), "modelMarcas");        
    },

       aoClicarNoBotaoSalvarNaTelaDeAdicionar: function() {

        var view = this.getView();
        let modeloAdicao = view.getModel("modelMarcas").getData();

        modeloAdicao.cnpj = modeloAdicao.cnpj.replace(/[^\w\s]/gi, '');
        modeloAdicao.telefone = modeloAdicao.telefone.replace(/[^\w\s]/gi, '');
        let corpoRequisicaoAdicao = JSON.stringify(modeloAdicao);

        //var ehMarcaValida = 
        validacoesDeEntrada.validadorDeEntradas(modeloAdicao, view);

        //if(ehMarcaValida) {
            this.salvarMarca(corpoRequisicaoAdicao);
        //}
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
                if (response.ok) {
                    this.limparCamposDeEntrada();
                    this.aoClicarNaMensagemDeSucessoAdicionar();
                    this.aoSalvarAdicaoComSucesso();
                } else {
                    response.json().then(response => {
                        this.exibirErro(response);
                    })
                }
            })
        }, 

        exibirErro: function(response) {
            const detalhes = "Detalhes:";
            const validacoes = "Erros de validação:";
            const titulo = "Erro";
            let erros = Object.values(response.Extensions.Erro).join("\n");
            //let erros = Object.values(response.Extensions.Erro).split(",").join("\n");
            debugger
            MessageBox.error(`${response.Title} \n \n ${erros}`, {
                title: titulo,
                details:              
                `<p> <strong>${validacoes} ${erros}` +
                `<p> <strong>${detalhes}` + `${response.Detail}`,
                styleClass: "sResponsivePaddingClasses",
                dependentOn: this.getView()
            })
        }
    });
 });