using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;


using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        List<string> encryptedRecords = new List<string>();

        for (int i = 0; i < 20; i++)
        {
            string family = GenerateFamily();
            string name = GenerateName();
            string surname = GenerateSurname();
            string birthday = GenerateBirthday();
            string passport = EncryptData(GenerateDataPassport());
            string phoneNumber = EncryptData(GenerateNumberPhone());
            string cardNumber = EncryptData(GenerateNumberCard());
            string idCard = GenerateIdCard();
            string validity = GenerateValidity();
            string cvvCode = EncryptData(GenerateCVVCode());
            string cardType = EncryptData(GenerateType());
            string bankIssuer = GenerateBankIssuer();
            string bankAcquirer = GenerateBankAcquirer();
            string country = GenerateCountry();
            string paymentDate = GenerateDataPay();
            string amount = GenerateSum().ToString();
            string location = GenerateLocation();

            string record = $"{family}, {name}, {surname}, {birthday}, {passport}, {phoneNumber}, {cardNumber}, {idCard}, {validity}, {cvvCode}, {cardType}, {bankIssuer}, {bankAcquirer}, {country}, {paymentDate}, {amount}, {location}";
            encryptedRecords.Add(record);

        }

        static void SaveDataToDatabase(List<string> records)
        {
            string connectionString = "Server=localhost;Database=BankBD;User Id=root;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                foreach (string record in records)
                {
                    string[] values = record.Split(',').Select(s => s.Trim()).ToArray();

                    var formattedValues = values.Select(val => $"{val}").ToArray();

                    var dataTuple = (formattedValues[0], formattedValues[1], formattedValues[2], formattedValues[3], formattedValues[4], formattedValues[5], formattedValues[6], formattedValues[7], formattedValues[8], formattedValues[9], formattedValues[10], formattedValues[11], formattedValues[12], formattedValues[13], formattedValues[14], formattedValues[15], formattedValues[16]);


                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO `BANK`(`FAMILY`, `NAME`, `SURNAME`, `BIRTHDAY`, `DATA_PASPORT`, `NABMER_PHONE`, `NAMBER_CARD`, `ID_CARD`, `VALIDITY`, `CVV_CODE`, `TYPE`, `BANK_ISSUER`, `BANK_ACQUIRER`, `COUNTRY`, `DATA_PAY`, `SUM`, `LOCATION`) VALUES (@Family, @Name, @Surname, @Birthday, @DataPassport, @PhoneNumber, @CardNumber, @IdCard, @Validity, @CVVCode, @CardType, @BankIssuer, @BankAcquirer, @Country, @DataPay, @Amount, @Location)", connection))
                    {

                        cmd.Parameters.AddWithValue("@Family", formattedValues[0]);
                        cmd.Parameters.AddWithValue("@Name", formattedValues[1]);
                        cmd.Parameters.AddWithValue("@Surname", formattedValues[2]);
                        cmd.Parameters.AddWithValue("@Birthday", GenerateBirthday());
                        cmd.Parameters.AddWithValue("@DataPassport", formattedValues[4]);
                        cmd.Parameters.AddWithValue("@PhoneNumber", formattedValues[5]);
                        cmd.Parameters.AddWithValue("@CardNumber", formattedValues[6]);
                        cmd.Parameters.AddWithValue("@IdCard", formattedValues[7]);
                        cmd.Parameters.AddWithValue("@Validity", GenerateValidity());
                        cmd.Parameters.AddWithValue("@CVVCode", formattedValues[9]);
                        cmd.Parameters.AddWithValue("@CardType", formattedValues[10]);
                        cmd.Parameters.AddWithValue("@BankIssuer", formattedValues[11]);
                        cmd.Parameters.AddWithValue("@BankAcquirer", formattedValues[12]);
                        cmd.Parameters.AddWithValue("@Country", formattedValues[13]);
                        cmd.Parameters.AddWithValue("@DataPay", GenerateDataPay());
                        cmd.Parameters.AddWithValue("@Amount", formattedValues[15]);
                        cmd.Parameters.AddWithValue("@Location", formattedValues[16]);

                        cmd.ExecuteNonQuery();

                        Console.WriteLine(dataTuple);
                    }
                }
            }
        }

        /*foreach (string record in encryptedRecords)
        {
            string[] values = record.Split(',').Select(s => s.Trim()).ToArray();

            // Создайте новый массив, обернув каждое значение в одинарные кавычки
            var formattedValues = values.Select(val => $"'{val}'").ToArray();

            // Выведите кортеж с обернутыми значениями
            var dataTuple = (formattedValues[0], formattedValues[1], formattedValues[2], formattedValues[3], formattedValues[4], formattedValues[5], formattedValues[6], formattedValues[7], formattedValues[8], formattedValues[9], formattedValues[10], formattedValues[11], formattedValues[12], formattedValues[13], formattedValues[14], formattedValues[15], formattedValues[16]);

            Console.WriteLine(dataTuple);
        }*/

        SaveDataToDatabase(encryptedRecords);
    }

    static string GenerateFamily()
    {
        string[] families = { "Ivanov", "Petrov", "Sidorov", "Smirnov", "Kuznetsov", "Mikhailov", "Zaitsev", "Volkov", "Kozlov", "Popov", "Fedorov", "Sokolov", "Orlov", "Novikov", "Morozov", "Egorov", "Semyonov", "Kotov", "Vasiliev", "Pavlov", "Gorbachev", "Belyakov", "Kozlov", "Romanov", "Lebedev", "Bogdanov", "Stepanov", "Golubev", "Borisov", "Tikhonov" };
        return families[new Random().Next(families.Length)];
    }

    static string GenerateName()
    {
        string[] names = { "Alexey", "Sergey", "Dmitriy", "Andrey", "Igor", "Maxim", "Pavel", "Nikolay", "Denis", "Roman", "Anton", "Vladimir", "Oleg", "Artem", "Mikhail", "Ivan", "Evgeny", "Viktor", "Yuri", "Gennady", "Konstantin", "Anatoly", "Valentin", "Yaroslav", "Dmitry", "Stanislav", "Aleksei", "Nikita", "Sergei", "Kirill" };
        return names[new Random().Next(names.Length)];
    }

    static string GenerateSurname()
    {
        string[] surnames = { "Ivanovich", "Petrovich", "Andreevich", "Dmitrievich", "Sergeevich", "Nikolaevich", "Vladimirovich", "Olegovich", "Maximovich", "Antonovich", "Dmitryevich", "Alexandrovich", "Romanovich", "Mikhailovich", "Viktorovich", "Igorovich", "Nikolayevich", "Fedorovich", "Gennadyevich", "Anatolyevich" };
        return surnames[new Random().Next(surnames.Length)];
    }
    static string GenerateBirthday()
    {
        int year = new Random().Next(1910, 2005);
        int month = new Random().Next(1, 13);
        int day = new Random().Next(1, 29);
        return $"{year:D4}-{month:D2}-{day:D2}";
    }

    static string GenerateDataPassport()
    {
        return new Random().Next(1000000000, 2000000000).ToString();
    }

    static string GenerateNumberPhone()
    {
        return "89" + new Random().Next(100000000, 1000000000).ToString();
    }

    static string GenerateNumberCard()
    {
        return new Random().Next(1000000000, 2000000000).ToString();
    }

    static string GenerateIdCard()
    {
        string[] cardTypes = { "debet", "credit" };
        return cardTypes[new Random().Next(cardTypes.Length)];
    }

    static string GenerateValidity()
    {
        int year = new Random().Next(2025, 2031);
        int month = new Random().Next(1, 13);
        int day = new Random().Next(1, 29);
        return $"{year:D4}-{month:D2}-{day:D2}";
    }

    static string GenerateCVVCode()
    {
        return new Random().Next(100, 999).ToString();
    }

    /*static string GenerateBankAccount()
    {
        return new Random().Next(1000000000, 1000000000).ToString();
    }*/

    static string GenerateType()
    {
        string[] cardTypes = { "MIR", "VISA", "MasterCard", "American Express" };
        return cardTypes[new Random().Next(cardTypes.Length)];
    }

    static string GenerateBankIssuer()
    {
        string[] bankIssuers = { "Sberbank", "Alfa Bank", "VTB", "Gazprombank", "Tinkoff Bank", "VTB24", "Promsvyazbank", "Raiffeisenbank", "UniCredit Bank", "Rosbank", "MDM Bank", "Otkritie Bank", "Svyaznoy Bank", "Uralsib", "Home Credit Bank", "Russian Standard Bank", "Rusfinance Bank", "Credit Bank of Moscow", "Transcapitalbank", "B&N Bank" };
        return bankIssuers[new Random().Next(bankIssuers.Length)];
    }

    static string GenerateBankAcquirer()
    {
        string[] bankAcquirers = { "Sberbank", "Alfa Bank", "VTB", "Gazprombank", "Tinkoff Bank", "VTB24", "Promsvyazbank", "Raiffeisenbank", "UniCredit Bank", "Rosbank", "MDM Bank", "Otkritie Bank", "Svyaznoy Bank", "Uralsib", "Home Credit Bank", "Russian Standard Bank", "Rusfinance Bank", "Credit Bank of Moscow", "Transcapitalbank", "B&N Bank" };
        return bankAcquirers[new Random().Next(bankAcquirers.Length)];
    }

    static string GenerateCountry()
    {
        string[] countries = { "Russia", "USA", "Germany", "France", "China", "Japan", "Canada", "Brazil", "India", "Australia", "UK", "Spain", "Italy", "Mexico", "South Korea", "South Africa", "Argentina", "New Zealand", "Turkey", "Netherlands", "Sweden", "Norway", "Denmark", "Switzerland", "Portugal", "Austria", "Belgium", "Ireland", "Greece", "Poland", "Hungary", "Czech Republic", "Romania", "Ukraine", "Singapore", "Malaysia", "Thailand", "Vietnam", "Indonesia", "Philippines", "Saudi Arabia", "United Arab Emirates", "Egypt", "Nigeria", "Kenya", "Ghana", "Morocco", "Israel", "Jordan", "Lebanon", "Qatar", "Kuwait", "Bahrain", "Oman", "Sri Lanka", "Bangladesh", "Pakistan" };
        return countries[new Random().Next(countries.Length)];
    }

    static string GenerateDataPay()
    {
        int year = new Random().Next(2005, 2024);
        int month = new Random().Next(1, 13);
        int day = new Random().Next(1, 29);
        return $"{year:D2}-{month:D2}-{day:D2}";
    }

    static int GenerateSum()
    {
        return new Random().Next(1, 100000);
    }

    static string GenerateLocation()
    {
        string[] locations = { "Diksi", "Auchan", "Lenta", "Perekrestok", "Magnit", "O'Key", "Metro Cash & Carry", "Spar", "Kaufland", "Walmart", "Carrefour", "Tesco", "Aldi", "Costco", "Target", "Sainsbury's", "Woolworths", "Coop", "Edeka", "Kroger", "Whole Foods", "Lidl", "Waitrose", "Safeway", "Publix", "Giant Eagle", "Stop & Shop", "Albert Heijn", "Migros", "Coles", "Wegmans", "Ikea", "Leroy Merlin", "Media Markt", "Fnac", "Best Buy", "Home Depot", "Lowes", "B&Q", "Argos", "Harrods", "Macy's", "Nordstrom", "Neiman Marcus", "Bloomingdale's", "Harvey Nichols", "Selfridges", "John Lewis", "Debenhams", "Sephora", "Ulta", "Boots", "Superdrug" };
        return locations[new Random().Next(locations.Length)];
    }

    static string EncryptData(string data)
    {
        string key = "l9X7Vu8ssNQ5xS0/G5dD0w==";
        byte[] keyBytes = Convert.FromBase64String(key);
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = keyBytes;
            aesAlg.IV = new byte[16]; // Initialize the IV as needed

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            // Perform encryption
            byte[] encryptedData;
            using (var msEncrypt = new MemoryStream())
            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                csEncrypt.Write(dataBytes, 0, dataBytes.Length);
                csEncrypt.FlushFinalBlock();
                encryptedData = msEncrypt.ToArray();
            }

            return Convert.ToBase64String(encryptedData);
        }
    }

   /* static string DecryptData(string data)
    {
        string key = "l9X7Vu8ssNQ5xS0/G5dD0w==";
        byte[] keyBytes = Convert.FromBase64String(key);

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = keyBytes;
            aesAlg.IV = new byte[16]; // Initialize the IV as needed

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            // Convert the Base64 string back to bytes
            byte[] encryptedData = Convert.FromBase64String(data);

            // Perform decryption
            byte[] decryptedData;
            using (var msDecrypt = new MemoryStream(encryptedData))
            using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
                decryptedData = new byte[encryptedData.Length];
                csDecrypt.Read(decryptedData, 0, decryptedData.Length);
            }

            return Encoding.UTF8.GetString(decryptedData).TrimEnd('\0');
        }
    }*/


}
