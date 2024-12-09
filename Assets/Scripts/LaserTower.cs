using UnityEngine;

public class LaserTower : Tower
{
    [SerializeField] private Transform gunTransfrom;
    public override void shootEnemy(Enemy enemy)
    {
        GetComponentInChildren<RoketSpawner>().SpawnRocket(enemy.transform);
        base.shootEnemy(enemy);
        gunTransfrom.LookAt(enemy.transform);
    }
}
