using MongoMvcDemo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MongoMvcDemo.Services
{
    public class EmployeeService
    {
        private readonly IMongoCollection<Employee> _employees;

        public EmployeeService(IOptions<MongoDbSettings> settings, IMongoClient client)
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _employees = database.GetCollection<Employee>(settings.Value.EmployeesCollection);
        }

        public List<Employee> GetAll() => _employees.Find(emp => true).ToList();
        public Employee? Get(string id) => _employees.Find(emp => emp.Id == id).FirstOrDefault();
        public void Create(Employee emp) => _employees.InsertOne(emp);
        public void Update(string id, Employee emp) => _employees.ReplaceOne(e => e.Id == id, emp);
        public void Delete(string id) => _employees.DeleteOne(e => e.Id == id);
    }
}