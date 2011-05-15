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
        
        public bool isShaky;
        public bool isActive;
        public float initialShake;
        public bool isWallBouncing;

        public TitleObject(Game game,SpriteBatch sB,Texture2D passedTexture):base(game,sB)
        {
            isKilled = false;
            isActive = false;
            texture = passedTexture;
            initialShake = 0f;
            isWallBouncing = false;
        }




        protected override void LoadContent()
        {

            //base.LoadContent();
        }


        public override void Update(GameTime gameTime)
        {
            // Player Update Code Here

            if (isWallBouncing)
            {
                WallBounce(texture);
            }

            UpdatePV();
          //  base.Update(gameTime);

        }




        public override void Draw(GameTime gameTime)
        {


            if (isShaky)
            {
                Random rand = new Random();
                Vector2 tempPosition = new Vector2(0, 0);
                tempPosition.X = position.X + (float)rand.Next(-1, 1) * position.X * initialShake*0.01f;
                tempPosition.Y = position.Y + (float)rand.Next(-1, 1) * position.Y * initialShake*0.01f;
                spriteBatch.Draw(texture,tempPosition, null, Color.White, rotation, new Vector2(texture.Width / 2, texture.Height / 2), scale, SpriteEffects.None, 0);
            }


            else
            {
                if (isUnFading)
                {
                   // colorLerp = Color.Lerp(colorLerp, Color.White, UnFadingLerp);
                    colorLerp.R = (byte)customRGBA;
                    colorLerp.G = (byte)customRGBA;
                    colorLerp.B = (byte)customRGBA;
                    colorLerp.A = (byte)customRGBA;
                    spriteBatch.Draw(texture, position, null, colorLerp, rotation, new Vector2(texture.Width / 2, texture.Height / 2), scale, SpriteEffects.None, 0);
                }
                else
                {
                    spriteBatch.Draw(texture, position, null, Color.White, rotation, new Vector2(texture.Width / 2, texture.Height / 2), scale, SpriteEffects.None, 0);
                }
            }


         //   base.Draw(gameTime);
        }


        protected override void UpdatePV()
        {
            velocity = velocity * (1f - friction);
            position += speed * velocity;

            //base.UpdatePV();
        }













    }




}
