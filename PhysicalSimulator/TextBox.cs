using System;
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
        private bool state;
        private float size;
        private int textBoxSize;
        private float wordSize;
        private Texture2D background;
        private Texture2D fontLetters;
        private Texture2D fontNumbers;
        private Collider collider;
        //private Vector2 position;
        //private Rectangle rectangle;
        private SpriteBatch spriteBatch;
        private KeyBoardInput keyboard;

        public string input;

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

        public void getInput()
        {
            if(!this.state)
                return;
            input = keyboard.getCurrentKeyboardInput(input, textBoxSize);
        }

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

        public bool getState()
        {
            if (state)
                return true;
            return false;
        }

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

        public bool Collide()
        {
            return this.collider.ClickOnMouseCollider(this);
        }

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
