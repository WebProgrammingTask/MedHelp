using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedHelp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MedHelp.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context =
                new MedHelpContext(serviceProvider.GetRequiredService<DbContextOptions<MedHelpContext>>()))
            {
                if (context.Templates.Any())
                {
                    return;
                }
                var templates = new[]{
                    new Template
                    {
                        Name = "Справка о приеме",
                        Description = "Самая обычная справка о приеме какая только может быть",
                        ImagePath = "https://pp.userapi.com/c638519/v638519335/547d6/N8qDUbqrCG4.jpg"
                    },
                    new Template
                    {
                        Name = "Направление на анализы",
                        Description = "Куда сказано, туда и иди",
                        ImagePath = "https://pp.userapi.com/c630317/v630317313/1303d/i-eVXtwVRSo.jpg"
                    },
                    new Template
                    {
                        Name = "Направление к другому врачу",
                        Description = "Ну, в этой ситуации я как бы уже это... Мои полномочия уже как бы всё... Окончены!",
                        ImagePath = "https://pp.userapi.com/c623226/v623226313/4ab8b/RJ8H-rRuc3U.jpg"
                    }
                };
                context.Templates.AddRange(templates);
                var patients = new[]{
                    "Наглая бабка, у которой болит мизинец на ноге",
                    "Дедуля",
                    "Ребенок, у которого 36.9"
                };
                var random = new Random();
                var lastOpenedDocuments = Enumerable.Range(1, 3).Select(index => new LastOpenedDocument
                {
                    Template = templates[index - 1],
                    Patient = patients[index - 1],
                    LastOpenedTime = DateTime.Now.AddHours(-random.Next(10))
                });
                context.LastOpenedDocuments.AddRange(lastOpenedDocuments);

                context.SaveChanges();
            }
        }
    }
}
