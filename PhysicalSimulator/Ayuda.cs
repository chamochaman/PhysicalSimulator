using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhysicalSimulator
{
    public partial class Ayuda : Form
    {
        public Ayuda()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Representa todos los títulos posibles de la pantalla de ayuda para ponerselos a los label.
        /// </summary>
        string[] titles = { "Paso 1", "Paso 2", "Paso 3", "Paso 4", "Paso 5", "Paso 6" };
        /// <summary>
        /// Representa el paso actual en el que se encuentra.
        /// </summary>
        int i = 0;
        /// <summary>
        /// Representa el máximo de pasos disponibles.
        /// </summary>
        int max = 5;
        /// <summary>
        /// Representa el vector con todas las explicaciones paso por paso que serán accedidas dependiendo de la i.
        /// </summary>
        string[] pasos = { "Una vez esté en la pantalla de simulación, debe dirigirse hacia la derecha, y hacer click en el cuadro blanco al frente de los textos Velocidad X, Velocidad Y, etc... Una vez allí está activo el cuadro de texto para recibir los valores de las variables, por favor, digítelos con los números del teclado que se encuentran a la derecha. Si desea borrar el valor ingresado, debe utilizar el botón suprimir.",
                         "Una vez haya ingresado todos los datos (tenga en cuenta, que solo permite positivos o cero), puede dar click en el botón que dice INICIAR, este permitirá que la simulación se lleve a cabo, tenga en cuenta, que si el objeto se sale de la pantalla, la simulación continuará hasta que haga click en PAUSAR.",
                         "El botón VER REPORTE está disponible si y sólo si la simulación está en pausa, al hacer click, se cerrara la ventqana de simulación, y tendra disponible una nueva ventaná e la que podrá ver el gráfico matemático que representa la simulación, ademas de algunos datos importantes de la misma que le permitirán realizar estudios de la simulación realizada.",
                         "Dentro del reporte, aparece la gráfica que representa el moviemiento, esta grafíca representa la última simulación realizada, y no es editable, en la parte inferior, aparece un botón que dice SIGUIENTE, si hace un click sobre el mismo, lo llevara a la siguiente gráfica matemática, actualmente solo permite ver la gráfica de velocidad vs tiempo y de aceleración vs tiempo.",
                         "Si desea salir del reporte puede cerrar la ventana, una vez la cierre encontrará la ventana de log-in desde la cual puede volver a acceder a las simulaciones.",
                         "Si termino de realizar la simulación, presione el botón pausar, el cual le permite modificar los valores de las variables y le presentará nuevamente el botón INICIAR que le permitirá realizar nuevamente la simulación con la nueva configuración."};

        /// <summary>
        /// Este método se ejecuta cuando carga el form, lo que hace es configurar por defecto el form para que quede en el paso 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ayuda_Load(object sender, EventArgs e)
        {
            title.Text = titles[i];
            paso.Text = pasos[i];
            btn.Text = titles[i + 1];
            enablebtn();

        }

        /// <summary>
        /// Este método se ejecuta cuando el usuario da click en el botón que lleva al siguiente paso.Lo que hace es sumarle 1 a la i, y volver
        /// a mostrar todos los datos en la pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e)
        {
            if (i == max)
            {
                enablebtn();
                return;
            }
            enablebtn();
            i++;

            title.Text = titles[i];
            paso.Text = pasos[i];
            enablebtn();
        }

        /// <summary>
        /// Este método verifica la posición actual de la axplicación, y si muestra o no el siguiente o el anterior caso, es decir, si se encuentra 
        /// el paso 0, no debería mostrar el botón de la izquierda que permite dirigirse al paso anterior.
        /// </summary>
        private void enablebtn()
        {
            if (i == 0)
                btn0.Visible = false;
            else
            {
                btn0.Text = titles[i - 1];
                btn0.Visible = true;
            }

            if (i == max)
                btn.Visible = false;
            else
            {
                btn.Text = titles[i + 1];
                btn.Visible = true;
            }
        }

        /// <summary>
        /// Este método se ejecuta cuando el usuario da click en el botón de ir al paso anterior. Lo que hace es restarle 1 a la i, y volver
        /// a mostrar todos los datos en la pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn0_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                enablebtn();
                return;
            }
            enablebtn();
            i--;

            title.Text = titles[i];
            paso.Text = pasos[i];
            enablebtn();

        }
    }

}
