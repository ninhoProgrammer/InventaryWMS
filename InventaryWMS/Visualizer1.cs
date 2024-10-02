using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReisWMS
{
    // TODO: agregar lo siguiente a la definición de SomeType para ver este visualizador al depurar instancias de SomeType:
    // 
    //  [DebuggerVisualizer(typeof(Visualizer1))]
    //  [Serializable]
    //  public class SomeType
    //  {
    //   ...
    //  }
    // 
    /// <summary>
    /// Un Visualizador para SomeType.  
    /// </summary>
    public class Visualizer1 : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            if (windowService == null)
                throw new ArgumentNullException("windowService");
            if (objectProvider == null)
                throw new ArgumentNullException("objectProvider");

            // TODO: obtener el objeto para el que se muestra un visualizador.
            //       Convertir el resultado de objectProvider.GetObject() 
            //       al tipo del objeto que se está visualizando.
            object data = (object)objectProvider.GetObject();

            // TODO: mostrar su vista del objeto.
            //       Sustituir displayForm con su Formulario o Control personalizado.
            using (Form displayForm = new Form())
            {
                displayForm.Text = data.ToString();
                windowService.ShowDialog(displayForm);
            }
        }

        // TODO: agregar el siguiente a su código de comprobación para comprobar el visualizador:
        // 
        //    Visualizer1.TestShowVisualizer(new SomeType());
        // 
        /// <summary>
        /// Comprueba el visualizador alojándolo fuera del depurador.
        /// </summary>
        /// <param name="objectToVisualize"> El objeto que se va a mostrar en el visualizador.</param>
        public static void TestShowVisualizer(object objectToVisualize)
        {
            VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(Visualizer1));
            visualizerHost.ShowVisualizer();
        }
    }
}
