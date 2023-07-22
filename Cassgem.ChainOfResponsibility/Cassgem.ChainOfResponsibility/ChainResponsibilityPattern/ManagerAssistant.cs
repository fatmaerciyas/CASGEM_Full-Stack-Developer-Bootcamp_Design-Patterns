using Cassgem.ChainOfResponsibility.Dal;
using Cassgem.ChainOfResponsibility.Models;

namespace Cassgem.ChainOfResponsibility.ChainResponsibilityPattern
{
    public class ManagerAssistant : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if(req.Amount <= 100000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Aleyna Çelik";
                customerProcess.Desciption = "Müşterinin talep ettiği tutar, şube müdür yardımcısı tarafından ödendi.";
                context.CustomerProcesss.Add(customerProcess);
                context.SaveChanges();
            }

            else
            {

                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Aleyna Çelik";
                customerProcess.Desciption = "Müşteri tarafından talep edilen tutar günlük ödeme bakiyemi aştığı için işlemi şube müdürüne yönlendirdim";
                context.CustomerProcesss.Add(customerProcess);

                context.SaveChanges();
                NextApprover.ProcessRequest(req);

            }
        }
    }
}
