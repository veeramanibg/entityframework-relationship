using OnetoOneFluentDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnetoOneFluentDemo
{
    class Program
    {
        static void Main(string[] args)
        {


            //Customer customer;
            using (var context = new EFTestModelOnetoOneFluent())
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
    }
}
