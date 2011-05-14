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


    public class WeaponObject : GameObject
    {


        public WeaponObject(Game game, SpriteBatch sB, Texture2D passedTexture): base(game, sB)
        {
            position = new Vector2(10, 10);
            texture = passedTexture;
 
        }



        protected override void LoadContent()
        {


         //   texture = Game.Content.Load<Texture2D>("PATHTOWEAPONSPRITE");
            //origin = new Vector2(texture.Width / 2f, texture.Height / 2f);

            //position = new Vector2(20, 40);

         
            //base.LoadContent();
        }


        public override void Update(GameTime gameTime)
        {
            // Player Update Code Here

            position += 0.01f * position;

            base.Update(gameTime);

        }




        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Draw(texture, position, Color.White);

            base.Draw(gameTime);
        }



    }







}
