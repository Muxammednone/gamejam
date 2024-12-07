using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Transform EnemyForEnemy;

    private int _hp;
    private int _damage;
    private float _speed;
    private string _tag;
    private bool _dead = false;

    public int Damage 
    { 
        set { _damage = value; } 
        get { return _damage; } 
    }

    public int HP
    {
        set { _hp = value; }
        get { return _hp; }        
    }

    public bool Dead
    {
        private set { _dead = true; }
        get { return _dead; }        
    }

    public float Speed
    { 
        set { _speed = value; }
        get { return _speed; } 
    }

    public string Tag
    { 
        set { _tag = value; }
        get { return _tag; } 
    }

    public void GetDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
            _dead = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        EnemyForEnemy = GameObject.Find(_tag).transform;
    }

    // Update is called once per frame
    public void Update()
    {
        transform.position = Vector2.Lerp(transform.position, EnemyForEnemy.position, Time.deltaTime * _speed);
    }
}
