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

        public bool isActive;
        public bool isLoaded;
        public bool isCompleted;
        

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
            isLoaded = false;

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



        public Vector2 GenerateRandomPositionOutside()
        {
            //radius of 1337

            float radius = 3*1337;

            Random rand = new Random();
            
            float x = radius*(float)Math.Cos(2*Math.PI* rand.NextDouble());
            float y = radius * (float)Math.Sin(2 * Math.PI * rand.NextDouble());

            Vector2 pos = new Vector2(x, y);
            return pos;

        }


    }







}
