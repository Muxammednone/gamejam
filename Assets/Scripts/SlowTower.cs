using UnityEngine;
using System.Collections;
public class SlowTower : Tower
{
    public float normalSpeed = 5.0f;       
    public float slowedSpeed = 2.0f;     
    public float slowDuration;
       
    public override void shootEnemy(Enemy enemy)
    {
        base.shootEnemy(enemy);
        SlowDown(slowDuration, enemy);

    }
    public void SlowDown(float duration, Enemy enemy)
    {
        if (!enemy.isSlowed) // ѕровер€ем, не наложено ли замедление уже
        {
            StartCoroutine(SlowdownCoroutine(duration, enemy));
        }
    }

    private IEnumerator SlowdownCoroutine(float duration, Enemy enemy)
    {
        enemy.isSlowed = true;
        enemy.speed = slowedSpeed;       

        yield return new WaitForSeconds(duration);

        enemy.speed = normalSpeed;     
        enemy.isSlowed = false;
    }
}
