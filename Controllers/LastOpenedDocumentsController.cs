using System;
using System.Collections.Generic;
using System.Linq;
using MedHelp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedHelp.Controllers
{
    [Route("api/[controller]")]
    public class LastOpenedDocumentsController : Controller
    {
        private static readonly Template[] Templates =
        {
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

        private static readonly string[] Patients =
        {
            "Наглая бабка, у которой болит мизинец на ноге",
            "Дедуля",
            "Ребенок, у которого 36.9"
        };

        [HttpGet]
        [HttpGet("[action]")]
        public IEnumerable<LastOpenedDocument> LastOpenedDocuments()
        {
            var random = new Random();
            return Enumerable.Range(1, 3).Select(index => new LastOpenedDocument
            {
                Template = Templates[random.Next(Templates.Length)],
                Patient = Patients[random.Next(Patients.Length)],
                LastOpenedTime = DateTime.Now.AddHours(-random.Next(10))
            });
        }
    }
}