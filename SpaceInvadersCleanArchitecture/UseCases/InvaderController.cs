﻿using System.Numerics;
//using SFML.System;
using bitbox.SpaceInvadersCleanArchitecture.Entitys;
using System.Diagnostics;

namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
    public class InvaderController : IInvaderController
    {
        private IInvader invader;
        private IWindowController window = new WindowController(); //TODO warum geht nicht IWindow        

        //private List<IProjectile> projectiles;
        //private RectangleShape _invaderRect = new RectangleShape(new Vector2f(40, 40));

        //public RectangleShape invaderRect { get { return _invaderRect; } }
        private Vector2 grid;
        private float invaderPositionInGrid;

        private Vector2 _position = new Vector2();
        public Vector2 position { get { return _position; } }
        private Vector2 _size = new Vector2(40, 40);
        public Vector2 size { get { return _size; } }

        private bool _isFire;
        public bool isFire { get { return _isFire; } }

        private int _animation = 0;
        public int GetAnimation() { return _animation;}

        private int hight = 1;
        private int speed = 0;       

        private Stopwatch watch = new Stopwatch();
        private bool watchOff = true;
        private long duration;

        Random rand = new Random();
        private int randShoot;

        public InvaderController() { }

        public InvaderController(Vector2 position, Vector2 velocity, int gridX, int gridY)
        {            
            invader = new Invader(position, velocity);
            //projectiles = new List<IProjectile>();
            grid = new Vector2(gridX, gridY);
            UpdateInvaderLevel();
            _position = new Vector2(_size.X * 2 + ((1920 / 2) / _size.X * 3) * invader.InvaderPosition.X, _position.Y); //TODO: Windowsizeentity verwednen
            //_invaderRect.Position = new Vector2f(_invaderRect.Size.X * 2 + (Globals.windowSize.X / _invaderRect.Size.X * 3) * invader.InvaderPosition.X, _invaderRect.Position.Y);
            // Weitere Initialisierungen
        }

        public void Update()
        {
            if(watchOff)
            {
                watch.Start();
                watchOff = false;
            }
            /*if (hight < 7)
            {
                speed = hight; // at high speeds the invaders get out of sequence so I limited them to speed 10 as max
            }*/
            speed = 8;
            _isFire = false;



            //moveStep = moveClock.ElapsedTime;
            //randomTime = randomClock.ElapsedTime;
            duration = watch.ElapsedMilliseconds;
            

            MoveInvader(speed);

            /*
            for (int i = 0; i < projectiles.Count; i++)
            {
                if (!projectiles[i].isDead)
                {
                    projectiles[i].Update();
                }
                else
                {
                    projectiles.RemoveAt(i); // Removes the instance of the, out of window bounds, projectile
                }
            }
            */

            if (invader.InvaderPosition.Y == 4)
            {
                Fire();
            }
        }

        private void Fire()
        {
            randShoot = rand.Next(0, 300);
            if (randShoot < 1)
            {                
                _isFire = true;
            }
        }

        private void MoveInvader(int speed)
        {
            
            if (!(_position.X < 0 && invader.Velocity.X < 0) &&
                !((_position.X + _size.X) > window.GetWindowWidth() && invader.Velocity.X > 0))
            {

                if (duration > 1000 / (long)speed)
                {
                    //Console.WriteLine("invaderRect.Position.X alt = " + invaderRect.Position.X);

                    _position = new Vector2(_position.X + invader.Velocity.X, _position.Y + invader.Velocity.Y);

                    //Console.WriteLine("Position Y = " + _invaderRect.Position.Y);

                    //Console.WriteLine("invaderRect.Position.X neu = " + invaderRect.Position.X);
                    

                    //Globals.InvaderTexture(ref invader.InvaderRect, animation);

                    if (_animation == 0)
                    {
                        _animation = 1;
                    }
                    else if (_animation == 1)
                    {
                        _animation = 0;
                    }
                                                          
                   watch.Restart();
                }
            }
            else
            {                
                invader.ChangeDirektion();
                //if (hight < 10)
                //    hight++;
                hight++;
                UpdateInvaderLevel();
            }

            //UpdateInvaderLevel(hight);

            /*if (invaderRect.Position.Y != invaderPositionInGrid)
            {
                invaderRect.Position = new Vector2f(invaderRect.Position.X, invaderPositionInGrid);
            }*/
         
        }

        private void UpdateInvaderLevel()
        {
            _position = new Vector2(_position.X, ((window.GetWindowHight() / _size.Y * 3) * invader.InvaderPosition.Y) + 33 * hight);
        }

    }
}

