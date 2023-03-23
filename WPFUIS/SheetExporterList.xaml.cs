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
    /// Lógica de interacción para SheetExporterList.xaml
    /// </summary>
    public partial class SheetExporterList : Window
    {
        Autodesk.Revit.ApplicationServices.Application _revitApp;
        Autodesk.Revit.DB.Document _document;
        Autodesk.Revit.DB.DWGExportOptions _cadOpt;
        public SheetExporterList(Autodesk.Revit.ApplicationServices.Application revitApp, Autodesk.Revit.DB.Document document, DWGExportOptions cadopt)
        {
            InitializeComponent();
            _revitApp = revitApp;
            _document = document;
            _cadOpt = cadopt;
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Document doc = _document;
            doc.Close(false);
            Close();
        }

        private void btnSelect_All(object sender, RoutedEventArgs e)
        {
            SheetList.SelectAll();
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            Document doc = _document;
            DWGExportOptions dOpt = _cadOpt;
            ICollection<ElementId> selectedIds = new List<ElementId>();

            foreach(object o in SheetList.SelectedItems)
            {
                ViewSheet vs = o as ViewSheet;
                ElementId eleid = vs.Id;
                selectedIds.Add(eleid);
            }

            dOpt.SharedCoords = false;
            dOpt.ExportingAreas = false;
            dOpt.TargetUnit = ExportUnit.Millimeter;
            dOpt.FileVersion = ACADVersion.R2013;
            dOpt.MergedViews = true;
            doc.Export(@"G:\Unidades compartidas\MANSUR\SURMAN PEDREGAL\01_RESIDENCIA MANSUR\01_AXM\01_MNSR_Project\02_CAD\Plugin", "MNSR_AXMA_ARC_", selectedIds, dOpt);

        }
    }
}
