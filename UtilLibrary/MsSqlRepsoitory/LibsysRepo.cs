﻿using Dapper;
using System;
using System.Collections.Generic;
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
            //_connectionString = ConfigurationManager.ConnectionStrings["LibsysAzure"].ConnectionString;
            _connectionString = "Data Source=SQL6009.site4now.net;Initial Catalog=DB_A53DDD_mpol;User Id=DB_A53DDD_mpol_admin;Password=Password123;";
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

        #region librarian
        /// <summary>
        /// Adds a librarian to the database. Returns an ID number
        /// and adds it to librarian.
        /// </summary>
        /// <param name="visitor">A filled librarian object</param>
        public void AddNewLibrarian(ILibrarians librarian)
        {
            string storedProcedure = StoredProcedures.AddNewLibrarians.ToString();

            var obj = new { 
                CheifLibrarian = librarian.CheifLibrarian,
                Password = librarian.Password,
                FirstName = librarian.Firstname,
                LastName = librarian.Firstname
            };

            using (var conn = Create_Connection())
            {
                var id = conn.Query<int>(storedProcedure, obj, commandType: CommandType.StoredProcedure).Single();
                librarian.LibrarianID = id;
            }
        }
        #endregion

        #region visitors
        /// <summary>
        /// Adds a visitor to the database. Returns an ID number
        /// and adds it to visitor.
        /// </summary>
        /// <param name="visitor">A filled visitor object</param>
        public void AddNewVisitor(IVisitors visitor)
        {
            string storedProcedure = StoredProcedures.AddNewVisitor.ToString();

            var obj = new { 
                IdentityNo = visitor.IdentityNo,
                Firstname = visitor.Firstname,
                Lastname = visitor.Lastname,
                Password = visitor.Password
            };

            using (var conn = Create_Connection())
            {
                var id = conn.Query<int>(storedProcedure, obj, commandType: CommandType.StoredProcedure).Single();
                visitor.VisitorsID = id;
            }
        }
        #endregion

        #region User
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
        #endregion
    }
}
