using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PhysicalSimulator
{
    class Button : Object
    {
        /// <summary>
        /// Representa el estado del botón, si esta activo en escena o no.
        /// </summary>
        private bool state;
        /// <summary>
        /// 
        /// </summary>
        private float size;
        /// <summary>
        /// Representa el tamaño máximo del botón
        /// </summary>
        private int textBoxSize;
        /// <summary>
        /// Representa el tamaño de la letra dentro del botón
        /// </summary>
        private float wordSize;
        /// <summary>
        /// Representa la textura del fondo del botón
        /// </summary>
        private Texture2D background;
        /// <summary>
        /// Representa la textura con las letras para el botón
        /// </summary>
        private Texture2D fontLetters;
        /// <summary>
        /// Representa la textura con los números para el botón
        /// </summary>
        private Texture2D fontNumbers;
        /// <summary>
        /// Representa el colisionador asociado a la entidad.
        /// </summary>
        private Collider collider;
        /// <summary>
        /// Representa la clase de XNA que permite renderizar en pantalla.
        /// </summary>
        private SpriteBatch spriteBatch;
        /// <summary>
        /// Represeta el valor que tiene el botón.
        /// </summary>
        public string input;
        /// <summary>
        /// Este método se encarga de pintar en pantalla el texto dentro del botón.
        /// </summary>
        public void DrawText()
        {
            DrawBackGround();

            float pos = position.X;
            int x = 71;
            int y = 98;

            for (int i = 0; i < this.input.Length; ++i)
            {

                int word;
                Texture2D font;
                if (input[i] >= '0' && input[i] <= '9')
                {
                    font = fontNumbers;
                    word = input[i] - '0';
                }
                else
                {
                    font = fontLetters;
                    word = input[i] - 'a';
                }

                int mod = word % 9;
                int div = word / 9;
                spriteBatch.Draw(font, new Vector2(pos, position.Y), new Rectangle(mod * x + 1 * mod + 2, div * y + div * 1 + 2, x, y), Color.White, 0, new Vector2(325, 150), size, SpriteEffects.None, 0);
                //spriteBatch.Draw(font, new Vector2(pos, position.Y), new Rectangle(mod * x + 1 * mod + 2, div * y + div * 1 + 2, x, y), Color.White);
                pos += x*size;
            }
        }
        /// <summary>
        /// Este método cambia el estado del botón si es presionado
        /// </summary>
        /// <returns></returns>
        public bool Pressed()
        {
            return this.setState(); 
        }

        /// <summary>
        /// Este método pinta el fondo del botón
        /// </summary>
        public void DrawBackGround()
        {
            float pos = position.X; 
            int x = 71;
            int y = 98;
            Texture2D font = fontNumbers;
            for (int i = 0; i < textBoxSize; ++i)
            {
                spriteBatch.Draw(font, new Vector2(pos, position.Y), new Rectangle(4 * x + 1 * 4 + 2, 1 * y + 1 * 1 + 2, x, y), Color.White, 0, new Vector2(325, 150), size, SpriteEffects.None, 0);
                pos += x * size;
            }
        }

        /// <summary>
        /// Este método retorna el estado del botón
        /// </summary>
        /// <returns></returns>
        public bool getState()
        {
            if (state)
                return true;
            return false;
        }

        /// <summary>
        /// Este método cambia el estado del botón si se presionó
        /// </summary>
        /// <returns></returns>
        public bool setState()
        {
            if (this.Collide())
            {
                //input = string.Empty;
                return true;
            }
            else if(this.collider.ClickOutMouseCollider(this) && state == true)
            {
               // input = string.Empty;
                return false;
            }
            return false;
        }

        /// <summary>
        /// Este método verifica la colisión del botón con el mouse.
        /// </summary>
        /// <returns></returns>
        public bool Collide()
        {
            return this.collider.ClickOnMouseCollider(this);
        }

        public Button(bool state, float size, float wordSize, int textBoxSize, Texture2D background, Texture2D font1, Texture2D font2, SpriteBatch sb, Vector2 position, Rectangle rectangle)
        {
            base.rectangle = rectangle;
            this.state = state;
            this.size = size;
            this.wordSize = wordSize;
            this.background = background;
            this.spriteBatch = sb;
            base.position = position;
            this.fontLetters = font1;
            this.fontNumbers = font2;
            this.textBoxSize = textBoxSize;
            this.collider = new Collider();
            this.input = string.Empty;
        }
    }
}
