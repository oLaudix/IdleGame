using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace IdleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a game that's 160 x 120
            var game = new Game("Spritemap Animation", 1200, 700);
            // Set the window scale to 3x to see the sprite better.
            game.SetWindowScale(1f);
            // Set the background color to a bluish hue.
            game.Color = new Color(0.3f, 0.5f, 0.7f);

            // Create a scene.
            var scene = new Scene();
            // Add the animating entity to the scene.
            scene.Add(new AnimatingEntity(game.HalfWidth, game.HalfHeight));
            scene.Add(new AnimatingEntity(game.HalfWidth+20, game.HalfHeight+20));
            Player player = new Player(1, 2);
            //player.gearList[10].UpgradeGear();
            player.StartStage();
            while (true)
            {
                player.Attack(1);
                Console.Clear();
                Console.WriteLine("Stage(" + player.stage + "): " + player.currentStage.CurrentHP + "/" + player.currentStage.MaxHP);
                Console.WriteLine("Prize: " + player.currentStage.Prize);
                Console.WriteLine("Stage Kills: " + player.currentStage.Kills);
                Console.WriteLine("Damage: " + player.GetTotalDps());
                Console.WriteLine("Gold: " + player.gold);
                System.Threading.Thread.Sleep(10);
            }

            // Start the game with the scene that was just created.
            game.MouseVisible = true;
            game.Start(scene);
        }
    }

    class AnimatingEntity : Entity
    {
        // Set up an enum to use for the four different animations.
        enum Animation
        {
            WalkUp,
            WalkDown,
            WalkLeft,
            WalkRight,
            PlayOnce,
            PingPong,
            Death,
            Idle,
            WeaponOut,
            Shoot
        }

        // Create the Spritemap to use. Use Sprite.png as the texture, and define the cell size as 32 x 32.
        //Spritemap<Animation> spritemap = new Spritemap<Animation>("enemy_animations.png", 88, 68);
        //Spritemap<Animation> spritemap = new Spritemap<Animation>("iron_iso.png", 148, 78);
        //Spritemap<Animation> spritemap = new Spritemap<Animation>("heavy_turret.png", 106, 56);
        //Spritemap<Animation> spritemap = new Spritemap<Animation>("plane.png", 86, 77);
        //Spritemap<Animation> spritemap = new Spritemap<Animation>("dicokka.png", 124, 76);
        Spritemap<Animation> spritemap = new Spritemap<Animation>("rocket.png", 124, 110);
        public AnimatingEntity(float x, float y) : base(x, y)
        {
            // Add the animation data for the PlayOnce test.
            spritemap.Add(Animation.Idle, "0", 3);
            //spritemap.Add(Animation.Death, "0,1,2,3,4,5,6,7,0,1,2,3,4,5,6,7,0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,31", 4);
            //spritemap.Add(Animation.WalkRight, "41,42,43,44,45,46,47,48,49,50,51,52", 4);
            //spritemap.Add(Animation.WeaponOut, "33,34,35,36,37,38,39,40", 4);
            //spritemap.Add(Animation.Shoot, "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17", 4);
            //spritemap.Add(Animation.Shoot, "0,1,2,3,4", 4);
            //spritemap.Add(Animation.Shoot, "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67", 1);
            //spritemap.Add(Animation.Shoot, "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,31,32,33", 2);
            //spritemap.Add(Animation.Shoot, "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16", 4);
            spritemap.Add(Animation.Shoot, "0,1,2,3,4,5,6,7, 8,9,10,8,9,10,8,9,10,8,9,10,8,9,10,8,9,10,8,9,10,8,9,10,8,9,10,8,9,10, 11,12,13,14,15,16,11,12,13,14,15,16,11,12,13,14,15,16,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26, 27,28,29,30,31,32,33,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,", 4);

            // Center the spritemap's origin.
            spritemap.CenterOrigin();
            // Play the walking down animation immediately.
            spritemap.Play(Animation.Shoot);

            // Add the graphic to the Entity so that it renders.
            //AddGraphic(spritemap);
            AddGraphic(spritemap);
            //AddGraphic(spritemap2);
        }

        public override void Update()
        {
            base.Update();
            //X=X+0.1f;
            if (Input.KeyPressed(Key.Up))
            {
                // Play the walk up animation when the up key is pressed.
                spritemap.Play(Animation.WalkUp);
            }
            if (Input.KeyPressed(Key.Down))
            {
                // Play the walk down animation when the down key is pressed.
                spritemap.Play(Animation.WalkDown);
            }
            if (Input.KeyPressed(Key.V))
            {
                // Play the walk left animation when the left key is pressed.
                spritemap.Play(Animation.Shoot);
            }
            if (Input.KeyPressed(Key.Z))
            {
                // Play the walk right animation when the right key is pressed.
                spritemap.Play(Animation.WeaponOut);
            }
            if (Input.KeyPressed(Key.X))
            {
                // Play the PlayOnce test animation.
                spritemap.Play(Animation.Death);
            }
            if (Input.KeyPressed(Key.C))
            {
                // Play the PingPong test animation.
                spritemap.Play(Animation.WalkRight);
            }
        }
    }
}
