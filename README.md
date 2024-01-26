# ProjetoTeste
Contém 2 microserviços que seguem o mesmo princído de design de software o DDD, Contudo os padrões de arquitetura de software não são os mesmos. 

O microserviço de cliente segue o o padrão arquiterural [Explicit Dependencies](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles) segundo literatura uma abordagem mais objetiva e clara do relacionamento e dependências entre as clases, que não esconde nada dos desenvolvedores. Digamos ser esta também uma implementação que segue o padrão (KISS)[https://uxdesign.blog.br/a-origem-do-keep-it-simple-stupid-kiss-b24085dc1327], foram aplicados os conceitos de IOC, DI, CQRS, OO, Unit Of Work e Repositories Pattern.

O microserviço Cartao, além dos padrões de arquitetura mencionados acima, segue outros mais complexos e sofisticados como o [MEdiator](https://medium.com/tableless/mediatr-com-asp-net-core-7b98ba0ca640) resultando em um código com alto nível de desacoplamento, aliás essa a principal vantagem da utilização do padrão, onde o termo acoplamento está relacionado diretamente a custo. O conceito de behaviors é aplicado para validar as requisições utilizando o Fluent Validation.

**Roteiro para criar as imagens é containers e rodas o projeto.
