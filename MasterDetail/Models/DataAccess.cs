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
            connection.CreateTable<Supermercado>();
            connection.CreateTable<TraceabilityWorkShift>();
            connection.CreateTable<Turnos>();
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


        public void InsertSupermercado(Supermercado supermercado)
        {
            connection.Insert(supermercado);
        }
        public void UpdateSupermercado(Supermercado supermercado)
        {
            connection.Update(supermercado);
        }
        public void DeleteSupermercado(Supermercado supermercado)
        {
            connection.Delete(supermercado);
        }
        public Supermercado GetSupermercado(int id)
        {
            return connection.Table<Supermercado>().FirstOrDefault(x => x.Id == id);
        }
        public List<Supermercado> GetSupermercados()
        {
            return connection.Table<Supermercado>().OrderBy(x => x.SpmName).ToList();
        }
        public void DisposeSupermercado()
        {
            connection.Dispose();
        }


        public void InsertTurno(Turnos turno)
        {
            connection.Insert(turno);
        }
        public void UpdateTurno(Turnos turno)
        {
            connection.Update(turno);
        }
        public void DeleteTurno(Turnos turno)
        {
            connection.Delete(turno);
        }
        public Turnos GetTurno(int id)
        {
            return connection.Table<Turnos>().FirstOrDefault(x => x.Id == id);
        }
        public List<Turnos> GetTurnos()
        {
            return connection.Table<Turnos>().OrderBy(x => x.TurnDate).ToList();
        }
        public void DisposeTurnos()
        {
            connection.Dispose();
        }


        public void InsertTraza(TraceabilityWorkShift traceabilityWork)
        {
            connection.Insert(traceabilityWork);
        }
        public void UpdateTraza(TraceabilityWorkShift traceabilityWork)
        {
            connection.Update(traceabilityWork);
        }
        public void DeleteTraza(TraceabilityWorkShift traceabilityWork)
        {
            connection.Delete(traceabilityWork);
        }
        public TraceabilityWorkShift GetTraza(int id)
        {
            return connection.Table<TraceabilityWorkShift>().FirstOrDefault(x => x.Id == id);
        }
        public List<TraceabilityWorkShift> GetTrazas()
        {
            return connection.Table<TraceabilityWorkShift>().OrderBy(x => x.ActualState).ToList();
        }
        public void DisposeTraza()
        {
            connection.Dispose();
        }

    }
}
