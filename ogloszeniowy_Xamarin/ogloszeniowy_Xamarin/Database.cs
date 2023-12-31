﻿using SQLite;
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

        public Task<int> InsertApplication(User_application userApp)
        {
            return _database.InsertAsync(userApp);
        }

        public Task<int> InsertSaved(User_saved userSaved)
        {
            return _database.InsertAsync(userSaved);
        }

        public Task<int> DeleteSaved(User_saved userSaved)
        {
            return _database.DeleteAsync(userSaved);
        }

        public Task<List<User_application>> GetApps(int user_id)
        {
            return _database.QueryAsync<User_application>("SELECT * FROM User_application WHERE User_id=?", user_id);
        }

        public Task<List<User_saved>> GetSaved(int user_id)
        {
            return _database.QueryAsync<User_saved>("SELECT * FROM User_saved WHERE User_id=?", user_id);
        }

        public Task<List<User_saved>> GetSavedById(int saved_id)
        {
            return _database.QueryAsync<User_saved>("SELECT * FROM User_saved WHERE Saved_id=? LIMIT 1", saved_id);
        }

        public Task<List<Announcement>> GetAnnouncementWithPageFilter(int page, int annPerPage)
        {
            int offset = (page * annPerPage) - annPerPage;
            return _database.QueryAsync<Announcement>("SELECT * FROM Announcement LIMIT ? OFFSET ?", annPerPage, offset);
        }

        public Task<List<Announcement>> GetAnnouncementById(int announcement_id)
        {
            return _database.QueryAsync<Announcement>("SELECT * FROM Announcement WHERE Announcement_id=? LIMIT 1", announcement_id);
        }

        public Task<List<Announcement>> GetAnnouncementByFiltres(string positionName, int category_id, string positionLevel, string contractType, string workingTime, string workType)
        {
            return _database.QueryAsync<Announcement>("SELECT * FROM Announcement WHERE Category_id=? AND Position_name LIKE ? AND Position_level=? AND Contract_type=? AND Working_time=? AND Work_type=?", category_id, $"%{positionName}%", positionLevel, contractType, workingTime, workType);
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

        public Task<List<Company>> GetCompanyById(int company_id)
        {
            return _database.QueryAsync<Company>("SELECT * FROM Company WHERE Company_id=? LIMIT 1", company_id);
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

        public Task<int> UpdateAnnoucement(Announcement announcement)
        {
            return _database.UpdateAsync(announcement);
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
