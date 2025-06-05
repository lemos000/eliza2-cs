# eliza2-api

Eliza é uma API RESTful desenvolvida em Java com Spring Boot, concebida como um MVP para servir como psicóloga virtual empática e acessível, especialmente voltada ao suporte psicológico de pessoas em situação de vulnerabilidade após desastres, catástrofes naturais ou grandes crises sociais.

A solução integra a inteligência artificial do Google Gemini, permitindo conversas humanizadas, acolhedoras e responsivas, capazes de entender o contexto emocional do usuário e oferecer orientações ou encaminhamentos de forma segura e ética. A IA foi treinada para compreender demandas sensíveis e proporcionar suporte inicial até que o indivíduo possa receber acompanhamento especializado.


Como MVP, Eliza foi projetada para ser facilmente expandida no futuro, permitindo integrações com outros serviços de assistência social, plataformas de telemedicina, equipes de resposta a emergências e órgãos de saúde pública. A API pode ser incorporada a aplicativos móveis, portais de atendimento emergencial e sistemas de monitoramento pós-crise, promovendo cuidado psicológico imediato e humanizado em larga escala.
## Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- PostgreSQL
- Swagger (OpenAPI)
- Gemini API (Google Generative Language)
- Razor Pages

## Configuração

1. **Clone o repositório:**
   








2. **Configure a string de conexão no `appsettings.json`:**
```bash 
"ConnectionStrings": { "DefaultConnection": "Host=localhost;Database=eliza2db;Username=seu_usuario;Password=sua_senha" }
```





 
3. **Rode as migrations para criar o banco de dados:**
```bash
dotnet ef database update
```
 
4. **Execute o projeto:**
```bash
dotnet run
```

## Endpoints Principais

Acesse a documentação interativa via Swagger em:  
`https://localhost:{porta}/swagger`

### Usuários

- `POST /api/usuario/register` — Cadastro de usuário
- `POST /api/usuario/login` — Login de usuário

### Mensagens

- `POST /api/mensagem/enviar/{usuarioId}` — Envia uma mensagem e recebe resposta do Gemini
- `GET /api/mensagem/historico/{usuarioId}` — Lista o histórico de mensagens do usuário
- `GET /api/mensagem/{id}` — Busca uma mensagem específica
- `PUT /api/mensagem/{usuarioId}/{mensagemId}` — Atualiza uma mensagem
- `DELETE /api/mensagem/{usuarioId}/{mensagemId}` — Remove uma mensagem

## Estrutura do Projeto

- `Controllers/` — Controllers da API
- `Services/` — Serviços de negócio e integração (incluindo Gemini)
- `Model/Entity/` — Entidades do banco de dados
- `Model/DTO/` — Objetos de transferência de dados
- `Data/` — Contexto do Entity Framework

## Observações

- Certifique-se de que a API Key do Gemini está correta em `GeminiService`.
- O projeto utiliza HTTPS por padrão.
- Para ambiente de desenvolvimento, o Swagger está habilitado.

---

Projeto acadêmico da FIAP, desenvolvido para a matéria de ADVANCED BUSINESS DEVELOPMENT WITH .NET
