using UnityEngine;

public class DuplicatingEnemy : BaseEnemy
{
    public void Start()
    {
        health = 50;
        damage = 5;
    }

    //on respawn, divide health by 2 and spawn a copy of gameobject with the same health and damage
    //keep doing this until health is less than or equal to 0, then despawn
}
