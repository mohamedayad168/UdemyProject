using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Infrastructure.Configuration;

namespace UsersSeeder
{
    public class UsersReader
    {
        public static IEnumerable<Users> ReadUsersFromCsv(string path)
        {



            IEnumerable<Users> records = new List<Users>();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ",",
                MissingFieldFound = null,
                BadDataFound = null,
                IgnoreBlankLines = true,
                TrimOptions = TrimOptions.Trim,
                HeaderValidated = null,
                IgnoreReferences = true
            };


            try
            {
                using var reader = new StreamReader(path);
                using var csv = new CsvReader(reader, config);


                records = csv.GetRecords<Users>().ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV: {ex.Message}");
            }
            return records;

        }

    }

    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CountryName { get; set; }
        public string City { get; set; }
        public string? State { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }= false;

        public override string ToString()
        {
            return $"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, Email: {Email}, Password: {Password}, CountryName: {CountryName}, City: {City}, State: {State}, Age: {Age} ,Gender:{Gender}, CreatedDate: {CreatedDate}, ModifiedDate: {ModifiedDate}, IsDeleted: {IsDeleted}";
        }




    }


}
