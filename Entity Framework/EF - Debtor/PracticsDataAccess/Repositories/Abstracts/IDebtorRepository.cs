using PracticsDomainLayer.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace PracticsDataAccess.Repositories.Abstracts;

public interface IDebtorRepository : IBaseRepository<Debtor>
{
    public ICollection<Debtor> GetDebtorsWithEmailDomains(string[] emailDomains);
    public ICollection<Debtor> GetDebtorsWithinAgeRange(int minAge, int maxAge);
    public ICollection<Debtor> GetDebtorsWithDebthold(decimal threshold);
    public ICollection<Debtor> GetDebtorsWithLongNamesAndPhone();
    public ICollection<Debtor> GetDebtorsBornInWinterMonths();
    public ICollection<Debtor> GetDebtorsWithDebtAboveAverage();
    public int GetYearWithMostDebtors();
    public ICollection<Debtor> GetDebtorsWithHighestDebts();
    public decimal GetTotalDebt();
    public ICollection<string> GetElderlyDebtorsNames(int thresholdYear);
    public ICollection<string> GetDebtorsWithDebtGreaterThanAge(decimal multiplier);
    public ICollection<Debtor> GetDebtorsNotBornInWinterMonths();
    public ICollection<Debtor> GetDebtorsWithDebtNotAboveAverage();
    public ICollection<string> GetDebtorsWithNoRepeatedDigitsInPhone();
    public ICollection<string> GetDebtorsWithThreeSameLetters();
    public int GetBirthYearWithMostDebtors();
    public ICollection<Debtor> GetDebtorsWithGreatestDebt();
    public ICollection<Debtor> GetDebtorsWithSmileableNames();
}
