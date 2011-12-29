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

        public int HP;
        public int initialHP;


        public TitleObject(Game game,SpriteBatch sB,Texture2D passedTexture):base(game,sB)
        {
            isKilled = false;
            isActive = false;
            texture = passedTexture;
            initialShake = 0f;
            isWallBouncing = false;
            initialHP = 10;
            HP = initialHP;
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

            if (HP < 1)
            {
                this.isAlive = false;
                this.isKilled = true;
            }
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
                    int cValue = (int)(256f * Math.Pow((double)(float)((float)HP / (float)initialHP) ,2));
                    Color brightness = new Color(cValue,cValue,cValue,256);
                    if (HP == 2 || HP == 1)
                        brightness = Color.White;
                    spriteBatch.Draw(texture, position, null, brightness, rotation, new Vector2(texture.Width / 2, texture.Height / 2), scale, SpriteEffects.None, 0);
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
