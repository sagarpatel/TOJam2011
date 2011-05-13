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



    public class PlayerObject : GameObject
    {




        public PlayerObject(Game game, SpriteBatch sB): base(game, sB)
        {
            position = new Vector2(10, 10);
 
        }



        protected override void LoadContent()
        {


            texture = Game.Content.Load<Texture2D>("Sprites/gclV1");
            origin = new Vector2(texture.Width / 2f, texture.Height / 2f);

            position = new Vector2(200, 100);

         
            //base.LoadContent();
        }


        public override void Update(GameTime gameTime)
        {
            // Player Update Code Here





            base.Update(gameTime);

        }




        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Draw(texture, position, Color.White);


            base.Draw(gameTime);
        }




    }


}
