using Newtonsoft.Json;

namespace BibliotecaPessoal.Models
{
    public enum TipoMensagem
    {
        Erro,
        Sucesso,
        Informacao
    }

    public class MensagemPartial
    {
        public TipoMensagem Tipo { get; set; }

        public string Mensagem { get; set; }

        public MensagemPartial(string menssagem, TipoMensagem tipo)
        {
            this.Tipo = tipo;
            this.Mensagem = menssagem;
        }

        public static string Serealizar(string mensagem, TipoMensagem tipo)
        {
            var Mensagem = new MensagemPartial(mensagem, tipo);
            return JsonConvert.SerializeObject(Mensagem);
        }
        
        public static MensagemPartial Deserializar(string mensagemString)
        {
            return JsonConvert.DeserializeObject<MensagemPartial>(mensagemString);
        }
    }
    
}