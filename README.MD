## 🌐 ApiGateway10-RedisCache-docker
Exemplo de utilização de criação de ApiGateway com utilização de cache Redis.

| Tecnologia | Descrição |
|-----------|-----------|
| **BFF** | Arquitetura que cria um servidor back-end exclusivo para atender a uma interface específica. |
| **Ocelot** | ponto de entrada único para o seu sistema, interceptando requisições e roteando-as para os microsserviços adequados servindo como proxy reverso|
| **Redis** | Banco de dados em memória (RAM) de altíssima velocidade. |

#### 📁 Requisitos do Projeto
- Limpe os certificados existentes e Gere e confie em um novo certificado local
```bash
dotnet dev-certs https --clean
dotnet dev-certs https --trust
```

- Criar pasta e Exporte o certificado como um arquivo físico, a configuração do seu contêiner exigi um caminho direto
```bash
mkdir %USERPROFILE%\.dotnet\corefx\cryptography\x509stores\mycerts
dotnet dev-certs https -ep %USERPROFILE%\.dotnet\corefx\cryptography\x509stores\mycerts\webApi.pfx -p pa55w0rd
```

- Conferir se o certificado está na pasta 
```bash
C:\Users\[SEU_USUARIO]\.dotnet\corefx\cryptography\x509stores\mycerts
```

#### Executar a aplicação

VSCode Terminal [1] - Abrir Container
```bash
cd Sistema
docker-compose up --build  
```

VSCode Terminal [2]
```bash
cd Sistema/Services/Pessoa/Sistema.Pessoa.API
dotnet run
```

VSCode Terminal [3]
```bash
cd Sistema/Services/Produto/Sistema.Produto.API
dotnet run
```

VSCode Terminal [4]
```bash
cd Sistema/Services/Agrupador/Sistema.Agrupador.API
dotnet run
```

VSCode Terminal [5]
```bash
cd Sistema/ApiGateways/Base/Sistema.ApiGateway
dotnet run
```

VSCode Terminal [6] - Fechar Container
```bash
cd Sistema
docker compose down 
```

- Caso haja falha de compilação por Portas ocupadas, rastrear portas no PowerShell e fecha-las.
```bash
netstat -ano | findstr :3000 
ou 
netstat -ano | findstr :3001
ou
netstat -ano | findstr :4000 
ou 
netstat -ano | findstr :4001
ou
netstat -ano | findstr :5100 
ou 
netstat -ano | findstr :5101
```
- O comando vai retornar uma linha. O último número dessa linha é o PID. Use esse número para fechar o processo:
```bash
taskkill /F /PID <NUMERO_DO_PID>
```

#### 🧪 Executar Endpoints 
- Importar Coleção de testes que contém na pasta Postman **Redis Gateway Cache Example.postman_collection.json**

#### 🧪 Executar Redis
- Abra o terminal: Abra o Prompt de Comando (CMD) ou PowerShell no Windows.

- Inicie o cliente: Digite o comando abaixo e pressione Enter:
```bash
memurai-cli
```

- Teste a conexão: Digite **PING** e aperte Enter. O servidor responderá **PONG**

Para buscar chaves no Redis
```bash
KEYS *Pessoa_Agrupador*
```

Retornar todos os campos e valores de um hash armazenado em uma chave específica.
```bash
HGETALL "Sistema_development_Pessoa_Agrupador_3673a9fd-191a-479c-a41f-3dc5611aa77d"
```

Exibir somente Json de um hash armazenado em uma chave específica.
```bash
HGET "Sistema_development_Pessoa_Agrupador_3673a9fd-191a-479c-a41f-3dc5611aa77d" data
```
