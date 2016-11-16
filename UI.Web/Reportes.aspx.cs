using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;


public partial class Reportes : System.Web.UI.Page
{
    ReportesLogic reportesLogic = new ReportesLogic();
    ReportDocument crystalReport = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        try
        {
            dsCursos dsCursos = reportesLogic.GetDataCursos();
            if (dsCursos.cursos.Rows.Count > 0)
            {
                crystalReport.Load(Server.MapPath("~/CrystalReport.rpt"));
                crystalReport.SetDataSource(dsCursos);
                CrystalReportViewer1.RefreshReport();
                CrystalReportViewer1.ReportSource = crystalReport;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void Img1_Click(object sender, ImageClickEventArgs e)
    {
        dsCursos dsCursos = reportesLogic.GetDataCursos();
        if (dsCursos.cursos.Rows.Count > 0)
        {
            crystalReport.Load(Server.MapPath("~/CrystalReport.rpt"));
            crystalReport.SetDataSource(dsCursos);
            CrystalReportViewer1.RefreshReport();
            CrystalReportViewer1.ReportSource = crystalReport;
            crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "PersonDetails");
        }
        
    }
}