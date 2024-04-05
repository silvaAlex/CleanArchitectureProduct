using CleanArchitectureProduct.Application.UseCases.Pedidos;
using CleanArchitectureProduct.Communication.Request;
using CleanArchitectureProduct.Communication.Response;
using CleanArchitectureProduct.Exception;
using Microsoft.AspNetCore.Mvc;


namespace CleanArchitectureProduct.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly CreatePedidoUseCase _createPedidoUseCase;
        private readonly ReadPedidoUseCase _readPedidoUseCase;
        private readonly UpdatePedidoUseCase _updatePedidoUseCase;
        private readonly DeletePedidoUseCase _deletePedidoUseCase;

        public PedidoController(CreatePedidoUseCase createPedidoUseCase,
            ReadPedidoUseCase readPedidoUseCase,
            UpdatePedidoUseCase updatePedidoUseCase,
            DeletePedidoUseCase deletePedidoUseCase)
        {
            _createPedidoUseCase = createPedidoUseCase;
            _readPedidoUseCase = readPedidoUseCase;
            _updatePedidoUseCase = updatePedidoUseCase;
            _deletePedidoUseCase = deletePedidoUseCase;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PedidoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJSON), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PedidoResponse>> GetPedido(int id)
        {
            var result = await _readPedidoUseCase.ExecuteAsync(id);

            if (result is not null)
            {
                var response = new PedidoResponse().GetPedidoResponse(result);

                return Ok(response);
            }

            return NotFound(new ResponseErrorJSON($"Pedido com {id} não foi encontrado"));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseRegisteredPedidoJSON), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJSON), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutPedido(int id, [FromBody] bool pago = true)
        {
            bool isUpdate = await _updatePedidoUseCase.ExecuteAsync(id, pago);

            if (isUpdate)
            {
                return Ok("Pedido atualizado");
            }

            return BadRequest(new ResponseErrorJSON("Erro ao atualizar o pedido"));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseRegisteredPedidoJSON), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJSON), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeletePedido(int id)
        {
            bool isDelete = await _deletePedidoUseCase.ExecuteAsync(id);

            if (isDelete)
            {
                return Ok($"Pedido com {id} deletado com sucesso");
            }

            return BadRequest(new ResponseErrorJSON($"Pedido com {id} não pode ser removido ou não foi encontrado"));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredPedidoJSON), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJSON), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostPedidoAsync([FromBody] RequestPedidoJSON pedido)
        {
            try
            {
                var result = await _createPedidoUseCase.Execute(pedido);

                if (result is not null)
                {
                    return Created(string.Empty,result.Id);
                }

                return BadRequest(new ResponseErrorJSON("Erro ao criar pedido"));
            }
            catch (CleanArchitectureProductException ex)
            {
                return BadRequest(new ResponseErrorJSON($"Erro ao criar pedido - Exception: {ex.Message}"));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorJSON("Unknown error"));
            }
        }
    }
}
