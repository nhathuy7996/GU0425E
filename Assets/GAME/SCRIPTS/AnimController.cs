using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField] PlayerController playerController;


    // Start is called before the first frame update
    void Start()
    {
        this.animator = this.GetComponent<Animator>();
        this.playerController = this.GetComponentInParent<PlayerController>();
    }


    // Update is called once per frame
    void Update()
    {
        this.animator.SetTrigger(this.playerController.PlayerState.ToString());
        this.animator.SetFloat("IsShoot", this.playerController.IsShoot ? 1 : 0);
    }

    public void SetSpeed(float speed)
    {
        this.animator.speed = speed;
    }
 
}
