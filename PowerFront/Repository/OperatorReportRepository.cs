using PowerFront.Data;
using PowerFront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerFront.Repository
{
    public class OperatorReportRepository : IOperatorReportRepository
    {
        private readonly OperatorReportData operatorReportData;

        public OperatorReportRepository(OperatorReportData operatorReportData)
        {
            this.operatorReportData = operatorReportData;
        }

        public ICollection<string> GetDevices()
        {
            return operatorReportData.GetDevices();
        }

        public ICollection<OperatorReportViewModel> GetReport()
        {
            return operatorReportData.GetReport();
        }

        public ICollection<OperatorReportViewModel> GetReport(OperatorReportFilterViewModel model)
        {
            return operatorReportData.GetReport(model);
        }

        public ICollection<string> GetWebsites()
        {
            return operatorReportData.GetWebsites();
        }
    }
}