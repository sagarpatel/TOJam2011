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

        public WeaponObject[] weapon1;
        public WeaponObject[] weapon2;

        public int maxcount_weapon1;
        public int maxcount_weapon2;

        public InputHandler inputHandler;


        public PlayerObject(Game game, SpriteBatch sB): base(game, sB)
        {
            position = new Vector2(10, 10);
            speed = 1f;
            friction = 0.1f;
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


            // for player2 controls
            inputHandler = new InputHandler(game,1);
            Game.Components.Add(inputHandler);
            
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

            velocity.X += inputHandler.gamepadState.ThumbSticks.Left.X;
            UpdatePV();

            base.Update(gameTime);

            

        }




        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Draw(texture, position, Color.White);


            base.Draw(gameTime);
        }




        ///Non Drawablecomponents functions
        ///

        protected override void UpdatePV()
        {

            position += speed *velocity * (1f - friction);

            base.UpdatePV();
        }



    }


}
