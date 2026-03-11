# Projeto umaConsulta

Aplicação Windows Forms desenvolvida em .NET 8 para consulta de dados de atletas integrados com o Supabase.

## Requisitos de Software

* Visual Studio 2022
* .NET 8.0 SDK
* Pacote NuGet supabase-csharp
* Pacote NuGet DotNetEnv

## Configuração do Banco de Dados

Para testar a consulta, execute o seguinte script no SQL Editor do seu dashboard Supabase para criar a estrutura necessária:

```sql
CREATE TABLE atletas (
  id uuid DEFAULT gen_random_uuid() PRIMARY KEY,
  nome text NOT NULL,
  modalidade text,
  celular text,
  data_nascimento date,
  created_at timestamptz DEFAULT now()
);

-- Habilitar leitura para acesso anon
ALTER TABLE atletas ENABLE ROW LEVEL SECURITY;
CREATE POLICY "Allow Public Read" ON atletas FOR SELECT USING (true);

# Preencher .env

