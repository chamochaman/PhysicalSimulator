#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace PhysicalSimulator
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<Texture2D> texturas = new List<Texture2D>();
        Entity entity = new Entity();
        TextBox mousex,mousey;
        Button Iniciar, Reporte; Reportes form;
        TextBox tbVelocidadX, tbVelocidadY, tbAceleracionX, tbAceleracionY, LabelVX, LabelVY, LabelAX, LabelAY;
        float delayStartButton = 200f;
        float ellapsedTimeButton = 0f;
        bool active  = false;
        /// <summary>
        /// game1
        /// </summary>
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            entity.Initialize(new Vector2(0, 305),
                              new Vector2(0, -120),
                              new Vector2(0, 98),
                              new Rectangle(0,150,146,40),
                              0.0f);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            texturas.Add(Content.Load<Texture2D>("Boton1.bmp"));
            texturas.Add(Content.Load<Texture2D>("fondo.bmp"));
            texturas.Add(Content.Load<Texture2D>("font2.bmp"));
            texturas.Add(Content.Load<Texture2D>("font3.png"));
            texturas.Add(Content.Load<Texture2D>("font4.png"));
            entity.LoadContent(texturas);
            //tbVelocidadX, tbVelocidady, tbAceleracionX, tbAceleracionY;

            tbVelocidadX = new TextBox(false, 0.2f, 0.5f, 6, texturas[1], texturas[3], texturas[4], spriteBatch, new Vector2(1200, 90), new Rectangle(1136, 60, 85, 20));
            tbVelocidadY = new TextBox(false, 0.2f, 0.5f, 6, texturas[1], texturas[3], texturas[4], spriteBatch, new Vector2(1200, 120), new Rectangle(1136, 90, 85, 20));
            tbAceleracionX = new TextBox(false, 0.2f, 0.5f, 6, texturas[1], texturas[3], texturas[4], spriteBatch, new Vector2(1200, 150), new Rectangle(1136, 120, 85, 20));
            tbAceleracionY = new TextBox(false, 0.2f, 0.5f, 6, texturas[1], texturas[3], texturas[4], spriteBatch, new Vector2(1200, 180), new Rectangle(1136, 150, 85, 20));

            LabelVX = new TextBox(false, 0.2f, 0.5f, 12, texturas[1], texturas[3], texturas[4], spriteBatch, new Vector2(980, 90), new Rectangle());
            LabelVY = new TextBox(false, 0.2f, 0.5f, 12, texturas[1], texturas[3], texturas[4], spriteBatch, new Vector2(980, 120), new Rectangle()); 
            LabelAX = new TextBox(false, 0.2f, 0.5f, 14, texturas[1], texturas[3], texturas[4], spriteBatch, new Vector2(951, 150), new Rectangle());
            LabelAY = new TextBox(false, 0.2f, 0.5f, 14, texturas[1], texturas[3], texturas[4], spriteBatch, new Vector2(951, 180), new Rectangle());

            LabelVX.input = "velocidad x:";
            LabelVY.input = "velocidad y:";
            LabelAX.input = "aceleracion x:";
            LabelAY.input = "aceleracion y:";//71

            Iniciar = new Button(false, 0.2f, 0.5f, 7, texturas[1], texturas[3], texturas[4], spriteBatch, new Vector2(1154, 672), new Rectangle(1089, 642, 100, 20));
            Iniciar.input = "iniciar";

            Reporte = new Button(false, 0.2f, 0.5f, 11, texturas[1], texturas[3], texturas[4], spriteBatch, new Vector2(1154, 600), new Rectangle(1089, 570, 157, 20));
            Reporte.input = "ver reporte";

            
            mousex = new TextBox(false, 0.2f, 0.5f, 6, texturas[1], texturas[3], texturas[4], spriteBatch, new Vector2(600, 200), new Rectangle(600, 200, 146, 40));
            mousey = new TextBox(false, 0.2f, 0.5f, 6, texturas[1], texturas[3], texturas[4], spriteBatch, new Vector2(600, 250), new Rectangle(700, 200, 146, 40));
            //text1.input = "culo";
            /* texturas.Add(Content.Load<Texture2D>("Menu1.bmp"));
             texturas.Add(Content.Load<Texture2D>("Boton1.bmp"));
             */
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Si se presiona el botón f1 instancia el form de ayuda, y cierra la ventana de simulación
            if (Keyboard.GetState().IsKeyDown(Keys.F1))
            {
                Ayuda form = new Ayuda();

                form.Show();
                form.Refresh();
                this.Exit();
            }
            // si se activa la simulación empieza a ejecutar el método UpDate de la entidad
            if (Iniciar.Pressed() && !active && ellapsedTimeButton > delayStartButton)
            {
                ellapsedTimeButton = 0;
                this.active = true;
                Iniciar.input = "pausar";
                int vx, vy, ax, ay;
                if (tbVelocidadX.input == "")
                    vx = 0;
                else
                    vx = int.Parse(tbVelocidadX.input);

                if (tbVelocidadY.input == "")
                    vy = 0;
                else
                    vy = int.Parse(tbVelocidadY.input);

                if (tbAceleracionX.input == "")
                    ax = 0;
                else
                    ax = int.Parse(tbAceleracionX.input);
                if (tbAceleracionY.input == "")
                    ay = 0;
                else
                    ay = int.Parse(tbAceleracionY.input);


                
                entity.Initialize(new Vector2(0, 150),
                                    new Vector2(vx, vy),
                                    new Vector2(ax, ay),
                                    new Rectangle(),
                                    0.0f);
                entity.InitializeHistory();
            }
            //Si se se presiona el botón PAUSAR, se reinicia el botón y se desactiva la simulación
            if (active && Iniciar.Pressed() && ellapsedTimeButton > delayStartButton)
            {
                this.active = false;
                Iniciar.input = "iniciar";
                ellapsedTimeButton = 0;
            }

            ellapsedTimeButton += gameTime.ElapsedGameTime.Milliseconds;

            if(active)            
                entity.Update(gameTime); 
            //text.input = i.ToString();
            //Si no está activa la simulación, permite abrir el buffer para la entrada de los datos a los text boxes.
            if (!active)
            {
                tbAceleracionX.TurnOnBuffer();
                tbAceleracionY.TurnOnBuffer();
                tbVelocidadX.TurnOnBuffer();
                tbVelocidadY.TurnOnBuffer();
            }

            //Si se presiona el botón de VER REPORTE, se instancia el form de reportes, y se cierra la ventana de simulación
            if (Reporte.Pressed() && !active && ellapsedTimeButton > delayStartButton)
            {
                ellapsedTimeButton = 0;
                form = new Reportes(entity.History);
                
                form.Show();
                form.Refresh();
                this.Exit();
            }

           // mousex.input = Mouse.GetState().X.ToString();
            //mousey.input = Mouse.GetState().Y.ToString();
            if (entity.position.X > 1300 || entity.position.Y > 950)
            {
                this.active = false;
                Iniciar.input = "iniciar";
                ellapsedTimeButton = 0;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            //Se dibuja en pantalla todas las entidades
            spriteBatch.Begin();
            //text.DrawBackGround();
            tbVelocidadX.DrawText();
            tbVelocidadY.DrawText();
            tbAceleracionX.DrawText();
            tbAceleracionY.DrawText();
            LabelVX.DrawText();
            LabelVY.DrawText();
            LabelAX.DrawText();
            LabelAY.DrawText();
            //mousex.DrawText();
            //mousey.DrawText();
            Iniciar.DrawText();
            Reporte.DrawText();
            entity.Draw(spriteBatch);
            //spriteBatch.Draw(texturas[0], new Vector2(GraphicsDevice.Viewport.Width / 2 - texturas[0].Width / 2, GraphicsDevice.Viewport.Height / 2 - texturas[0].Height / 2), Color.White);
            //spriteBatch.Draw(texturas[1], new Vector2(GraphicsDevice.Viewport.Width / 2 - texturas[1].Width / 2 + 100, GraphicsDevice.Viewport.Height / 2 - texturas[1].Height / 2 + 80), Color.White);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
