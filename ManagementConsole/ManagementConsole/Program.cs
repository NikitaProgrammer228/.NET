using ManagementConsole.Data;
using ManagementConsole.Models;

static void Main(string[] args)
{
    using (var db = new DataContext())
    {
        SeedData(db);
    }
}

 static void SeedData(DataContext db)
{
    // Step A: Add 3 entries to the department table
    var departments = new List<Department>
    {
        new Department { Id = Guid.NewGuid(), Name = "Management" },
        new Department { Id = Guid.NewGuid(), Name = "Development" },
        new Department { Id = Guid.NewGuid(), Name = "Analytics" }
    };
      
    db.Departments.AddRange(departments);
    db.SaveChanges();

    // Step B: Add 100 entries to the employee table
    var random = new Random();

    for (int i = 0; i < 100; i++)
    {
        var departmentId = departments[random.Next(0, 3)].Id;
        var timespan = random.Next(0, 3) switch
        {
            0 => "08:00-17:00",
            1 => "09:00-18:00",
            2 => "10:00-19:00",
            _ => throw new NotImplementedException(),
        };

        db.Employees.Add(new Employee
        {
            Id = Guid.NewGuid(),
            DepartmentId = departmentId,
            Timespan = timespan,
            Busy = false
        });
    }

    db.SaveChanges();
}