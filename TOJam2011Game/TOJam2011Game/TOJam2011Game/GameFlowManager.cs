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


    public class GameFlowManager: Microsoft.Xna.Framework.DrawableGameComponent
    {
        public static PlayerObject player1;
        public Level1Screen level1Screen;
        public Level2Screen level2Screen;



        public GameFlowManager(Game game, SpriteBatch sB):base(game)
        {
            player1 = new PlayerObject(game, sB);
            level1Screen = new Level1Screen(game, sB);
            level2Screen = new Level2Screen(game, sB);

        }





        public override void Initialize()
        {
            level1Screen.isActive = true;
            level2Screen.isActive = false;

            player1.position = new Vector2(-200, 600);
      

            Game.Components.Add(player1);
            Game.Components.Add(level1Screen);


            base.Initialize();
        }




        protected override void LoadContent()
        {
            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }







        public override void Update(GameTime gameTime)
        {
            //basic level flow
            // assuming level1 is already active
            if (level1Screen.isCompleted == true && level2Screen.isActive == false)
            {
                //kill the level
                level1Screen.isActive = false;
                Game.Components.Remove(level1Screen);
                level1Screen.Dispose();
          
                //Put next level
                level2Screen.isActive = true;
                level2Screen.isCompleted = false;
                Game.Components.Add(level2Screen);

            }


            base.Update(gameTime);
        }




        //There should be nothing to draw
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

        }










    }





}
