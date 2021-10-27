using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Util;

namespace AlienInvaders
{
    /// <summary>
    /// This class handles the inputs the player makes.
    /// The player uses the left and right arrow keys to move the spaceship.
    /// The player presses the space bar to fire the projectile.
    /// When prompted to a specific game sreen, the player presses enter to restart.
    /// </summary>
    public class PlayerInput : DrawableGameComponent
    {
        SpriteBatch sb;
        Texture2D spaceship;
        Rectangle rectspaceship;


        public PlayerInput(Game game) : base(game)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// This method loads in the enemies and the player
        /// The enemies are in rows and columns and move back and forth
        /// </summary>
        protected override void LoadContent()
        {
            sb = new SpriteBatch(this.Game.GraphicsDevice);
            spaceship = this.Game.Content.Load<Texture2D>("spaceship");
            rectspaceship.Width = spaceship.Width;
            rectspaceship.Height = spaceship.Height;
            rectspaceship.X = 0;
            rectspaceship.Y = 400;
            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {
            KeyboardState kb = Keyboard.GetState();
            for (int r = 0; r < AliensandSpaceship.rows; r++)
            {
                for (int c = 0; c < AliensandSpaceship.cols; c++)
                {
                    if (AliensandSpaceship.invaderalive[r, c].Equals(true))
                    {
                        if (AliensandSpaceship.rectinvader[r, c].Y + AliensandSpaceship.rectinvader[r, c].Height > rectspaceship.Y)
                        {
                            AliensandSpaceship.rows = 0;
                            AliensandSpaceship.cols = 0;
                            ScoreManager.Lives--;
                            GameStates.intGameState = 1;
                            
                        }
                    }
                }
            }
            if (kb.IsKeyDown(Keys.Left))
            {
                rectspaceship.X = rectspaceship.X - 3;
            }

            if (kb.IsKeyDown(Keys.Right))
            {
                rectspaceship.X = rectspaceship.X + 3;
            }
            if (kb.IsKeyDown(Keys.Space) && Projectile.ProjectileVisible.Equals(false))
            {
                Projectile.ProjectileVisible = true;
                Projectile.rectprojectile.X = rectspaceship.X + (rectspaceship.Width / 2) - (Projectile.rectprojectile.Width / 2);
                Projectile.rectprojectile.Y = rectspaceship.Y - Projectile.rectprojectile.Height + 2;
            }
            if (Projectile.ProjectileVisible.Equals(true))
            {
                Projectile.rectprojectile.Y = Projectile.rectprojectile.Y - 5;
            }
            if (Projectile.ProjectileVisible.Equals(true))
            {
                for (int r = 0; r < AliensandSpaceship.rows; r++)
                {
                    for (int c = 0; c < AliensandSpaceship.cols; c++)
                    {
                        if (AliensandSpaceship.invaderalive[r, c].Equals(true))
                        {
                            if (Projectile.rectprojectile.Intersects(AliensandSpaceship.rectinvader[r, c]))
                            {
                                Projectile.ProjectileVisible = false;
                                AliensandSpaceship.invaderalive[r, c] = false;
                                ScoreManager.Score++;
                            }
                        }
                    }
                }
            }
            if (ScoreManager.Score == 50)
            {
                GameStates.intGameState = 2;
                if (GameStates.intGameState == 2 && kb.IsKeyDown(Keys.Enter))
                {
                    GameStates.intGameState = 0;
                    ScoreManager.Score = 0;
                    ScoreManager.Lives = 1;
                    Timer.time = 0;
                    ScoreManager.maxTimeRun = false;
                    AliensandSpaceship.rows = 5;
                    AliensandSpaceship.cols = 10;
                    AliensandSpaceship.invaderspeed = 3;
                    for (int r = 0; r < AliensandSpaceship.rows; r++)
                    {
                        for (int c = 0; c < AliensandSpaceship.cols; c++)
                        {
                            AliensandSpaceship.rectinvader[r, c].Width = AliensandSpaceship.invader.Width;
                            AliensandSpaceship.rectinvader[r, c].Height = AliensandSpaceship.invader.Height;
                            AliensandSpaceship.rectinvader[r, c].X = 60 * c;
                            AliensandSpaceship.rectinvader[r, c].Y = 60 * r;
                            AliensandSpaceship.invaderalive[r, c] = true;
                        }
                    }
                    rectspaceship.Width = spaceship.Width;
                    rectspaceship.Height = spaceship.Height;
                    rectspaceship.X = 0;
                    rectspaceship.Y = 400;
                    Projectile.rectprojectile.Width = Projectile.projectile.Width;
                    Projectile.rectprojectile.Height = Projectile.projectile.Height;
                    Projectile.rectprojectile.X = 0;
                    Projectile.rectprojectile.Y = 0;
                }
            }
            if (Projectile.rectprojectile.Y + Projectile.rectprojectile.Height < 0)
            {
                Projectile.ProjectileVisible = false;
            }
            if (GameStates.intGameState == 1 && kb.IsKeyDown(Keys.Enter))
            {
                GameStates.intGameState = 0;
                ScoreManager.Score = 0;
                ScoreManager.Lives = 1;
                Timer.time = 0;
                ScoreManager.maxTimeRun = false;
                AliensandSpaceship.rows = 5;
                AliensandSpaceship.cols = 10;
                AliensandSpaceship.invaderspeed = 3;
                for (int r = 0; r < AliensandSpaceship.rows; r++)
                {
                    for (int c = 0; c < AliensandSpaceship.cols; c++)
                    {
                        AliensandSpaceship.rectinvader[r, c].Width = AliensandSpaceship.invader.Width;
                        AliensandSpaceship.rectinvader[r, c].Height = AliensandSpaceship.invader.Height;
                        AliensandSpaceship.rectinvader[r, c].X = 60 * c;
                        AliensandSpaceship.rectinvader[r, c].Y = 60 * r;
                        AliensandSpaceship.invaderalive[r, c] = true;
                    }
                }
                rectspaceship.Width = spaceship.Width;
                rectspaceship.Height = spaceship.Height;
                rectspaceship.X = 0;
                rectspaceship.Y = 400;
                Projectile.rectprojectile.Width = Projectile.projectile.Width;
                Projectile.rectprojectile.Height = Projectile.projectile.Height;
                Projectile.rectprojectile.X = 0;
                Projectile.rectprojectile.Y = 0;

            }

            
            base.Update(gametime);
        }
        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            sb.Draw(spaceship, rectspaceship, Color.White);
            sb.End();
            base.Draw(gameTime);
        }
    }
}
