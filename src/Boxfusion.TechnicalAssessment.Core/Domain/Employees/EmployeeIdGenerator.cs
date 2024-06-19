using System.Linq;
using System;
using Abp.Dependency;

namespace Boxfusion.TechnicalAssessment.Domain.Employees
{
    /// <summary>
    /// Provides methods for generating unique employee IDs.
    /// This class generates IDs consisting of 2 random uppercase letters followed by 4 random digits.
    /// The IDs are checked for uniqueness against the database to ensure no duplicates.
    /// </summary>
    public static class EmployeeIdGenerator
    {

        private static Random random = new Random();

        public static string GenerateId()
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const int letterCount = 2;

            // Generate 2 random uppercase letters
            var randomLetters = new string(Enumerable.Repeat(letters, letterCount)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            // Generate 4 random digits
            var randomNumbers = random.Next(0, 9999).ToString("D4");

            return randomLetters + randomNumbers;
        }

        public static string GenerateNewId()
        {
            var employeeManager = IocManager.Instance.Resolve<EmployeeManager>();

            var newId = employeeManager.GenerateUniqueIdAsync()
                                       .GetAwaiter()
                                       .GetResult();

            return newId;
        }
    }

}
