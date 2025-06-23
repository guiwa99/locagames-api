## LocaGames API

## Rotas (REST)

| Rota | Descrição |
| --- | --- |
| `POST /jogo` | Incluir um novo jogo |
| `GET /jogo` | Listar todos os jogos |
| `PUT /jogo/{id}/alugar` | Alugar algum jogo |
| `PUT /jogo/{id}/devolver` | Devolver algum jogo |
| `GET /jogo/{id}` | Detalhar algum jogo |
| `PUT /jogo/{id}` | Editar algum jogo |
| `DELETE /jogo/{id}` | Deletar algum jogo |

## Modelo (Jogo)
- Identificador: `long`
- Titulo: `string`
- Descricao: `string`
- Disponivel: `bool`
- Categoria: `ENUM (BRONZE, PRATA e OURO)`
- Responsavel: `string`
- DataRetirada: `Datetime`

## Requisitos
1. `POST /jogo`
- Deve receber Titulo, Descricao e Categoria na request.
- Deve iniciar a propriedade Disponivel como `true`.
- Deve iniciar a propriedade Responsavel como `null`.
- Deve iniciar a propriedade DataRetirada como `null`.

2. `GET /jogo`
- Deve listar todos os jogos.
- Deve listar todas as propriedades, exceto Descricao e Responsavel.
- Ordenar por titulo.
- Deve haver uma propriedade `IsEmAtraso` do tipo `bool`. Se a data atual for maior que a DataRetirada, então deve ser `true`, se a data atual for menor que a DataRetirada, então deve ser `false`.
- Usar DTOs. A propriedade `IsEmAtraso` deve estar apenas na response, não na entidade.

3. `PUT /jogo/{id}/alugar`
- Deve receber nome do responsavel na request. 
- Não deve ser possível alugar um jogo que já está alugado, ou seja, com a propriedade Disponivel `false`.
- Deve atualizar a propriedade Disponivel como `false`.
- Deve atualizar a propriedade Responsavel com o responsavel recebido na request.
- A DataRetirada deve ser calculada com base na categoria do jogo:
- Se for BRONZE, a DataRetirada deve ser a data atual + 9 dias. 
- Se for PRATA, a DataRetirada deve ser a data atual + 6 dias. 
- Se for OURO, a DataRetirada deve ser a data atual + 3 dias.

4. `PUT /jogo/{id}/devolver`
- Só deve ser possível devolver um jogo que está alugado, ou seja, a propriedade Disponivel deve ser `false`.
- A DataRetirada do jogo deve ser atualizada para `null`.
- O Responsavel do jogo deve ser atualizado para `null`.
- Disponivel deve ser atualizado para `true`.

5. `GET /jogo/{id}`
- Deve detalhar o jogo pelo id.
- Deve haver uma propriedade `IsEmAtraso` do tipo `bool`. Se a data atual for maior que a DataRetirada, então deve ser `true`, se a data atual for menor que a DataRetirada, então deve ser `false`.
- Usar DTOs. A propriedade `IsEmAtraso` deve estar apenas na response, não na entidade.

6. `PUT /jogo/{id}/atualizar`
- Deve ser possível receber Titulo, Descricao e Categoria pela request e atualizar os mesmos.
- Não é necessário atualizar todos de uma vez, ou seja, deve ser possível atualizar apenas o título, mas a descrição manter a mesma existente.

7. `DELETE /jogo/{id}`
- Deve ser possível deletar um jogo pelo id.
- Não deve ser possível deletar um jogo que está alugado, ou seja, com a propriedade Disponivel `false`.

## Dicas
1. Usar as boas práticas vistas no curso.

2. Foque nos requisitos pedidos. Se não foi pedido, não precisa fazer.

3. Dê preferencia ao fazer os requisitos antes de fazer extras. Mas quando terminar os requisitos, fique a vontade para fazer funcionalidades extras que façam sentido para o projeto.
