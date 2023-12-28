using ConsoleApp1;
using Microsoft.EntityFrameworkCore;
using NegoSudLib.DTO;
using NegoSudLib.NegosudDbContext;
using NegoSudLib.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        SeedService.SeedDatabase();
    }
}