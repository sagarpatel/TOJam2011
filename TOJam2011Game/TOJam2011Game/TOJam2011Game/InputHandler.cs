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


    public class InputHandler:Microsoft.Xna.Framework.GameComponent
    {

        public GamePadState gamepadState;
        public PlayerIndex playerIndex;

       



        public InputHandler(Game game,int pIndex):base(game)
        {

            //Set which controler we are handling

            switch (pIndex)
            {
                case(1):
                    playerIndex = PlayerIndex.One;
                    break;

                case(2):
                    playerIndex = PlayerIndex.Two;
                    break;

                case(3):
                    playerIndex = PlayerIndex.Three;
                    break;

                case(4):
                    playerIndex = PlayerIndex.Four;
                    break;

                default:
                    break;
                    
            }


            
        }




        public override void Update(GameTime gameTime)
        {

            gamepadState = GamePad.GetState(playerIndex);




            base.Update(gameTime);
        }









    }





}
