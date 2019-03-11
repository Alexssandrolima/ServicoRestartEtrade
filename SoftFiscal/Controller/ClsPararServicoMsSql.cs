using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceProcess;
using System.Windows.Forms;


namespace SoftFiscal.Controller
{
    class ClsPararServicoMsSql
    {
        static string sMsql = "MSSQL$SQL2014";

        internal static bool MetodoPararIniciarServicoSql()
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController p in services)
            {
                 try
                {
                    if (p.ServiceName.ToUpper() == sMsql.ToUpper())
                    {
                        if (p.Status == ServiceControllerStatus.Stopped)
                        {
                            p.Start();
                            do
                            {
                                p.Refresh();
                                if (p.Status == ServiceControllerStatus.Running) return true;
                            }
                            while (p.Status == ServiceControllerStatus.Running);
                        }
                        if (p.Status == ServiceControllerStatus.Running)
                        {
                            p.Stop();
                            do
                            {
                                p.Refresh();
                                if (p.Status == ServiceControllerStatus.Stopped) return true;
                            }
                            while (p.Status == ServiceControllerStatus.Stopped);
                        }
                        return false;
                        //switch (p.Status)
                        //{
                        //    case ServiceControllerStatus.Running:
                        //        //return "Running";
                        //        //return true;
                        //    case ServiceControllerStatus.Stopped:
                        //        //return "Stopped";
                        //        //return true;
                        //    case ServiceControllerStatus.Paused:
                        //        //return "Paused";
                        //        //return true;
                        //    case ServiceControllerStatus.StopPending:
                        //        //return "Stopping";
                        //        //return true;
                        //    case ServiceControllerStatus.StartPending:
                        //        //return "Starting";                                
                        //        //return true;
                        //    default:
                        //        //return "Status Changing";
                        //        return true;
                        //}
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("->" + ex.Message);
                    return false;
                }
            }
            return true;
        }

        internal static bool MetodoPararServicoSql()
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController p in services)
            {
                try
                {
                    if (p.ServiceName.ToUpper() == sMsql.ToUpper())
                    {
                        if (p.Status == ServiceControllerStatus.Stopped) return true;
                        if (p.Status == ServiceControllerStatus.Running || p.Status == ServiceControllerStatus.Paused || p.Status == ServiceControllerStatus.ContinuePending)
                        {
                            p.Stop();
                            while ((p.Status == ServiceControllerStatus.Running || p.Status == ServiceControllerStatus.StopPending || p.Status == ServiceControllerStatus.Paused))
                            {
                                p.Refresh();
                            }
                            if (p.Status == ServiceControllerStatus.Stopped) return true;
                            
                        }
                        //if (p.Status == ServiceControllerStatus.Running)
                        //{
                        //    p.Stop();
                        //    do
                        //    {
                        //        p.Refresh();
                        //        if (p.Status == ServiceControllerStatus.Stopped) return true;
                        //    }
                        //    while (p.Status == ServiceControllerStatus.Stopped);
                        //}
                        return false;
                        //switch (p.Status)
                        //{
                        //    case ServiceControllerStatus.Running:
                        //        //return "Running";
                        //        //return true;
                        //    case ServiceControllerStatus.Stopped:
                        //        //return "Stopped";
                        //        //return true;
                        //    case ServiceControllerStatus.Paused:
                        //        //return "Paused";
                        //        //return true;
                        //    case ServiceControllerStatus.StopPending:
                        //        //return "Stopping";
                        //        //return true;
                        //    case ServiceControllerStatus.StartPending:
                        //        //return "Starting";                                
                        //        //return true;
                        //    default:
                        //        //return "Status Changing";
                        //        return true;
                        //}
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("->" + ex.Message);
                    return false;
                }
            }

            return true;
        }

        internal static bool MetodoIniciarServicoSql()
        {
            ServiceController[] services = ServiceController.GetServices();

            foreach (ServiceController p in services)
            {
                try
                {
                    if (p.ServiceName.ToUpper() == sMsql.ToUpper())
                    {
                        if (p.Status == ServiceControllerStatus.Running) return true;
                        if (p.Status == ServiceControllerStatus.Stopped)
                        {
                            p.Start();
                            while ((p.Status == ServiceControllerStatus.Stopped || p.Status == ServiceControllerStatus.StartPending || p.Status == ServiceControllerStatus.Paused))
                            {
                                p.Refresh();
                            }
                            if (p.Status == ServiceControllerStatus.Running) return true;
                            //p.Start();
                            //do
                            //{
                            //    p.Refresh();
                            //    if (p.Status == ServiceControllerStatus.Running) return true;
                            //}
                            //while (p.Status == ServiceControllerStatus.Running);
                        }
                        return false;
                        //switch (p.Status)
                        //{
                        //    case ServiceControllerStatus.Running:
                        //        //return "Running";
                        //        //return true;
                        //    case ServiceControllerStatus.Stopped:
                        //        //return "Stopped";
                        //        //return true;
                        //    case ServiceControllerStatus.Paused:
                        //        //return "Paused";
                        //        //return true;
                        //    case ServiceControllerStatus.StopPending:
                        //        //return "Stopping";
                        //        //return true;
                        //    case ServiceControllerStatus.StartPending:
                        //        //return "Starting";                                
                        //        //return true;
                        //    default:
                        //        //return "Status Changing";
                        //        return true;
                        //}
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("->" + ex.Message);
                    return false;
                }
            }
            return true;
        }
    }
}
