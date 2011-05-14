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


        SpriteFont spriteFont1;

        
        public Level1Screen(Game game, SpriteBatch sB): base(game, sB)
        {


            spriteFont1 = Game.Content.Load<SpriteFont>("Fonts/SF1");
            
            isActive = true;

        }




        protected override void LoadContent()
        {
            
            //base.LoadContent();
        }



        protected override void UnloadContent()
        {
            //Unload and kill level stuff here
            base.UnloadContent();
        }


        public override void Update(GameTime gameTime)
        {
            // Level logic update here
            
            base.Update(gameTime);

        }




        public override void Draw(GameTime gameTime)
        {

          //  spriteBatch.Draw stuff here

            spriteBatch.DrawString(spriteFont1,"test1", new Vector2(400, 0), Color.Green);
                
            
            base.Draw(gameTime);
        }








    }






}
