namespace Cod3rsGrowth.Forms
{
    public class Mensagens
    {
        public static void MostrarMensagemDeErro(string mensagem)
        {
            const string tituloMensagemDeErro = "Erro";
            MessageBox.Show(mensagem, tituloMensagemDeErro, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void MostrarMensagemDeSucesso(string mensagem)
        {
            const string tituloMensagemDeSucesso = "Sucesso";
            MessageBox.Show(mensagem, tituloMensagemDeSucesso, MessageBoxButtons.OK);
        }
    }
}
