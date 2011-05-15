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
 
        TitleObject iTitle;
        TitleObject iiTitle;
        TitleObject iiiTitle;

        bool isintroComplete;


        public Level1Screen(Game game, SpriteBatch sB): base(game, sB)
        {
            spriteFont1 = Game.Content.Load<SpriteFont>("Fonts/SF1");
            isActive = true;
            isCompleted = false;
            isintroComplete = false;
        
                      
            // set up level content
            iTitle = new TitleObject(game, sB, Game.Content.Load<Texture2D>("Sprites/InfinitelyV2"));
            iTitle.targetPosition = new Vector2(700, 150);
            iTitle.position = -iTitle.targetPosition;

            iiTitle = new TitleObject(game, sB, Game.Content.Load<Texture2D>("Sprites/ImprobableV2"));
            iiTitle.position = GenerateRandomPositionOutside();
            iiTitle.rotation = 0f;
            iiTitle.targetPosition = new Vector2(300, 300);
            iiTitle.targetRotation = 20f * (float)Math.PI;


            iiiTitle = new TitleObject(game, sB, Game.Content.Load<Texture2D>("Sprites/IncertitudeV1"));
            iiiTitle.targetPosition = new Vector2(600, 500);
            iiiTitle.position = -iiiTitle.targetPosition;

            Game.Components.Add(iTitle);
            Game.Components.Add(iiTitle);
            Game.Components.Add(iiiTitle);
            
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
            if (isintroComplete == false)
            {
                //run and check intro status
                if (HandleIntro())
                {
                    isintroComplete = true;
                }

            }


            if (isintroComplete)
            {
                HandleEnemies();
            }
            
            

            //Level Completion condition
            if (iTitle.isKilled)
            {
                isCompleted = true;
            }


            base.Update(gameTime);

        }




        public override void Draw(GameTime gameTime)
        {

          //  spriteBatch.Draw stuff here
            spriteBatch.DrawString(spriteFont1,"test1", new Vector2(400, 0), Color.Green);
                
            base.Draw(gameTime);
        }


        public void HandleEnemies()
        {
            // Collision with weapons check

            foreach (KeyValuePair<int, WeaponObject[]> entry in GameFlowManager.player1.weaponDict)
            {
                foreach (WeaponObject w in entry.Value)
                {
                    if (w.isAlive && w.isSolid)
                    {
                        if (iTitle.CheckCollision(w.position, w.texture.Width, w.texture.Height))
                        {
                            w.isAlive = false;
                            iTitle.isAlive = false;
                            iTitle.isKilled = true;
                        }
                    }
                }
            }

            if (iTitle.isKilled == true && iTitle.isAlive == false)
            {
                Game.Components.Remove(iTitle);
                iTitle.Dispose();
            }


        }



        public bool HandleIntro()
        {

            //Send first message to position
            iTitle.position.X = MathHelper.Lerp(iTitle.position.X, iTitle.targetPosition.X, 0.05f);
            iTitle.position.Y = MathHelper.Lerp(iTitle.position.Y, iTitle.targetPosition.Y, 0.05f);

            //check if first message arrived
            if (Math.Round((double)iTitle.position.X) == (double)iTitle.targetPosition.X)
            {
                //send second message
                iiTitle.position.X = MathHelper.Lerp(iiTitle.position.X, iiTitle.targetPosition.X, 0.05f);
                iiTitle.position.Y = MathHelper.Lerp(iiTitle.position.Y, iiTitle.targetPosition.Y, 0.05f);
                iiTitle.rotation = MathHelper.Lerp(iiTitle.rotation, iiTitle.targetRotation, 0.05f);
                // check is second message has arrived
                if (Math.Round((double)iiTitle.position.X) == (double)iiTitle.targetPosition.X)
                {
                    //send third message
                    iiiTitle.position.X = MathHelper.Lerp(iiiTitle.position.X, iiiTitle.targetPosition.X, 0.05f);
                    iiiTitle.position.Y = MathHelper.Lerp(iiiTitle.position.Y, iiiTitle.targetPosition.Y, 0.05f);
                    //check if third message has arrived
                    if (Math.Round((double)iiiTitle.position.X) == (double)iiiTitle.targetPosition.X)
                    {
                        return true;
                    }
                }

            }

            return false;

        }





    }






}
