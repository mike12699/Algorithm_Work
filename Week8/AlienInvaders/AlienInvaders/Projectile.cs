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
    /// This class handles the projectile. This is what will hit the enemies.
    /// When the projectile collides with the enemy it will disable both the projectile and alien.
    /// The way this is coded is that the projectile cannot be repeatedly fired.
    /// Only one projectile is visible on the screen at a time.
    /// </summary>

    public class Projectile : DrawableGameComponent
    {
        SpriteBatch sb;
        public static Texture2D projectile;
        public static Rectangle rectprojectile;
        public static bool ProjectileVisible = false;

        public Projectile(Game game) : base(game)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            sb = new SpriteBatch(this.Game.GraphicsDevice);
            projectile = this.Game.Content.Load<Texture2D>("projectile");
            rectprojectile.Width = projectile.Width;
            rectprojectile.Height = projectile.Height;
            rectprojectile.X = 0;
            rectprojectile.Y = 0;
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            if (ProjectileVisible.Equals(true))
            {
                sb.Draw(projectile, rectprojectile, Color.White);
            }
            sb.End();
            base.Draw(gameTime);
        }
    }
}
