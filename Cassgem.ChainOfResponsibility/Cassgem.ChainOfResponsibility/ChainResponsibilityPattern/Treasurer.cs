using Cassgem.ChainOfResponsibility.Dal;
using Cassgem.ChainOfResponsibility.Models;

namespace Cassgem.ChainOfResponsibility.ChainResponsibilityPattern
{
    public class Treasurer : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if(req.Amount <= 50000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Fatma Erciyas";
                customerProcess.Desciption = "Müşterinin talep ettiği tutar, veznedar tarafından ödendi.";
                context.CustomerProcesss.Add(customerProcess);

                context.SaveChanges();
            }

            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Fatma Erciyas";
                customerProcess.Desciption = "Müşteri tarafından talep edilen tutar günlük ödeme bakiyemi aştığı için işlemi şube müdür yardımcısına yönlendirdim";
                context.CustomerProcesss.Add(customerProcess);

                context.SaveChanges();
                NextApprover.ProcessRequest(req);

               

            }
        }
    }
}
