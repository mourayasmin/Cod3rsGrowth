sap.ui.define([], () => {
  "use strict";

  return {
    formatadorDeCNPJ: function (cnpj) {

      cnpj = cnpj.replace(/(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/, '$1.$2.$3/$4-$5');
      return cnpj;
    },

    formatadorDeTelefone: function (telefone) {
      telefone = telefone.replace(/^(\d\d)(\d{5})(\d{0,4}).*/, "($1)$2-$3");
      return telefone;
    },

    formatarCNPJ: function (cnpj) {
      if (cnpj != undefined) {
        return cnpj.replace(/(\d{2})(\d{3})?(\d{3})(\d{4})(\d{2})/, "$1.$2.$3/$4-$5");
      }
      return cnpj;
    },

    formatarDataDeCadastro(dataDeCriacao) {
      if (!dataDeCriacao) {
        return ""
      }

      const stringBarra = "/";
      const stringDataLocalPtBr = "pt-BR";
      const padStart = 2;
      const stringZero = "0";
      const ajusteMesJaneiro = 1;
      let dataFormatada = new Date(dataDeCriacao);
      dataFormatada.toLocaleDateString(stringDataLocalPtBr);
      let dia = dataFormatada
        .getDate()
        .toString()
        .padStart(padStart, stringZero);
      let mes = (dataFormatada.getMonth() + ajusteMesJaneiro)
        .toString()
        .padStart(padStart, stringZero);
      let ano = dataFormatada.getFullYear();
      return dia + stringBarra + mes + stringBarra + ano;
    },
  }
});