using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PhysicalSimulator
{
    /// <summary>
    /// Entidad base de la cual hereda Entity.
    /// </summary>
    public class Object
    {
        /// <summary>
        /// Representa la posición de un objeto en la escena.
        /// </summary>
        public Vector2 position { get; set; }
        /// <summary>
        /// Representa el rectangulo de un objeto en le escena, sirve para calcular las colisiones.
        /// </summary>
        public Rectangle rectangle { get; set; }
      
    }
}
