using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllyData",menuName = "ScriptableObjects/New AllyData")]
public class AllyData : ScriptableObject
{
    public Vector3[] positionList = new Vector3[1000000];
    public Material deadMaterial;
    public Material stunnedMaterial;
    public float maxHealth;
    public float maxSpeed;
    public float damage;
    public float size;
    public int level;
}
