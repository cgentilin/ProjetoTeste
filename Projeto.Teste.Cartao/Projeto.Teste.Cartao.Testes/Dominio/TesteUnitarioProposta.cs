using Projeto.Teste.Cartao.Dominio.Entidades;
using Projeto.Teste.Cartao.Dominio.Enum;

namespace Projeto.Teste.Cartao.Testes.Dominio
{
    public class TesteUnitarioProposta
    {
        //Exemplo de Testes Unitários, muitos outros poderiam ser realizados inclusive testes mocados "Mock"
        //para validar regras de negócio mais complexas e até mesmo persistir dados em memória para
        //validar a camada de persistência. Contudo por absoluta sobrecarga de trabalho nesta semana em especial
        //não pude implementá-los nesta oportunidade.

        //Aqui foram realizados testes de duas regras de negócio do dominio renda mínima e aprovar proposta.

        [Theory(DisplayName = "Renda mínima insuficiente")]
        [InlineData("Charles", "65149427", "1973-12-14", 1000, 800, enuSituacaoProposta.AguardandoAnalise)]
        public void NaoValidaRendaMinima(string nome, 
            string documento, 
            DateTime data, 
            decimal valor, 
            decimal valorenda, 
            enuSituacaoProposta situacao)
        {
            var proposta = new Proposta()
            {
                NomeProponente = nome,
                DocumentoProponente = documento,
                DataProposta = data,
                ValorProposta = valor,
                ValorRendaProponente = valorenda,
                SituacaoProposta = situacao
                
            };

            Assert.False(proposta.ValidaValorMinimoRenda());
        }

        [Theory(DisplayName = "Renda mínima suficiente")]
        [InlineData("Charles", "65149427", "1973-12-14", 1000, 800, enuSituacaoProposta.AguardandoAnalise)]
        public void ValidaRendaMinima(string nome,
            string documento,
            DateTime data,
            decimal valor,
            decimal valorenda,
            enuSituacaoProposta situacao)
        {
            var proposta = new Proposta()
            {
                NomeProponente = nome,
                DocumentoProponente = documento,
                DataProposta = data,
                ValorProposta = valor,
                ValorRendaProponente = valorenda,
                SituacaoProposta = situacao

            };

            Assert.True(proposta.ValidaValorMinimoRenda());
        }

        [Fact(DisplayName = "Não aprova proposta valor maior ou igual 50% renda")]
        public void NaoAprovaProposta()
        {
            var proposta = new Proposta()
            {
                Id = 9999,
                NomeProponente = "João das coves",
                DocumentoProponente = "55022456168",
                DataProposta = System.DateTime.Now,
                ValorProposta = 1500,
                ValorRendaProponente = 3000,
                SituacaoProposta = enuSituacaoProposta.AguardandoAnalise
            };

            Assert.True(proposta.AnaliseProposta());
        }

        [Fact(DisplayName = "Aprova proposta valor menor que 50% renda")]
        public void AprovaProposta()
        {
            var proposta = new Proposta()
            {
                Id = 9999,
                NomeProponente = "João das coves",
                DocumentoProponente = "55022456168",
                DataProposta = System.DateTime.Now,
                ValorProposta = 1500,
                ValorRendaProponente = 3500,
                SituacaoProposta = enuSituacaoProposta.AguardandoAnalise
            };

            Assert.True(proposta.AnaliseProposta());
        }

    }
}
