using AllinOne.Models;
using Dapper;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

#pragma warning disable

namespace AllinOne.Services
{
    public class StudentService
    {
        private readonly string connectionString = WebApplication.CreateBuilder().Configuration.GetConnectionString("StagingConnection");
        public Student GetStudentById(int id)
        {

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                // default holatda recommendation sql injectiondan himoyalaydi
                //DynamicParameters parameter = new DynamicParameters();
                //parameter.Add("id", id);
                //parameter.Add("Branch", id);

                var values = new
                {
                    Id = id,
                    BranchId = 3
                };

                Student student = connection.QueryFirstOrDefault<Student>("GetStudentById", values, commandTimeout: 90 ,commandType: CommandType.StoredProcedure);

                return student;
            }
           
        }
    }
}
