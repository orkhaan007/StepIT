using Microsoft.EntityFrameworkCore;
using PracticsDataAccess.Contexts;
using PracticsDataAccess.Repositories.Abstracts;
using PracticsDomainLayer.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace PracticsDataAccess.Repositories.Concretes;

public class DebtorRepository : BaseRepository<Debtor>, IDebtorRepository
{
    public ICollection<Debtor> GetDebtorsWithEmailDomains(string[] emailDomains)
    {
        return GetAll().Where(debtor => emailDomains.Any(domain => debtor.Email.EndsWith(domain))).ToList();
    }

    public ICollection<Debtor> GetDebtorsWithinAgeRange(int minAge, int maxAge)
    {
        var currentDate = DateTime.Now;
        return GetAll().Where(debtor => currentDate.Year - debtor.BirthDay.Year >= minAge && currentDate.Year - debtor.BirthDay.Year <= maxAge).ToList();
    }

    public ICollection<Debtor> GetDebtorsWithDebthold(decimal threshold)
    {
        return GetAll().Where(debtor => debtor.Debt <= threshold).ToList();
    }

    public ICollection<Debtor> GetDebtorsWithLongNamesAndPhone()
    {
        return GetAll().Where(debtor => debtor.FullName.Length > 18 && debtor.Phone.Count(c => c == '7') >= 2).ToList();
    }

    public ICollection<Debtor> GetDebtorsBornInWinterMonths()
    {
        return GetAll().Where(debtor => debtor.BirthDay.Month == 12 || debtor.BirthDay.Month == 1 || debtor.BirthDay.Month == 2).ToList();
    }

    public ICollection<Debtor> GetDebtorsWithDebtAboveAverage()
    {
        var averageDebt = GetAll().Average(debtor => debtor.Debt);
        return GetAll().Where(debtor => debtor.Debt > averageDebt).OrderBy(debtor => debtor.Debt).ToList();
    }

    public int GetYearWithMostDebtors()
    {
        return GetAll().GroupBy(debtor => debtor.BirthDay.Year).OrderByDescending(group => group.Count()).Select(group => group.Key).FirstOrDefault();
    }

    public ICollection<Debtor> GetDebtorsWithHighestDebts()
    {
        return GetAll().OrderByDescending(debtor => debtor.Debt).Take(5).ToList();
    }

    public decimal GetTotalDebt()
    {
        return GetAll().Sum(debtor => debtor.Debt);
    }

    public ICollection<string> GetElderlyDebtorsNames(int thresholdYear)
    {
        return GetAll().Where(debtor => debtor.BirthDay.Year <= thresholdYear).Select(debtor => debtor.FullName).ToList();
    }

    public ICollection<string> GetDebtorsWithDebtGreaterThanAge(decimal multiplier)
    {
        var currentDate = DateTime.Now;
        return GetAll().Where(debtor => (currentDate.Year - debtor.BirthDay.Year) * multiplier >= debtor.Debt).Select(debtor => debtor.FullName).ToList();
    }

    public ICollection<Debtor> GetDebtorsNotBornInWinterMonths()
    {
        return GetAll().Where(debtor => debtor.BirthDay.Month != 12 && debtor.BirthDay.Month != 1 && debtor.BirthDay.Month != 2).ToList();
    }

    public ICollection<Debtor> GetDebtorsWithDebtNotAboveAverage()
    {
        var averageDebt = GetAll().Average(debtor => debtor.Debt);
        return GetAll().Where(debtor => debtor.Debt <= averageDebt).OrderBy(debtor => debtor.Debt).ToList();
    }

    public ICollection<string> GetDebtorsWithNoRepeatedDigitsInPhone()
    {
        return GetAll().Where(debtor => debtor.Phone.Distinct().Count() == debtor.Phone.Length).Select(debtor => $"{debtor.FullName}, {DateTime.Now.Year - debtor.BirthDay.Year}, {debtor.Debt}").ToList();
    }

    public ICollection<string> GetDebtorsWithThreeSameLetters()
    {
        return GetAll().Where(debtor => debtor.FullName.ToLower().Distinct().Count() <= debtor.FullName.Length - 3).Select(debtor => debtor.FullName).OrderBy(name => name).ToList();
    }

    public int GetBirthYearWithMostDebtors()
    {
        return GetAll().GroupBy(debtor => debtor.BirthDay.Year).OrderByDescending(group => group.Sum(debtor => debtor.Debt)).Select(group => group.Key).FirstOrDefault();
    }

    public ICollection<Debtor> GetDebtorsWithGreatestDebt()
    {
        var debtors = GetAll().OrderByDescending(debtor => debtor.Debt).ToList();
        var greatestDebt = debtors.First().Debt;
        return debtors.Where(debtor => debtor.Debt == greatestDebt).ToList();
    }

    public ICollection<Debtor> GetDebtorsWithSmileableNames()
    {
        return GetAll().Where(debtor => debtor.FullName.ToLower().Contains("s") && debtor.FullName.ToLower().Contains("m") && debtor.FullName.ToLower().Contains("i") && debtor.FullName.ToLower().Contains("l") && debtor.FullName.ToLower().Contains("e")).ToList();
    }
}
