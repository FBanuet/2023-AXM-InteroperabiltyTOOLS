using System;
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
using Autodesk.Revit.UI;
using System.Configuration;
using WinForms = System.Windows.Forms;
using System.Globalization;

namespace DATools.WPFUIS
{
    /// <summary>
    /// Lógica de interacción para SheetListUI.xaml
    /// </summary>
    public partial class SheetListUI : Window
    {
        Autodesk.Revit.ApplicationServices.Application _revitApp;
        Autodesk.Revit.DB.Document _document;
        public SheetListUI(Autodesk.Revit.ApplicationServices.Application revitApp, Autodesk.Revit.DB.Document document)
        {
            InitializeComponent();
            _revitApp = revitApp;
            _document = document;
            
        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            
            PopulateListBox();
        }
        private void PopulateListBox()
        {

            Document doc = _document;
            List<ViewSheet> viewSheets = GetSheetData(doc);

            SheetList.ItemsSource = viewSheets;
            

            RAPWPF.WpfApplication.DoEvents();

        }
        private List<ViewSheet> GetSheetData(Document doc)
        {
            List<ViewSheet> viewSheets = new FilteredElementCollector(doc)
                .OfClass(typeof(ViewSheet))
                .Cast<ViewSheet>().OrderBy(vs => vs.SheetNumber)
                .ToList();

            return viewSheets;
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            Document doc = _document;
            using(Transaction trans = new Transaction(doc, "SheetIssueDateSet")) 
            {
                trans.Start();

                foreach (object o in SheetList.SelectedItems)
                {
                    ViewSheet vs = o as ViewSheet;
                    Parameter par = vs.get_Parameter(BuiltInParameter.SHEET_ISSUE_DATE);

                    string value = GetDateNow();

                    par.Set(value);
                }

                    trans.Commit();
            }

            TaskDialog.Show("AXM", "Operación Exitosa");
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }



        private string GetDateNow()
        {
            DateTime localDate = DateTime.Now;
            DateTime utcDate = DateTime.UtcNow;
            String[] cultureNames = { "es-MX" };

            string output = "";

            foreach (var cu in cultureNames)
            {
                // mes , dia y año
                var clt = new CultureInfo(cu);
                var mes = localDate.Month.ToString(clt);
                var dia = localDate.Day.ToString(clt);
                var año = localDate.Year.ToString(clt);


                output += mes + "/" + dia + "/" + año;
            }

            return output;
        }

        private void btnSelect_All(object sender, RoutedEventArgs e)
        {
            SheetList.SelectAll();
        }
    }
}
