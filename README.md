🏅 Gamification.Domain — Exercício TDD de Concessão de Badges

Projeto desenvolvido como parte do exercício TDD para concessão de badges por missão no contexto de gamificação acadêmica (ClassHero).
O foco é aplicar Test-Driven Development (Red → Green → Refactor) para validar regras de domínio puras, sem persistência real.

📁 Estrutura do Projeto
src/Gamification.Domain/          → biblioteca de domínio
 ├─ Awards/
 │   ├─ AwardBadgeService.cs      → serviço de domínio (regra principal)
 │   └─ Policies/BonusPolicy.cs   → política pura de cálculo de bônus/XP
 ├─ Model/
 │   ├─ Badge.cs
 │   ├─ RewardLog.cs
 │   └─ XpAmount.cs
 └─ Ports/
     ├─ IAwardsReadStore.cs
     ├─ IAwardsWriteStore.cs
     └─ IAwardsUnitOfWork.cs

tests/Gamification.Domain.Tests/  → suíte de testes unitários (xUnit)
 ├─ AwardBadgeServiceTests.cs
 └─ BonusPolicyTests.cs

⚙️ Como Executar
Pré-requisitos

.NET 9 SDK instalado

Passos no terminal
# Clonar o repositório (ou abrir a pasta do projeto)
cd gamification

# Compilar a solução
dotnet build

# Rodar todos os testes
dotnet test


Ou, se quiser executar apenas o projeto de testes:

dotnet test tests/Gamification.Domain.Tests/Gamification.Domain.Tests.csproj

🧠 O que foi implementado

AwardBadgeService
Aplica as regras principais de concessão de badges, garantindo unicidade, elegibilidade e atomicidade simulada.

BonusPolicy
Calcula o XP de acordo com as janelas de bônus do tema (integral, reduzido ou fora do período).

Ports (IAwardsReadStore, IAwardsWriteStore, IAwardsUnitOfWork)
Interfaces que permitem testar o domínio com fakes e mocks, sem dependências externas.

Entidades e Value Objects
(Badge, XpAmount, RewardLog) modelam valores e logs do domínio de forma imutável.

🧪 Testes Implementados

Os testes seguem o estilo AAA (Arrange, Act, Assert) e cobrem as regras exigidas no enunciado:

Categoria	Descrição
Concessão básica	Verifica se uma badge é concedida apenas uma vez quando a missão é concluída.
Janelas de bônus	Confirma o cálculo de XP nas três janelas (integral, reduzido, sem bônus).
Elegibilidade	Falha se a missão não estiver concluída.
Unicidade	Impede duplicação de badge para o mesmo estudante e missão.
Idempotência	Garante que requisições repetidas com o mesmo requestId não criem novas concessões.
Atomicidade/Auditoria (simuladas)	Valida que gravações ocorrem de forma atômica e registram o motivo (reason).
🧩 Observações

Não há persistência real — os testes utilizam fakes in-memory para simular leitura e escrita.

O design segue o princípio de intenção explícita, expondo apenas o método ConcederBadge() no domínio.

A solução foi pensada para expansão futura (logs reais, Value Objects adicionais, Unit of Work).

Requisições repetidas são tratadas de forma idempotente, sem gerar exceções desnecessárias.

🚀 Entrega

O projeto está pronto para:

envio como .zip, ou

publicação no GitHub, com commits pequenos e mensagens descritivas (ex.:
feat(domain): implementar regra de bônus integral).
