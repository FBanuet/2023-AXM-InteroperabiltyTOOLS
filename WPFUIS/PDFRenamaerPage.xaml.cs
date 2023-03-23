using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autodesk.Revit.DB;
using WinForms = System.Windows.Forms;

namespace DATools.WPFUIS
{
    /// <summary>
    /// Lógica de interacción para PDFRenamaerPage.xaml
    /// </summary>
    public partial class PDFRenamaerPage : Window
    {
        Autodesk.Revit.ApplicationServices.Application _revitApp;
        public PDFRenamaerPage(Autodesk.Revit.ApplicationServices.Application revitApp)
        {
            InitializeComponent();
            _revitApp = revitApp;
        }

        private void btnFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new WinForms.FolderBrowserDialog();
            if (WinForms.DialogResult.OK == dialog.ShowDialog())
            {
                SourceFolder.Text = dialog.SelectedPath;
            }

        }

        private void btnRename_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SourceFolder.Text))
            {
                MessageBox.Show("Seleccione el folder de destino o Ruta");
                SourceFolder.Focus();
                return;
            }
            if(Directory.Exists(SourceFolder.Text) == false)
            {
                MessageBox.Show("LA RUTA NO EXISTE");
                SourceFolder.Focus();
                return;

            }
            
            //find all PDF FIles


            //var files = Directory.EnumerateFiles(SourceFolder.Text, "*.pdf", SearchOption.AllDirectories);

            string sourcefolder = SourceFolder.Text;
            string[] files = Directory.GetFiles(sourcefolder);
            int count = files.Count(), success = 0;
            double curStep = 0, current = 0, tempval;

            foreach(string file in files)
            {
                string filename = System.IO.Path.GetFileName(file);
                string newname = filename.Remove(23, 11);

                RenamePDFFile(file, newname);
                success++;
                current++;

                tempval = current * 100 / count;

                if(tempval - 5 > curStep)
                {
                    curStep = tempval;
                    progressBar.Value = curStep;
                    RAPWPF.WpfApplication.DoEvents();

                }
            }
            progressBar.Value = 100;
            RAPWPF.WpfApplication.DoEvents();

            MessageBox.Show("PDFS RENOMBRADOS CON EXITO " + success + "ARCHIVOS RENOMBRADOS , " + (count - success));
            Close();
        }
        
        private static void RenamePDFFile(string bigName, string Shortname)
        {
            try
            {
                string directorypath = System.IO.Path.GetDirectoryName(bigName);
                if(directorypath == null)
                {
                    MessageBox.Show("INTERNAL ERROR");

                }
                var newfilewithpath = System.IO.Path.Combine(directorypath, Shortname);
                FileInfo finfo = new FileInfo(bigName);
                finfo.MoveTo(newfilewithpath);
                

                
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                
                
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void logError(string targetFolder, string fileName, string error)
        {
            string logFile = System.IO.Path.Combine(targetFolder, "error.log");
            using (StreamWriter sw = new StreamWriter(logFile, true))
            {
                sw.WriteLine("File: " + fileName + " upgrades fail: " + error);
            }
        }
    }
}
