using System;
namespace bitbox.SpaceInvadersCleanArchitecture.UseCases
{
	public class CollisionController : ICollisionController
	{
		public CollisionController()
		{
		}

        public void CheckCollision(ref IMovableObject player, ref IMovableObject[,] invaders, ref IBarrierController[] barriers, ref List<ProjectileController> projectiles)
        {
            CheckCollisionWithBorders(ref projectiles);
            CheckCollisionWithBarriers(ref barriers, ref projectiles);
            CheckCollisionWithPlayer(ref player, ref projectiles);
            CheckCollisionWithInvader(ref invaders, ref projectiles);

        }

        public void CheckCollisionWithBorders(ref List<ProjectileController> projectiles)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                if (projectiles[i] != null)
                {
                    if (projectiles[i].position.Y == 0 || projectiles[i].position.Y >= 1920 / 2)
                    {                        
                        projectiles[i].SetIsDead(true);                        
                        //projectiles[i] = null;
                    }
                }
            }

        }

        public void CheckCollisionWithBarriers(ref IBarrierController[] barriers, ref List<ProjectileController> projectiles)
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
                                //projectiles[i] = null;
                            }
                        }
                        else
                        {
                            if (projectiles[i].position.Y <= (barriers[j].position.Y + barriers[j].size.Y) &&
                            ((projectiles[i].position.X >= barriers[j].position.X) && (projectiles[i].position.X <= (barriers[j].position.X + barriers[j].size.X))))
                            {
                                projectiles[i].SetIsDead(true);
                                //projectiles[i] = null;
                            }
                        }

                    }
                }
            }
        }

        public void CheckCollisionWithPlayer(ref IMovableObject player, ref List<ProjectileController> projectiles)
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
                            //TODO: Delete Player
                            //projectiles[i] = null;
                        }
                    }
                }
            }
        }

        public void CheckCollisionWithInvader(ref IMovableObject[,] invaders, ref List<ProjectileController> projectiles)
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
                                    //projectiles[i] = null;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

