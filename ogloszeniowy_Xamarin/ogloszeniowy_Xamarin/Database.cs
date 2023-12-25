using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using system_ogloszeniowy.classes;
using system_ogloszeniowy.Tables;

namespace system_ogloszeniowyAleToXamarin
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Announcement>().Wait();
            _database.CreateTableAsync<Announcement_category>().Wait();
            _database.CreateTableAsync<Announcement_subcategory>().Wait();
            _database.CreateTableAsync<Announcement_working_days>().Wait();
            _database.CreateTableAsync<Company>().Wait();
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<User_application>().Wait();
            _database.CreateTableAsync<User_course>().Wait();
            _database.CreateTableAsync<User_data>().Wait();
            _database.CreateTableAsync<User_education>().Wait();
            _database.CreateTableAsync<User_experience>().Wait();
            _database.CreateTableAsync<User_language>().Wait();
            _database.CreateTableAsync<User_link>().Wait();
            _database.CreateTableAsync<User_role>().Wait();
            _database.CreateTableAsync<User_saved>().Wait();
            _database.CreateTableAsync<User_skill>().Wait();
        }

        public Task<List<User>> GetUsers()
        {
            return _database.QueryAsync<User>("SELECT * FROM User");
        }

        public Task<List<User>> GetUsers(string login)
        {
            return _database.QueryAsync<User>("SELECT * FROM User WHERE Login=?", login);
        }

        public Task<List<User>> GetUsers(string login, string password)
        {
            return _database.QueryAsync<User>("SELECT * FROM User WHERE Login=? AND Password=?", login, password);
        }

        public Task<int> InsertUser(User user)
        {
            return _database.InsertAsync(user);
        }

        public Task<int> InsertRole(User_role role)
        {
            return _database.InsertAsync(role);
        }

        public Task<int> InsertAnnouncement(Announcement announcement)
        {
            return _database.InsertAsync(announcement);
        }

        public Task<List<User_role>> GetRoles()
        {
            return _database.QueryAsync<User_role>("SELECT * FROM User_role");
        }

        public Task<List<Announcement>> GetAnnouncements()
        {
            return _database.QueryAsync<Announcement>("SELECT * FROM Announcement");
        }

        public Task<List<Company>> GetCompany()
        {
            return _database.QueryAsync<Company>("SELECT * FROM Company");
        }

        public Task<List<Announcement_category>> GetCategory()
        {
            return _database.QueryAsync<Announcement_category>("SELECT * FROM Announcement_category");
        }

        public Task<List<User_language>> GetUser_language()
        {
            return _database.QueryAsync<User_language>("SELECT * FROM User_language");
        }

        public Task<List<User_language>> GetUser_language(int user_id)
        {
            return _database.QueryAsync<User_language>("SELECT * FROM User_language WHERE User_id=?", user_id);
        }

        public Task<int> InsertUser_language(User_language language)
        {
            return _database.InsertAsync(language);
        }

        public Task<List<User_data>> GetUser_data(int user_id)
        {
            return _database.QueryAsync<User_data>("SELECT * FROM User_data WHERE User_id=?", user_id);
        }

        public Task<int> InsertUser_data(User_data user_data)
        {
            return _database.InsertAsync(user_data);
        }

        public Task<int> DeleteUser_language(User_language language)
        {
            return _database.DeleteAsync(language);
        }

        public Task<int> UpdateUser_data(User_data user_data)
        {
            return _database.UpdateAsync(user_data);
        }

        public Task<int> UpdateUser(User user)
        {
            return _database.UpdateAsync(user);
        }

        public Task<int> InsertCategory(Announcement_category category)
        {
            return _database.InsertAsync(category);
        }

        public Task<int> InsertCompany(Company company)
        {
            return _database.InsertAsync(company);
        }
    }
}
