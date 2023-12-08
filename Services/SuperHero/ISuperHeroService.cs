namespace SuperHeroApi.Services.Interface;

using SuperHeroApi.Entities.Models;


public interface ISuperHero
{
    Task<List<SuperHero>> AddHero(SuperHero hero);
    Task<List<SuperHero>> UpdateHero(int id, SuperHero hero);
    Task<List<SuperHero>> DeleteHero(int id);
    Task<List<SuperHero>> GetSuperHeroes();
    Task<SuperHero> GetSuperHero(int id);

}