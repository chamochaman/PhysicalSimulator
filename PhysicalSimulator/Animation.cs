using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PhysicalSimulator
{
    class Animation
    {
        private List<Texture2D> sprites;
        private float framesPerSecond;
        private float elapsedTime;
        private int frames;
        private int currentFrame;
        private bool looping;
        private bool state;

        public void Initialize(List<Texture2D> textures, float fps, bool looping, bool state)
        {
            this.sprites = textures;
            this.framesPerSecond = fps;
            this.looping = looping;
            this.elapsedTime = 0.0f;
            this.frames = textures.Count();
            this.state = state;
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime += (float)gameTime.ElapsedGameTime.Milliseconds;

            if (!state)
                return;

            if (currentFrame == frames)
            {
                currentFrame = 0;
                if (!looping)
                {
                    state = false;
                    return;
                }
            }

            if (elapsedTime > framesPerSecond)
            {
                elapsedTime = 0;
                currentFrame++;
            }
        }

        public void Draw(Vector2 position, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(sprites[currentFrame], position, Color.White);
            spriteBatch.End();
        }
    }
}
