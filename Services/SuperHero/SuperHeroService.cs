using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Entities.Context;
using SuperHeroApi.Entities.Models;
using SuperHeroApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroApi.Services;

public class SuperHeroService : ISuperHero
{
    private readonly SuperHeroContext _context;

    public SuperHeroService(SuperHeroContext context)
    {
        _context = context;
    }

    public async Task<List<SuperHero>> AddHero(SuperHero hero)
    {
        await _context.SuperHero.AddAsync(hero);
        await _context.SaveChangesAsync();
        return await GetSuperHeroes();
    }

    public async Task<List<SuperHero>> DeleteHero(int id)
    {
        var dbHero = await _context.SuperHero.FindAsync(id);

        if (dbHero is null) throw new KeyNotFoundException("No SuperHero found");

        _context.SuperHero.Remove(dbHero);
        await _context.SaveChangesAsync();
        return await GetSuperHeroes();

    }

    public async Task<SuperHero> GetSuperHero(int id)
    {
        var hero = await _context.SuperHero.FindAsync(id);

        if (hero is null) throw new KeyNotFoundException("No SuperHero found");

        return hero;
    }

    public async Task<List<SuperHero>> GetSuperHeroes()
    {
        var heroes = await _context.SuperHero.ToListAsync();
        return heroes;
    }

    public async Task<List<SuperHero>> UpdateHero(int id, SuperHero hero)
    {
        var dbHero = await _context.SuperHero.FindAsync(id);

        if (dbHero is null) throw new KeyNotFoundException("No SuperHero found");

        dbHero.Name = hero.Name;
        dbHero.FirstName = hero.FirstName;
        dbHero.LastName = hero.LastName;
        dbHero.Place = hero.Place;

        _context.SaveChanges();

        return await GetSuperHeroes();

    }
}