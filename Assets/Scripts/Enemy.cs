using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public int _hp;
    public float speed;
    public bool isSlowed;
    public bool dead;
    public void GetDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0) dead = true;
    }
    

    
}
