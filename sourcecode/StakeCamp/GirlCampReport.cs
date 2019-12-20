using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RKLib.ExportData;
using System.Data.Common;
using System.IO;
using System.Windows.Forms;

namespace StakeCamp
{
    public static class GirlCampReport
    {
        public static void GetReport(string sql, DbCommand cmd)
        {
            // Export all the details to Excel

            string filename = "";
            
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel file(*.xls)|*.xls|(All files(*.*)|*.*";
            sfd.FileName = "ExcelReport.xls";
            sfd.FilterIndex = 1;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    filename = sfd.FileName;

                    DataTable dtEmployee = GenericDataAccess.ExecuteSelectCommand(cmd);                                  
                    RKLib.ExportData.Export objExport = new RKLib.ExportData.Export("Win");

                    objExport.ExportDetails(dtEmployee, Export.ExportFormat.Excel, filename);
                    MessageBox.Show("Report Exported succesfully to Excel");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }

        }//end class
    }
}
