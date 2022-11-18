using ApiDashboard.Models;
using ApiDashboard.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class CardController : ControllerBase
    {
        private ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Card>>> GetCards()
        {
            try
            {
                var cards = await _cardService.GetCards();
                return Ok(cards);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Cards");
            }
        }

        [HttpGet("PesquisarPeloTitulo")]
        public async Task<ActionResult<IAsyncEnumerable<Card>>> GetCardsByTitle([FromQuery] string name)
        {
            try
            {
                var cards = await _cardService.GetCardsByTitle(name);
                if (cards.Count() == 0)
                {
                    return NotFound($"Não existe card com o título {name}");
                }
                return Ok(cards);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Cards pelo nome do título");
            }
        }

        [HttpGet("{id:int}", Name = "GetCards")]
        public async Task<ActionResult<Card>> GetCard(int id)
        {
            try
            {
                var card = await _cardService.GetCard(id);
                if (card == null)
                {
                    return NotFound($"Não existe card com o código {id}");
                }
                return Ok(card);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter o código do Cards");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Card card)
        {
            try
            {
                await _cardService.CreateCard(card);
                return CreatedAtRoute(nameof(GetCards), new { id = card.Id }, card);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar o Card");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Card card)
        {
            try
            {
                if (card.Id == id)
                {
                    await _cardService.UpdateCard(card);
                    return Ok($"O card com o id={id} foi atualizado com sucesso.");
                }
                else
                {
                    return BadRequest("Dados inconsistentes.");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao editar o Card");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var card = await _cardService.GetCard(id);
                if (card != null)
                {
                    await _cardService.DeleteCard(card);
                    return Ok($"O card com o id={id} foi excluído com sucesso.");
                }
                else
                {
                    return NotFound($"O card não foi encontrado.");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao excluir o Card");
            }
        }
    }
}
