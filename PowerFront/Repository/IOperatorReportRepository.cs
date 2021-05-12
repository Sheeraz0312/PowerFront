using PowerFront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerFront.Repository
{
    public interface IOperatorReportRepository
    {
        ICollection<OperatorReportViewModel> GetReport();
        ICollection<string> GetWebsites();
        ICollection<string> GetDevices();
        ICollection<OperatorReportViewModel> GetReport(OperatorReportFilterViewModel model);
    }
}
