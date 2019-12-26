using UnityEngine;

[RequireComponent(typeof(SideScrollingCharacter))]
public class SideScrollingCharacterController : MonoBehaviour
{
    protected SideScrollingCharacter character;

    protected virtual void Awake()
    {
        character = GetComponent<SideScrollingCharacter>();
    }
}