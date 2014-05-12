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
            if (entity.rectangle.Intersects(boxCollider.rectangle))
                return true;
            return false;
        }

        public bool MouseCollider(Object boxCollider)
        {
            if (boxCollider.rectangle.Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 2, 2)))
                return true;
            return false;
        }

        public bool ClickOnMouseCollider(Object boxCollider)
        {
            if (MouseCollider(boxCollider) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                return true;
            return false;
        }

        public bool ClickOutMouseCollider(Object boxCollider)
        {
            if (!MouseCollider(boxCollider) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                return true;
            return false;
        }
    }
}
