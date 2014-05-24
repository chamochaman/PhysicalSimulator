using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;

namespace PhysicalSimulator
{
    /// <summary>
    /// Clase entidad, esta clase es el objeto base de las escenas, cualquier objeto dentro de la escena herado su comportamiento y sus atributos.
    /// </summary>
    public class Entity : Object
    {
        /// <summary>
        /// Representa el alias con el que será nombrada la entidad.
        /// </summary>
        private string tag;
        /// <summary>
        /// Representa si la entidad está activa o no.
        /// </summary>
        private bool activeInScene;
        /// <summary>
        /// Representa la posición de la entidad.
        /// </summary>
        private Vector2 position;
        /// <summary>
        /// Representa la animación que tiene la entidad.
        /// </summary>
        private Animation animation;
        /// <summary>
        /// Representa el colisionador asociado a la entidad.
        /// </summary>
        private Collider collider;
        /// <summary>
        /// Representa la capa de la escena en la cual se encuentra la entidad.
        /// </summary>
        private int layer;
        /// <summary>
        /// Representa el vector velocidad de la entidad.
        /// </summary>
        private Vector2 velocity;
        /// <summary>
        /// Representa el vector con la velocidad inicial de la entidad, este es utilizado para calcular el movimiento de la misma.
        /// </summary>
        private Vector2 initialVelocity;
        /// <summary>
        /// Representa el vector con la aceleración de la entidad.
        /// </summary>
        private Vector2 aceleration;
        /// <summary>
        /// Representa el angulo de dirección de la entidad.
        /// </summary>
        private float angle;
        /// <summary>
        /// Representa el tiempo total transcurrido desde que se empezo a actualizar la entidad
        /// </summary>
        private float totalTime;
        /// <summary>
        /// Representa el historico de la entidad alojado en una HashTable
        /// </summary>
        public List<Dictionary<float, List<float>>> History;
        /// <summary>
        /// Representa el rectangulo de colisión de la entidad.
        /// </summary>
        private Rectangle rectangle;

        public void InitializeHistory()
        {
            this.History = new List<Dictionary<float, List<float>>>();
            History.Add(new Dictionary<float, List<float>>());
            History.Add(new Dictionary<float, List<float>>());
            History.Add(new Dictionary<float, List<float>>());
        }

        /// <summary>
        /// Este método sirve para inicializar la entidad.
        /// </summary>
        public void Initialize(Vector2 position, Vector2 velocity, Vector2 aceleration, Rectangle rectangle,float angle)
        {
            this.position = position;
            this.initialVelocity = velocity;
            this.aceleration = aceleration;
            this.velocity = new Vector2(initialVelocity.X, initialVelocity.Y);
            this.angle = angle;
            this.totalTime = 0;
            this.rectangle = rectangle;
            this.InitializeHistory();
        }
        /// <summary>
        /// Este método sirve para actualizar una entidad.
        /// </summary>
        /// <param name="gameTime">Recibe el delta del tiempo para poder actualizar los atributos de la entidad.</param>
        public void Update(GameTime gameTime)
        {
            float time = gameTime.ElapsedGameTime.Milliseconds/1000f;
            this.History[0].Add(totalTime, new List<float> { position.X, position.Y });
            this.History[1].Add(totalTime, new List<float> { velocity.X, velocity.Y });
            this.History[2].Add(totalTime, new List<float> { aceleration.X, aceleration.Y });
            
            this.totalTime += time;

            velocity.Y = (initialVelocity.Y * (float)(Math.Sin(angle * Math.PI / 180))) - (aceleration.Y * totalTime);
            velocity.X = initialVelocity.X + (aceleration.X * time);
            velocity.Y = initialVelocity.Y + aceleration.Y * ((totalTime - time));

            position.X = velocity.X * time + position.X;

            if(angle != 0)
                position.Y = velocity.Y * (float)(Math.Sin(angle * Math.PI / 180)) * time - 0.5f * aceleration.Y * (float)(Math.Pow(time, 2)) + position.Y;
            else
                position.Y = (float)(0.5) * aceleration.Y * (float)Math.Pow(time, 2) + time * velocity.Y + position.Y;

            initialVelocity.X = velocity.X;

        }

        /// <summary>
        /// Este método permite activar o desactivar una entidad de la escena.
        /// </summary>
        /// <param name="state">Recibe el estado.</param>
        public void SetActive(bool state)
        {
            this.activeInScene = state;
        }

        /// <summary>
        /// Este método sirve para renderizar en pantalla la entidad actual
        /// </summary>
        /// <param name="spriteBatch">Recibe un spriteBatch que es la clase que realiza la renderización en Monogame y XNA</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (spriteBatch != null)
                animation.Draw(position, spriteBatch);
            else
            {
                MessageBox.Show("Error en la instanciación del spriteBatch.");
                return;
            }
        }

        /// <summary>
        /// Este método carga el contenido de la entidad.
        /// </summary>
        /// <param name="textures">Recibe una lista de texturas que serán pasadas a la animación de la entidad.</param>
        public void LoadContent(List<Texture2D> textures)
        {
            animation = new Animation();
            animation.Initialize(textures, 1, true, true);         
        }

        /// <summary>
        /// Este método sirve para comparar entidad por un tag y no por su referencia.
        /// </summary>
        /// <param name="tag">recibe un tag a comparar</param>
        /// <returns>retorna true si el tag coincide con la entidad, de lo contrario retorna false.</returns>
        public bool CompareTag(string tag)
        {
            if (this.tag == tag)
                return true;
            return false;
        }


        public Entity()
        {
           
        }
    }
}
