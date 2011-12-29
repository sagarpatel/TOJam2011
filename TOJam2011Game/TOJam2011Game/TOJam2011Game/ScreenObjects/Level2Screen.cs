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


    public class Level2Screen: ScreenObject
    {

        PlayerObject mainPlayer;

        SpriteFont spriteFont1;

        TitleObject canyouseemeTitle;
        TitleObject IPreadytolearnTitle;
        TitleObject lvl2warning1;
        TitleObject keepafloat;
        TitleObject letsstartthelearning;
        TitleObject forscience;
        TitleObject apertureascii;


        double timeCounter;

        float totalAngularVelocity;

        ParticleEngine PE1;


        public Level2Screen(Game game, SpriteBatch sB): base(game, sB)
        {
            isActive = true;
            isCompleted = false;
            timeCounter = 0;

            mainPlayer = GameFlowManager.player1;

            int maxHP = 20;

            canyouseemeTitle = new TitleObject(game, sB, Game.Content.Load<Texture2D>("Sprites/Level2/canyouseemeV1"));
            canyouseemeTitle.position = new Vector2(400, 100);
            canyouseemeTitle.initialHP = maxHP;
            canyouseemeTitle.HP = maxHP;

            IPreadytolearnTitle = new TitleObject(game, sB, Game.Content.Load<Texture2D>("Sprites/Level2/IPreadytolearn"));
            IPreadytolearnTitle.position = new Vector2(600, 300);
            IPreadytolearnTitle.initialHP = maxHP;
            IPreadytolearnTitle.HP = maxHP;

            lvl2warning1 = new TitleObject(game, sB, Game.Content.Load<Texture2D>("Sprites/Level2/lv2warning1"));
            lvl2warning1.position = new Vector2(100 + lvl2warning1.texture.Width/2, 100 + lvl2warning1.texture.Height/2);
            lvl2warning1.initialHP = maxHP;
            lvl2warning1.HP = maxHP;

            keepafloat = new TitleObject(game, sB, Game.Content.Load<Texture2D>("Sprites/Level2/keepafloat"));
            keepafloat.position = new Vector2(300 + lvl2warning1.texture.Width / 2, 100 + lvl2warning1.texture.Height / 2);
            keepafloat.initialHP = maxHP;
            keepafloat.HP = maxHP;

            letsstartthelearning = new TitleObject(game, sB, Game.Content.Load<Texture2D>("Sprites/Level2/letsstartthelearning"));
            letsstartthelearning.position = new Vector2(200 + lvl2warning1.texture.Width / 2, 100 + lvl2warning1.texture.Height / 2);
            letsstartthelearning.initialHP = maxHP;
            letsstartthelearning.HP = maxHP;

            forscience = new TitleObject(game, sB, Game.Content.Load<Texture2D>("Sprites/Level2/forscience"));
            forscience.position = new Vector2(200 + lvl2warning1.texture.Width / 2, 200 + lvl2warning1.texture.Height / 2);
            forscience.initialHP = maxHP;
            forscience.HP = maxHP;

            apertureascii = new TitleObject(game, sB, Game.Content.Load<Texture2D>("Sprites/Level2/apertureasciiV3"));
            apertureascii.position = new Vector2(10+ apertureascii.texture.Width / 2, 50 + lvl2warning1.texture.Height / 2);
      

            spriteFont1 = Game.Content.Load<SpriteFont>("Fonts/SF1");


            totalAngularVelocity = 0;

            PE1 = new ParticleEngine(sB, Game.Content.Load<Texture2D>("Sprites/goatV1"),2);

        }




        protected override void LoadContent()
        {
            canyouseemeTitle.isActive = true;
            Game.Components.Add(canyouseemeTitle);
            //base.LoadContent();
        }



        public override void Update(GameTime gameTime)
        {
            // Level logic update here


            Handle_and_CheckWeaponCollision(canyouseemeTitle);

            if (canyouseemeTitle.isKilled && IPreadytolearnTitle.isActive == false)
            {
                //continue to next message
                mainPlayer.activeTextureID = 8;
                timeCounter += gameTime.ElapsedGameTime.TotalMilliseconds;
                //enter only once
                if (timeCounter > 2000 && IPreadytolearnTitle.isActive == false)
                {
                    //add next message
                    IPreadytolearnTitle.isActive = true;
                    Game.Components.Add(IPreadytolearnTitle);
                    timeCounter = 0;
                }

            }


            if (IPreadytolearnTitle.isActive && lvl2warning1.isActive == false)
            {
                Handle_and_CheckWeaponCollision(IPreadytolearnTitle);

                if (IPreadytolearnTitle.isKilled)
                {
                    timeCounter += gameTime.ElapsedGameTime.TotalMilliseconds;

                    if (timeCounter > 2000)
                    {
                        lvl2warning1.isActive = true;
                        Game.Components.Add(lvl2warning1);
                        timeCounter = 0;
                    }
                }
            }



            if (lvl2warning1.isActive && keepafloat.isActive == false)
            {
                Handle_and_CheckWeaponCollision(lvl2warning1);

                if (lvl2warning1.isKilled)
                {
                    timeCounter += gameTime.ElapsedGameTime.TotalMilliseconds;

                    if (timeCounter > 2000)
                    {
                        keepafloat.isActive = true;
                        Game.Components.Add(keepafloat);
                        timeCounter = 0;
                    }
                }
            }



            if (keepafloat.isActive && letsstartthelearning.isActive == false)
            {
                Handle_and_CheckWeaponCollision(keepafloat);

                if (keepafloat.isKilled)
                {
                    timeCounter += gameTime.ElapsedGameTime.TotalMilliseconds;

                    if (timeCounter > 2000)
                    {
                        letsstartthelearning.isActive = true;
                        Game.Components.Add(letsstartthelearning);
                        timeCounter = 0;
                    }
                }
            }



            if (letsstartthelearning.isActive && forscience.isActive == false)
            {
                Handle_and_CheckWeaponCollision(letsstartthelearning);

                if (letsstartthelearning.isKilled)
                {
                    timeCounter += gameTime.ElapsedGameTime.TotalMilliseconds;

                    if (timeCounter > 1000)
                    {
                        forscience.isActive = true;
                        Game.Components.Add(forscience);
                        timeCounter = 0;
                    }
                }
            }



            if (forscience.isActive && apertureascii.isActive == false)
            {
                Handle_and_CheckWeaponCollision(forscience);

                if (forscience.isKilled)
                {
                    timeCounter += gameTime.ElapsedGameTime.TotalMilliseconds;

                    if (timeCounter > 1000)
                    {
                        apertureascii.isActive = true;
                        Game.Components.Add(apertureascii);
                        timeCounter = 0;

                        apertureascii.velocity = new Vector2(5,0);
                        apertureascii.friction = 0;
                        apertureascii.speed = 1;
                        apertureascii.isUnFading = true;
                        apertureascii.customRGBA = 20;
                        apertureascii.colorLerp.R = (byte)apertureascii.customRGBA;
                        apertureascii.colorLerp.G = (byte)apertureascii.customRGBA;
                        apertureascii.colorLerp.B = (byte)apertureascii.customRGBA;
                        apertureascii.colorLerp.A = (byte)apertureascii.customRGBA;

                        apertureascii.rotation = -0.001f;     
                        
                        
                    }
                }
            }


            if (apertureascii.isActive && apertureascii.isKilled == false)
            {

                if (apertureascii.IsInsideScreen(apertureascii.texture))
                {

                    
                    apertureascii.isWallBouncing = true;             
                    apertureascii.rotation += totalAngularVelocity;
                    mainPlayer.activeTextureID = 9;

                    if (apertureascii.customRGBA > 200)
                    {
                        mainPlayer.activeTextureID = 10;
                    }

                    Handle_and_CheckWeaponCollisionLightUp(apertureascii, gameTime);
         
                }

            }

            if (apertureascii.isKilled)
            {
                isCompleted = true;

            }

            if (forscience.isAlive == false)
            {
                Game.Components.Remove(canyouseemeTitle);
                canyouseemeTitle.Dispose();

                Game.Components.Remove(IPreadytolearnTitle);
                IPreadytolearnTitle.Dispose();

                Game.Components.Remove(keepafloat);
                keepafloat.Dispose();


                Game.Components.Remove(letsstartthelearning);
                letsstartthelearning.Dispose();


                Game.Components.Remove(lvl2warning1);
                lvl2warning1.Dispose();

                Game.Components.Remove(forscience);
                forscience.Dispose(); 

            }

            PE1.UpdateParticles(PE1.ParticleArray, gameTime, (mainPlayer.position ));

            if (mainPlayer.IsInsideScreen(mainPlayer.textureList[mainPlayer.activeTextureID]) == false)
            {
                mainPlayer.position = new Vector2(Game1.screenWidth / 2, Game1.screenHeight - 100);

            }


            base.Update(gameTime);

        }

        


        public override void Draw(GameTime gameTime)
        {

            //  spriteBatch.Draw stuff here

            //spriteBatch.DrawString(spriteFont1, "test2", new Vector2(400, 0), Color.Green);

            PE1.DrawExplosion(PE1.ParticleArray, spriteBatch, gameTime);


            base.Draw(gameTime);
        }


        public void Handle_and_CheckWeaponCollision(TitleObject gameObject)
        {
            if (gameObject.isAlive)
            {
                foreach (KeyValuePair<int, WeaponObject[]> entry in mainPlayer.weaponDict)
                {
                    foreach (WeaponObject w in entry.Value)
                    {
                        if (w.isAlive && w.isSolid)
                        {
                            if (gameObject.CheckCollision(w.position, w.texture.Width, w.texture.Height))
                            {
                                w.isAlive = false;
                                gameObject.HP--;
                                if (gameObject.HP == 0)
                                {
                                   // Game.Components.Remove(gameObject);
                                  //  gameObject.Dispose();
                                }
                            }
                        }
                    }
                }
            }
        }


        public void Handle_and_CheckWeaponCollisionLightUp(GameObject gameObject,GameTime gameTime)
        {
            if (gameObject.isAlive)
            {
                foreach (KeyValuePair<int, WeaponObject[]> entry in mainPlayer.weaponDict)
                {
                    foreach (WeaponObject w in entry.Value)
                    {
                        if (w.isAlive && w.isSolid)
                        {
                            if (gameObject.CheckCollision(w.position, w.texture.Width, w.texture.Height))
                            {
                                w.isAlive = false;

                                gameObject.customRGBA += 3;
                                gameObject.rotation -= 0.003f;
                                totalAngularVelocity -= 0.003f;


                                if (gameObject.customRGBA > 254)
                                {

                                    PE1.AddExplosion(PE1.ParticleArray, PE1.MaxParticles, gameObject.position, PE1.ExplosionSize, gameTime, w.velocity);
                                    mainPlayer.activeTextureID = 11;
                                    gameObject.isAlive = false;
                                    gameObject.isKilled = true;
                                    Game.Components.Remove(gameObject);
                                    gameObject.Dispose();
                                }
                            }

                        }
                    }
                }
            }
        }




    }






}
