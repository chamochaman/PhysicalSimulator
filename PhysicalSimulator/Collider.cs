using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace PhysicalSimulator
{
    /// <summary>
    /// Esta clase representa todas las colisiones activadas en escena.
    /// </summary>
    class Collider
    {
        /// <summary>
        /// Este método verifica que un objeto no se estrelle contra otro objeto
        /// </summary>
        /// <param name="boxCollider">La entidad contra la cual se verifica el impácto de la entidad</param>
        /// <param name="entity">La entidad base que será la que colisionará contra la caja</param>
        /// <returns>retorna true si la colisión se dio, de lo contrario, retorna false</returns>
        public bool BoxCollider(Object boxCollider, Object entity)
        {
            if (entity.rectangle.Intersects(boxCollider.rectangle))
                return true;
            return false;
        }

        /// <summary>
        /// Este método verifica si el rectangulo del puntero del mouse colisiona contra otro objeto.
        /// </summary>
        /// <param name="boxCollider">Objeto contra el cual se verificará la colisión del mouse</param>
        /// <returns>retorna true si la colisión se dio, de lo contrario, retorna false</returns>
        public bool MouseCollider(Object boxCollider)
        {
            if (boxCollider.rectangle.Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 2, 2)))
                return true;
            return false;
        }

        /// <summary>
        /// Este método verifica si ademas de hacer colisión el mouse contra otro objeto, tambien se hizo click sobre el mismo.
        /// </summary>
        /// <param name="boxCollider">Objeto contra el cual se verificará la colisión del mouse y se presionará el click</param>
        /// <returns>retorna true si la colisión se dio, de lo contrario, retorna false</returns>
        public bool ClickOnMouseCollider(Object boxCollider)
        {
            if (MouseCollider(boxCollider) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                return true;
            return false;
        }

        /// <summary>
        /// Este método verifica si luego de estar activa una colisón con click, el mouse salio de la colisión y realizó click en otro
        /// lugar diferente al objeto perteneciente a la colisión.
        /// </summary>
        /// <param name="boxCollider">Objeto contra el cual se verificará la colisión del mouse y se presionará el click</param>
        /// <returns>retorna true si la colisión se dio, de lo contrario, retorna false</returns>
        public bool ClickOutMouseCollider(Object boxCollider)
        {
            if (!MouseCollider(boxCollider) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                return true;
            return false;
        }
    }
}
