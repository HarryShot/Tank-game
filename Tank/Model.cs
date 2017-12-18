using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tank
{
    public delegate void Streep();
    class Model
    {
        public event Streep changeStreep;

        int sizeField;
        int amountTank;
        int amountApples;
        public int speedGame;
        int collectedApples;
        public GameStatus gameStatus;
        Random r;
        MainTank mainTank;
        Bullet bullet;
        int step;
        List<Tank> tanks;
        List<Dead_Tank> deadTank;
        List<Apple> apples;
         public Wall wall;
        internal Bullet Bullet
        {
            get { return bullet; }
        }
        internal MainTank MainTank
        {
            get { return mainTank; }
        }
        internal List<Dead_Tank> DeadTank
        {
            get { return deadTank; }
        }
        internal List<Apple> Apples
        {
            get { return apples; }
        }
        internal List<Tank> Tanks
        {
            get { return tanks; }
        }

        
        public Model(int sizeField, int amountTank, int amountApples, int speedGame)
        {
            this.sizeField = sizeField;
            this.amountTank = amountTank;
            this.amountApples = amountApples;
            this.speedGame = speedGame;
            r = new Random();

            NewGame();
        }
        public void Play()
        {
            while (gameStatus == GameStatus.playing)
            {
                Thread.Sleep(speedGame);

                RunAllObjectOnField();

                TryDestroyTank();
                IfCollisionOfTanks();
                IfCollisionOfTanksAndPlayer();
                IfPickApple();

            }
        }
         void CreateApples()
        {
            CreateApples(0);
        }
         void CreateApples(int newApples)
        {
            int x, y;
            while (apples.Count < amountApples+newApples)
            {
                x = r.Next(6) * 40;
                y = r.Next(6) * 40;
                bool flag = true;

                foreach (Apple a in apples)
                {
                    if (a.X == x && a.Y == y)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                    apples.Add(new Apple(x, y));
            }
        }

         void CreateTanks()
        {

            int x, y;
            while (tanks.Count < amountTank+1)
            {
                if (tanks.Count == 0)
                    tanks.Add(new Hunter(sizeField, r.Next(6) * 40, r.Next(6) * 40));
                x = r.Next(6) * 40;
                y = r.Next(6) * 40;
                bool flag = true;

                foreach (Tank t in tanks)
                {
                    if (t.X == x && t.Y == y)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                    tanks.Add(new Tank(sizeField, x, y));
            }
        }

        void RunAllObjectOnField()
        {
            bullet.Run();
            mainTank.Run();
            ((Hunter)tanks[0]).Run(mainTank.X, mainTank.Y);
            for (int i = 1; i < tanks.Count; i++)
                tanks[i].Run();

            foreach (Dead_Tank ft in deadTank)
                ft.Fire();
        }

         void IfPickApple()
        {
            for (int i = 0; i < apples.Count; i++)
                if (Math.Abs(mainTank.X - apples[i].X) < 15 && Math.Abs(mainTank.Y - apples[i].Y) < 15)
                {
                    apples[i] = new Apple(step += 25, 280);
                    CreateApples(++collectedApples);

                }
            if (collectedApples > 4)
            {
                gameStatus = GameStatus.winner;
                if (changeStreep != null)
                    changeStreep();
            }
        }

         void IfCollisionOfTanksAndPlayer()
        {
            for (int i = 0; i < tanks.Count; i++)
            {
                if (((Math.Abs(tanks[i].X - mainTank.X) <= 18) && (tanks[i].Y == mainTank.Y))
                           ||
                           ((Math.Abs(tanks[i].Y - mainTank.Y) <= 18) && (tanks[i].X == mainTank.X))
                           ||
                           ((Math.Abs(tanks[i].X - mainTank.X) <= 15) && (Math.Abs(tanks[i].Y - mainTank.Y) <= 15)))
                {
                    gameStatus = GameStatus.looser;
                    if (changeStreep != null)
                        changeStreep();

                }
            }
        }

         void IfCollisionOfTanks()
        {
            for (int i = 0; i < tanks.Count - 1; i++)
                for (int j = i + 1; j < tanks.Count; j++)
                    if (((Math.Abs(tanks[i].X - tanks[j].X) <= 20) && (tanks[i].Y == tanks[j].Y))
                        ||
                        ((Math.Abs(tanks[i].Y - tanks[j].Y) <= 20) && (tanks[i].X == tanks[j].X))
                        ||
                        ((Math.Abs(tanks[i].X - tanks[j].X) <= 15) && (Math.Abs(tanks[i].Y - tanks[j].Y) <= 15)))
                    {
                        if (i == 0)
                            ((Hunter)tanks[i]).TurnArround();
                        else
                            tanks[i].TurnArround();
                        tanks[j].TurnArround();

                    }
        }

         void TryDestroyTank()
        {
            for (int i = 1; i < tanks.Count; i++)
                if ((Math.Abs(bullet.X - tanks[i].X) < 15) && (Math.Abs(bullet.Y - tanks[i].Y) < 15) &&
                    (Math.Abs(bullet.X - tanks[i].X) > 5) && (Math.Abs(bullet.Y - tanks[i].Y) > 5))
                {
                    deadTank.Add(new Dead_Tank(tanks[i].X, tanks[i].Y));
                    tanks.RemoveAt(i);
                    bullet.DefaultSettings();
                }
        }
       

        internal void NewGame()
        {
            collectedApples = 0;
            step = -25;
            tanks = new List<Tank>();
            apples = new List<Apple>();
            deadTank = new List<Dead_Tank>();
            mainTank = new MainTank(sizeField);
            bullet = new Bullet();
            CreateTanks();
            CreateApples();
            wall = new Wall();
            gameStatus = GameStatus.stoping;
        }
    }
}
