using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Util;

namespace AlienInvaders
{
    /// <summary>
    /// This handles the enemy spaceships that will be loaded in the game.
    /// The aliens will move from right to left and slowly reach the bottom.
    /// When there is less than half of the aliens present, they will speed up.
    /// Aliens will reach the player and result in game over.
    /// </summary>
    public class AliensandSpaceship : DrawableGameComponent
    {
        SpriteBatch sb;
        public static Texture2D invader;
        public static Rectangle[,] rectinvader;
        public static bool[,] invaderalive;
        public static int rows = 5;
        public static int cols = 10;
        public static int invaderspeed = 4;
        public static string Direction = "RIGHT";

        public AliensandSpaceship(Game game) : base(game)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            sb = new SpriteBatch(this.Game.GraphicsDevice);
            invader = this.Game.Content.Load<Texture2D>("invader");
            rectinvader = new Rectangle[rows, cols];
            invaderalive = new bool[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    rectinvader[r, c].Width = invader.Width;
                    rectinvader[r, c].Height = invader.Height;
                    rectinvader[r, c].X = 60 * c;
                    rectinvader[r, c].Y = 60 * r;
                    invaderalive[r, c] = true;
                }
            }
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            int rightside = GraphicsDevice.Viewport.Width;
            int leftside = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (Direction.Equals("RIGHT"))
                        rectinvader[r, c].X = rectinvader[r, c].X + invaderspeed;
                    if (Direction.Equals("LEFT"))
                        rectinvader[r, c].X = rectinvader[r, c].X - invaderspeed;
                }
            }
            string ChangeDirection = "N";
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (invaderalive[r, c].Equals(true))
                    {
                        if (rectinvader[r, c].X + rectinvader[r, c].Width > rightside)
                        {
                            Direction = "LEFT";
                            ChangeDirection = "Y";
                        }

                        if (rectinvader[r, c].X < leftside)
                        {
                            Direction = "RIGHT";
                            ChangeDirection = "Y";
                        }
                    }
                }
            }
            if (ChangeDirection.Equals("Y"))
            {
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        rectinvader[r, c].Y = rectinvader[r, c].Y + 10;
                    }
                }
            }
            int count = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (invaderalive[r, c].Equals(true))
                    {
                        count = count + 1;
                    }
                }
            }
            if (count > (rows * cols / 2))
            {
                invaderspeed = invaderspeed;
            }
            if (count < (rows * cols / 2))
            {
                invaderspeed = 6;
            }
            if (count < (rows * cols / 5))
            {
                invaderspeed = 10;
            }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (invaderalive[r, c].Equals(true))
                    {
                        sb.Draw(invader, rectinvader[r, c], Color.White);
                    }
                }
            }
            sb.End();
            base.Draw(gameTime);
        }
    }
}
