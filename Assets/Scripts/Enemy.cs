using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int _hp;
    public float speed;
    public bool isSlowed;

    public void GetDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0) Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
       
    }
}
