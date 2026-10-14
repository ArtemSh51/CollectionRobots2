using UnityEngine;

public class TaskDistributor : MonoBehaviour
{
    [SerializeField] private ResourceScanner _resourceScanner;
    [SerializeField] private RobotWarehouse _robotWarehouse;

    private void Update()
    {
        Debug.Log(_resourceScanner.ScannedResources.Count);
        for (int i = 0; i < _resourceScanner.ScannedResources.Count; i++)
        {
            if (i == _resourceScanner.ScannedResources.Count - (_resourceScanner.ScannedResources.Count - _robotWarehouse.Robots.Count))
            {
                break;
            }

            _robotWarehouse.AddTask(i, _resourceScanner.GetResourcePosition(i));
        }
    }
}
