using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using System.IO;
using CsvHelper;
using System.Globalization;

namespace hadOOP
{
    class User
    {
        public List<User> users = new List<User>();

        
        public string UserName { get; set; }
        
        public string PwdHash { get; set; }
        
        public int HighScore { get; set; }

        public User(string userName, string pwdHash, int highScore)
        {
            UserName = userName;
            PwdHash = pwdHash;
            HighScore = highScore;
        }
        private void SetHighScore(int score)
        {
            if(score > this.HighScore)
            {
                this.HighScore = score;
            }
        }

        public void CreateUser(User user)
        {
            LoadUserList();
            if(UserNameTaken(user.UserName))
            {
                Console.WriteLine("Dej si jíne jmeno");
            }
            else
            {
                users.Add(user);
                var csvPath = Path.Combine(Environment.CurrentDirectory, "users.csv");

                using (var streamWriter = new StreamWriter(csvPath))
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    var userList = users;
                    csvWriter.WriteRecords(userList);
                }
            }
        }

        public void LoadUserList()
        {
            var csvPath = Path.Combine(Environment.CurrentDirectory, "users.csv");

            using(var streamReader = new StreamReader(csvPath))
            using(var csvParser = new CsvParser(streamReader,CultureInfo.InvariantCulture))
            {
                csvParser.Read();
                while(csvParser.Read())
                {
                    var userRecord = csvParser.Record;
                    var user = new User(userRecord[0], userRecord[1], int.Parse(userRecord[2]));
                    users.Add(user);
                }
            }
        }

        public bool UserNameTaken(string userName)
        {
            foreach(User u in users)
            {
                if(u.UserName == userName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
