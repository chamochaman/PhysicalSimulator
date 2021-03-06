﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PhysicalSimulator
{
    class TextBox : Object
    {
        /// <summary>
        /// Representa el estado del textbox, si esta activo en escena o no.
        /// </summary>
        private bool state;
        /// <summary>
        /// 
        /// </summary>
        private float size;
        /// <summary>
        /// Representa el tamaño máximo del textBox
        /// </summary>
        private int textBoxSize;
        /// <summary>
        /// Representa el tamaño de la letra dentro del textBox
        /// </summary>
        private float wordSize;
        /// <summary>
        /// Representa la textura del fondo del textBox
        /// </summary>
        private Texture2D background;
        /// <summary>
        /// Representa la textura con las letras para el textbox
        /// </summary>
        private Texture2D fontLetters;
        /// <summary>
        /// Representa la textura con los números para el textbox
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
        /// Representa la clase que captura las teclas presionadas.
        /// </summary>
        private KeyBoardInput keyboard;
        /// <summary>
        /// Represeta el valor que tiene el textbox.
        /// </summary>
        public string input;

        /// <summary>
        /// Este método se encarga de pintar en pantalla las teclas que hayan sido presionadas cuando el textbox estaba activo.
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
        /// Este método permite activar el estado del buffer que recibe lo ingresado por teclado
        /// </summary>
        public void TurnOnBuffer()
        {
            this.setState();
            if (this.getState())
            {
                this.getInput();
            }
        }

        /// <summary>
        /// Este método guarda la entrada del teclado en el textbox
        /// </summary>
        public void getInput()
        {
            if(!this.state)
                return;
            input = keyboard.getCurrentKeyboardInput(input, textBoxSize);
        }

        /// <summary>
        /// Este método pinta el fondo del textbox.
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
        /// Este método devuelve el estado actual del textbox
        /// </summary>
        /// <returns>retorna true si el estado está activo, sino, retorna false</returns>
        public bool getState()
        {
            if (state)
                return true;
            return false;
        }
        /// <summary>
        /// Este método permite modificar el estado del textbox.
        /// </summary>
        public void setState()
        {
            if (this.Collide() && state == false)
            {
                input = string.Empty;
                state = true;
            }
            else if(this.collider.ClickOutMouseCollider(this) && state == true)
            {
               // input = string.Empty;
                state = false;
            }
        }
        /// <summary>
        /// Este método verifica si existe colisión para cambiar el estado del textbox.
        /// </summary>
        /// <returns>retorna true si hay colisión, sino, retorna false</returns>
        public bool Collide()
        {
            return this.collider.ClickOnMouseCollider(this);
        }
        /// <summary>
        /// Constructor del textbox
        /// </summary>
        /// <param name="state"></param>
        /// <param name="size"></param>
        /// <param name="wordSize"></param>
        /// <param name="textBoxSize"></param>
        /// <param name="background"></param>
        /// <param name="font1"></param>
        /// <param name="font2"></param>
        /// <param name="sb"></param>
        /// <param name="position"></param>
        /// <param name="rectangle"></param>
        public TextBox(bool state, float size, float wordSize, int textBoxSize, Texture2D background, Texture2D font1, Texture2D font2, SpriteBatch sb, Vector2 position, Rectangle rectangle)
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
            this.keyboard = new KeyBoardInput();
        }
    }
}
