using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace UGWProject
{
    class Player:Character
    {
        //attributes
        private int memsColl;//Memories collected by the player
        private int moveSpd;//player speed default;
        private int spdWithBlock;//the speed of the player while moving the block
        KeyboardState kboardstate;//getting the keyboard state;
        KeyboardState prevKeyPressed; //takes the previous key that was pressed
        private bool hasJumped; //will set it so that the player can not constantly jump
        private Vector2 velocity;//the velcotiy of the player jumping/falling
        protected Vector2 playerPos; //the position in relation to the rectangle so it can jump;
        //the x and y to parse float to int and use for x and y in rectangle
        private int xPosV;
        private int yPosV;

        //properties
        public int MemsColl
        {
            get { return memsColl; }
            set { memsColl = value; }
        }

        public int MoveSpeed
        {
            get { return moveSpd; }
            set { moveSpd = value; }
        }

        public int SpeedWithBlock
        {
            get { return spdWithBlock; }
            set { spdWithBlock = value; }
        }

        public bool HasJumped
        {
            get { return hasJumped; }
        }

        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value ; }
        }

        public Vector2 PlayerPos
        {
            get { return playerPos; }
            set { playerPos = value; }
        }

        //constructor
        public Player(Rectangle playrect, Texture2D playtext):base(false, playrect,playtext)
        {
            hasJumped = false; //default, no jump
            playerPos = new Vector2(this.ObjRect.X, this.ObjRect.Y);//setting the position equal to the vector
            

        }




        //overrides move method to be specific to character
        override public void Move()
        {
            //takes the first key pressed in a returned array of keys
            kboardstate = new KeyboardState();
            //Keys[] keyarray = kboardstate.GetPressedKeys();
            //going to add aplayer enum later in
            if (IsDead == false)
            {

                playerPos += velocity;
                //this.ObjRect = new Rectangle( ) 
                if (kboardstate.IsKeyDown(Keys.Escape))
                {
                    //pause menu
                }
                else if (kboardstate.IsKeyDown(Keys.A))
                {
                    
                ObjRect = new Rectangle(ObjRect.X - moveSpd, ObjRect.Y, ObjRect.Width, ObjRect.Height);
                playerPos = new Vector2(this.ObjRect.X, this.ObjRect.Y);
                } 
                else if(kboardstate.IsKeyDown(Keys.F) && prevKeyPressed.IsKeyUp(Keys.D))
                {
                    //pushing/pulling the block from the right side.
                }  
                else if(kboardstate.IsKeyDown(Keys.D))
                {
                    ObjRect = new Rectangle(ObjRect.X + moveSpd, ObjRect.Y, ObjRect.Width, ObjRect.Height);
                    playerPos = new Vector2(this.ObjRect.X, this.ObjRect.Y);
                }
                else if (kboardstate.IsKeyDown(Keys.F) && prevKeyPressed.IsKeyUp(Keys.A))
                {
                    //pushing/pulling from the left side of the block
                }
                //Gravity and jumping v
                if (kboardstate.IsKeyDown(Keys.Space) && hasJumped == false)        
                {
                    //jumping
                        
                    playerPos.Y += 10f;
                    velocity.Y += -5f;
                    hasJumped = true;
                    ObjRect = new Rectangle((int)playerPos.X, (int)playerPos.Y, ObjRect.Width, ObjRect.Height);        
                }
                    if(hasJumped == true)
                    {
                        //gravity
                        float i = 1;
                        velocity.Y += 0.2f * i;
                    }
                    if (hasJumped ==false)                   
                    {
                        velocity.Y = 0f;
                        //need to make hasjumped = false in the collision method
                    }
      
                prevKeyPressed = kboardstate;
            }
            
        }
  



    }
}
