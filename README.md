# OdontoVision.API

API RESTful desenvolvida em ASP.NET Core com integração a Machine Learning (ML.NET), focada no gerenciamento odontológico: dentistas, pacientes, procedimentos e diagnósticos.

## Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core (com Oracle)
- ML.NET — Para detecção de fraudes
- Swashbuckle/Swagger — Documentação automática da API
- PostgreSQL/Oracle — Base de dados (atualmente Oracle)
- Visual Studio 2022

## Estrutura do Projeto

OdontoVision_API_V3_Final/
│
├── OdontoVision.API/                 # Projeto principal da API
│   ├── Controllers/                  # Endpoints REST
│   ├── Models/                       # ViewModels, DTOs e entidades auxiliares
│   ├── IA/                           # Camada de Machine Learning (IA)
│   │   └── MLModel.zip               # Modelo ML treinado
│   ├── Program.cs                   # Entry point com DI + Swagger
│   └── appsettings.json             # Configurações (connection strings)
│
├── OdontoVision.ML/                 # Biblioteca de integração com ML.NET
│   ├── FraudModelService.cs         # Serviço de predição
│   ├── FraudInput.cs                # Classe de entrada de dados
│   └── FraudPrediction.cs           # Classe de saída/predição
│
├── OdontoVision.ML.Training/       # Projeto de Console para treinar o modelo
│   ├── fraud-data.csv               # Dados sintéticos de treino
│   └── Program.cs                   # Pipeline de treinamento ML.NET

## Funcionalidades Principais

- Cadastro e consulta de dentistas, pacientes e procedimentos
- Registro de diagnósticos vinculados
- Integração com IA para detecção de fraudes com base em variáveis financeiras
- Treinamento do modelo com dados sintéticos
- Visualização via Swagger UI

## Inteligência Artificial (ML.NET)

A API integra um modelo de classificação binária treinado com ML.NET para prever potenciais fraudes com base em dados como:

- Valor da transação
- Tempo desde a última transação
- Se a transação é estrangeira
- Se é de país de alto risco

### Modelo

- Localização: OdontoVision.API/Models/MLModel.zip
- Gerado com o projeto OdontoVision.ML.Training a partir de fraud-data.csv

### ReTreinar

cd OdontoVision.ML.Training
dotnet run

O novo modelo será salvo e pode substituir o antigo.

## Endpoints

### Autenticação

POST /api/Auth/login  
POST /api/Auth/register

### Entidades

GET /api/Dentista  
GET /api/Paciente  
GET /api/Diagnostico  
GET /api/Procedimento

### Diagnóstico

POST /api/Diagnostico

### IA - Fraude

POST /api/IA/DetectFraud

Body esperado:
{
  "amount": 2500.0,
  "timeSinceLastTransaction": 3.2,
  "isForeignTransaction": true,
  "isHighRiskCountry": false
}

Resposta:
{
  "amount": 2500.0,
  "isFraud": false,
  "probability": 0.12,
  "score": -2.13
}

## Execução

1. Configure o banco Oracle no appsettings.json
2. Rode a API:

cd OdontoVision.API  
dotnet run

3. Acesse via navegador:
http://localhost:5094/swagger



