using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    [Header("Basic Projectile Stats")]
    [SerializeField]
    protected int damage;
    public int Damage => damage;
    [SerializeField]
    protected float speed;
}
