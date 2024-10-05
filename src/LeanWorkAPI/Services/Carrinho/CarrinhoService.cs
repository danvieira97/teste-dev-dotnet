using System;
using System.Data.SqlClient;
using Dapper;
using LeanWorkAPI.DTO;
using LeanWorkAPI.Models;

namespace LeanWorkAPI.Services.Carrinho;

public class CarrinhoService : ICarrinhoInterface
{
    private readonly IConfiguration _configuration;
    public CarrinhoService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<ResponseAdicionarItemDTO> AdicionarItem(int idCarrinho, RequestAdicionarItemDTO request)
    {
        ResponseAdicionarItemDTO response = new ResponseAdicionarItemDTO();

        if (request.Produto == "")
        {
            response.Mensagem = "Produto não informado";
            response.Status = false;
            return response;
        }

        if (request.Quantidade <= 0)
        {
            response.Mensagem = "Quantidade inválida";
            response.Status = false;
            return response;
        }

        if (request.PrecoUnitario <= 0)
        {
            response.Mensagem = "Preço inválido";
            response.Status = false;
            return response;
        }

        using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultMac")))
        {
            // Verifica se o carrinho existe
            var queryCarrinho = "SELECT * FROM Carrinhos WHERE CarrinhoId = @Id";
            var carrinho = await connection.QueryFirstOrDefaultAsync<CarrinhoModel>(queryCarrinho, new { Id = idCarrinho });

            if (carrinho is null)
            {
                response.Mensagem = "Carrinho não encontrado";
                return response;
            }

            // Adiciona o item ao carrinho
            var queryAdicionarItem = @"
            INSERT INTO Carrinho_Itens (CarrinhoId, Produto, Quantidade, PrecoUnitario, PrecoTotal) 
            OUTPUT INSERTED.Id, INSERTED.CarrinhoId, INSERTED.Produto, INSERTED.Quantidade, INSERTED.PrecoUnitario, (INSERTED.Quantidade * INSERTED.PrecoUnitario) AS PrecoTotal
            VALUES (@CarrinhoId, @Produto, @Quantidade, @PrecoUnitario, @PrecoTotal)";

            // Executa a inserção e captura o item inserido
            var item = await connection.QueryFirstOrDefaultAsync<ItemCarrinhoModel>(queryAdicionarItem, new
            {
                CarrinhoId = idCarrinho,
                request.Produto,
                request.Quantidade,
                request.PrecoUnitario,
                PrecoTotal = request.Quantidade * request.PrecoUnitario
            });

            response.Item = item;
        }

        return response;
    }


    public async Task<ResponseAtualizarItemDTO> AtualizarItem(int id, RequestAtualizarItemDTO request)
    {
        ResponseAtualizarItemDTO response = new ResponseAtualizarItemDTO();

        if (request.Quantidade <= 0)
        {
            response.Mensagem = "Quantidade inválida";
            response.Status = false;
            return response;
        }

        using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultMac")))
        {
            // Atualiza o item e retorna o item atualizado
            var queryAtualizar = @"UPDATE Carrinho_Itens 
                SET Quantidade = @Quantidade, 
                    PrecoTotal = Quantidade * PrecoUnitario
                OUTPUT INSERTED.Id, INSERTED.Produto, INSERTED.Quantidade, INSERTED.PrecoUnitario, INSERTED.PrecoTotal
                WHERE Id = @Id";

            var item = await connection.QueryFirstOrDefaultAsync<ItemCarrinhoModel>(queryAtualizar, new
            {
                request.Quantidade,
                id
            });

            if (item == null)
            {
                response.Mensagem = "Erro ao atualizar o item.";
                response.Status = false;
                return response;
            }

            response.Item = item;
        }

        return response;
    }

    public async Task<CarrinhoModel> ObterCarrinho(int idCarrinho)
    {
        CarrinhoModel? response = new();

        using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultMac")))
        {
            var query = "SELECT * FROM Carrinhos WHERE CarrinhoId = @Id";
            var carrinho = await connection.QueryFirstOrDefaultAsync<CarrinhoModel>(query, new { Id = idCarrinho });

            if (carrinho is null)
            {
                carrinho = new CarrinhoModel();
                return carrinho;
            }

            if (carrinho != null)
            {
                var queryItens = "SELECT * FROM Carrinho_Itens WHERE CarrinhoId = @IdCarrinho";
                var itens = await connection.QueryAsync<ItemCarrinhoModel>(queryItens, new { IdCarrinho = idCarrinho });

                carrinho.Itens = itens.ToList();
            }
            response = carrinho;
        }

        return response;
    }

    public async Task<ResponseDeletarItemDTO> RemoverItem(int idItem)
    {
        ResponseDeletarItemDTO response = new ResponseDeletarItemDTO();

        using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultMac")))
        {
            var buscarItem = "SELECT * FROM Carrinho_Itens WHERE Id = @IdItem";
            var item = await connection.QueryFirstOrDefaultAsync<ItemCarrinhoModel>(buscarItem, new { IdItem = idItem });

            if (item is null)
            {
                response.Mensagem = "Item não encontrado";
                response.Status = false;
                return response;
            }

            var query = "DELETE FROM Carrinho_Itens WHERE Id = @IdItem";
            await connection.ExecuteAsync(query, new { idItem });

            response.Mensagem = "Item removido com sucesso";
        }

        return response;
    }
}