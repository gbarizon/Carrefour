# Carrefour

Explicação da arquitetura do projeto:

Camada de Apresentação:

Responsável por interagir com os usuários ou sistemas externos.
Pode incluir controladores, rotas, serialização/desserialização de dados, autenticação e autorização, etc.
No caso do ASP.NET Core, essa camada pode ser representada pelos controladores da API.

Camada de Aplicação:

Coordena as operações de alto nível da aplicação.
Realiza a comunicação entre a camada de Apresentação e a camada de Domínio.
Implementa a lógica de negócio da aplicação.

Camada de Domínio:

Contém as regras de negócio e a lógica central da aplicação.
Inclui entidades, agregados, valor de objetos, serviços de domínio e interfaces de repositório.
É a parte mais importante do DDD, onde ocorre a modelagem e implementação do negócio.
Camada de Infraestrutura:

Lida com a persistência de dados, serviços externos, logging, envio de e-mails, etc.
Implementa as interfaces definidas na camada de Domínio, como os repositórios e serviços externos.
Pode utilizar tecnologias como bancos de dados, APIs de terceiros, serviços de mensageria, etc.
Banco de Dados:

Armazena os dados da aplicação, como lançamentos e saldos diários consolidados.
Pode ser um banco de dados relacional ou NoSQL, dependendo das necessidades e preferências da aplicação.


Aplicando:

Camada de Domínio:

Lancamento: Classe que representa um lançamento, contendo propriedades como Valor, Tipo, Data, etc.
SaldoDiario: Classe que representa o saldo diário consolidado, contendo propriedades como Data e Saldo.
ILancamentoRepository: Interface que define os métodos para manipular os lançamentos no repositório.
ISaldoDiarioRepository: Interface que define os métodos para manipular os saldos diários no repositório.
ILancamentoService: Interface que define os métodos para criar lançamentos.
ISaldoDiarioService: Interface que define o método para calcular o saldo diário consolidado.

Camada de Infraestrutura:

LancamentoRepository: Implementação da interface ILancamentoRepository que realiza a persistência dos lançamentos no banco de dados.
SaldoDiarioRepository: Implementação da interface ISaldoDiarioRepository que realiza a persistência dos saldos diários no banco de dados.
LancamentoService: Implementação da interface ILancamentoService que contém a lógica de negócio para criar lançamentos.
SaldoDiarioService: Implementação da interface ISaldoDiarioService que contém a lógica de negócio para calcular o saldo diário consolidado.
DbContext: Classe que representa o contexto do banco de dados e define as tabelas e relacionamentos.

Camada de Apresentação (API):

LancamentosController: Controlador que expõe os endpoints para criar lançamentos.
SaldoDiarioController: Controlador que expõe o endpoint para obter o saldo diário consolidado.


Readme para DOCKER

1 - Para colocar o sistema para funcionar primeiro o docker deve estar instalado na máquina, no meu caso estou com o windows 11 e utilizei
a seguinte URL para poder instalar:
	
	https://docs.docker.com/desktop/install/windows-install/
	
	Basta escolher o seu sistema operacional e instalar.

2 - Certifique-se de ter o Docker instalado e em execução no seu sistema Operacional.

	Baixe a imagem do SQL Server Express do Docker Hub executando o seguinte comando no terminal:
	
	docker pull mcr.microsoft.com/mssql/server:2019-latest
	
	logo em seguida executar o comando docker-compose up -d	
	
3 - docker build -t AspNetCoreFluxoDeCaixa
	
	Dentro do terminal powershell gerar a imagem da API
	
	docker build -t fluxodecaixa .	
	
4 - Após a conclusão da criação da imagem, você pode executar o contêiner Docker usando o comando 

	docker run -d -p 8080:80 fluxodecaixa
	
5 - Executar a migração (Entity Migration)

	Executar a migração com o comando 
	
	docker exec -it fluxodecaixa dotnet ef database update
	
5 - Agora, a aplicação ASP.NET Core estará em execução dentro de um contêiner Docker e será acessível em 
	http://localhost:8080
	

Readme para SQL Server Local

no arquivo appsettings.json no projeto de API

Descomentar o trecho de codigo

//SQL Server Local
//"ConnectionStrings": {
//    "DefaultConnection": "Data Source=LAPTOP-521E2CEI\\MSSQLEXPRESS;Database=FdCaixa;Trusted_Connection=True;TrustServerCertificate=True"
//},

E comentar

//DOCKER
"ConnectionStrings": {
"FluxoDeCaixaDiarioContexto": "Server=db;Database=FluxoDeCaixaDiarioDB;User=sa;Password=123Mudar!"
},
	
E entrar com a configuração do servidor local

No arquivo program.cs descomentar o trecho de codigo

//SQL Server Local
//builder.Services.AddDbContext<FluxoDeCaixaDiarioContexto>(options =>
//   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
//);

E comentar o trecho de codigo:

//DOCKER
builder.Services.AddDbContext<FluxoDeCaixaDiarioContexto>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("FluxoDeCaixaDiarioContexto"))
);
