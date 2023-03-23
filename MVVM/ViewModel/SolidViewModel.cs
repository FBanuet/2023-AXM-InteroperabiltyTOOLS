using DATools.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Structure;
using DATools.MVVM.ViewModelBases;
using Autodesk.Revit.UI.Selection;

namespace DATools.MVVM.ViewModel
{
    public class SolidViewModel : ViewModelBase
    {
        //PRIVATE GLOBAL PROPERTIES
        private Document _Doc { get; }
        private UIDocument _UIDoc { get; }

        //FACTORY METHOD OR RORO
        private SolidView _solidView;

        public SolidView solidView
        {
            get
            {
                if(_solidView == null)
                {
                    _solidView = new SolidView() { DataContext = this };
                }
                return _solidView;
            }
            set
            {
                _solidView = value;
                OnPropertyChanged(nameof(solidView));
            }
        }

        private bool _isCheckedSolid;

        public bool isCheckedSolid
        {
            get 
            {
                return _isCheckedSolid;
            }
            set
            {
                _isCheckedSolid = value;
                OnPropertyChanged(nameof(isCheckedSolid));
            }
        }


        private bool  _isCheckedUnobscured;

        public bool  isCheckedUnobscured
        {
            get
            {
                return _isCheckedUnobscured;
            }
            set
            {
                _isCheckedUnobscured = value;
                OnPropertyChanged(nameof(isCheckedUnobscured));
            }
        }

        private int _selectedIndex;

        public int selectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
                OnPropertyChanged(nameof(selectedIndex));
            }
        }

        //INSTANCIA DE RELAY COMMAND

        public RelayCommand<object> ButtonRun { get; set; }

        // CONSTRUCTOR OF THIS CLASS 
        public SolidViewModel(UIDocument uidoc)
        {
            _UIDoc = uidoc;
            _Doc = uidoc.Document;
            ButtonRun = new RelayCommand<object>(p => true, p => ButtonRunAction());
        }

        private void ButtonRunAction()
        {
            this.solidView.Close();

            //try{} catch{}

            try
            {
    
               var currentView = _Doc.ActiveView;

               if (currentView is View3D view3D)
               {
                    
                    IEnumerable<Rebar> rebars = null;
                    if (selectedIndex == 0)
                    {
                        rebars = new FilteredElementCollector(_Doc, currentView.Id).OfClass(typeof(Rebar)).Cast<Rebar>();
                    }
                    else
                    {
                        try
                        {
                            rebars = _UIDoc.Selection.PickObjects(ObjectType.Element, new RebRarFilter(), "Seleccione los Rebar deseados").Select(x => _Doc.GetElement(x)).Cast<Rebar>();
                        }
                        catch { }
                        
                    }
                    if (rebars == null) return;
                    using (Transaction t = new Transaction(_Doc, "REBAR SOLID 3D"))
                    {
                        t.Start();
                        foreach (var rebar in rebars)
                        {
                            rebar.SetSolidInView(view3D, isCheckedSolid);
                            rebar.SetUnobscuredInView(view3D, isCheckedUnobscured);
                        }

                        t.Commit();
                    }

                }
                else
                {
                    TaskDialog.Show("MVVM Apps", "Error please Open a 3DView");
                }
            }

            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("DATools", "Error, la aplicación unicamente funciona con Vistas 3D");
            }
        }
    }
     

    public class RebRarFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            return (elem.Category != null && elem is Rebar);
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            throw new NotImplementedException();
        }
    }
}
