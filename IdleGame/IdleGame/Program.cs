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
            Random allRandom = new Random();
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
        public List<Entity> Entities = new List<Entity>();
        public Sound cokka = new Sound("Assets/Sounds/cokka.ogg");
        public Sound minigun = new Sound("Assets/Sounds/minigun.ogg");
        public Sound ironiso = new Sound("Assets/Sounds/ironiso.ogg");
        public Music Music = new Music("Assets/Sounds/Rolemusic - If Pigs Could Sing.ogg");
        Player player = new Player(1, 2);
        public MainScene() : base()
        {
            Soldier soldier = new Soldier(990, 475, random, cokka);
            //AddGraphic(new Image("Assets/Img/Decals/des19.png"), test2.X + 10, test2.Y + 25);
            Obstacle obstacle = new Obstacle(soldier.X + 10, soldier.Y + 25, "des19", false);

            Sniper sniper = new Sniper(990, 675, random, cokka);
            Obstacle obstacle2 = new Obstacle(sniper.X + 10, sniper.Y + 30, "des08", false);

            IronSuit PlayerUnit = new IronSuit(soldier.X - 100, (soldier.Y+sniper.Y)/2, random, cokka);
            Add(soldier);
            Add(obstacle);
            Add(sniper);
            Add(obstacle2);
            Add(PlayerUnit);
            //Entities = GetEntitiesAll();
            

            // Add a blue rectangle to the Scene (just to indicate which scene is currently active.)
            AddGraphic(background);
            //background.Scale = 0.5f;
            //HP.Scale = 0.5f;
            this.player.StartStage();
            this.textEntity = new Entity(100, 100);
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
            //for (int a = 0;a < 1; a++)
            Add(new Cokka(random.Next(100, 1800), random.Next(550, 1000), random, cokka));


            //Add(new IronIso(random.Next(100, 1800), random.Next(550, 1000), random, ironiso));
            /*Add(new Heli(random.Next(100, 1800), random.Next(550, 1000), random, cokka));
            Add(new Hover(random.Next(100, 1800), random.Next(550, 1000), random, cokka));
            Add(new Mortar(random.Next(100, 1800), random.Next(550, 1000), random, cokka));
            Add(new Minigun(random.Next(100, 1800), random.Next(550, 1000), random, cokka));
            Add(new IronSuit(random.Next(100, 1800), random.Next(550, 1000), random, cokka));
            Add(new Rocket(random.Next(100, 1800), random.Next(550, 1000), random, cokka));*/
            //Add(new Sniper(random.Next(100, 1800), random.Next(550, 1000), random, cokka));
            //Add(new Turret(random.Next(100, 1800), random.Next(550, 1000), random, cokka));
            Soldier test = new Soldier(random.Next(100, 1800), random.Next(550, 1000), random, cokka);
            Add(test);
            Sound.GlobalVolume = 0.1f;
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
                Entities = GetEntitiesAll();
                //this.currentHP.CenterOriginZero();
                this.currentHP.String =
                    "Stage(" + player.stage + "): " + Math.Ceiling(player.currentStage.CurrentHP).ToString() + "/" + Math.Ceiling(player.currentStage.MaxHP).ToString() + "\n" +
                    ("Prize: " + player.currentStage.Prize) + "\n" +
                    ("Stage Kills: " + player.currentStage.Kills) + "\n" +
                    ("Gold: " + player.gold) + "\n" +
                    player.GetTotalDps().ToString() + "\n" +
                    "X: " + Input.MouseX + "\n" +
                    "Y: " + Input.MouseY + "\n" +
                    Entities.Count;
                //this.currentHP.Color = Color.Random;
                //Add(new AnimatingEntity(random.Next(100, 1800), random.Next(550, 1000)));
                // When the space bar is pressed switch to the SecondScene.
                //Game.SwitchScene(new SecondScene());
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
    
    class Obstacle : Entity
    {
        public Obstacle(float x, float y, string Path, bool flipped)
        {
            Image test = new Image("Assets/Img/Decals/" + Path + ".png");
            test.CenterOrigin();
            test.FlippedX = flipped;
            AddGraphic(test);
            SetPosition(x, y);
        }
    }

    class Sniper : Entity
    {
        // Set up an enum to use for the four different animations.
        enum Animation
        {
            Idle,
            Shoot
        }
        int shootInterval;
        int cooldown = 0;
        Random random;
        public Sound Sound;
        Spritemap<Animation> spritemap;
        public Sniper(float x, float y, Random random, Sound Sound) : base(x, y)
        {
            spritemap = new Spritemap<Animation>("Assets/Img/sniper.png", 51, 40);
            spritemap.Add(Animation.Shoot, "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18", 4).NoRepeat();
            spritemap.Add(Animation.Idle, "0", 4).NoRepeat();
            this.random = random;
            this.Sound = Sound;
            spritemap.CenterOrigin();
            spritemap.Play(Animation.Idle);
            AddGraphic(spritemap);
        }

        public override void Update()
        {
            if (cooldown <= 0)
            {
                spritemap.Play(Animation.Shoot);
                shootInterval = this.random.Next(10 * 60, 13 * 60);
                cooldown = shootInterval;
                //Sound.Play();
            }
            else
            {
                //spritemap.Play(Animation.Idle);
                cooldown--;
            }
            base.Update();
        }
    }

    class Rocket : Entity
    {
        // Set up an enum to use for the four different animations.
        enum Animation
        {
            Idle,
            Shoot
        }
        int shootInterval;
        int cooldown = 0;
        Random random;
        public Sound Sound;
        Spritemap<Animation> spritemap;
        public Rocket(float x, float y, Random random, Sound Sound) : base(x, y)
        {
            spritemap = new Spritemap<Animation>("Assets/Img/rocket.png", 124, 110);
            spritemap.Add(Animation.Shoot, "0,1,2,3,4,5,6,7, 8,9,10,8,9,10,8,9,10,8,9,10,8,9,10,8,9,10,8,9,10,8,9,10,8,9,10,8,9,10, 11,12,13,14,15,16,11,12,13,14,15,16,11,12,13,14,15,16,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26, 27,28,29,30,31,32,33,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,34,", 4).NoRepeat();
            spritemap.Add(Animation.Idle, "0", 4).NoRepeat();
            this.random = random;
            this.Sound = Sound;
            spritemap.CenterOrigin();
            spritemap.Play(Animation.Idle);
            AddGraphic(spritemap);
        }

        public override void Update()
        {
            if (cooldown <= 0)
            {
                spritemap.Play(Animation.Shoot);
                shootInterval = this.random.Next(10 * 60, 13 * 60);
                cooldown = shootInterval;
                //Sound.Play();
            }
            else
            {
                //spritemap.Play(Animation.Idle);
                cooldown--;
            }
            base.Update();
        }
    }

    class Cokka : Entity
    {
        // Set up an enum to use for the four different animations.
        enum Animation
        {
            Idle,
            Shoot
        }
        int shootInterval;
        int cooldown = 0;
        Random random;
        public Sound Sound;
        Spritemap<Animation> spritemap;
        public Cokka(float x, float y, Random random, Sound Sound) : base(x, y)
        {
            spritemap = new Spritemap<Animation>("Assets/Img/dicokka.png", 124, 76);
            spritemap.Add(Animation.Shoot, "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16", 4).NoRepeat();
            spritemap.Add(Animation.Idle, "0", 4).NoRepeat();
            this.random = random;
            this.Sound = Sound;
            spritemap.CenterOrigin();
            spritemap.Play(Animation.Idle);
            AddGraphic(spritemap);
        }

        public override void Update()
        {
            if (cooldown <= 0)
            {
                spritemap.Play(Animation.Shoot);
                shootInterval = this.random.Next(1 * 60, 3 * 60);
                cooldown = shootInterval;
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

    class Heli : Entity
    {
        // Set up an enum to use for the four different animations.
        enum Animation
        {
            Shoot
        }
        int Yshift = 0;
        bool down = true;
        int wait = 1;
        Random random;
        public Sound Sound;
        Spritemap<Animation> spritemap;
        public Heli(float x, float y, Random random, Sound Sound) : base(x, y)
        {
            spritemap = new Spritemap<Animation>("Assets/Img/heli.png", 88, 91);
            spritemap.Add(Animation.Shoot, "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15", 4);
            this.random = random;
            this.Sound = Sound;
            spritemap.CenterOrigin();
            spritemap.Play(Animation.Shoot);
            AddGraphic(spritemap);
        }

        public override void Update()
        {
            wait--;
            if (wait == 0)
            {
                if (down)
                {
                    Yshift--;
                    wait = 5;
                    if (Yshift < -2)
                        down = false;
                }
                else
                {
                    Yshift++;
                    wait = 5;
                    if (Yshift > 2)
                        down = true;
                }
                this.SetPosition(X, Y + Yshift);
            }
            //Sound.Play();
            base.Update();
        }
    }

    class Hover : Entity
    {
        // Set up an enum to use for the four different animations.
        enum Animation
        {
            Shoot
        }
        Random random;
        public Sound Sound;
        Spritemap<Animation> spritemap;
        public Hover(float x, float y, Random random, Sound Sound) : base(x, y)
        {
            spritemap = new Spritemap<Animation>("Assets/Img/hover.png", 104, 70);

            spritemap.Add(Animation.Shoot, "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35", 3);
            this.random = random;
            this.Sound = Sound;
            spritemap.CenterOrigin();
            spritemap.Play(Animation.Shoot);
            AddGraphic(spritemap);
        }

        public override void Update()
        {
            //Sound.Play();
            base.Update();
        }
    }

    class IronIso : Entity
    {
        // Set up an enum to use for the four different animations.
        enum Animation
        {
            Idle,
            Shoot
        }
        int shootInterval;
        int cooldown = 0;
        Random random;
        public Sound Sound;
        Spritemap<Animation> spritemap;
        public IronIso(float x, float y, Random random, Sound Sound) : base(x, y)
        {
            spritemap = new Spritemap<Animation>("Assets/Img/iron_iso.png", 148, 78);
            spritemap.Add(Animation.Shoot, "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17", 4).NoRepeat();
            spritemap.Add(Animation.Idle, "0", 4).NoRepeat();
            this.random = random;
            this.Sound = Sound;
            spritemap.CenterOrigin();
            spritemap.Play(Animation.Idle);
            AddGraphic(spritemap);
        }

        public override void Update()
        {
            if (cooldown <= 0)
            {
                spritemap.Play(Animation.Shoot);
                shootInterval = this.random.Next(1 * 60, 3 * 60);
                cooldown = shootInterval;
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

    class Mortar : Entity
    {
        // Set up an enum to use for the four different animations.
        enum Animation
        {
            Idle,
            Shoot
        }
        int shootInterval;
        int cooldown = 0;
        Random random;
        public Sound Sound;
        Spritemap<Animation> spritemap;
        public Mortar(float x, float y, Random random, Sound Sound) : base(x, y)
        {
            spritemap = new Spritemap<Animation>("Assets/Img/mortar2.png", 53, 54);
            spritemap.Add(Animation.Shoot, "18,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18", 4).NoRepeat();
            spritemap.Add(Animation.Idle, "18", 4).NoRepeat();
            this.random = random;
            this.Sound = Sound;
            spritemap.CenterOrigin();
            spritemap.Play(Animation.Idle);
            AddGraphic(spritemap);
        }

        public override void Update()
        {
            if (cooldown <= 0)
            {
                spritemap.Play(Animation.Shoot);
                shootInterval = this.random.Next(3*60, 5 * 60);
                cooldown = shootInterval;
                //Sound.Play();
            }
            else
            {
                //spritemap.Play(Animation.Idle);
                cooldown--;
            }
            base.Update();
        }
    }

    class Minigun : Entity
    {
        // Set up an enum to use for the four different animations.
        enum Animation
        {
            Shoot
        }
        Random random;
        public Sound Sound;
        Spritemap<Animation> spritemap;
        public Minigun(float x, float y, Random random, Sound Sound) : base(x, y)
        {
            spritemap = new Spritemap<Animation>("Assets/Img/minigun.png", 110, 45);

            spritemap.Add(Animation.Shoot, "0,1,2,3,4,5,6,7,8,9,10,11", 4);
            this.random = random;
            this.Sound = Sound;
            spritemap.CenterOrigin();
            spritemap.Play(Animation.Shoot);
            AddGraphic(spritemap);
        }

        public override void Update()
        {
            //Sound.Play();
            base.Update();
        }
    }

    class IronSuit : Entity
    {
        // Set up an enum to use for the four different animations.
        enum Animation
        {
            Shoot
        }
        Random random;
        public Sound Sound;
        Spritemap<Animation> spritemap;
        public IronSuit(float x, float y, Random random, Sound Sound) : base(x, y)
        {
            spritemap = new Spritemap<Animation>("Assets/Img/Player.png", 139, 61);

            spritemap.Add(Animation.Shoot, "0,1,2,3", 4);
            this.random = random;
            this.Sound = Sound;
            spritemap.CenterOrigin();
            spritemap.Play(Animation.Shoot);
            //spritemap.
            AddGraphic(spritemap);
        }

        public override void Update()
        {
            //Sound.Play();
            base.Update();
        }
    }

    class Turret : Entity
    {
        // Set up an enum to use for the four different animations.
        enum Animation
        {
            Shoot
        }
        Random random;
        public Sound Sound;
        Spritemap<Animation> spritemap;
        public Turret(float x, float y, Random random, Sound Sound) : base(x, y)
        {
            spritemap = new Spritemap<Animation>("Assets/Img/turret.png", 90, 42);

            spritemap.Add(Animation.Shoot, "0,1,2,3", 4);
            this.random = random;
            this.Sound = Sound;
            spritemap.CenterOrigin();
            spritemap.Play(Animation.Shoot);
            AddGraphic(spritemap);
        }

        public override void Update()
        {
            //Sound.Play();
            base.Update();
        }
    }

    class Soldier : Entity
    {
        // Set up an enum to use for the four different animations.
        enum Animation
        {
            Shoot
        }
        Random random;
        public Sound Sound;
        Spritemap<Animation> spritemap;
        public Soldier(float x, float y, Random random, Sound Sound) : base(x, y)
        {
            spritemap = new Spritemap<Animation>("Assets/Img/soldier.png", 64, 29);
            spritemap.Add(Animation.Shoot, "0,1,2,3", 4);
            this.random = random;
            this.Sound = Sound;
            spritemap.CenterOrigin();
            spritemap.Play(Animation.Shoot);
            AddGraphic(spritemap);
        }

        public override void Update()
        {
            //Sound.Play();
            base.Update();
        }
    }
}
