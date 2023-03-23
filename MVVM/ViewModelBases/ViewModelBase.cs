using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATools.MVVM.ViewModelBases
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        //PROPIEDAD PUBLICA DE TIPO EVENTO AL QUE SE HARA REFERENCIA EN LOS MÉTODOS DE ESTA CLASE
        public event PropertyChangedEventHandler PropertyChanged;

        //MÉTODO VOID DONDE SE HARA EL LLAMADO AL EVENTO PropertyChangedEventHandler
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler eventHandler = this.PropertyChanged;
            if (eventHandler == null) return;
            eventHandler(
                (object)this, new PropertyChangedEventArgs(propertyName)
                );
        }
    }
}
