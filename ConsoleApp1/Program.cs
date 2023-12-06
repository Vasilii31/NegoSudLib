using ConsoleApp1;
using Microsoft.EntityFrameworkCore;
using NegoSudLib.DTO;
using NegoSudLib.NegosudDbContext;
using NegoSudLib.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        //SeedService.SeedDatabase();

        ICollection<ProduitDTO> produitDTOs = new List<ProduitDTO>();
        NegoSudDBContext context = new NegoSudDBContext();
        ProduitService produitService = new ProduitService(context);
        produitDTOs = produitService.GetProduits();
        foreach (ProduitDTO prod in produitDTOs)
        {
            Console.WriteLine(prod.NomProduit);
        }
    }
}