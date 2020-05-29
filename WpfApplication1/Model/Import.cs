using System;
using System.Collections.Generic;

using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WpfApplication1.message;
using WpfApplication1.Model;

namespace WpfApplication1.Model
{
    
    class Import
    {
        OleDbConnection conn;
        OleDbDataAdapter MyDataAdapter;
       
        
     

        public void ImportarExcel(System.Windows.Controls.DataGrid dgv,string nombreHoja, ref DataTable dt)
        {

            MessageViewModel mv = new MessageViewModel();
            List<ListDepositos> ld = new List<ListDepositos>();
            string ruta = "";
            try
            {

                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Excel Files | *.xlsx";
                openFile.Title = "Seleccione el Archivo Excel";
                if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFile.FileName.Equals("") == false)
                    {
                        ruta = openFile.FileName;
                    }
                }
                conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ruta+ @";Extended Properties=""Excel 12.0 Xml;HDR=YES;""");
                MyDataAdapter = new OleDbDataAdapter("select banco,venta,tipo,operacion,FORMAT([fecha], 'dd/MM/yyyy') as [fecha] from [" + nombreHoja + "$]", conn);
                dt = new DataTable();
                MyDataAdapter.Fill(dt);
                dt.DefaultView.Sort = "fecha";
                

                dt = dt.DefaultView.ToTable();
                dgv.ItemsSource= dt.DefaultView;
              //  dgv.Columns["fecha"].
            }
            catch (Exception e)
            {
                mv.Message = mv.ToStringAllExceptionDetails(e);
                mv.Caption = "Error sql";
                mv.mensajeria();

            }

        }
    }
}
