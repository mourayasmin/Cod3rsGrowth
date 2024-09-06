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
                dataDeCriacao: "0001-01-29T14:23:14.057Z"
            }

            this.getView().setModel(new JSONModel(modeloEntrada), "modelMarcas");        
    },

       aoClicarNoBotaoSalvarNaTelaDeAdicionar: function() {

        //Se o modelo estiver vazio não deve ir ao servidor
        //Se a validação não passar. não deve ir ao servidor

        var view = this.getView();
        let modeloAdicao = view.getModel("modelMarcas").getData();

        modeloAdicao.cnpj = modeloAdicao.cnpj.replace(/[^\w\s]/gi, '');
        modeloAdicao.telefone = modeloAdicao.telefone.replace(/[^\w\s]/gi, '');
        let corpoRequisicaoAdicao = JSON.stringify(modeloAdicao);

        //var ehMarcaValida = validacoesDeEntrada.validadorDeEntradas(modeloAdicao, view);

        //if(!ehMarcaValida) return
    
        this.salvarMarca(corpoRequisicaoAdicao);
        },

        limparCamposDeEntrada: function() {
           this.getView().getModel("modelMarcas").setData({});
        },

        aoClicarNaMensagemDeSucessoAdicionar: function () {
			MessageBox.success("Marca criada com sucesso.");
		},

        salvarMarca(corpoRequisicaoAdicao) {
            debugger
            fetch("/api/Marca", {  
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: corpoRequisicaoAdicao
                
            })
            .then(response => {
                if (response.ok) {
                    debugger
                    this.limparCamposDeEntrada();
                    this.aoClicarNaMensagemDeSucessoAdicionar();
                    this.aoSalvarAdicaoComSucesso();
                } else {
                    debugger
                    response.json().then(response => {
                        this.exibirErro(response);
                    })
                }
            })
        }, 

        exibirErro: function(response) {
            let mensagemDeErro = "";
            const detalhes = "Detalhes";
            const status = "Status";
            const titulo = "Erro"
            debugger
            console.log(response);
            let erros = Object.keys(response.Extensions.Erro);
            // response.Extensions.Erro.forEach((erros) => {
            //     erros.forEach( (mensagem) => {
            //         mensagemDeErro += mensagem + "\n";
            //     })
            // })
            erros.forEach( nomeDoErro => {
                mensagemDeErro += erros + "\n";
                response.Extensions.Erro[mensagemDeErro].forEach(mensagem => {
                    mensagemDeErro += mensagem + "\n" 
                })
            }) 

            MessageBox.error(`${response.Title} \n \n`, {
                title: `${titulo}`,
                details:              
                `<p> <strong>${status}: ${mensagemDeErro}` +
                `<p> <strong>${detalhes}` + `${response.Detail}`,
                styleClass: "sResponsivePaddingClasses",
                dependentOn: this.getView()
            })
        }
    });
 });