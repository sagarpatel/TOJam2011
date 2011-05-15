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


    public class Level3Screen:ScreenObject
    {
        PlayerObject mainPlayer;
        SpriteFont spriteFont1;
        double timeCounter;

        float totalAngularVelocity;

        ParticleEngine PE1;

        FeynmanObject feynmanLecture;

        float gravity;
        float bulletPush;

        public Level3Screen(Game game, SpriteBatch sB): base(game, sB)
        {
            isActive = true;
            isCompleted = false;
            timeCounter = 0;

            mainPlayer = GameFlowManager.player1;

            PE1 = new ParticleEngine(sB, Game.Content.Load<Texture2D>("Sprites/goatV1"), 2);
            PE1.MaxParticles = 100;

            spriteFont1 = Game.Content.Load<SpriteFont>("Fonts/SF1");

            feynmanLecture = new FeynmanObject(game, sB);
            feynmanLecture.position = new Vector2(400, 150);

            gravity = 1f;
            bulletPush = 10f;
            
        }

        public override void Initialize()
        {

            feynmanLecture.videoPlayer.Play(feynmanLecture.feynmanVid);
            feynmanLecture.videoPlayer.GetTexture();
            feynmanLecture.velocity = new Vector2(5, 0);
            feynmanLecture.speed = 1f;
            feynmanLecture.friction = 0;
            feynmanLecture.isWallBouncing = true;
            Game.Components.Add(feynmanLecture);
            
            base.Initialize();
        }



        public override void Update(GameTime gameTime)
        {

            feynmanLecture.position.Y += gravity;

            Handle_and_CheckWeaponCollisionFeynman(feynmanLecture);

            foreach (EnemyObject e in feynmanLecture.enemies1)
            {
                Handle_and_CheckWeaponCollision(e);

            }

            base.Update(gameTime);
        }



        public override void Draw(GameTime gameTime)
        {

            //  spriteBatch.Draw stuff here

            spriteBatch.DrawString(spriteFont1, "test3", new Vector2(500, 0), Color.Green);

            PE1.DrawExplosion(PE1.ParticleArray, spriteBatch, gameTime);


            base.Draw(gameTime);
        }





        public void Handle_and_CheckWeaponCollisionFeynman(GameObject gameObject)
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
                                gameObject.position.Y -= bulletPush;
                               
                            }
                        }
                    }
                }
            }
        }



        public void Handle_and_CheckWeaponCollision(GameObject gameObject)
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
