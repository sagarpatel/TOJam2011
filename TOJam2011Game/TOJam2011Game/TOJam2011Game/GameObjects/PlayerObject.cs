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



    public class PlayerObject : GameObject
    {

        WeaponObject[] weapon1;
        WeaponObject[] weapon2;

        int maxcount_weapon1;
        int maxcount_weapon2;


        public PlayerObject(Game game, SpriteBatch sB): base(game, sB)
        {
            position = new Vector2(10, 10);

            maxcount_weapon1 = 10;
            maxcount_weapon2 = 20;

            weapon1 = new WeaponObject[maxcount_weapon1];
            for (int i = 0; i < maxcount_weapon1; i++)
            {
                weapon1[i] = new WeaponObject(game, sB, Game.Content.Load<Texture2D>("Sprites/GCLV3"));
             //   Game.Components.Add(weapon1[i]);
            }


            weapon2 = new WeaponObject[maxcount_weapon2];
            for (int i = 0; i < maxcount_weapon2; i++)
            {
                weapon2[i] = new WeaponObject(game, sB, Game.Content.Load<Texture2D>("Sprites/GCLV3"));
              //  Game.Components.Add(weapon2[i]);
                weapon2[i].position = new Vector2(20, 200);
            }

            
        }


        public override void Initialize()
        {

            for (int i = 0; i < maxcount_weapon1; i++)
            {   
                Game.Components.Add(weapon1[i]);
            }


          
            for (int i = 0; i < maxcount_weapon2; i++)
            {
                
                Game.Components.Add(weapon2[i]);
                weapon2[i].position = new Vector2(20, 200);
            }


            base.Initialize();
        }



        protected override void LoadContent()
        {


            texture = Game.Content.Load<Texture2D>("Sprites/GCLV3");
            origin = new Vector2(texture.Width / 2f, texture.Height / 2f);

            position = new Vector2(200, 100);


                     
            //base.LoadContent();
        }


        public override void Update(GameTime gameTime)
        {
            // Player Update Code Here


            base.Update(gameTime);

            

        }




        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Draw(texture, position, Color.White);


            base.Draw(gameTime);
        }




    }


}
