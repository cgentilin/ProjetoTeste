using Projeto.Teste.Dominio.Entidades;

namespace Projeto.Teste.Testes.Dominio
{
    // Cada teste deve ser escrito no seu respectivo namespace por quest�o de organiza��o.
    // Neste aqui ficam os de dominio 

    //Exemplo de Testes Unit�rios, muitos outros poderiam ser realizados inclusive testes mocados "Mock"
    //para validar regras de neg�cio mais complexas e at� mesmo persistir dados em mem�ria para
    //validar a camada de persist�ncia. Contudo por absoluta sobrecarga de trabalho nesta semana em especial
    //n�o pude implement�-los nesta oportunidade.

    public class TesteUnitarioCliente
    {
        [Theory(DisplayName = "N�o valida cliente CPF diferene 11 d�gitos")]
        [InlineData("Charles", "charles.gentilin@gmail.com", "65149427", "", "41996434708", "1973-12-14")]
        [InlineData("Charles", "charles.gentilin@gmail.com", "65149427", " ", "41996434708", "1973-12-14")]
        [InlineData("Charles", "charles.gentilin@gmail.com", "65149427", "ab", "41996434708", "1973-12-14")]
        [InlineData("Charles", "charles.gentilin@gmail.com", "65149427", "550224561", "41996434708", "1973-12-14")]
        [InlineData("Charles", "charles.gentilin@gmail.com", "65149427", "5502245616888", "41996434708", "1973-12-14")]
        [InlineData("Charles", "charles.gentilin@gmail.com", "65149427", "550224561-68", "41996434708", "1973-12-14")]
        public void NaoValidaCPFCliente(string nome, string email, string rg, string documento, string fone, DateTime data)
        {
            var cliente = new Cliente()
            {
                Nome = nome,
                Email = email,
                RG = rg,
                Documento = documento,
                Fone = fone,
                DataNascimento = data
            };

            Assert.Throws<ArgumentException>(() => cliente.Validar());
            //Assert.True(cliente.Validar());
        }

        [Theory(DisplayName = "Valida cliente CPF 11 d�gitos")]
        [InlineData("Charles", "charles.gentilin@gmail.com", "65149427", "5502245616", "41996434708", "1973-12-14")]
        public void ValidaCPFCliente(string nome, string email, string rg, string documento, string fone, DateTime data)
        {
            var cliente = new Cliente()
            {
                Nome = nome,
                Email = email,
                RG = rg,
                Documento = documento,
                Fone = fone,
                DataNascimento = data
            };

            Assert.True(cliente.Validar());
        }
    }
}