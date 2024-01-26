using Projeto.Teste.Dominio.Entidades;

namespace Projeto.Teste.Testes.Dominio
{
    // Cada teste deve ser escrito no seu respectivo namespace por questão de organização.
    // Neste aqui ficam os de dominio 

    //Exemplo de Testes Unitários, muitos outros poderiam ser realizados inclusive testes mocados "Mock"
    //para validar regras de negócio mais complexas e até mesmo persistir dados em memória para
    //validar a camada de persistência. Contudo por absoluta sobrecarga de trabalho nesta semana em especial
    //não pude implementá-los nesta oportunidade.

    public class TesteUnitarioCliente
    {
        [Theory(DisplayName = "Não valida cliente CPF diferene 11 dígitos")]
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

        [Theory(DisplayName = "Valida cliente CPF 11 dígitos")]
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