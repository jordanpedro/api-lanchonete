using ApiLanchonete.Model.Response;

using Application.Exceptions;
using Application.Model.Request;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Application.Services
{
    public class PedidoServices : IPedidoServices
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IClienteRepository _clienteRepository;
        public PedidoServices(IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository, IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
            _pedidoRepository = pedidoRepository;
        }
        public async Task<PedidoAgreggateModelResponse> GetAsync(long id)
        {
            var entity = await _pedidoRepository.GetAsync(id);

            if (entity is not null && entity.Id > 0)
            {
                return PedidoAgreggateModelResponse.FromEntityToResponse(entity);
            }
            else
                return new();
        }
        public async Task<bool> InsertAsync(PedidoAgreggateModelRequest pedido)
        {
            if (pedido?.ItensPedido?.Count() > 0)
            {
                decimal valorTotal = default;
                Cliente cliente = default;

                foreach (var item in pedido.ItensPedido)
                {
                    if (item.Quantidade <= 0) throw new QuantidadeDeProdutoInvalidaException("Quantidade de produto deve ser numerica maior que zero.");

                    var produto = await _produtoRepository.GetAsync(item.IdProduto);

                    if (produto is null || produto?.Id == 0) throw new ProdutoNaoEncontradoException("Produto nao encontrado!");

                    valorTotal += item.Quantidade * produto.Preco;
                }

                if (!string.IsNullOrEmpty(pedido.Cpf))
                {
                    cliente = await _clienteRepository.GetByCpfAsync(pedido.Cpf!);

                    if (cliente is null || cliente?.Id == 0)
                        throw new ClienteNaoEncontradoException("Cliente Nao encontrado");
                }
                long idPedido = await _pedidoRepository.InsertWithReturnIdAsync(PedidoAgreggateModelRequest.FromRequestToEntity(pedido, cliente,  valorTotal));

                if (idPedido > 0)
                {
                    foreach (var item in pedido.ItensPedido)
                    {
                        await _pedidoRepository.InsertItensAsync(ItemPedidoModelRequest.FromRequestToEntity(item, idPedido));
                    }

                    return true;
                }
                else
                    throw new FalhaNaGeracaoDoPedidoException("Houve uma falha na geeracao do pedido. Tente novamente mais tarde.");
            }
            else
            {
                throw new PedidoSemItensException("Pedido nao possui itens.");
            }
        }
        public async Task<bool> UpdateStatusAsync(PedidoAgreggateModelRequestUpdatStatus pedido, long id) => await _pedidoRepository.UpdateStatusAsync(PedidoAgreggateModelRequestUpdatStatus.FromRequestToEntity(pedido, id));
        public async Task<List<PedidoAgreggateModelResponse>> GetByStatusAsync(string status)
        {
            List<PedidoAgreggateModelResponse> entitiesResponse = new List<PedidoAgreggateModelResponse> ();    
            List <PedidoAgreggate> entities = await _pedidoRepository.GetByStatusAsync(status);

            if (entities is not null && entities?.Any() == true)
            {
                foreach (var entity in  entities)
                    entitiesResponse.Add(PedidoAgreggateModelResponse.FromEntityToResponse(entity));
                return entitiesResponse;
            }
            else
                return new();
        }
    }
}
