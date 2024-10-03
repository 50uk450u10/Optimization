using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerData", order = 2)]
public class PlayerData : ScriptableObject
{
    public int startingHealth = 100;
}
