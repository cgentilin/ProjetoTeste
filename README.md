# ProjetoTeste
Contém 2 microserviços que seguem o mesmo princído de design de software, o DDD, Contudo os padrões de arquitetura não são os mesmos. 

O microserviço de cliente segue o o padrão arquiterural [Explicit Dependencies](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles) Uma abordagem mais que pretende ser mais objetiva e clara sobre o relacionamento e dependências entre as clases, que não esconde nada. Digamos ser esta também uma implementação que segue a risca o conceito (KISS)[https://uxdesign.blog.br/a-origem-do-keep-it-simple-stupid-kiss-b24085dc1327], contudo não é uma implementação pobre, foram aplicados os padrões de IOC, DI, CQRS, OOP, Unit Of Work, Repository Pattern, [Guard Clauses](https://maiconheck.io/krafted/articles/guards.html) e testes utilizando xUnit.

O microserviço Cartão, além dos padrões de arquitetura mencionados acima, segue outros mais complexos e sofisticados como o [MEdiator](https://medium.com/tableless/mediatr-com-asp-net-core-7b98ba0ca640) resultando em um código com alto nível de desacoplamento, aliás essa a principal vantagem da utilização do padrão, onde o termo acoplamento está relacionado diretamente a custo. O conceito de behaviors é aplicado para validar as requisições utilizando Fluent Validation, toda requisição é validada antes de chegar ao handler aplicando assim o conceito de fast validation.

*A solução utiliza 3 container, mas é possível ter uma visão de todo projeto sem ter que criar e executar os containers. A pasta img contém inúmeras imagens de detalhes de todo projeto, a Wiki do projeto destaca algumas dessas imagens e acrescenta informações. 

**A seguir um Roteiro para criar as imagens e containers e executar o projeto. Este roteiro foi validado e produzio o resultado esperado quando executado utilizando uma máquina windows 11 com wsl2 instalado rodando ubuntu 22.04.3 LTS.

1) Criar uma rede docker
```bash
docker network create charles-network
```
2) Criar um volume para o mysql
```bash
docker volume create volume-mysql
```
3) Criar o container com Mysql, mantnha a porta mapeada e a rede
```bash
docker run -d --name charles-mysql -p "3306:3306" --network=charles-network -w "/usr/src/script" -v "volume-mysql:/usr/src/script" -e MYSQL_ROOT_PASSWORD=segredo mysql
```
5) Copiar o script da pasta scripsts do repositório para o volume criado no item 2.
```bash
docker volume inspect volume-mysql  #esse comando mostra o caminho físico da pasta
sudo cp ./create-database-charles-mysql.sql #caminho retornado pelo comando acima. Existem outras formas, mas o script precisa estar na pasta de volume
```
5) Alternativa ao passo 4
É possível abrir o código fonte no visual studio criar e rodar uma migration em ambos os projetos. Esse tutorial não descreve esse procedimento.

6) Executar o script, q se foi copiado corretamente no passo 4 já está dentro do container
```bash
docker exec charles-mysql bash -c "mysql -uroot -psegredo < create-database-charles-mysql.sql"
```

8) Criar a imagem e container do microserviço cliente na mesma rede do container mysql
```bash
docker build -t mscliente:latest .
docker run -d --name mscliente -p "9090:80" --network=charles-network -e ASPNETCORE_ENVIRONMENT=Production mscliente
```
9) Criar a imagem e container do microserviço cartão.
```bash
docker build -t mscartao:latest .
docker run -d --name mscartao -p "9095:80" --network=charles-network -e ASPNETCORE_ENVIRONMENT=Production mscartao
```
10) Confirmar se tudo ocorreu conforme esperado.
```bash
docker ps
docker logs mscliente
docker logs mscartao
```

![3container-solucao-rodando](https://github.com/cgentilin/ProjetoTeste/assets/47865895/6baaeb46-7303-45e8-a42d-1afab9216fb1)

