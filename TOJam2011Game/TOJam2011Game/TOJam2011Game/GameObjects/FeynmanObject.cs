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


    public class FeynmanObject:GameObject
    {


        public Video feynmanVid;
        public VideoPlayer videoPlayer;


        public FeynmanObject(Game game, SpriteBatch sB):base(game,sB)
        {


            isAlive = true;
            isKilled = false;


            feynmanVid = Game.Content.Load<Video>("Videos/F1v3");
            videoPlayer = new VideoPlayer();

            
        }


        public override void Update(GameTime gameTime)
        {
            // Player Update Code Here

            if (isWallBouncing)
            {
                WallBounce(texture);
            }


            UpdatePV();

            base.Update(gameTime);

        }




        public override void Draw(GameTime gameTime)
        {

            // spriteBatch.Draw(texture, position, Color.White);
            texture = videoPlayer.GetTexture();
            spriteBatch.Draw(texture, position, null, Color.White, rotation, new Vector2(texture.Width / 2, texture.Height / 2), scale, SpriteEffects.None, 0);

            base.Draw(gameTime);
        }


        


    }






}
