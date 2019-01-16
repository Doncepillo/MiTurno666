using MasterDetail.Interface;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterDetail
{
    public class DataAccess: IDisposable
    {
        private SQLiteConnection connection;

        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            connection = new SQLiteConnection(config.Plataforma,
                System.IO.Path.Combine(config.DirectorioDB, "MiturnoDB.db3"));

            connection.CreateTable<EmpaqueModel>();
        }
        public void InsertEmpaque(EmpaqueModel empaque)
        {
            connection.Insert(empaque);
        }
        public void UpdateEmpaque(EmpaqueModel empaque)
        {
            connection.Update(empaque);
        }
        public void DeleteEmpaque(EmpaqueModel empaque)
        {
            connection.Delete(empaque);
        }
        public EmpaqueModel GetEmpaque (int id)
        {
            return connection.Table<EmpaqueModel>().FirstOrDefault(x => x.Id == id);
        }
        public List<EmpaqueModel> GetEmpaques()
        {
            return connection.Table<EmpaqueModel>().OrderBy(x => x.LastName).ToList();
        }
        public void Dispose()
        {
            connection.Dispose();
        }

  }
}
