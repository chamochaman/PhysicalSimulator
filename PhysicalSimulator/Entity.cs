using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PhysicalSimulator
{
    class Entity : Object
    {
        private string tag;
        private bool activeInScene;
        private Vector2 position;
        private Animation animation;
        private Collider collider;
        private int layer;

        public void Initialize()
        {
            this.position.X = 10;
            this.position.Y = 10;
        }

        public void Update(GameTime gameTime)
        {
            this.position.X++;
            this.position.Y++;
        }

        public void SetActive(bool state)
        {
            this.activeInScene = state;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animation.Draw(position, spriteBatch);
        }

        public void LoadContent(List<Texture2D> textures)
        {
            animation = new Animation();
            animation.Initialize(textures, 1, true, true);
        }

        public bool CompareTag(string tag)
        {
            if (this.tag == tag)
                return true;
            return false;
        }
    }
}
