using Dapper;
using GCS.Domain.Concrete;
using GCS.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Repository.Concrete.Dapper
{
    public class DprContainerRepository:DprRepository<Container>,IContainerRepository
    {
        public DprContainerRepository(IDbConnection connection):base(connection)
        {

        }

        public List<Container> GetAllByVehicleId(long id)
        {
            var sql = "SELECT * FROM Containers A INNER JOIN Vehicles B on A.vehicleId = B.Id";
            var result = _connection.Query<Container, Vehicle, Container>(sql,
            (b, a) => { b.Vehicle = a; return b; }, splitOn: "Id");
            return result.ToList();
        }
    }
}
