using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PortalAdopcjiZwierzat.Data;
using PortalAdopcjiZwierzat.Models.Zwierzeta;
using System;
using System.Linq;

namespace PortalAdopcjiZwierzat.Models;


public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new PortalAdopcjiZwierzatContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<PortalAdopcjiZwierzatContext>>()))
        {
            // Look for any animals.
            if (context.Zwierze.Any())
            {
                return;   // DB has been seeded
            }


            List<Zwierze> seedData = new List<Zwierze>();

            string[] gatunki = { "pies", "kot", "świnka morska", "królik", "chomik", "szczur" };
            string[] imiona = { "Burek", "Mruczek", "Filemon", "Luna", "Tajga", "Puszek", "Azor", "Mango", "Hikari", "Lusia", "Pusia" };
            string[] plcie = { "samiec", "samica" };
            string[] rasyPsa = { "mieszaniec", "beagle", "labrador", "husky", "owczarek niemiecki", "akita" };
            string[] rasyKota = { "mieszaniec", "pers", "maine coon", "syjamski", "brytyjski" };
            string[] umaszczenia = { "rude", "białe", "czarne", "tricolor", "bure", "czarno-białe", "biało-rude", "szare", "brązowe" };
            string[] rodzajeSiersci = { "krótka", "długa" };
 



            Random random = new Random();

            for (int i = 1; i <= 50; i++)
            {
                var wylosowana_nazwa = gatunki[random.Next(gatunki.Length)];

                Zwierze zwierze = new Zwierze
                {
                    
                    Adoptowany = false,
                    Nazwa = wylosowana_nazwa,
                    Imie = imiona[random.Next(imiona.Length)],
                    Plec = plcie[random.Next(plcie.Length)],
                    Rasa = (wylosowana_nazwa == "pies") ? rasyPsa[random.Next(rasyPsa.Length)] : (wylosowana_nazwa == "kot") ? rasyKota[random.Next(rasyKota.Length)] : "mieszaniec",
                    Umaszczenie = umaszczenia[random.Next(umaszczenia.Length)],
                    Siersc = rodzajeSiersci[random.Next(rodzajeSiersci.Length)],
                    Wiek = random.Next(1, 10),
                    Opis = "Opis zwierzęcia",
                    ZdjecieUrl = "-"
                };

                seedData.Add(zwierze);
            }


            context.Zwierze.AddRange(seedData);
            context.SaveChanges();
        }
    }
}
