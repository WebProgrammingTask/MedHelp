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

                var medicines = new[]
                {
                    "НО-ШПА", "Фазостабил", "Аскорбиновая кислота-Русфар", "Аспирин", "Афала", "АФАЛАЗА", "Афлодерм",
                    "Афлюдол", "Афобазол", "Ацизол", "Календула", "Калмирекс"
                };
                context.Medicines.AddRange(medicines.Select(m => new Medicine {MedicineName = m}));

                var fields = new[]
                {
                    new Field
                    {
                        Properties = new List<Property>
                        {
                            new Property("type", "submit"),
                            new Property("buttonText", "Сохранить"),
                        },
                    },
                    new Field
                    {
                        Properties = new List<Property>
                        {
                            new Property("type", "input"),
                            new Property("model", "patientName"),
                            new Property("label", "ФИО пациента"),
                            new Property("placeholder", "Введите сюда имя пациента"),
                        },
                    },
                    new Field
                    {
                        Properties = new List<Property>
                        {
                            new Property("type", "dateTimePicker"),
                            new Property("label", "Дата рождения пациента"),
                            new Property("model", "patientBirthday"),
                            new Property("dateTimePickerOptions", "{\"format\" : \"YYYY-MM-DD\"}")

                        }
                    },
                    new Field
                    {
                        Properties = new List<Property>
                        {
                            new Property("type", "dateTimePicker"),
                            new Property("label", "Дата посещения пациента"),
                            new Property("model", "patientBirthday"),
                            new Property("dateTimePickerOptions", "{\"format\" : \"YYYY-MM-DD\"}")
                        }
                    },
                    new Field
                    {
                        Properties = new List<Property>
                        {
                            new Property("type", "input"),
                            new Property("inputType", "text"),
                            new Property("model", "speciality"),
                            new Property("label", "Специальность")
                        }
                    },
                    new Field
                    {
                        Properties = new List<Property>
                        {
                            new Property("type", "input"),
                            new Property("inputType", "text"),
                            new Property("model", "doctorName"),
                            new Property("label", "Имя доктора")
                        }
                    },
                    new Field
                    {
                        Properties = new List<Property>
                        {
                            new Property("type", "textArea"),
                            new Property("model", "complaints"),
                            new Property("label", "Жалобы"),
                            new Property("rows", "5")
                        }
                    }
                };

                var templates = new[]
                {
                    new Template
                    {
                        Name = "Справка о приеме",
                        Fields = fields.ToList(),
                        SchemeJson =
                            @"{""fields"":[{""type"":""submit"",""buttonText"":""Сохранить""},{""type"":""input"",""inputType"":""text"",""model"":""patientName"",""label"":""ФИО пацента"",""placeholder"":""Введите сюда имя пациента""},{""type"":""dateTimePicker"",""label"":""Дата рождения пациента"",""model"":""patientBirthday"",""dateTimePickerOptions"":{""format"":""YYYY-MM-DD""}},{""type"":""dateTimePicker"",""label"":""Дата посещения"",""model"":""visitDay"",""dateTimePickerOptions"":{""format"":""YYYY-MM-DD""}},{""type"":""input"",""inputType"":""text"",""model"":""speciality"",""label"":""Специальность""},{""type"":""input"",""inputType"":""text"",""model"":""doctorName"",""label"":""Имя доктора""},{""type"":""textArea"",""model"":""complaints"",""label"":""Жалобы"",""rows"":5},{""type"":""textArea"",""model"":""anammnesis"",""label"":""Анамнез"",""rows"":5},{""type"":""textArea"",""model"":""recommended"",""label"":""Рекомендации"",""rows"":5},{""type"":""vueMultiSelect"",""label"":""Лекарства"",""placeholder"":""Пожалуйста, выберите лекарства"",""values"":[],""selectOptions"":{""multiple"":true,""hideselected"":true,""multiSelect"":true,""closeOnSelect"":true,""showLabels"":false,""searchable"":true,""taggable"":true,""limit"":10}},{""type"":""submit"",""buttonText"":""Сохранить""}]}",
                        ModelJson =
                            @"{""patientName"":"""",""patientBirthday"":""2017-12-10T23:29:08.947Z"",""visitDay"":""2017-12-10T23:29:08.947Z"",""medicines"":""[]"",""speciality"":"""",""doctorName"":"""",""complaints"":"""",""anammnesis"":"""",""recommended"":""""}",
                        Description = "Самая обычная справка о приеме какая только может быть",
                        ImagePath = "https://doc-rf.com/templates/SYNERGY-CP1251/images/sprav/ych/doc.jpg"
                    },
                    new Template
                    {
                        Name = "Направление на анализы",
                        //Description = "Куда сказано, туда и иди",
                        Description = "Без анализов тут не обойтись",
                        ImagePath = "http://mediaspravka.ru/photos/15_1.jpg"
                    },
                    new Template
                    {
                        Name = "Направление к другому врачу",
                        //Description = "Ну, в этой ситуации я как бы уже это... Мои полномочия уже как бы всё... Окончены!",
                        Description = "Такого я ещё не видел. Пусть мои коллеги посмотрят",
                        ImagePath = "https://i.imgur.com/AoSVPpc.png"
                    }
                };
                context.Templates.AddRange(templates);
                var patients = new[]
                {
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