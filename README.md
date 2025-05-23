
# OdontoVision.API

A OdontoVision.API é uma aplicação backend robusta desenvolvida em ASP.NET Core 8, focada na gestão de clínicas odontológicas. Além das funcionalidades CRUD tradicionais, a solução inclui integração com machine learning usando ML.NET para a detecção de fraudes com base em transações simuladas.

---

## Visão Geral da Arquitetura

O projeto segue uma abordagem **Clean Architecture** com separação em camadas:

- **OdontoVision.API**: camada de apresentação, responsável por expor endpoints REST.
- **OdontoVision.Application**: contém regras de negócio e serviços.
- **OdontoVision.Domain**: define as entidades e interfaces do domínio.
- **OdontoVision.Infrastructure**: implementação de repositórios, configuração do banco de dados.
- **OdontoVision.ML**: camada dedicada à predição com ML.NET.

```
📦 OdontoVision_API_V3_Final/
├── 📁 OdontoVision.API
│   ├── Controllers/
│   ├── IA/
│   │   └── MLModel.zip
│   └── Program.cs
├── 📁 OdontoVision.Application
├── 📁 OdontoVision.Domain
├── 📁 OdontoVision.Infrastructure
├── 📁 OdontoVision.ML
│   ├── FraudModelService.cs
│   └── Model Classes
├── 📁 OdontoVision.ML.Training
│   └── Program.cs (Treinamento)
```

---

## Endpoints Disponíveis

### Dentistas
- `GET /api/Dentista`
- `GET /api/Dentista/{id}`
- `POST /api/Dentista`
- `PUT /api/Dentista/{id}`
- `DELETE /api/Dentista/{id}`

### Pacientes
- `GET /api/Paciente`
- `GET /api/Paciente/{id}`
- `POST /api/Paciente`
- `PUT /api/Paciente/{id}`
- `DELETE /api/Paciente/{id}`

### Procedimentos
- `GET /api/Procedimento`
- `GET /api/Procedimento/{id}`
- `POST /api/Procedimento`
- `PUT /api/Procedimento/{id}`
- `DELETE /api/Procedimento/{id}`

### Diagnósticos
- `GET /api/Diagnostico`
- `GET /api/Diagnostico/{id}`
- `POST /api/Diagnostico`
- `PUT /api/Diagnostico/{id}`
- `DELETE /api/Diagnostico/{id}`

### Predição de Fraude (IA)
- `POST /api/IA/DetectFraud`

Payload:
```json
{
  "amount": 3000.5,
  "timeSinceLastTransaction": 2.5,
  "isForeignTransaction": true,
  "isHighRiskCountry": false
}
```

Resposta:
```json
{
  "isFraud": true,
  "probability": 0.91,
  "score": 4.13
}
```

---

## Exemplo de Teste com Postman

**POST /api/Dentista**
```json
{
  "nome": "Dr. Carlos Silva",
  "cro": "12345-SP",
  "especialidade": "Ortodontia",
  "email": "carlos@odontovision.com",
  "telefone": "(11)91234-5678"
}
```

**POST /api/Diagnostico**
```json
{
  "descricao": "Cárie avançada no molar superior direito.",
  "dataDiagnostico": "2025-05-21T00:00:00",
  "pacienteId": 1,
  "dentistaId": 1
}
```

---

## Execução da API

```bash
cd OdontoVision.API
dotnet run
```

Swagger estará disponível em:
[http://localhost:5094/swagger](http://localhost:5094/swagger)


