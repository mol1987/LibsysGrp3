﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilLibrary.MsSqlRepsoitory.Enums;

namespace UtilLibrary.MsSqlRepsoitory
{
    /// <summary>
    /// A repository for our library application.
    /// </summary>
    public class LibsysRepo : ILibsysRepo
    {
        #region privates
        private readonly string _connectionString;

        #endregion

        #region constructor
        public LibsysRepo()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LibsysAzureJesse"].ConnectionString;
        }
        #endregion

        #region UtilMethods
        private SqlConnection Create_Connection()
        {
            return new SqlConnection(_connectionString);
        }

        #endregion

        #region items
        #endregion

        #region seminars
        #endregion

        #region Users
        public IUsers LoginUser(string identityNo, string password)
        {
            IUsers returnUser = null;
            string storedProcedure = StoredProcedures.Login.ToString();

            var obj = new
            {
                IdentityNo = identityNo,
                Password = password
            };

            using (var conn = Create_Connection())
            {
                returnUser = conn.Query<Users>(storedProcedure, obj, commandType: CommandType.StoredProcedure).Single();
            }

            return returnUser;
        }
        public void AddUser(IUsers user)
        {
            string storedProcedure = StoredProcedures.AddUser.ToString();
            int affectedRows;

            var obj = new
            {
                IdentityNo = user.IdentityNo,
                Password = user.Password,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                JoinDate = user.JoinDate,
                Banned = user.Banned,
                UsersCategory = user.UsersCategory
            };

            using (var conn = Create_Connection())
            {
                affectedRows = conn.Execute(storedProcedure, obj, commandType: CommandType.StoredProcedure);
            }
          
        }
        public IEnumerable<T> GetUsers<T>()
        {
            string storedProcedure = StoredProcedures.GetUsers.ToString();
            IEnumerable<T> usersList;
            using (var conn = Create_Connection())
            {
                usersList = conn.Query<T>(storedProcedure, commandType: CommandType.StoredProcedure);
            }
            return usersList;
        } 
        public void RemoveUser(IUsers user)
        {
            string storedProcedure = StoredProcedures.DeleteUser.ToString();
            var obj = new
            {
                UsersID = user.UsersID
            };
            using (var conn = Create_Connection())
            {
                conn.Execute(storedProcedure, obj, commandType: CommandType.StoredProcedure);
            }
        }
        public void EditUser(IUsers user)
        {
            string storedProcedure = StoredProcedures.EditUser.ToString();
            var obj = new
            {
                UsersID = user.UsersID,
                IdentityNo = user.IdentityNo,
                Password = user.Password,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                JoinDate = user.JoinDate,
                Banned = user.Banned,
                UsersCategory = user.UsersCategory
            };
            using (var conn = Create_Connection())
            {
                conn.Execute(storedProcedure, obj, commandType: CommandType.StoredProcedure);
            }
        }
        #endregion
    }
}
