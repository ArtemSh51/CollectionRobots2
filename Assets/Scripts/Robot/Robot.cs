using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Robot : MonoBehaviour
{
    [SerializeField] private Transform _hand;
    [SerializeField] private Transform _townHall;
    [SerializeField] private ResourceSpawner _spawner;
    [SerializeField] private float _distanceToResource;
    [SerializeField] private float _distanceToTownHall;

    [SerializeField] private InputReader _inputReader;

    private Transform _resource;
    private NavMeshAgent _agent;
    private bool _hasResource;

    public StateMachine StateMachine { get; private set; }

    public RobotMover RobotMover { get; private set; }

    public RobotToucher RobotToucher { get; private set; }

    public TownHallMover TownHallMover { get; private set; }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

        StateMachine = new StateMachine();
        RobotMover = new RobotMover(this, _distanceToResource);
        RobotToucher = new RobotToucher(this, _hand);
        TownHallMover = new TownHallMover(this, _townHall, _spawner, _distanceToTownHall);
    }

    private void Update()
    {
        StateMachine.Update();
    }

    public void SetResorcePosition(Transform resource)
    {
        _resource = resource;

        if (_hasResource == false)
        {
            RobotMover.SetResourcePosition(_resource);

            StateMachine.ChangeState(RobotMover);

            _hasResource = true;
        }
    }

    public void SetHasResource(bool isReceivedResources)
    {
        _hasResource = isReceivedResources;
    }

    public NavMeshAgent GetNavMeshAgent()
    {
        return _agent;
    }
}
