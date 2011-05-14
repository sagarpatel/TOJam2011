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


    public class Level1Screen:ScreenObject
    {


        public Level1Screen(Game game, SpriteBatch sB): base(game, sB)
        {

            



        }




        protected override void LoadContent()
        {

            //base.LoadContent();
        }



        public override void Update(GameTime gameTime)
        {
            // Level logic update here

            base.Update(gameTime);

        }




        public override void Draw(GameTime gameTime)
        {

          //  spriteBatch.Draw stuff here

            base.Draw(gameTime);
        }








    }






}
