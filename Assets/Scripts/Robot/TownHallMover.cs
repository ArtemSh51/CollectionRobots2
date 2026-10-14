using UnityEngine;

public class TownHallMover : State
{
    private Robot _robot;
    private Transform _townHall;
    private ResourceSpawner _spawner;
    private Transform _resource;
    private float _distanceToTownHall;

    public TownHallMover(Robot robot, Transform townHall, ResourceSpawner spawner, float distanceToTownHall)
    {
        _robot = robot;
        _townHall = townHall;
        _spawner = spawner;
        _distanceToTownHall = distanceToTownHall;
    }

    public override void Enter()
    {
        _robot.GetNavMeshAgent().SetDestination(_townHall.position);
    }

    public override void Update()
    {
        if (Vector3.Distance(_robot.transform.position, _townHall.position) <= _distanceToTownHall)
        {
            _robot.SetHasResource(false);

            if (_resource.TryGetComponent(out Resource resource))
            {
                _spawner.ReturnResource(resource);
            }

            _robot.StateMachine.ChangeState(_robot.RobotMover);
        }
    }

    public void SetResourcePosition(Transform resource)
    {
        _resource = resource;
    }
}
