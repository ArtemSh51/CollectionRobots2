using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode _creatingFlagKeyCode;

    public event Action CreatingFlagButtonPressed;

    private void Update()
    {
        if (Input.GetKeyDown(_creatingFlagKeyCode))
        {
            CreatingFlagButtonPressed?.Invoke();
        }
    }
}
