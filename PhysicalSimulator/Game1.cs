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
        TextBox text,text1, mousex,mousey;
        int i = 0;
        /// <summary>
        /// game1
        /// </summary>
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            entity.Initialize(new Vector2(0, 150),
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
            text = new TextBox(false, 0.2f, 0.5f, 6, texturas[1], texturas[3], texturas[4], spriteBatch, new Vector2(200, 100), new Rectangle(200 - (int)(71 * 0.5) * 6, 100 - (int)(98 * 0.5), (int)(71 * 0.5) * 6, (int)(98 * 0.5)));
            text1 = new TextBox(false, 0.2f, 0.5f, 6, texturas[1], texturas[3], texturas[4], spriteBatch, new Vector2(200, 200), new Rectangle(200, 200, 146, 40));
            mousex = new TextBox(false, 0.2f, 0.5f, 6, texturas[1], texturas[3], texturas[4], spriteBatch, new Vector2(600, 200), new Rectangle(600, 200, 146, 40));
            mousey = new TextBox(false, 0.2f, 0.5f, 6, texturas[1], texturas[3], texturas[4], spriteBatch, new Vector2(600, 250), new Rectangle(700, 200, 146, 40));
            text1.input = "culo";
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
            

            // TODO: Add your update logic here
            entity.Update(gameTime); 
            //text.input = i.ToString();
            text.setState();
            if (text.getState())
            {
                text.getInput();
            }
            i++; text1.setState();
            if (text1.getState())
            {
                text1.getInput();
            }
            i++;

            mousex.input = Mouse.GetState().X.ToString();
            mousey.input = Mouse.GetState().Y.ToString();

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

            spriteBatch.Begin();
            //text.DrawBackGround();
            text.DrawText();
            text1.DrawText();
            mousex.DrawText();
            mousey.DrawText();
            entity.Draw(spriteBatch);
            //spriteBatch.Draw(texturas[0], new Vector2(GraphicsDevice.Viewport.Width / 2 - texturas[0].Width / 2, GraphicsDevice.Viewport.Height / 2 - texturas[0].Height / 2), Color.White);
            //spriteBatch.Draw(texturas[1], new Vector2(GraphicsDevice.Viewport.Width / 2 - texturas[1].Width / 2 + 100, GraphicsDevice.Viewport.Height / 2 - texturas[1].Height / 2 + 80), Color.White);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
