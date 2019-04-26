using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    Animator animator;
    private bool roarHandled = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("stop") && !roarHandled)
        {
            StartCoroutine(HandleRoar());
        }
        
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("Collision");
        if (col.tag == "Respawn")
        {
            //Debug.Log("It Worked");
            animator.SetBool("stop", true);
        }
    }

    private IEnumerator HandleRoar()
    {
        roarHandled = true;
        // process pre-yield
        yield return new WaitForSeconds(6.0f);
        // process post-yield
        animator.SetBool("roaring", true);
        roarHandled = false;
    }
}
