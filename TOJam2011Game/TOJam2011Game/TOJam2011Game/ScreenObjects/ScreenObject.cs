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


namespace TOJam2011Game
{



    public abstract class ScreenObject : Microsoft.Xna.Framework.DrawableGameComponent
    {

        protected bool isActive;
        protected bool isLoaded;
        protected bool isCompleted;

        protected SpriteBatch spriteBatch;

        public ScreenObject(Game game, SpriteBatch sB): base(game)
        {
            spriteBatch = sB;
            isActive = false;
            isLoaded = false;
            isCompleted = false;

        }



        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }







        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

        }




    }







}
