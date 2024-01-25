using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Teste.Dominio.DTO
{
    public class Resultado<T> where T : class 
    {
        public T? Data { get; private set; }
        public bool Sucesso { get; private set; }
        public string SucessoMensagem { get; private set; }
        public string ErroMensagem { get; private set; }

        public Resultado(T data, bool sucesso, string mensagem)
        {
            Data = data;
            Sucesso = sucesso;
            if (sucesso)
                SucessoMensagem = mensagem;
            else
                ErroMensagem = mensagem;
        }

        public Resultado(bool sucesso, string mensagem)
        {
            Data = null;
            Sucesso = sucesso;
            if (sucesso)
                SucessoMensagem = mensagem;
            else
                ErroMensagem = mensagem;
        }
    }
}
