using NaughtyCharacter;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator _animator;
    
    private readonly int Open = Animator.StringToHash("Open");
    private readonly int Close = Animator.StringToHash("Close");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Character player))
        {
            _animator.ResetTrigger(Close);
            _animator.SetTrigger(Open);
            Debug.Log("Open");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Character player))
        {
            _animator.ResetTrigger(Open);
            _animator.SetTrigger(Close);
            Debug.Log("Close");
        }
    }
    
}
