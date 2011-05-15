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


    public class TitleObject : GameObject
    {

        public Vector2 targetPosition;
        public float targetRotation;
        public bool isKilled;

        public TitleObject(Game game,SpriteBatch sB,Texture2D passedTexture):base(game,sB)
        {
            isKilled = false;
            texture = passedTexture;
        }




        protected override void LoadContent()
        {

            //base.LoadContent();
        }


        public override void Update(GameTime gameTime)
        {
            // Player Update Code Here


            base.Update(gameTime);

        }




        public override void Draw(GameTime gameTime)
        {

            // spriteBatch.Draw(texture, position, Color.White);
            spriteBatch.Draw(texture, position, null, Color.White, rotation, new Vector2(texture.Width / 2, texture.Height / 2), scale, SpriteEffects.None, 0);

            base.Draw(gameTime);
        }















    }




}
