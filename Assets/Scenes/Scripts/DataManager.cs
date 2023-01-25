using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public event Action DataUpdated;

    PlayerData_SO playerData_SO;

    public PlayerData_SO PlayerData_SO => playerData_SO; 
}
