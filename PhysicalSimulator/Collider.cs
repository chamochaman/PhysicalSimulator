using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace PhysicalSimulator
{
    class Collider
    {
        public bool BoxCollider(Object boxCollider, Object entity)
        {
            if (entity.getRectangle().Intersects(boxCollider.getRectangle()))
                return true;
            return false;
        }

        public bool MouseCollider(Object boxCollider, MouseState mouse)
        {
            if (boxCollider.getRectangle().Intersects(new Rectangle(mouse.X, mouse.Y, 2, 2)))
                return true;
            return false;
        }

        public bool ClickOnMouseCollider(Object boxCollider, MouseState mouse)
        {
            if (MouseCollider(boxCollider, mouse) && mouse.LeftButton == ButtonState.Pressed)
                return true;
            return false;
        }
    }
}
