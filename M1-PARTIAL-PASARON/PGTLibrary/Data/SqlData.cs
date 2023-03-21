using PGTLibrary.Database;
using PGTLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTLibrary.Data
{
    public class SqlData : ISqlData
    {
        private ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }

        public usermodel verify(string username, string password)
        {
            usermodel result = _db.LoadData<usermodel, dynamic>("dbo.login",
                new { username, password }, connectionStringName, true).FirstOrDefault();

            return result;
        }

        public void register(string username, string firstName, string lastName, string password)
        {
            _db.SaveData<dynamic>(
                "dbo.register",
                new { username, firstName, lastName, password },
                connectionStringName,
                true
                );
        }

        public void addgastos(lagaymodel gastos)
        {
            _db.SaveData("lagay", new
            {
                gastos.userId,
                gastos.GastosName,
                gastos.GastosType,
                gastos.Brand,
                gastos.Code,
                gastos.Remarks,
                gastos.dateAdded,
                gastos.Price
            },
                connectionStringName, true);
        }

        public List<listgastos> listgastos()
        {
            return _db.LoadData<listgastos, dynamic>("dbo.listgastos", new { }, connectionStringName, true).ToList();
        }

        public listgastos showgastosdetails(DateOnly dateAdded)
        {
            return _db.LoadData<listgastos, dynamic>("dbo.showdateofgastos", new { dateAdded }, connectionStringName, true).FirstOrDefault();
        }

    }
}
