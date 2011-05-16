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

        public TimeSpan timeSpan;

        public EnemyObject[] enemies1;
        public EnemyObject[] enemies2;
        

        public int maxenemies;

        bool isat8secSpawed;
        bool isat14secSpawed;

        int enemycounter;

        Texture2D soph;
        
        public FeynmanObject(Game game, SpriteBatch sB):base(game,sB)
        {


            isAlive = true;
            isKilled = false;
            isat8secSpawed = false;
            isat14secSpawed = false;


            enemycounter = 0;

            feynmanVid = Game.Content.Load<Video>("Videos/F1v3");
            videoPlayer = new VideoPlayer();

            timeSpan = new TimeSpan();


            maxenemies = 17;

            enemies1 = new EnemyObject[maxenemies];
            for(int i =0;i<maxenemies;i++)
            {
                enemies1[i] = new EnemyObject(game, sB, Game.Content.Load<Texture2D>("Sprites/Enemies/42V1"));
                enemies1[i].isWallBouncing = true;
                Game.Components.Add(enemies1[i]);
            }

            enemies2 = new EnemyObject[maxenemies];
            for (int i = 0; i < maxenemies; i++)
            {
                enemies2[i] = new EnemyObject(game, sB, Game.Content.Load<Texture2D>("Sprites/Enemies/soph"));
                enemies2[i].isWallBouncing = true;
                Game.Components.Add(enemies2[i]);
            }



        }


        public override void Update(GameTime gameTime)
        {
            // Player Update Code Here
            timeSpan = videoPlayer.PlayPosition;


            if (timeSpan > TimeSpan.FromSeconds(7) && isat8secSpawed== false)
            {
                foreach (EnemyObject enemy in enemies1)
                {
                    if (enemy.isAlive == false)
                    {
                        enemy.isAlive = true;
                        enemy.velocity = GenerateRandomVelocity();
                        enemy.position = position;
                        enemycounter++;
                        break;
                    }
                }

                if (enemycounter == maxenemies)
                {
                    isat8secSpawed = true;


                }
            }

            ///soph

            if (timeSpan > TimeSpan.FromSeconds(14) && isat14secSpawed == false)
            {
                foreach (EnemyObject enemy in enemies2)
                {
                    if (enemy.isAlive == false)
                    {
                        enemy.isAlive = true;
                        enemy.velocity = GenerateRandomVelocity();
                        enemy.position = position;
                        enemycounter++;
                        break;
                    }
                }

                if (enemycounter == maxenemies)
                {
                    isat14secSpawed = true;

    
                }
            }










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


        public Vector2 GenerateRandomVelocity()
        {

            float baseSpeed = 2f;

            Random rand = new Random();

            float x = baseSpeed * (float)Math.Cos(2 * Math.PI * rand.NextDouble());
            float y = baseSpeed * (float)Math.Sin(2 * Math.PI * rand.NextDouble());

            Vector2 vel = new Vector2(x, y);
            return vel;

        }



        


    }






}
