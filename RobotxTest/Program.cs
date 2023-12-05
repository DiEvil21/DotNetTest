using System;
using System.Data;
using System.Data.SQLite;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        try
        {
            //Cards_20211005080948
            string connectionString = "Data Source=clients.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand createTableCommand = new SQLiteCommand(
                "CREATE TABLE IF NOT EXISTS Clients (Id INTEGER PRIMARY KEY, CardCode TEXT, StartDate TEXT, FinishDate TEXT, " +
                "LastName TEXT, FirstName TEXT, SurName TEXT, FullName TEXT, GenderId TEXT, Birthday TEXT, " +
                "PhoneHome TEXT, PhoneMobil TEXT, Email TEXT, City TEXT, Street TEXT, House TEXT, Apartment TEXT, " +
                "AltAddress TEXT, CardType TEXT, OwnerGuid TEXT, CardPer TEXT, Turnover TEXT)",
                connection))
                {
                    createTableCommand.ExecuteNonQuery();
                }

                XDocument xmlDocument = XDocument.Load("Cards_20211005080948.xml");

                foreach (var cardElement in xmlDocument.Descendants("Card"))
                {
                    string cardCode = cardElement.Attribute("CARDCODE")?.Value ?? string.Empty;
                    string startDateString = cardElement.Attribute("STARTDATE")?.Value ?? string.Empty;
                    DateTime startDate = string.IsNullOrEmpty(startDateString) ? DateTime.MinValue : DateTime.Parse(startDateString);

                    string finishDateString = cardElement.Attribute("FINISHDATE")?.Value ?? string.Empty;
                    DateTime finishDate = string.IsNullOrEmpty(finishDateString) ? DateTime.MinValue : DateTime.Parse(finishDateString);

                    string lastName = cardElement.Attribute("LASTNAME")?.Value ?? string.Empty;
                    string firstName = cardElement.Attribute("FIRSTNAME")?.Value ?? string.Empty;
                    string surName = cardElement.Attribute("SURNAME")?.Value ?? string.Empty;
                    string fullName = cardElement.Attribute("FULLNAME")?.Value ?? string.Empty;
                    string genderId = cardElement.Attribute("GENDERID")?.Value ?? string.Empty;
                    string birthdayString = cardElement.Attribute("BIRTHDAY")?.Value ?? string.Empty;
                    DateTime birthday = string.IsNullOrEmpty(birthdayString) ? DateTime.MinValue : DateTime.Parse(birthdayString);

                    string phoneHome = cardElement.Attribute("PHONEHOME")?.Value ?? string.Empty;
                    string phoneMobil = cardElement.Attribute("PHONEMOBIL")?.Value ?? string.Empty;
                    string email = cardElement.Attribute("EMAIL")?.Value ?? string.Empty;
                    string city = cardElement.Attribute("CITY")?.Value ?? string.Empty;
                    string street = cardElement.Attribute("STREET")?.Value ?? string.Empty;
                    string house = cardElement.Attribute("HOUSE")?.Value ?? string.Empty;
                    string apartment = cardElement.Attribute("APARTMENT")?.Value ?? string.Empty;
                    string altAddress = cardElement.Attribute("ALTADDRESS")?.Value ?? string.Empty;
                    string cardType = cardElement.Attribute("CARDTYPE")?.Value ?? string.Empty;
                    string ownerGuid = cardElement.Attribute("OWNERGUID")?.Value ?? string.Empty;
                    string cardPer = cardElement.Attribute("CARDPER")?.Value ?? string.Empty;
                    string turnover = cardElement.Attribute("TURNOVER")?.Value ?? string.Empty;

                    using (SQLiteCommand insertCommand = new SQLiteCommand(
                        "INSERT INTO Clients (CardCode, StartDate, FinishDate, LastName, FirstName, SurName, FullName, GenderId, Birthday, PhoneHome, PhoneMobil, Email, City, Street, House, Apartment, AltAddress, CardType, OwnerGuid, CardPer, Turnover) " +
                        "VALUES (@cardCode, @startDate, @finishDate, @lastName, @firstName, @surName, @fullName, @genderId, @birthday, @phoneHome, @phoneMobil, @email, @city, @street, @house, @apartment, @altAddress, @cardType, @ownerGuid, @cardPer, @turnover)",
                        connection))
                    {
                        insertCommand.Parameters.AddWithValue("@cardCode", cardCode);
                        insertCommand.Parameters.AddWithValue("@startDate", startDate);
                        insertCommand.Parameters.AddWithValue("@finishDate", finishDate);
                        insertCommand.Parameters.AddWithValue("@lastName", lastName);
                        insertCommand.Parameters.AddWithValue("@firstName", firstName);
                        insertCommand.Parameters.AddWithValue("@surName", surName);
                        insertCommand.Parameters.AddWithValue("@fullName", fullName);
                        insertCommand.Parameters.AddWithValue("@genderId", genderId);
                        insertCommand.Parameters.AddWithValue("@birthday", birthday);
                        insertCommand.Parameters.AddWithValue("@phoneHome", phoneHome);
                        insertCommand.Parameters.AddWithValue("@phoneMobil", phoneMobil);
                        insertCommand.Parameters.AddWithValue("@email", email);
                        insertCommand.Parameters.AddWithValue("@city", city);
                        insertCommand.Parameters.AddWithValue("@street", street);
                        insertCommand.Parameters.AddWithValue("@house", house);
                        insertCommand.Parameters.AddWithValue("@apartment", apartment);
                        insertCommand.Parameters.AddWithValue("@altAddress", altAddress);
                        insertCommand.Parameters.AddWithValue("@cardType", cardType);
                        insertCommand.Parameters.AddWithValue("@ownerGuid", ownerGuid);
                        insertCommand.Parameters.AddWithValue("@cardPer", cardPer);
                        insertCommand.Parameters.AddWithValue("@turnover", turnover);

                        insertCommand.ExecuteNonQuery();
                    }
                }



                Console.WriteLine("Import completed successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
