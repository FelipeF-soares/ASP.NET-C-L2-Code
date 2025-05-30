# 📦 GameStore.API - Processo Seletivo L2 Code

Esta aplicação foi desenvolvida como parte de um **processo seletivo** da empresa **L2 Code**.  
Trata-se de uma **API REST desenvolvida em .NET 8** que recebe uma lista de pedidos via JSON e retorna um valor pré-estabelecido de acordo com as regras internas da aplicação.

---

## 🚀 Tecnologias Utilizadas

- ✅ .NET 8
- ✅ SQL Server 2022 (em container Docker)
- ✅ Docker & Docker Compose
- ✅ Entity Framework Core

---

## 📥 Exemplo de JSON de Entrada

```json
{
  "pedidos": [
    {
      "pedido_id": 1,
      "produtos": [
        {
          "produto_id": "PS5",
          "dimensoes": { "altura": 40, "largura": 10, "comprimento": 25 }
        },
        {
          "produto_id": "Volante",
          "dimensoes": { "altura": 40, "largura": 30, "comprimento": 30 }
        }
      ]
    },
    {
      "pedido_id": 2,
      "produtos": [
        {
          "produto_id": "Joystick",
          "dimensoes": { "altura": 15, "largura": 20, "comprimento": 10 }
        },
        {
          "produto_id": "Fifa 24",
          "dimensoes": { "altura": 10, "largura": 30, "comprimento": 10 }
        },
        {
          "produto_id": "Call of Duty",
          "dimensoes": { "altura": 30, "largura": 15, "comprimento": 10 }
        }
      ]
    },
    {
      "pedido_id": 3,
      "produtos": [
        {
          "produto_id": "Headset",
          "dimensoes": { "altura": 25, "largura": 15, "comprimento": 20 }
        }
      ]
    },
    {
      "pedido_id": 4,
      "produtos": [
        {
          "produto_id": "Mouse Gamer",
          "dimensoes": { "altura": 5, "largura": 8, "comprimento": 12 }
        },
        {
          "produto_id": "Teclado Mecânico",
          "dimensoes": { "altura": 4, "largura": 45, "comprimento": 15 }
        }
      ]
    },
    {
      "pedido_id": 5,
      "produtos": [
        {
          "produto_id": "Cadeira Gamer",
          "dimensoes": { "altura": 120, "largura": 60, "comprimento": 70 }
        }
      ]
    },
    {
      "pedido_id": 6,
      "produtos": [
        {
          "produto_id": "Webcam",
          "dimensoes": { "altura": 7, "largura": 10, "comprimento": 5 }
        },
        {
          "produto_id": "Microfone",
          "dimensoes": { "altura": 25, "largura": 10, "comprimento": 10 }
        },
        {
          "produto_id": "Monitor",
          "dimensoes": { "altura": 50, "largura": 60, "comprimento": 20 }
        },
        {
          "produto_id": "Notebook",
          "dimensoes": { "altura": 2, "largura": 35, "comprimento": 25 }
        }
      ]
    },
    {
      "pedido_id": 7,
      "produtos": [
        {
          "produto_id": "Jogo de Cabos",
          "dimensoes": { "altura": 5, "largura": 15, "comprimento": 10 }
        }
      ]
    },
    {
      "pedido_id": 8,
      "produtos": [
        {
          "produto_id": "Controle Xbox",
          "dimensoes": { "altura": 10, "largura": 15, "comprimento": 10 }
        },
        {
          "produto_id": "Carregador",
          "dimensoes": { "altura": 3, "largura": 8, "comprimento": 8 }
        }
      ]
    },
    {
      "pedido_id": 9,
      "produtos": [
        {
          "produto_id": "Tablet",
          "dimensoes": { "altura": 1, "largura": 25, "comprimento": 17 }
        }
      ]
    },
    {
      "pedido_id": 10,
      "produtos": [
        {
          "produto_id": "HD Externo",
          "dimensoes": { "altura": 2, "largura": 8, "comprimento": 12 }
        },
        {
          "produto_id": "Pendrive",
          "dimensoes": { "altura": 1, "largura": 2, "comprimento": 5 }
        }
      ]
    }
  ]
}
```

## Como Executar

### Pré-requisitos

- Docker
- Docker Compose

### Passos para executar

1. Clone o repositório:

```bash
git clone https://github.com/FelipeF-soares/ASP.NET-C-L2-Code.git
```

2. Suba os containers da API e do banco de dados:

```bash

docker-compose up --build
```

3. Aguarde a inicialização completa dos containers.

4. Inicie primeiro o Banco de Dados.

5. Inicie a api para atualizar o banco e as tabelas.

6. A API estará disponível em:

```url
http://localhost:8080/swagger/index.html
```

6. Contato Felipe felipe.fends@gmail.com
