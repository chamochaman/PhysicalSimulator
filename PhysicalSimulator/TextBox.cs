using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PhysicalSimulator
{
    class TextBox
    {
        private bool state;
        private float size;
        private float wordSize;
        private Texture2D background;
        private Texture2D font;
        private Collider collider;
        private Vector2 position;
        private SpriteBatch spriteBatch;

        public string input;

        public void DrawText()
        {
            if (this.input.Length == 0)
                return;

            float pos = position.X;
            int x = 70;
            int y = 52;

            for (int i = 0; i < this.input.Length; ++i)
            {
                int word = input[i] - 'a';
                spriteBatch.Draw(font, new Vector2(pos, position.Y), new Rectangle(x * (word % 4), y * (word / 4), x, y), Color.White);
                pos += x;
            }
        }

        public void DrawBackGround()
        {
            spriteBatch.Draw(background, position, Color.White);
        }

        public TextBox(bool state, float size, float wordSize, Texture2D background, Texture2D font, SpriteBatch sb, Vector2 position)
        {
            this.state = state;
            this.size = size;
            this.wordSize = wordSize;
            this.background = background;
            this.spriteBatch = sb;
            this.position = position;
            this.font = font;
        }
    }
}
