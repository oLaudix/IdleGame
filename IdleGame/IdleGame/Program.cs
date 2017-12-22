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
            var game = new Game("Spritemap Animation", 1920, 1080);
            // Set the window scale to 3x to see the sprite better.
            //game.SetWindowScale(5f);
            game.SetWindowAutoFullscreen(true);
            // Set the background color to a bluish hue.
            game.Color = new Color(0.3f, 0.5f, 0.7f);

            // Create a scene.
            var scene = new MainScene();
        //scene.Add(new Background(0, 0, "background.png"));
        // Add the animating entity to the scene.
        //scene.Add(new AnimatingEntity(game.HalfWidth, game.HalfHeight));
        //scene.Add(new AnimatingEntity(game.HalfWidth+20, game.HalfHeight+20));
        //Player player = new Player(1, 2);
        //player.gearList[10].UpgradeGear();
        //player.StartStage();
        /*while (true)
        {
            player.Attack(1);
            Console.Clear();
            Console.WriteLine("Stage(" + player.stage + "): " + player.currentStage.CurrentHP + "/" + player.currentStage.MaxHP);
            Console.WriteLine("Prize: " + player.currentStage.Prize);
            Console.WriteLine("Stage Kills: " + player.currentStage.Kills);
            Console.WriteLine("Damage: " + player.GetTotalDps());
            Console.WriteLine("Gold: " + player.gold);
            System.Threading.Thread.Sleep(10);
        }*/

        // Start the game with the scene that was just created.
        game.MouseVisible = true;
            game.Start(scene);
        }
    }

    class MainScene : Scene
    {
        int counter = 0;
        Image background = new Image("Assets/Img/background.png");
        Image HP = new Image("Assets/Img/HPBar.png");
        Image HPBG = new Image("Assets/Img/HPBarBG.png");
        Image HPFG = new Image("Assets/Img/HPBarFG.png");
        Entity textEntity;
        Text currentHP;
        Random random = new Random();
        int secondpassedmakesurer = 0;
        public Sound cokka = new Sound("Assets/Sounds/cokka.ogg");
        public Sound minigun = new Sound("Assets/Sounds/minigun.ogg");
        public Music Music = new Music("Assets/Sounds/Rolemusic - If Pigs Could Sing.ogg");
        Player player = new Player(1, 2);
        public MainScene() : base()
        {
            // Add a blue rectangle to the Scene (just to indicate which scene is currently active.)
            AddGraphic(background);
            //HP.Scale = 0.5f;
            this.player.StartStage();
            this.textEntity = new Entity(900, 500);
            this.currentHP = new Text("", "Assets/Fonts/trench100free.ttf", 30);
            FormatText(currentHP);
            //this.Damage = new FormatedText(player.GetTotalDps().ToString(), 50, new Vector2(currentHP.X, currentHP.Y + 50));
            //this.Damage.SetPosition(text.X, text.Y + 50);
            this.textEntity.AddGraphic(currentHP);
            //this.currentHP.Color = Color.Black;
            //this.textEntity.AddGraphic(Damage);
            Add(textEntity);
            AddGraphic(HPBG, (1920 - 750) / 2, 2);
            AddGraphic(HPFG, (1920 - 750) / 2, 2);
            HPBG.Scale = 1f;
            HPFG.Scale = 1f;
            Add(new AnimatingEntity(random.Next(100, 1800), random.Next(550, 1000), UnitType.Cokka, random, cokka));
            minigun.Volume = 0.1f;
        }

        public override void Update()
        {

            if (Input.KeyPressed(Key.Space))
            {
                if (Music.IsPlaying)
                {
                    Music.Pause();
                }
                else
                {
                    Music.Play();
                }
            }
            //if (secondpassedmakesurer == 60)
            {
                HPFG.ClippingRegion = new Rectangle(0, 0, (int)(HPFG.Width * (player.currentStage.CurrentHP / player.currentStage.MaxHP)), HPFG.Height);
                counter++;
                player.Attack(60);
                //this.currentHP.CenterOriginZero();
                this.currentHP.String =
                    "Stage(" + player.stage + "): " + Math.Ceiling(player.currentStage.CurrentHP).ToString() + "/" + Math.Ceiling(player.currentStage.MaxHP).ToString() + "\n" +
                    ("Prize: " + player.currentStage.Prize) + "\n" +
                    ("Stage Kills: " + player.currentStage.Kills) + "\n" +
                    ("Gold: " + player.gold) + "\n" +
                    player.GetTotalDps().ToString() + "\n" +
                    Input.MouseX + "\n" +
                    HPBG.Width;
                //this.currentHP.Color = Color.Random;
                //Add(new AnimatingEntity(random.Next(100, 1800), random.Next(550, 1000)));
                // When the space bar is pressed switch to the SecondScene.
                //Game.SwitchScene(new SecondScene());
                if (!minigun.IsPlaying)
                {
                    minigun.Play();
                }
                if (Input.KeyPressed(Key.Escape))
                {
                    // Play the walk up animation when the up key is pressed.
                    minigun.Stop();
                    //foreach (var entity in GetEntities< AnimatingEntity >)
                }
                base.Update();
            }
        }

        public void FormatText(Text Text)
        {
            Text.OutlineThickness = 2;
            Text.TextStyle = TextStyle.Bold;
            Text.SetPosition(0, 0);
            Text.Color = Color.Yellow;
            Text.OutlineColor = Color.Black;
        }

    }
    class AnimatingEntity : Entity
    {
        // Set up an enum to use for the four different animations.
        enum Animation
        {
            WalkRight,
            Death,
            Idle,
            WeaponOut,
            Shoot
        }
        int shootInterval;
        int cooldown = 0;
        Random random;
        public Sound Sound;
        // Create the Spritemap to use. Use Sprite.png as the texture, and define the cell size as 32 x 32.
        //Spritemap<Animation> spritemap = new Spritemap<Animation>("enemy_animations.png", 88, 68);
        //Spritemap<Animation> spritemap = new Spritemap<Animation>("iron_iso.png", 148, 78);
        //Spritemap<Animation> spritemap = new Spritemap<Animation>("heavy_turret.png", 106, 56);
        //Spritemap<Animation> spritemap = new Spritemap<Animation>("plane.png", 86, 77);
        //Spritemap<Animation> spritemap = new Spritemap<Animation>("dicokka.png", 124, 76);
        Spritemap<Animation> spritemap;// = new Spritemap<Animation>("rocket.png", 124, 110);
        public AnimatingEntity(float x, float y, UnitType UnitType, Random random, Sound Sound) : base(x, y)
        {
            switch (UnitType)
            {
                case UnitType.Cokka:
                    spritemap = new Spritemap<Animation>("Assets/Img/dicokka.png", 124, 76);
                    spritemap.Add(Animation.Shoot, "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16", 4).NoRepeat();
                    spritemap.Add(Animation.Idle, "0", 4).NoRepeat();
                    this.random = random;
                    this.Sound = Sound;
                    //spritemap.Scale = 2;
                    break;
                default:
                    spritemap = new Spritemap<Animation>("Assets/Img/rocket.png", 124, 110);
                    spritemap.Add(Animation.Shoot, "0,1,2,3,4,5,6,7, 8,9,10,8,9,10,8,9,10,8,9,10,8,9,10,8,9,10,8,9,10,8,9,10,8,9,10,8,9,10, 11,12,13,14,15,16,11,12,13,14,15,16,11,12,13,14,15,16,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26, 27,28,29,30,31,32,33,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,", 4);
                    break;
            }
            // Add the animation data for the PlayOnce test.
            //spritemap = new Spritemap<Animation>("rocket.png", 124, 110);
            //spritemap.Add(Animation.Idle, "0", 3);
            //spritemap.Add(Animation.Death, "0,1,2,3,4,5,6,7,0,1,2,3,4,5,6,7,0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,31", 4);
            //spritemap.Add(Animation.WalkRight, "41,42,43,44,45,46,47,48,49,50,51,52", 4);
            //spritemap.Add(Animation.WeaponOut, "33,34,35,36,37,38,39,40", 4);
            //spritemap.Add(Animation.Shoot, "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17", 4);
            //spritemap.Add(Animation.Shoot, "0,1,2,3,4", 4);
            //spritemap.Add(Animation.Shoot, "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67", 1);
            //spritemap.Add(Animation.Shoot, "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,31,32,33", 2);
            //spritemap.Add(Animation.Shoot, "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16", 4);
            //spritemap.Add(Animation.Shoot, "0,1,2,3,4,5,6,7, 8,9,10,8,9,10,8,9,10,8,9,10,8,9,10,8,9,10,8,9,10,8,9,10,8,9,10,8,9,10, 11,12,13,14,15,16,11,12,13,14,15,16,11,12,13,14,15,16,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26, 27,28,29,30,31,32,33,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,", 4);

            // Center the spritemap's origin.
            spritemap.CenterOrigin();
            // Play the walking down animation immediately.
            spritemap.Play(Animation.Idle);

            // Add the graphic to the Entity so that it renders.
            //AddGraphic(spritemap);
            AddGraphic(spritemap);
            //AddGraphic(spritemap2);
        }

        public override void Update()
        {
            if (cooldown <= 0)
            {
                spritemap.Play(Animation.Shoot);
                shootInterval = this.random.Next(3, 10);
                cooldown = shootInterval * 60;
                Sound.Play();
            }
            else
            {
                //spritemap.Play(Animation.Idle);
                cooldown--;
            }
            base.Update();

        }
    }
}
