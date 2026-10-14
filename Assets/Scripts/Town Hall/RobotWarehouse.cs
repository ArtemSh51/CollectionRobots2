using System.Collections.Generic;
using UnityEngine;

public class RobotWarehouse : MonoBehaviour
{
    [SerializeField] private List<Robot> _robots;

    public IReadOnlyList<Robot> Robots => _robots;

    public void AddTask(int index, Transform target)
    {
        _robots[index].SetResorcePosition(target);
    }
}
