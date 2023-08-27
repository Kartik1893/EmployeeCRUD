using EmployeeTestProject.DTO.Request;

namespace EmployeeTestProject.Models
{
    public static class SeedData
    {

        public static async void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();

                var employeeList = new List<Employee>()
                {
                    new Employee
                {
                    FirstName = "Vicki",
                    LastName = "Vinson",
                    Age = 30,
                    Email = "VickiGVinson@rhyta.com",
                    CreatedTs = DateTime.UtcNow,
                    IsActive = true
                },
                new Employee
                {
                    FirstName = "Jon",
                    LastName = "Medina",
                    Age = 33,
                    Email = "JonRMedina@jourrapide.com",
                    CreatedTs = DateTime.UtcNow,
                    IsActive = true
                },
                new Employee
                {
                    FirstName = "Joshua",
                    LastName = "Russell",
                    Age = 38,
                    Email = "JoshuaCRussell@armyspy.com",
                    CreatedTs = DateTime.UtcNow,
                    IsActive = true
                },
                new Employee
                {
                    FirstName = "Janet",
                    LastName = "Sanches",
                    Age = 24,
                    Email = "JanetDSanches@jourrapide.com",
                    CreatedTs = DateTime.UtcNow,
                    IsActive = true
                },
                new Employee
                {
                    FirstName = "Dennis",
                    LastName = "Lueck",
                    Age = 28,
                    Email = "DennisWLueck@teleworm.us",
                    CreatedTs = DateTime.UtcNow,
                    IsActive = true
                }
                };

                var employeeAddressList = new List<EmployeeAddress>(){
                     new EmployeeAddress
                {
                    Address1 = "3284 Worley Avenue",
                    Address2 =  "Valley Lane",
                    City = "Mountain View",
                    State = "California",
                    Country ="United States",
                    ZipCode = "82939",
                    CreatedTs = DateTime.UtcNow,
                    EmployeeAddressId = Guid.NewGuid(),
                    IsActive = true,
                },
                new EmployeeAddress
                {
                    Address1 = "4648 Franklin Avenue",
                    Address2 =  "Rollins Road",
                    City = "Live Oak",
                    State = "California",
                    Country = "United States",
                    ZipCode = "32064",
                    CreatedTs = DateTime.UtcNow,
                    EmployeeAddressId = Guid.NewGuid(),
                    IsActive = true
                },
                new EmployeeAddress
                {
                    Address1 = "1489 Heliport Loop",
                    Address2 =  "Don Jackson Lane",
                    City = "Jasper",
                    State = "Florida",
                    Country = "United States",
                    ZipCode = "47546",
                    CreatedTs = DateTime.UtcNow,
                    EmployeeAddressId = Guid.NewGuid(),
                    IsActive = true
                },
                new EmployeeAddress
                {
                    Address1 = "115 Ward Road",
                    Address2 =  "Sheila Lane",
                    City = "White Plains",
                    State = "New York",
                    Country = "United States",
                    ZipCode = "10601",
                    CreatedTs = DateTime.UtcNow,
                    EmployeeAddressId = Guid.NewGuid(),
                    IsActive = true
                },
                new EmployeeAddress
                {
                    Address1 = "3052 Brighton Circle Road",
                    Address2 =  "Briarhill Lane",
                    City = "Lester Prairie",
                    State = "California",
                    Country = "United States",
                    ZipCode = "55354",
                    CreatedTs = DateTime.UtcNow,
                    EmployeeAddressId = Guid.NewGuid(),
                    IsActive = true
                }
                };
                if (!context.Employee.Any())
                {
                    for (int i = 0; i < employeeList.Count; i++)
                    {
                        var empId = Guid.NewGuid();
                        employeeList[i].EmployeeId = empId;
                        employeeAddressList[i].EmployeeId = empId;
                    }
                    await context.AddRangeAsync(employeeList);
                    await context.AddRangeAsync(employeeAddressList);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}

