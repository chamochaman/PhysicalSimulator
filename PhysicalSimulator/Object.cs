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
        private Vector2 position;
        private Rectangle rectangle;

        public Rectangle getRectangle()
        {
            return rectangle;
        }

        public Vector2 getPosition()
        {
            return position;
        }
    }
}
