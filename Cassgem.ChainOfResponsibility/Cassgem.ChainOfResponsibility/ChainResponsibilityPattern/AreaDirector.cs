using Cassgem.ChainOfResponsibility.Dal;
using Cassgem.ChainOfResponsibility.Models;

namespace Cassgem.ChainOfResponsibility.ChainResponsibilityPattern
{
    public class AreaDirector:  Employee
    {

        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if (req.Amount <= 300000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Hakan Bahşiş";
                customerProcess.Desciption = "Müşterinin talep ettiği tutar, bölge müdürü tarafından ödendi.";
                context.CustomerProcesss.Add(customerProcess);
                context.SaveChanges();
            }

            else
            {

                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Hakan Bahşiş";
                customerProcess.Desciption = "Müşteri tarafından talep edilen tutar günlük ödeme bakiyemi aştığı için işlem gerçekleştirilemedi";
                context.CustomerProcesss.Add(customerProcess);

                context.SaveChanges();
             
            }
        }
    }
}
