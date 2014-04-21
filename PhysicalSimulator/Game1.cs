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
        TextBox text;

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
            entity.Initialize();
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
            entity.LoadContent(texturas);
            text = new TextBox(false, 12f, 12f, texturas[1], texturas[2], spriteBatch, new Vector2(50, 50));
            text.input = "culo";
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
            text.DrawBackGround();
            text.DrawText();
            entity.Draw(spriteBatch);
            //spriteBatch.Draw(texturas[0], new Vector2(GraphicsDevice.Viewport.Width / 2 - texturas[0].Width / 2, GraphicsDevice.Viewport.Height / 2 - texturas[0].Height / 2), Color.White);
            //spriteBatch.Draw(texturas[1], new Vector2(GraphicsDevice.Viewport.Width / 2 - texturas[1].Width / 2 + 100, GraphicsDevice.Viewport.Height / 2 - texturas[1].Height / 2 + 80), Color.White);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
