# ProjetoTeste
Contém 2 microserviços que seguem o mesmo princído de design de software, o DDD, Contudo os padrões de arquitetura não são os mesmos. 

O microserviço de cliente segue o o padrão arquiterural [Explicit Dependencies](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles) Uma abordagem mais que pretende ser mais objetiva e clara sobre o relacionamento e dependências entre as clases, que não esconde nada. Digamos ser esta também uma implementação que segue a risca o conceito (KISS)[https://uxdesign.blog.br/a-origem-do-keep-it-simple-stupid-kiss-b24085dc1327], contudo não é uma implementação pobre, foram aplicados os padrões de IOC, DI, CQRS, OOP, Unit Of Work, Repository Pattern, [Guard Clauses](https://maiconheck.io/krafted/articles/guards.html) e testes utilizando xUnit.

O microserviço Cartão, além dos padrões de arquitetura mencionados acima, segue outros mais complexos e sofisticados como o [MEdiator](https://medium.com/tableless/mediatr-com-asp-net-core-7b98ba0ca640) resultando em um código com alto nível de desacoplamento, aliás essa a principal vantagem da utilização do padrão, onde o termo acoplamento está relacionado diretamente a custo. O conceito de behaviors é aplicado para validar as requisições utilizando Fluent Validation, toda requisição é validada antes de chegar ao handler aplicando assim o conceito de fast validation.

*A solução utiliza 3 container, mas é possível ter uma visão bastante detalhada de todo sem ter que criar e executar os containers. A pasta img contém inúmeras imagens de detalhes do projeto.

**A seguir um Roteiro para criar as imagens e containers e executar o projeto. Este roteiro foi validado e produzio o resultado esperado quando executado utilizando uma máquina windows com wsl2 instalado rodando ubunto 22.04.3 LTS.
