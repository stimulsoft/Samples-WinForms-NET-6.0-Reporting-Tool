using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Export_and_Print_Report_from_Code
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);

            InitializeComponent();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            var report = new StiReport();
            report.Load(@"Reports\TwoSimpleLists.mrt");
            report.Print();

            MessageBox.Show("Complete", "Print Report");
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            var report = new StiReport();
            report.Load(@"Reports\TwoSimpleLists.mrt");
            report.Render();

            var stream = new MemoryStream();
            switch (comboBoxFormat.Text)
            {
                case "PDF":
                    report.ExportDocument(StiExportFormat.Pdf, stream);
                    break;

                case "Word":
                    report.ExportDocument(StiExportFormat.Word2007, stream);
                    break;

                case "Excel":
                    report.ExportDocument(StiExportFormat.Excel2007, stream);
                    break;

                case "Text":
                    report.ExportDocument(StiExportFormat.Text, stream);
                    break;

                case "Image":
                    report.ExportDocument(StiExportFormat.ImagePng, stream);
                    break;
            }

            // Save to Local Storage
            /*using (var fileStream = File.Create(@"d:\TwoSimpleLists.pdf"))
            {
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fileStream);
            }*/

            MessageBox.Show("Complete", "Export Report");
        }
    }
}
