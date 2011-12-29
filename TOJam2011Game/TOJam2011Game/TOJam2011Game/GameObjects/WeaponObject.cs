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

        public int fireRate;

        public WeaponObject(Game game, SpriteBatch sB, Texture2D passedTexture): base(game, sB)
        {

            position = new Vector2(10, 10);
            texture = passedTexture;
            isAlive = false;
            fireRate = 1;
 
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

            UpdatePV();

            if (IsInsideScreen(texture) == false)
            {
                isAlive = false;
            }
            

            base.Update(gameTime);

        }




        public override void Draw(GameTime gameTime)
        {
            if (isAlive)
            {
                spriteBatch.Draw(texture, position, null, Color.White, rotation, new Vector2(texture.Width / 2, texture.Height / 2), scale, SpriteEffects.None, 0);

            }

            base.Draw(gameTime);
        }



        protected override void UpdatePV()
        {
            velocity = velocity * (1f - friction);
            position += speed * velocity;

            base.UpdatePV();
        }


        


    }







}
