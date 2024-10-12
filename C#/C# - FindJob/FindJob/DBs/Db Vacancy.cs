using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Database
{
    public class VacancyDatabase
    {
        public static List<Vacancy.Vacancy> vacancies = new List<Vacancy.Vacancy>();

        public static void AddVacancy(Vacancy.Vacancy vacancy)
        {
            vacancies.Add(vacancy);
        }

        public static void UpdateVacancy(Vacancy.Vacancy updatedVacancy)
        {
            Vacancy.Vacancy existingVacancy = GetVacancyById(updatedVacancy.Id);
            if (existingVacancy != null)
            {
                existingVacancy.Title = updatedVacancy.Title;
                existingVacancy.Description = updatedVacancy.Description;
                existingVacancy.Category = updatedVacancy.Category;
                existingVacancy.Salary = updatedVacancy.Salary;
            }
        }

        public static void DeleteVacancy(Guid vacancyId)
        {
            Vacancy.Vacancy vacancyToDelete = GetVacancyById(vacancyId);
            if (vacancyToDelete != null)
            {
                vacancies.Remove(vacancyToDelete);
            }
        }

        public static Vacancy.Vacancy GetVacancyById(Guid vacancyId)
        {
            return vacancies.FirstOrDefault(v => v.Id == vacancyId);
        }

        public static List<Vacancy.Vacancy> GetAllVacancies()
        {
            return vacancies;
        }

        public static List<Vacancy.Vacancy> GetVacanciesByCategory(string category)
        {
            return vacancies.Where(v => v.Category == category).ToList();
        }

        public static void SaveVacancysToJson()
        {
            string json = JsonSerializer.Serialize(vacancies, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("vacancies.json", json);
        }

        public static void LoadVacancysFromJson()
        {
            if (File.Exists("vacancies.json"))
            {
                string json = File.ReadAllText("vacancies.json");
                if (!string.IsNullOrWhiteSpace(json))
                    vacancies = JsonSerializer.Deserialize<List<Vacancy.Vacancy>>(json);
            }
            else
                vacancies = new List<Vacancy.Vacancy>();
        }
    }
}