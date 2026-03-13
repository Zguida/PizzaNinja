using StarterAssets;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{

    [SerializeField] private Transform spawn;
    
    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            CharacterController cc = player.GetComponent<CharacterController>();
            if (cc != null) cc.enabled = false;
            player.transform.position = spawn.position;
            player.transform.rotation = spawn.rotation;
            var controller = player.GetComponent<ThirdPersonController>();
            controller._cinemachineTargetYaw = 0;
            controller._cinemachineTargetPitch = 0;
            if (cc != null) cc.enabled = true;
        }
    }

}
    