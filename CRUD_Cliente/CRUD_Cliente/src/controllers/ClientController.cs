using CRUD_Cliente.src.dto;
using CRUD_Cliente.src.repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRUD_Cliente.src.controllers
{
    [ApiController]
    [Route("api/Clients")]
    [Produces("application/json")]
    public class ClientController : ControllerBase
    {
        #region Attributes
        private readonly IClient _repository;
        #endregion

        #region Constructor
        public ClientController(IClient repository)
        {
            _repository = repository;
        }
        #endregion

        #region Method
        /// <summary>
        /// Pegar todos os clientes
        /// </summary>
        /// <para>Resumo: Método assincrono para pegar todos os usuários</para>
        /// <returns>ActionResult</returns> 
        /// <response code="200">Retorna todos os usuarios</response> 
        /// <response code="403">Usuario não autorizado</response>
        [HttpGet("all")]
        public async Task<ActionResult> GetAllClient()
        {
            var list = await _repository.GetAllClient();

            if (list.Count < 1) return NoContent();

            return Ok(list);
        }

        /// <summary> 
        /// Pegar cliente pelo Nome
        /// </summary> 
        /// <param name="name">Nome do cliente</param> 
        /// <returns>ActionResult</returns> 
        /// <response code="200">Cliente encontrado</response> 
        /// <response code="404">Cliente não existente</response>
        [HttpGet("name/{name}")]
        public async Task<ActionResult> GetByName([FromRoute] string name)
        {
            try
            {
                return Ok(await _repository.GetByName(name)); 
            }
            catch(Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }

        /// <summary> 
        /// Pegar clientes pelo Nome
        /// </summary> 
        /// <param name="names">Nome dos clientes</param> 
        /// <returns>ActionResult</returns> 
        /// <response code="200">Clientes encontrado</response> 
        /// <response code="404">Cliente não existente</response>
        [HttpGet("names/{names}")]
        public async Task<ActionResult> GetByNames([FromRoute] string names)
        {
            try
            {
                return Ok(await _repository.GetByNames(names));
            }
            catch(Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Criar novo Cliente 
        /// </summary> 
        /// <param name="client">Contrutor para criar cliente</param> 
        /// <returns>ActionResult</returns> 
        /// <remarks> 
        /// Exemplo de requisição: 
        /// 
        ///     POST /api/Clients/create 
        ///     { 
        ///         "nome": "Nome do Usuario", 
        ///         "cpf": "123.456.789-10",
        ///         "datanascimento": "2022-08-19"
        ///         "sexo": "MASCULINO", 
        ///         "estado": "São Paulo", 
        ///         "cidade": "São Paulo",
        ///     } 
        ///     
        /// </remarks> 
        /// <response code="201">Retorna cliente criado</response> 
        /// <response code="422">Cleinte ja cadastrado</response>
        [HttpPost("create")]
        [ProducesResponseType(201)]
        [ProducesResponseType(422)]
        public async Task<ActionResult> Create([FromBody] NewClientDTO client)
        {
            await _repository.Create(client);
            return Created($"api/Clients/{client.CPF}", client);
        }

        /// <summary>
        /// Atualizar Cliente 
        /// </summary> 
        /// <param name="client">Contrutor para atualizar cliente</param> 
        /// <returns>ActionResult</returns> 
        /// <remarks> 
        /// Exemplo de requisição: 
        /// 
        ///     PUT /api/Clients/update 
        ///     { 
        ///         "id": 0,
        ///         "nome": "Nome do Usuario",
        ///         "datanascimento": "2022-08-19"
        ///         "sexo": "MASCULINO", 
        ///         "estado": "São Paulo", 
        ///         "cidade": "São Paulo",
        ///     } 
        ///     
        /// </remarks> 
        /// <response code="200">Cliente atualizado</response> 
        /// <response code="400">Erro na requisição</response>
        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody] UpdateClientDTO client)
        {
            try
            {
                await _repository.Update(client);
                return Ok(client);
            }
            catch(Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Deletar Cliente
        /// </summary>
        /// <param name="id">Id do Cliente</param>
        /// <returns>ActionResult</returns>
        /// <response code="204">Cliente deletada</response>
        /// <response code="404">Id do cliente não existe</response>
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _repository.Delete(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }
        #endregion
    }
}
