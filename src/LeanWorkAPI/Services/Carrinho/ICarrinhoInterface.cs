using System;
using LeanWorkAPI.DTO;
using LeanWorkAPI.Models;

namespace LeanWorkAPI.Services.Carrinho;

public interface ICarrinhoInterface
{
    Task<CarrinhoModel> ObterCarrinho(int idCarrinho);
    Task<ResponseAdicionarItemDTO> AdicionarItem(int idCarrinho, RequestAdicionarItemDTO request);
    Task<ResponseDeletarItemDTO> RemoverItem(int idItem);
    Task<ResponseAtualizarItemDTO> AtualizarItem(int id, RequestAtualizarItemDTO request);
}
