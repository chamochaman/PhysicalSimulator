using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PhysicalSimulator
{
    /// <summary>
    /// Esta clase representa la animación de las entidades visibles, por medio de esta clase se puede dibujar en pantalla cualquier imagen en movimiento.
    /// </summary>
    public class Animation
    {
        /// <summary>
        /// Representa la lista de texturas que hacen parte de la animación
        /// </summary>
        private List<Texture2D> sprites;
        /// <summary>
        /// Representa la velocidad de actualización
        /// </summary>
        private float framesPerSecond;
        /// <summary>
        /// Representa el delta del tiempo
        /// </summary>
        private float elapsedTime;
        /// <summary>
        /// Representa el número de sprites
        /// </summary>
        private int frames;
        /// <summary>
        /// Representa el indice del spite actual.
        /// </summary>
        private int currentFrame;
        /// <summary>
        /// Representa si la animación es un bucle o no
        /// </summary>
        private bool looping;
        /// <summary>
        /// Representa si la animación está activa o no
        /// </summary>
        private bool state;

        /// <summary>
        /// Inicializa la los atributos de la animación
        /// </summary>
        /// <param name="textures">Representa una lista de texturas que harán parte de una animación</param>
        /// <param name="fps">Representa la velocidad con la que se actualizará la animación</param>
        /// <param name="looping">Representa si la animación es un bucle o solo se repite una vez</param>
        /// <param name="state">Representa si la animación está activa o no</param>
        public void Initialize(List<Texture2D> textures, float fps, bool looping, bool state)
        {
            this.sprites = textures;
            this.framesPerSecond = fps;
            this.looping = looping;
            this.elapsedTime = 0.0f;
            this.frames = textures.Count();
            this.state = state;
        }

        /// <summary>
        /// Este método actualiza la animación
        /// </summary>
        /// <param name="gameTime">Recibe el delta del tiempo para saber si actualiza la animación o no.</param>
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

        /// <summary>
        /// Este método renderiza la animación.
        /// </summary>
        /// <param name="position">Recibe la posición para pintarla</param>
        /// <param name="spriteBatch">Recibe el SpriteBatch que le permitirá renderizar en pantalla.</param>
        public void Draw(Vector2 position, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprites[currentFrame], position, Color.White);
        }
    }
}
