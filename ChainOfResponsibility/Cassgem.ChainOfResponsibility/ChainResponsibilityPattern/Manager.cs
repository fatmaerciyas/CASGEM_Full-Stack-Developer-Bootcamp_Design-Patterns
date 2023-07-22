using Cassgem.ChainOfResponsibility.Dal;
using Cassgem.ChainOfResponsibility.Models;

namespace Cassgem.ChainOfResponsibility.ChainResponsibilityPattern
{
    public class Manager: Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if (req.Amount <= 100000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Nurgül Yücel";
                customerProcess.Desciption = "Müşterinin talep ettiği tutar, şube müdürü tarafından ödendi.";
                context.CustomerProcesss.Add(customerProcess);
                context.SaveChanges();
            }

            else
            {

                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Nurgül Yücel";
                customerProcess.Desciption = "Müşteri tarafından talep edilen tutar günlük ödeme bakiyemi aştığı için işlemi bçlge müdürüne yönlendirdim";
                context.CustomerProcesss.Add(customerProcess);

                context.SaveChanges();
                NextApprover.ProcessRequest(req);

            }
        }
    }
}
