using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedHelp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Type = MedHelp.Models.Type;

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
                var types = new[]
                {
                    new Type
                    {
                        TypeName = "SingleLine"
                    },
                    new Type
                    {
                        TypeName = "MultiLine",
                    },
                    new Type
                    {
                        TypeName = "Number",
                    },
                    new Type
                    {
                        TypeName = "Date",
                    }
                };
                context.Types.AddRange(types);

                var templates = new[]{
                    new Template
                    {
                        Name = "Справка о приеме",
                        SchemeJson = @"{""fields"":[{""type"":""submit"",""buttonText"":""Сохранить""},{""type"":""input"",""inputType"":""text"",""model"":""patientName"",""label"":""ФИО пацента"",""placeholder"":""Введите сюда имя пациента""},{""type"":""dateTimePicker"",""label"":""Дата рождения пациента"",""model"":""patientBirthday"",""dateTimePickerOptions"":{""format"":""YYYY-MM-DD""}},{""type"":""dateTimePicker"",""label"":""Дата посещения"",""model"":""visitDay"",""dateTimePickerOptions"":{""format"":""YYYY-MM-DD""}},{""type"":""input"",""inputType"":""text"",""model"":""speciality"",""label"":""Специальность""},{""type"":""input"",""inputType"":""text"",""model"":""doctorName"",""label"":""Имя доктора""},{""type"":""textArea"",""model"":""complaints"",""label"":""Жалобы"",""rows"":5},{""type"":""textArea"",""model"":""anammnesis"",""label"":""Анамнез"",""rows"":5},{""type"":""textArea"",""model"":""recommended"",""label"":""Рекомендации"",""rows"":5},{""type"":""submit"",""buttonText"":""Сохранить""}]}",
                        ModelJson = @"{""patientName"":"""",""patientBirthday"":""2017-12-10T23:29:08.947Z"",""visitDay"":""2017-12-10T23:29:08.947Z"",""speciality"":"""",""doctorName"":"""",""complaints"":"""",""anammnesis"":"""",""recommended"":""""}",
                        Description = "Самая обычная справка о приеме какая только может быть",
                        ImagePath = "https://pp.userapi.com/c638519/v638519335/547d6/N8qDUbqrCG4.jpg",
                        Properties = new List<Property>
                        {
                            new Property
                            {
                                Type = types[0],
                                Theme = "Имя пациента"
                            },
                            new Property
                            {
                                Type = types[1],
                                Theme = "Жалобы"
                            }
                        }
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
