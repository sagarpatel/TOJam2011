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




    public abstract class GameObject : Microsoft.Xna.Framework.DrawableGameComponent
    {



        protected SpriteBatch spriteBatch;
        public Texture2D texture;

        public bool isAlive;
        public bool isSolid;

        public int HP;

        public Vector2 position;
        public Vector2 velocity;

        public Vector2 origin;
        public float radius;

        public float speed;
        public float scale;
        public float rotation;
        public float friction;

        public Rectangle rect;

     

        public GameObject(Game game, SpriteBatch sB): base(game)
        {
            spriteBatch = sB;

            isAlive = true;
            isSolid = true;
            position = new Vector2(0, 0);
            velocity = new Vector2(0, 0);

            origin = new Vector2(0, 0);

            scale = 1.0f;

        }



        public override void Initialize()
        {
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
            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {

          //  spriteBatch.Draw(texture, position, null, Color.White, rotation, new Vector2(texture.Width / 2, texture.Height / 2), scale, SpriteEffects.None, 0);

            base.Draw(gameTime);

        }


        public bool CheckCollision(Vector2 otherpos, int W, int H)
        {

            Rectangle myRec = new Rectangle((int)position.X - texture.Width/2, (int)position.Y - texture.Height/2, texture.Width, texture.Height);
            Rectangle otherRec = new Rectangle((int)otherpos.X - W/2, (int)otherpos.Y - H/2, W, H);

            if (myRec.Intersects(otherRec))
                return true;
            else
                return false;


        }


        protected virtual void UpdatePV()
        {

            position += velocity*(1-friction);

        }





    }











}
