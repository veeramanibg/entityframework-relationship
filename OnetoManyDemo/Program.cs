using OnetoManyDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnetoManyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EFTestModel())
            {
                IEnumerable<Customer> customers = context.Customers.ToList() as IEnumerable<Customer>;
                Console.WriteLine("Customer Details   : ");
                foreach (var item in customers)
                {
                    Console.WriteLine("Customer Name: " + string.Join(" ", new object[]
                        {
                        item.FirstName,item.LastName
                        }));
                    foreach (var cusdetails in item.CustomerDetails)
                    {
                        Console.WriteLine("    Customer Contacts   :" + string.Join(" ", new object[]
                        {
                       cusdetails.Email, cusdetails.Address
                        }));
                    }


                }

                // Insert();
                Console.ReadKey();
            }
            //Insert();

        }
        public static void Insert()
        {
            try
            {
                using (var context = new EFTestModel())
                {

                    using (var dbcontextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            context.Customers.Add(new Customer
                            {

                                FirstName = "Latha ",
                                LastName = "Aamu"
                            });
                            context.SaveChanges();
                            context.CustomerDetails.Add(new CustomerDetails
                            {
                                CustomerID = 10,
                                Email = "latha22@gmail.com",
                                Address = "Aamu"
                            });
                            context.SaveChanges();
                            dbcontextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbcontextTransaction.Rollback();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
