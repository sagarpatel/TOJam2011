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
        public EnemyObject[] enemies3;
        public EnemyObject[] enemies4;
        public EnemyObject[] enemies5;

        public EnemyObject[] enemies6;

        public int maxenemies;

        bool isat8secSpawed;
        bool isat14secSpawed;

        bool is30secSpawned;
        bool is47secSpawned;
        bool is62Spawned;
        bool is76Spawned;

        int enemycounter;

        bool isWin;
        bool isLose;

        Texture2D soph;

        Texture2D winTex;
        Texture2D loseTex1;
        Texture2D loseTex2;

        int timeCounter;
        
        public FeynmanObject(Game game, SpriteBatch sB):base(game,sB)
        {
            winTex = Game.Content.Load<Texture2D>("Sprites/win");
            loseTex1 = Game.Content.Load<Texture2D>("Sprites/yldfdV2");
            loseTex2 = Game.Content.Load<Texture2D>("Sprites/dissV1");

            timeCounter = 0;


            isAlive = true;
            isKilled = false;
            isat8secSpawed = false;
            isat14secSpawed = false;

            is30secSpawned = false;
            is47secSpawned = false;
            is62Spawned = false;
            is76Spawned = false;

            enemycounter = 0;

            isWin = false;
            isLose = false;

            feynmanVid = Game.Content.Load<Video>("Videos/F1v3");
            videoPlayer = new VideoPlayer();

            timeSpan = new TimeSpan();


            maxenemies = 30;

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

            enemies3 = new EnemyObject[30];
            for (int i = 0; i < 30; i++)
            {
                enemies3[i] = new EnemyObject(game, sB, Game.Content.Load<Texture2D>("Sprites/Enemies/exploringV1"));
                enemies3[i].isWallBouncing = true;
                Game.Components.Add(enemies3[i]);
            }

            enemies4 = new EnemyObject[50];
            for (int i = 0; i < 50; i++)
            {
                enemies4[i] = new EnemyObject(game, sB, Game.Content.Load<Texture2D>("Sprites/Enemies/onionsV1"));
                enemies4[i].isWallBouncing = true;
                Game.Components.Add(enemies4[i]);
            }

            enemies5 = new EnemyObject[20];
            for (int i = 0; i < 20; i++)
            {
                enemies5[i] = new EnemyObject(game, sB, Game.Content.Load<Texture2D>("Sprites/Enemies/fomaiV2"));
                enemies5[i].isWallBouncing = true;
                Game.Components.Add(enemies5[i]);
            }


            enemies6 = new EnemyObject[20];
            for (int i = 0; i < 20; i++)
            {
                enemies6[i] = new EnemyObject(game, sB, Game.Content.Load<Texture2D>("Sprites/Enemies/ymbwV1"));
                enemies6[i].isWallBouncing = true;
                Game.Components.Add(enemies6[i]);
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
                        enemy.velocity = GenerateRandomVelocity(enemycounter);
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
                        enemy.velocity = GenerateRandomVelocity(enemycounter);
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


            ///exploring

            if (timeSpan > TimeSpan.FromSeconds(30) && is30secSpawned == false)
            {
                foreach (EnemyObject enemy in enemies3)
                {
                    if (enemy.isAlive == false)
                    {
                        enemy.isAlive = true;
                        enemy.velocity = 10 * GenerateRandomVelocity(enemycounter);
                        enemy.position = position;
                        enemycounter++;
                        //break;
                    }
                }

                is30secSpawned = true;
            }


            ///onions

            if (timeSpan > TimeSpan.FromSeconds(47) && is47secSpawned == false)
            {
                foreach (EnemyObject enemy in enemies4)
                {
                    if (enemy.isAlive == false)
                    {
                        enemy.isAlive = true;
                        enemy.velocity = GenerateRandomVelocity(enemycounter);
                        enemy.position = position;
                        enemycounter++;
                        //break;
                    }
                }

                is47secSpawned = true;
            }



            ///find out more about it

            if (timeSpan > TimeSpan.FromSeconds(62) && is62Spawned == false)
            {
                foreach (EnemyObject enemy in enemies5)
                {
                    if (enemy.isAlive == false)
                    {
                        enemy.isAlive = true;
                        enemy.velocity = GenerateRandomVelocity(enemycounter);
                        enemy.position = position;
                        enemycounter++;
                        //break;
                    }
                }

                is62Spawned = true;
            }


            if (timeSpan > TimeSpan.FromSeconds(76) && is76Spawned == false)
            {
                foreach (EnemyObject enemy in enemies6)
                {
                    if (enemy.isAlive == false)
                    {
                        enemy.isAlive = true;
                        enemy.velocity = GenerateRandomVelocity(enemycounter);
                        enemy.position = position;
                        enemycounter++;
                        //break;
                    }
                }

                is76Spawned = true;
            }





            



            if (isWallBouncing)
            {
                texture = videoPlayer.GetTexture();
                WallBounce(texture);
            }

            if (this.position.Y - texture.Height/2 < 10)
                this.position.Y = 20 + texture.Height/2;

            UpdatePV();


            if (this.position.Y > Game1.screenHeight)
            {
                isLose = true;
                videoPlayer.Stop();
            }


            if (timeSpan > TimeSpan.FromSeconds(90))
            {

                videoPlayer.Stop();
                isWin = true;
                isLose = false;
            }

            if (isWin || isLose)
            {

                foreach (EnemyObject enemy in enemies1)
                {
                    enemy.isAlive = false;
                    Game.Components.Remove(enemy);
                }
                foreach (EnemyObject enemy in enemies2)
                {
                    enemy.isAlive = false;
                    Game.Components.Remove(enemy);
                }
                foreach (EnemyObject enemy in enemies3)
                {
                    enemy.isAlive = false;
                    Game.Components.Remove(enemy);
                }
                foreach (EnemyObject enemy in enemies4)
                {
                    enemy.isAlive = false;
                    Game.Components.Remove(enemy);

                }
                foreach (EnemyObject enemy in enemies5)
                {
                    enemy.isAlive = false;
                    Game.Components.Remove(enemy);
                }
                foreach (EnemyObject enemy in enemies6)
                {
                    enemy.isAlive = false;
                    Game.Components.Remove(enemy);
                }

            }
            

            base.Update(gameTime);

        }




        public override void Draw(GameTime gameTime)
        {

            // spriteBatch.Draw(texture, position, Color.White);
            if (isWin == false && isLose == false)
            {
                texture = videoPlayer.GetTexture();
                spriteBatch.Draw(texture, position, null, Color.White, rotation, new Vector2(texture.Width / 2, texture.Height / 2), scale, SpriteEffects.None, 0);
            }

            if (isWin)
            {
                GraphicsDevice.Clear(Color.Black);
                spriteBatch.Draw(winTex, new Vector2(200, 100), Color.White);
            //    System.Threading.Thread.Sleep(3000);
                timeCounter += gameTime.ElapsedGameTime.Milliseconds;
                if(timeCounter > 4000)
                    Game.Exit();
            }
            else if (isLose)
            {
                GraphicsDevice.Clear(Color.Black);
                spriteBatch.Draw(loseTex1, new Vector2(20, 100), Color.White);
           //     System.Threading.Thread.Sleep(2000);
                if (timeCounter > 3000)
                    spriteBatch.Draw(loseTex2, new Vector2(40, 300), Color.White);
           //     System.Threading.Thread.Sleep(3000);

                timeCounter += gameTime.ElapsedGameTime.Milliseconds;
                if (timeCounter > 6000)
                    Game.Exit();

            }

            
            base.Draw(gameTime);
        }


        public Vector2 GenerateRandomVelocity(int seed)
        {

            float baseSpeed = 2f;

            Random rand = new Random(seed);

            float x = baseSpeed * (float)Math.Cos(2 * Math.PI * rand.NextDouble());
            float y = baseSpeed * (float)Math.Sin(2 * Math.PI * rand.NextDouble());

            Vector2 vel = new Vector2(x, y);
            return vel;

        }



        


    }






}
