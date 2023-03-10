using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicTacToe.Models;
using TicTacToe.Services;
using TicTacToe.Entities;
using TicTacToe.Services;
using TicTacToe.Models;
using System.ComponentModel;

namespace TicTacToe.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    
    public class PlayFieldController : ControllerBase
    {
        private IPlayFieldService _playService;

        public PlayFieldController(IPlayFieldService playService)
        {
            _playService = playService;
        }

        [HttpPost("create")]
        public IActionResult Creation([FromBody] PFModel pfModel)
        {
            _playService.CreatePlayField(pfModel);

            return Ok(pfModel);
        }
        [HttpGet("getall")]
        public IActionResult GetPlayFields()
        {
            var playFields = _playService.GetAll();
            if (playFields == null)
            {
                return NotFound();
            }
            return Ok(playFields);
        }
        [HttpGet("{id}")]
        public IActionResult GetPlayFieldById(int id)
        {
            var playField = _playService.GetByIdPlayField(id);
            if (playField == null)
            {
                return NotFound();
            }
            return Ok(playField);
        }
        [HttpPatch("update")]
        public IActionResult UpdatePlayField([FromBody] UpdatePlayFieldRequest updateModel)
        {
            if (updateModel == null)
            {
                return BadRequest();
            }

            var p = _playService.GetById(updateModel.PFuk);

            if (p == null)
            {
                return NotFound();
            }

            int state = (int)_playService.Update(updateModel);

            switch(state)
            {
                case -3:
                    return Ok("Field coordinates is out of range.");
                case -2:
                    return Ok("You can't change marked field.");
                case -1:
                    return Ok(_playService.GetById(updateModel.PFuk));
                case 0:
                    return Ok("The game ended in a draw!");
                case 1:
                    return Ok("Player №1 is winner!");
                case 2:
                    return Ok("Player №2 is winner!");
            }

            return NoContent();  
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var p = _playService.GetById(id);

            if (p == null)
            {
                return NotFound();
            }

            _playService.DeletePlayField(p);

            return NoContent();  
        }

    }
    
}
