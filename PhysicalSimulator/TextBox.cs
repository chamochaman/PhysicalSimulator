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
        private float wordSize;
        private Texture2D background;
        private Texture2D fontLetters;
        private Texture2D fontNumbers;
        private Collider collider;
        private Vector2 position;
        private Rectangle rectangle;
        private SpriteBatch spriteBatch;

        public string input;

        public void DrawText()
        {
            if (this.input.Length == 0)
                return;

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

        public void DrawBackGround()
        {
            spriteBatch.Draw(background, position, Color.White);
        }

        public void setState()
        {
            if (this.Collide())
                state = true;
            else
                state = false;
        }

        public bool Collide()
        {
            return this.collider.ClickOnMouseCollider(this, Mouse.GetState());
        }

        public TextBox(bool state, float size, float wordSize, Texture2D background, Texture2D font1, Texture2D font2, SpriteBatch sb, Vector2 position, Rectangle rectangle)
        {
            this.rectangle = rectangle;
            this.state = state;
            this.size = size;
            this.wordSize = wordSize;
            this.background = background;
            this.spriteBatch = sb;
            this.position = position;
            this.fontLetters = font1;
            this.fontNumbers = font2;
        }
    }
}
