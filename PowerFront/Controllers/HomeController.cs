using OfficeOpenXml;
using PowerFront.Models;
using PowerFront.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowerFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOperatorReportRepository repository;

        public HomeController(IOperatorReportRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            ViewBag.Websites = repository.GetWebsites();
            ViewBag.Devices = repository.GetDevices();
            return View();
        }

        public JsonResult GetReportData()
        {
            return Json(repository.GetReport(),JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetFilteredReportData(OperatorReportFilterViewModel model)
        {
            return Json(repository.GetReport(model), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void DownloadExcel(OperatorReportFilterViewModel model)
        {  
            var operatorReport  = repository.GetReport(model);

            ExcelPackage Ep = new ExcelPackage();
            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Report");
            Sheet.Cells["A1"].Value = "S.No";
            Sheet.Cells["B1"].Value = "Operator Name";
            Sheet.Cells["C1"].Value = "Proactive Sent";
            Sheet.Cells["D1"].Value = "Proactive Answered";
            Sheet.Cells["E1"].Value = "Proactive Response Rate";
            Sheet.Cells["F1"].Value = "Reactive Received";
            Sheet.Cells["G1"].Value = "Reactive Answered";
            Sheet.Cells["H1"].Value = "Reactive Response Rate";
            Sheet.Cells["I1"].Value = "Total Chat Length";
            Sheet.Cells["J1"].Value = "Average Chat Length";
            int row = 2;
            foreach (var item in operatorReport)
            { 
                Sheet.Cells[string.Format("A{0}", row)].Value = item.ID;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.Name;
                Sheet.Cells[string.Format("C{0}", row)].Value = item.ProactiveSent;
                Sheet.Cells[string.Format("D{0}", row)].Value = item.ProactiveAnswered;
                Sheet.Cells[string.Format("E{0}", row)].Value = item.ProactiveResponseRate;
                Sheet.Cells[string.Format("F{0}", row)].Value = item.ReactiveReceived;
                Sheet.Cells[string.Format("G{0}", row)].Value = item.ReactiveAnswered;
                Sheet.Cells[string.Format("H{0}", row)].Value = item.ReactiveResponseRate;
                Sheet.Cells[string.Format("I{0}", row)].Value = item.TotalChatLength;
                Sheet.Cells[string.Format("J{0}", row)].Value = item.AverageChatLength;
                row++;
            }


            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "Report.xlsx");
            Response.BinaryWrite(Ep.GetAsByteArray());
            Response.End();
        }
    }
}