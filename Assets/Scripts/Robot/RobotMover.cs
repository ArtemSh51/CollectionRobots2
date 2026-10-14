using UnityEngine;

public class RobotMover : State
{
    private Robot _robot;
    private Transform _resource;
    private float _distanceToResource;

    public RobotMover(Robot robot, float distanceToResource)
    {
        _robot = robot;
        _distanceToResource = distanceToResource;
    }

    public void SetResourcePosition(Transform resource)
    {
        _resource = resource;
    }

    public override void Enter()
    {
        _robot.GetNavMeshAgent().SetDestination(_resource.position);
    }

    public override void Exit()
    {
        _robot.GetNavMeshAgent().ResetPath();
    }

    public override void Update()
    {
        if (Vector3.Distance(_resource.position, _robot.transform.position) <= _distanceToResource)
        {
            _robot.RobotToucher.SetResourcePosition(_resource);
            _robot.StateMachine.ChangeState(_robot.RobotToucher);
        }
    }
}
