using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OnetoOneDemo.Model;
namespace OnetoOneDemo
{
    class Program
    {

        static void Main(string[] args)
        {

            //Customer customer;
            using (var context = new EFTestModel())
            {
                IEnumerable<Customer> customers = context.Customers.ToList() as IEnumerable<Customer>;
                Console.WriteLine("Customer Details   : ");
                foreach (var item in customers)
                {
                    Console.WriteLine("Customer Name: " + string.Join(" ", new object[]
                        {
                        item.FirstName,item.LastName
                        }) + "    Customer Contacts   :" + string.Join(" ", new object[]
                        {
                       item.CustomerDetails.Email, item.CustomerDetails.Address
                        }));
                }

                // Insert();
                Console.ReadKey();
            }
        }

        public static void Insert()
        {
            try
            {
                using (var context = new EFTestModel())
                {
                    context.Customers.Add(new Customer
                    {
                        CustomerID = 2,
                        FirstName = "Karthik ",
                        LastName = "Maha"
                    });
                    //context.SaveChanges();
                    context.CustomerDetails.Add(new CustomerDetails
                    {
                        CustomerID = 2,
                        Email = "Karthik@gmail.com",
                        Address = "Dindual"
                    });
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
