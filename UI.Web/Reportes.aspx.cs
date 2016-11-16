using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using Business.Entities;
using Business.Logic;
using Util;
using Util.CustomException;

public partial class Reportes : System.Web.UI.Page
{
    private ReportesLogic reportesLogic = new ReportesLogic();
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportDocument crystalReport = new ReportDocument();
        try
        {
            crystalReport.Load(HttpContext.Current.Server.MapPath("~/CrystalReport.rpt"));
            dsCursos dsCursos = reportesLogic.GetData();
            crystalReport.SetDataSource(dsCursos);
            CrystalReportViewer1.ReportSource = crystalReport;
        }
        catch (Exception ex)
            
        {
            linkReporteCursos.Text = ex.Message;
        }
       
    }
    protected void linkReportePlanes_Click(object sender, EventArgs e)
    {

    }
    protected void linkReporteCursos_Click(object sender, EventArgs e)
    {
        ReportDocument crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("~/CrytalReport.rpt"));
        dsCursos dsCursos = reportesLogic.GetData();
        crystalReport.SetDataSource(dsCursos);
        CrystalReportViewer1.ReportSource = crystalReport;
    }
}