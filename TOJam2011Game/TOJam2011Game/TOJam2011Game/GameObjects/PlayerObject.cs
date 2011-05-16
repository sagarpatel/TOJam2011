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

        public Vector2 velocity_weapon1;
        public Vector2 velocity_weapon2;

        public InputHandler inputHandler;

        public Dictionary<int, WeaponObject[]> weaponDict;

        public int fireRate_weapon1;
        public int fireRate_weapon2;

        public bool isControllable;
        public bool isMoveable;

        public int APressedCount;

        public int activeTextureID;

        public List<Texture2D> textureList;

        SoundEffect weapon_sound1;
        
       

        public PlayerObject(Game game, SpriteBatch sB): base(game, sB)
        {
            isControllable = true;
            isMoveable = true;
            APressedCount = 0;

            //position = new Vector2(10, 10);
            speed = 2f;
            friction = 0.15f;
            maxcount_weapon1 = 10;
            maxcount_weapon2 = 20;
            //Higher number, slower the rate
            fireRate_weapon1 = 300;
            fireRate_weapon2 = 100;

            velocity_weapon1 = new Vector2(0,-10);
            velocity_weapon2 = new Vector2(0,-20);

            activeTextureID = 0;

            weapon1 = new WeaponObject[maxcount_weapon1];
            for (int i = 0; i < maxcount_weapon1; i++)
            {
                weapon1[i] = new WeaponObject(game, sB, Game.Content.Load<Texture2D>("Sprites/Player/mainWeaponV1"));
                weapon1[i].velocity = velocity_weapon1;
                weapon1[i].fireRate = fireRate_weapon1;
                Game.Components.Add(weapon1[i]);
            }


            weapon2 = new WeaponObject[maxcount_weapon2];
            for (int i = 0; i < maxcount_weapon2; i++)
            {
                weapon2[i] = new WeaponObject(game, sB, Game.Content.Load<Texture2D>("Sprites/Player/mainWeaponV1"));
                weapon2[i].velocity = velocity_weapon2;
                weapon2[i].fireRate = fireRate_weapon2;
                Game.Components.Add(weapon2[i]);
                
            }

            weaponDict = new Dictionary<int,WeaponObject[]>();

            weaponDict.Add(1, weapon1);
            weaponDict.Add(2, weapon2);

            textureList = new List<Texture2D>();
            textureList.Add(Game.Content.Load<Texture2D>("Sprites/Player/ChromiumLogoV2")); //element 0
            textureList.Add(Game.Content.Load<Texture2D>("Sprites/Player/heyouV1"));
            textureList.Add(Game.Content.Load<Texture2D>("Sprites/Player/ouch"));
            textureList.Add(Game.Content.Load<Texture2D>("Sprites/Player/hit_a"));
            textureList.Add(Game.Content.Load<Texture2D>("Sprites/Player/pewpew"));
            textureList.Add(Game.Content.Load<Texture2D>("Sprites/Player/moveme")); //element 5
            textureList.Add(Game.Content.Load<Texture2D>("Sprites/Player/goodjob"));
            textureList.Add(Game.Content.Load<Texture2D>("Sprites/Player/nextlvl")); //element 7
            textureList.Add(Game.Content.Load<Texture2D>("Sprites/Player/smileyfaceV1"));
            textureList.Add(Game.Content.Load<Texture2D>("Sprites/Player/shiftyface"));//element9
            textureList.Add(Game.Content.Load<Texture2D>("Sprites/Player/OOOface"));//element10
            textureList.Add(Game.Content.Load<Texture2D>("Sprites/Player/polegoatFace"));//element11

            //Sounds from soundjay.com and flashkit.com
            weapon_sound1 = Game.Content.Load<SoundEffect>("SoundEffects/button-4");
            

            // for player2 controls
            inputHandler = new InputHandler(game,1);
            Game.Components.Add(inputHandler);
            
        }


        public override void Initialize()
        {
       
            base.Initialize();
        }



        protected override void LoadContent()
        {


            //texture = Game.Content.Load<Texture2D>("Sprites/ChromiumLogoV2");
            //origin = new Vector2(texture.Width / 2f, texture.Height / 2f);

          //  position = new Vector2(200, 100);


                     
            //base.LoadContent();
        }


        public override void Update(GameTime gameTime)
        {
            // Player Update Code Here
            if (isControllable)
            {
                Controls(gameTime);
            }

            if (isWallBouncing)
            {
                WallBounce(textureList[activeTextureID]);
            }

            UpdatePV();

 

            base.Update(gameTime);

        }




        public override void Draw(GameTime gameTime)
        {
            Texture2D textureToDraw = textureList[activeTextureID];

            spriteBatch.Draw(textureToDraw, position, null, Color.White, rotation, new Vector2(textureToDraw.Width / 2, textureToDraw.Height / 2), scale, SpriteEffects.None, 0);



            base.Draw(gameTime);
        }




        ///Non Drawablecomponents functions
        ///

        protected override void UpdatePV()
        {
            velocity = velocity * (1f - friction);
            position += speed * velocity;

            base.UpdatePV();
        }




        public void FireWeapon(int weaponID,GameTime gameTime)
        {

       
            foreach (KeyValuePair<int, WeaponObject[]> entry in weaponDict)
            {
                //Slect right weapon
                if (entry.Key == weaponID)
                {
                    foreach (WeaponObject w in entry.Value)
                    {
                        if ((int)gameTime.TotalGameTime.TotalMilliseconds % w.fireRate == 0)
                        {
                            if (w.isAlive == false)
                            {
                                w.isAlive = true;
                                w.position = position;
                                APressedCount += 1;

                                SoundEffect.MasterVolume = 0.002f;
                                weapon_sound1.Play();

                                break;
                            }
                        }
                    }
                }
            }
            


        }


        public void Controls(GameTime gameTime)
        {
            //Button inputs

            KeyboardState keybState = Keyboard.GetState();

            if (inputHandler.gamepadState.Buttons.X == ButtonState.Pressed)
            {
                FireWeapon(1, gameTime);
            }

            if (inputHandler.gamepadState.Buttons.A == ButtonState.Pressed)
            {
                FireWeapon(2, gameTime);
                
            }

            if (keybState.IsKeyDown(Keys.A))
            {
                FireWeapon(2, gameTime);
            }



            if (isMoveable)
            {
                ///PV
                ///
                float speed = 1f;
                velocity.X += inputHandler.gamepadState.ThumbSticks.Left.X;
                velocity.Y -= inputHandler.gamepadState.ThumbSticks.Left.Y;

                if (keybState.IsKeyDown(Keys.Left))
                {
                    velocity.X -= speed;
                }
                if (keybState.IsKeyDown(Keys.Right))
                {
                    velocity.X += speed;
                }

                if (keybState.IsKeyDown(Keys.Up))
                {
                    velocity.Y -= speed;
                }
                if (keybState.IsKeyDown(Keys.Down))
                {
                    velocity.Y += speed;
                }




            }

        }



    }


}
