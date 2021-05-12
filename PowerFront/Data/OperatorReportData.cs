using PowerFront.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PowerFront.Data
{
    public class OperatorReportData
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        public ICollection<OperatorReportViewModel> GetReport()
        {
            var report = new List<OperatorReportViewModel>();
            try
            {
                SqlCommand sqlcomm = new SqlCommand("[OperatorProductivity]", conn);
                sqlcomm.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = sqlcomm.ExecuteReader();
                while (dr.Read())
                {
                    OperatorReportViewModel opVM = new OperatorReportViewModel();
                    opVM.ID = Convert.ToInt32(dr[0]);
                    opVM.Name = Convert.ToString(dr[1]);
                    opVM.ProactiveSent = Convert.ToInt32(dr[2]) > 0 ? Convert.ToInt32(dr[2]).ToString() : "--";
                    opVM.ProactiveAnswered = Convert.ToInt32(dr[3]) > 0 ? Convert.ToInt32(dr[3]).ToString() : "--";
                    opVM.ProactiveResponseRate = Convert.ToInt32(dr[4]) > 0 ? Convert.ToInt32(dr[4]).ToString() + "%" : "--";
                    opVM.ReactiveReceived = Convert.ToInt32(dr[5]) > 0 ? Convert.ToInt32(dr[5]).ToString() : "--";
                    opVM.ReactiveAnswered = Convert.ToInt32(dr[6]) > 0 ? Convert.ToInt32(dr[6]).ToString() : "--";
                    opVM.ReactiveResponseRate = Convert.ToInt32(dr[7]) > 0 ? Convert.ToInt32(dr[7]).ToString() + "%" : "--";
                    opVM.AverageChatLength = string.IsNullOrEmpty(Convert.ToString(dr[9])) ? "--" : Convert.ToString(dr[9]) + "m";
                    opVM.TotalChatLength = string.IsNullOrEmpty(Convert.ToString(dr[8])) ? "--" : Common.DateTimeManagement.RelativeTime(Convert.ToInt32(dr[8]));
                    report.Add(opVM);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return report;
        }

        public ICollection<OperatorReportViewModel> GetReport(OperatorReportFilterViewModel model)
        {
            var report = new List<OperatorReportViewModel>();
            try
            {
                SqlCommand sqlcomm = new SqlCommand("[OperatorProductivity]", conn);
                sqlcomm.CommandType = System.Data.CommandType.StoredProcedure;
                sqlcomm.Parameters.AddWithValue("@website", model.Website);
                sqlcomm.Parameters.AddWithValue("@device", model.Device);
                switch (model.DateFilter)
                {
                    case "Custom":
                        {
                            sqlcomm.Parameters.AddWithValue("@From", model.From);
                            sqlcomm.Parameters.AddWithValue("@To", model.To);
                            break;
                        }
                    case "Pre-Defined":
                        {
                            switch (model.PreDefined)
                            {
                                case "Today":
                                    {
                                        sqlcomm.Parameters.AddWithValue("@From", DateTime.Now);
                                        sqlcomm.Parameters.AddWithValue("@To", DateTime.Now);
                                        break;
                                    }
                                case "Yesterday":
                                    {
                                        sqlcomm.Parameters.AddWithValue("@From", DateTime.Now.AddDays(-1));
                                        sqlcomm.Parameters.AddWithValue("@To", DateTime.Now.AddDays(-1));
                                        break;
                                    }
                                case "This Week":
                                    {
                                        sqlcomm.Parameters.AddWithValue("@From", DateTime.Now.AddDays(-((int)DateTime.Now.DayOfWeek - 1)));
                                        sqlcomm.Parameters.AddWithValue("@To", DateTime.Now);
                                        break;
                                    }
                                case "Last Week":
                                    {
                                        sqlcomm.Parameters.AddWithValue("@From", DateTime.Now.AddDays(-((int)DateTime.Now.DayOfWeek - 1)).AddDays(-7));
                                        sqlcomm.Parameters.AddWithValue("@To", DateTime.Now.AddDays(-((int)DateTime.Now.DayOfWeek - 1)));
                                        break;
                                    }
                                case "This Month":
                                    {
                                        sqlcomm.Parameters.AddWithValue("@From",new DateTime(DateTime.Now.Year, DateTime.Now.Month,1));
                                        sqlcomm.Parameters.AddWithValue("@To", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)));
                                        break;
                                    }
                                case "Last Month":
                                    {
                                        sqlcomm.Parameters.AddWithValue("@From", new DateTime(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month, 1));
                                        sqlcomm.Parameters.AddWithValue("@To", new DateTime(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month, DateTime.DaysInMonth(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month)));
                                        break;
                                    }
                                case "This Year":
                                    {
                                        sqlcomm.Parameters.AddWithValue("@From", new DateTime(DateTime.Now.Year,1,1));
                                        sqlcomm.Parameters.AddWithValue("@To", DateTime.Now);
                                        break;
                                    }
                                case "Last Year":
                                    {
                                        sqlcomm.Parameters.AddWithValue("@From", new DateTime(DateTime.Now.AddYears(-1).Year,1, 1));
                                        sqlcomm.Parameters.AddWithValue("@To", new DateTime(DateTime.Now.AddYears(-1).Year,12, DateTime.DaysInMonth(DateTime.Now.AddYears(-1).Year, DateTime.Now.AddYears(-1).Month)));
                                        break;
                                    }
                                default:
                                    break;
                            }
                            break;
                        }
                    default:
                        break;
                }
                conn.Open();
                SqlDataReader dr = sqlcomm.ExecuteReader();
                while (dr.Read())
                {
                    OperatorReportViewModel opVM = new OperatorReportViewModel();
                    opVM.ID = Convert.ToInt32(dr[0]);
                    opVM.Name = Convert.ToString(dr[1]);
                    opVM.ProactiveSent = Convert.ToInt32(dr[2]) > 0 ? Convert.ToInt32(dr[2]).ToString() : "--";
                    opVM.ProactiveAnswered = Convert.ToInt32(dr[3]) > 0 ? Convert.ToInt32(dr[3]).ToString() : "--";
                    opVM.ProactiveResponseRate = Convert.ToInt32(dr[4]) > 0 ? Convert.ToInt32(dr[4]).ToString() + "%" : "--";
                    opVM.ReactiveReceived = Convert.ToInt32(dr[5]) > 0 ? Convert.ToInt32(dr[5]).ToString() : "--";
                    opVM.ReactiveAnswered = Convert.ToInt32(dr[6]) > 0 ? Convert.ToInt32(dr[6]).ToString() : "--";
                    opVM.ReactiveResponseRate = Convert.ToInt32(dr[7]) > 0 ? Convert.ToInt32(dr[7]).ToString() + "%" : "--";
                    opVM.AverageChatLength = string.IsNullOrEmpty(Convert.ToString(dr[9])) ? "--" : Convert.ToString(dr[9]) + "m";
                    opVM.TotalChatLength = string.IsNullOrEmpty(Convert.ToString(dr[8])) ? "--" : Common.DateTimeManagement.RelativeTime(Convert.ToInt32(dr[8]));
                    report.Add(opVM);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return report;
        }

        public ICollection<string> GetWebsites()
        {
            var websites = new List<string>();
            try
            {
                SqlCommand sqlcomm = new SqlCommand("[sp_chat_websites]", conn);
                sqlcomm.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = sqlcomm.ExecuteReader();
                while (dr.Read())
                { 
                    websites.Add(Convert.ToString(dr[0]));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return websites;
        }

        public ICollection<string> GetDevices()
        {
            var devices = new List<string>();
            try
            {
                SqlCommand sqlcomm = new SqlCommand("[sp_chat_devices]", conn);
                sqlcomm.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = sqlcomm.ExecuteReader();
                while (dr.Read())
                {
                    devices.Add(Convert.ToString(dr[0]));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return devices;
        }
    }
}