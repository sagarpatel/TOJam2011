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


        EnemyObject enemy1;

        Vector2 itargetPosition;

        public Level1Screen(Game game, SpriteBatch sB): base(game, sB)
        {
            spriteFont1 = Game.Content.Load<SpriteFont>("Fonts/SF1");
            isActive = true;

            itargetPosition = new Vector2(100, 100);

            // set up level content
            enemy1 = new EnemyObject(game, sB, Game.Content.Load<Texture2D>("Sprites/InfinitelyV2"));
            enemy1.position = GenerateRandomPositionOutside();

            Game.Components.Add(enemy1);
            
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

            HandleEnemies();

            enemy1.position.X = MathHelper.Lerp(enemy1.position.X, itargetPosition.X, 0.05f);
            enemy1.position.Y = MathHelper.Lerp(enemy1.position.Y, itargetPosition.Y, 0.05f);

            

            //Level Completion condition
            if (enemy1.isKilled)
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
                        if (enemy1.CheckCollision(w.position, w.texture.Width, w.texture.Height))
                        {
                            w.isAlive = false;
                            enemy1.isAlive = false;
                            enemy1.isKilled = true;
                        }
                    }
                }
            }

            if (enemy1.isKilled == true && enemy1.isAlive == false)
            {
                Game.Components.Remove(enemy1);
                enemy1.Dispose();
            }


        }





    }






}
