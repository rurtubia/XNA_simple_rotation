using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace RotacionImagenesXNA
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D spriteTextura;
        Rectangle spriteRectangulo;

        Vector2 spriteOrigen;
        Vector2 spritePosicion;
        
        float rotacion;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            spriteTextura = Content.Load<Texture2D>("nave");
            spritePosicion = new Vector2(250, 200);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            spriteRectangulo = new Rectangle
                (
                    (int)spritePosicion.X, 
                    (int)spritePosicion.Y, 
                    spriteTextura.Width, 
                    spriteTextura.Height
                );
            spriteOrigen = new Vector2
                (
                spriteRectangulo.Width / 2,
                spriteRectangulo.Height / 2
                );
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) rotacion += 0.2f;
            if (Keyboard.GetState().IsKeyDown(Keys.Left)) rotacion -= 0.2f;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(spriteTextura, spritePosicion, null, Color.White,
            rotacion, spriteOrigen, 1f, SpriteEffects.None, 0);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
