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
        public Vector2 position { get; set; }
        public Rectangle rectangle { get; set; }
      
    }
}
