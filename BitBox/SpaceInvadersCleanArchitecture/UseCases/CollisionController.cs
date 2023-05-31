using System;
namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
	public class CollisionController : ICollisionController
	{
        public bool collisionDetected = false;
		public CollisionController()
		{
		}
        
        public void CheckCollision( IMovableObject player,  IMovableObject[,] invaders,  IBarrierController[] barriers,  List<IMovableObject> projectiles)
        {
            CheckCollisionWithBorders( projectiles);
            CheckCollisionWithBarriers( barriers,  projectiles);
            CheckCollisionWithPlayer( player,  projectiles);
            CheckCollisionWithInvader( invaders,  projectiles);

        }

        public void CheckCollisionWithBorders( List<IMovableObject> projectiles)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                if (projectiles[i] != null)
                {
                    if (projectiles[i].position.Y == 0 || projectiles[i].position.Y >= 1920 / 2)
                    {                        
                        projectiles[i].SetIsDead(true);
                        collisionDetected = true;
                    }
                    else
                    {
                        collisionDetected = false;
                    }
                                      
                }                
            }            

        }

        public void CheckCollisionWithBarriers( IBarrierController[] barriers,  List<IMovableObject> projectiles)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                for (int j = 0; j < barriers.Length; j++)
                {
                    if (projectiles[i] != null)
                    {
                        if (!projectiles[i].isPlayerProjectile)
                        {
                            if (projectiles[i].position.Y >= (barriers[j].position.Y) &&
                            ((projectiles[i].position.X >= barriers[j].position.X) && (projectiles[i].position.X <= (barriers[j].position.X + barriers[j].size.X))))
                            {
                                projectiles[i].SetIsDead(true);
                                collisionDetected = true;
                            }
                            else
                            {
                                collisionDetected = false;
                            }
                        }
                        else
                        {
                            if (projectiles[i].position.Y <= (barriers[j].position.Y + barriers[j].size.Y) &&
                            ((projectiles[i].position.X >= barriers[j].position.X) && (projectiles[i].position.X <= (barriers[j].position.X + barriers[j].size.X))))
                            {
                                projectiles[i].SetIsDead(true);
                                collisionDetected = true;
                            }
                            else
                            { 
                                collisionDetected = false;
                            }
                            
                        }

                    }                   
                }
            }
        }

        public void CheckCollisionWithPlayer( IMovableObject player,  List<IMovableObject> projectiles)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                if (projectiles[i] != null && player != null)
                {
                    if (!projectiles[i].isPlayerProjectile)
                    {
                        if (projectiles[i].position.Y >= (player.position.Y) &&
                        ((projectiles[i].position.X >= player.position.X) && (projectiles[i].position.X <= (player.position.X + player.size.X))))
                        {
                            projectiles[i].SetIsDead(true);
                            player.SetIsDead(true);
                            collisionDetected = true;
                        }
                        else
                        {
                            collisionDetected = false;
                        }
                    }
                }
            }
        }

        public void CheckCollisionWithInvader( IMovableObject[,] invaders,  List<IMovableObject> projectiles)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                for (int j = 0; j < invaders.GetLength(0); j++)
                {
                    for (int k = 0; k < invaders.GetLength(1); k++)
                    {
                        if (projectiles[i] != null && invaders[j, k] != null)
                        {
                            if (projectiles[i].isPlayerProjectile)
                            {
                                if (projectiles[i].position.Y <= (invaders[j, k].position.Y + invaders[j, k].size.Y) &&
                                ((projectiles[i].position.X >= invaders[j, k].position.X) && (projectiles[i].position.X <= (invaders[j, k].position.X + invaders[j, k].size.X))))
                                {
                                    projectiles[i].SetIsDead(true);
                                    invaders[j, k].SetIsDead(true);
                                    collisionDetected = true;
                                }
                                else
                                {
                                    collisionDetected = false;
                                }
                            }
                        }
                    }
                }
            }
        }


        public bool CollisionTest(IMovableObject projectiles)
        {            
            if (projectiles != null)
            {
                if (projectiles.position.Y == 0 || projectiles.position.Y >= 1920 / 2)
                {
                    projectiles.SetIsDead(true);
                    return true;
                }

                return false;
            }
            return false;
        }
    }
}

