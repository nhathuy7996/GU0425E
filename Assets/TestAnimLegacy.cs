using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimLegacy : MonoBehaviour
{
    [SerializeField]
    Animation animation333;

    [SerializeField] AnimationClip animationClip;
    // Start is called before the first frame update
    void Start()
    {
        this.animation333 = this.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            this.animation333.clip = animationClip;
            this.animation333.Play();
        }
             
    }   
}
