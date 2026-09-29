using UnityEngine;
using System.Collections.Generic;

public class TowerManager : MonoBehaviour
{
    public List<Transform> towerPositions;

    public void Start()
    {
        towerPositions = new List<Transform>();
    }
}
