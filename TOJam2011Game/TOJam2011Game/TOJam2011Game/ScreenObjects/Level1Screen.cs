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

        Texture2D toj;

        bool isintroComplete;
        bool istutorialComplete;
        bool isPlayerLaunched;
        bool ismovingComplete;

        Rectangle screenRectangle;

        PlayerObject mainPlayer;

        double timeCount;

        SoundEffect wall_smack;
        SoundEffect toilet_flush;

        public Level1Screen(Game game, SpriteBatch sB): base(game, sB)
        {
            spriteFont1 = Game.Content.Load<SpriteFont>("Fonts/SF1");
            isActive = true;
            isCompleted = false;
            isintroComplete = false;
            istutorialComplete = false;
            ismovingComplete = false;
            
            isPlayerLaunched = false;

            screenRectangle = new Rectangle(0, 0, Game1.screenWidth,Game1.screenHeight);
                      
            // set up level content
            iTitle = new TitleObject(game, sB, Game.Content.Load<Texture2D>("Sprites/InfinitelyV2"));
            iTitle.targetPosition = new Vector2(650, 150);
            iTitle.position = -10f*iTitle.targetPosition;

            iiTitle = new TitleObject(game, sB, Game.Content.Load<Texture2D>("Sprites/ImprobableV2"));
            iiTitle.position = GenerateRandomPositionOutside();
            iiTitle.rotation = 0f;
            iiTitle.targetPosition = new Vector2(450, 350);
            iiTitle.targetRotation = 20f * (float)Math.PI;


            iiiTitle = new TitleObject(game, sB, Game.Content.Load<Texture2D>("Sprites/IncertitudeV1"));
            iiiTitle.targetPosition = new Vector2(600, 500);
            iiiTitle.position = -iiiTitle.targetPosition;
            iiiTitle.initialShake = 1f;

            Game.Components.Add(iTitle);
            Game.Components.Add(iiTitle);
            Game.Components.Add(iiiTitle);

            mainPlayer = GameFlowManager.player1;

            mainPlayer.isControllable = false;
            mainPlayer.isMoveable = false;
            mainPlayer.activeTextureID = 1;

            timeCount = 0;

            wall_smack = Game.Content.Load<SoundEffect>("SoundEffects/smack-1");
            toilet_flush = Game.Content.Load<SoundEffect>("SoundEffects/toilet-flush-2");

            SoundEffect.MasterVolume = 0.08f;
            toilet_flush.Play();

            toj = Game.Content.Load<Texture2D>("Sprites/TOJstamp");
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

            //Enter tutorial
            if (isintroComplete)
            {
                if (isPlayerLaunched == false)
                {
                    mainPlayer.velocity = new Vector2(10, 0);
                    mainPlayer.friction = 0.01f;
                    isPlayerLaunched = true;
                }

                if (mainPlayer.IsInsideScreen(mainPlayer.textureList[mainPlayer.activeTextureID]))
                {
                    mainPlayer.isWallBouncing = true;
                    if (mainPlayer.activeTextureID == 0)
                    {
                        mainPlayer.activeTextureID = 1;
                    }

                    if (mainPlayer.velocity.X < 1f)
                    {
                        if (mainPlayer.activeTextureID == 1)
                        {
                            wall_smack.Play();
                        }
                        mainPlayer.activeTextureID = 2;
                        
                        
                        if (Math.Abs(mainPlayer.velocity.X) < 0.1f)
                        {
                            mainPlayer.activeTextureID = 3;
                            mainPlayer.isControllable = true;
                            mainPlayer.friction = 0.15f;
                        }
                    }

                }

                if (mainPlayer.APressedCount>1)
                {
                    mainPlayer.activeTextureID = 4;
                }
          
                HandleEnemies();
            }


            timeCount += gameTime.ElapsedGameTime.TotalMilliseconds;

            //Level Completion condition
            if (iTitle.isKilled && iiTitle.isKilled && iiiTitle.isKilled)
            {
                mainPlayer.activeTextureID = 5;
                mainPlayer.isMoveable = true;

                if (mainPlayer.velocity.Length() > 5f)
                {
                    mainPlayer.activeTextureID = 6;
                    istutorialComplete = true;
                    isCompleted = true;
                }

            }


            base.Update(gameTime);

        }




        public override void Draw(GameTime gameTime)
        {

          //  spriteBatch.Draw stuff here
            spriteBatch.Draw(toj, new Vector2(100, 100), Color.White);
                
            base.Draw(gameTime);
        }


        public void HandleEnemies()
        {
            // Collision with weapons check

            foreach (KeyValuePair<int, WeaponObject[]> entry in mainPlayer.weaponDict)
            {
                foreach (WeaponObject w in entry.Value)
                {
                    if (w.isAlive && w.isSolid)
                    {
                        //for title1
                        if (iTitle.isAlive)
                        {
                            if (iTitle.CheckCollision(w.position, w.texture.Width, w.texture.Height))
                            {
                                w.isAlive = false;
                                iTitle.isAlive = false;
                                iTitle.isKilled = true;
                            }
                        }
                        //for title2
                        if (iiTitle.isAlive)
                        {
                            if (iiTitle.CheckCollision(w.position, w.texture.Width, w.texture.Height))
                            {
                                w.isAlive = false;
                                iiTitle.isAlive = false;
                                iiTitle.isKilled = true;
                            }
                        }
                        //for title3
                        if (iiiTitle.isAlive)
                        {
                            if (iiiTitle.CheckCollision(w.position, w.texture.Width, w.texture.Height))
                            {
                                w.isAlive = false;
                                iiiTitle.isAlive = false;
                                iiiTitle.isKilled = true;
                            }
                        }
                    }
                }
            }

            //for title1
            if (iTitle.isKilled == true && iTitle.isAlive == false)
            {
                Game.Components.Remove(iTitle);
                iTitle.Dispose();
            }
            //for title2
            if (iiTitle.isKilled == true && iiTitle.isAlive == false)
            {
                Game.Components.Remove(iiTitle);
                iiTitle.Dispose();
            }
            //for title3
            if (iiiTitle.isKilled == true && iiiTitle.isAlive == false)
            {
                Game.Components.Remove(iiiTitle);
                iiiTitle.Dispose();
            }



        }



        public bool HandleIntro()
        {

            //Send first message to position
            iTitle.position.X = MathHelper.Lerp(iTitle.position.X, iTitle.targetPosition.X, 0.09f);
            iTitle.position.Y = MathHelper.Lerp(iTitle.position.Y, iTitle.targetPosition.Y, 0.09f);

            //check if first message arrived
            if (Math.Round((double)iTitle.position.X) == (double)iTitle.targetPosition.X)
            {
                //send second message
                iiTitle.position.X = MathHelper.Lerp(iiTitle.position.X, iiTitle.targetPosition.X, 0.1f);
                iiTitle.position.Y = MathHelper.Lerp(iiTitle.position.Y, iiTitle.targetPosition.Y, 0.1f);
                iiTitle.rotation = MathHelper.Lerp(iiTitle.rotation, iiTitle.targetRotation, 0.085f);
                // check is second message has arrived
                if (Math.Round((double)iiTitle.position.X) == (double)iiTitle.targetPosition.X)
                {
                    //send third message
                    iiiTitle.position.X = MathHelper.Lerp(iiiTitle.position.X, iiiTitle.targetPosition.X, 0.075f);
                    iiiTitle.position.Y = MathHelper.Lerp(iiiTitle.position.Y, iiiTitle.targetPosition.Y, 0.075f);
                    //Shaky feel code
                    iiiTitle.isShaky = true;
                    iiiTitle.initialShake = MathHelper.Lerp(iiTitle.initialShake, 100f, 0.9f);
                  
                    //check if third message has arrived
                    if (Math.Round((double)iiiTitle.position.X) == (double)iiiTitle.targetPosition.X)
                    {
                        iiiTitle.isShaky = false;
                        return true;
                    }
                }

            }

            return false;

        }





    }






}
