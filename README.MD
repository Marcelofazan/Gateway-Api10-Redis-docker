## Api10-Gateway-Redis-Cache
Exemplo de utilização de criação de ApiGateway com utilização de cache em Redis

# Limpe os certificados existentes
dotnet dev-certs https --clean

# Gere e confie em um novo certificado local
dotnet dev-certs https --trust

# Criar pasta
mkdir %USERPROFILE%\.dotnet\corefx\cryptography\x509stores\mycerts

# Exporte o certificado como um arquivo físico, a configuração do seu contêiner exigi um caminho direto
dotnet dev-certs https -ep %USERPROFILE%\.dotnet\corefx\cryptography\x509stores\mycerts\webApi.pfx -p pa55w0rd

# Conferir se o certificado está na pasta 
C:\Users\[SEU_USUARIO]\.dotnet\corefx\cryptography\x509stores\mycerts


VSCode Terminal [1] - Abrir Container
cd Sistema
docker-compose up --build  

VSCode Terminal [2]
cd Sistema/Services/Pessoa/Sistema.Pessoa.API
dotnet run

VSCode Terminal [3]
cd Sistema/Services/Produto/Sistema.Produto.API
dotnet run

VSCode Terminal [4]
cd Sistema/Services/Agrupador/Sistema.Agrupador.API
dotnet run

VSCode Terminal [5]
cd Sistema/ApiGateways/Base/Sistema.ApiGateway
dotnet run

VSCode Terminal [6] - Fechar Container
cd Sistema
docker compose down 


// Caso haja falha de compilação por Portas ocupadas, rastrear portas no PowerShell e fecha-las.
netstat -ano | findstr :3000 ou netstat -ano | findstr :3001

netstat -ano | findstr :4000 ou netstat -ano | findstr :4001

netstat -ano | findstr :5100 ou netstat -ano | findstr :5101

O comando vai retornar uma linha. O último número dessa linha é o PID. 

//Use esse número para fechar o processo:
taskkill /F /PID <NUMERO_DO_PID>



Abra o terminal: Abra o Prompt de Comando (CMD) ou PowerShell no Windows.

Inicie o cliente: Digite o comando abaixo e pressione Enter:
memurai-cli

Teste a conexão: Digite PING e aperte Enter. 
O servidor responderá PONG

KEYS *Pessoa_Agrupador*


HGETALL "Sistema_development_Pessoa_Agrupador_3673a9fd-191a-479c-a41f-3dc5611aa77d"

// Exibir somente Json 
HGET "Sistema_development_Pessoa_Agrupador_3673a9fd-191a-479c-a41f-3dc5611aa77d" data
