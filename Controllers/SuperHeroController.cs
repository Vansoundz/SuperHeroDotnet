using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Entities.Models;
using SuperHeroApi.Services.Interface;

namespace SuperHeroApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SuperheroController : ControllerBase
{
    private readonly ISuperHeroService _service;

    public SuperheroController(ISuperHeroService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
    {
        var heroes = await _service.GetSuperHeroes();
        return Ok(heroes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SuperHero>> GetHero(int id)
    {
        try
        {
            var hero = await _service.GetSuperHero(id);
            return Ok(hero);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
    {
        var res = await _service.AddHero(hero);
        return Ok(res);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<SuperHero>> UpdateHero(int id, SuperHero hero)
    {
        try
        {
            var res = await _service.UpdateHero(id, hero);
            return Ok(res);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
    {
        try
        {
            var res = await _service.DeleteHero(id);
            return Ok(res);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


}