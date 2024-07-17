using Unity.VisualScripting;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    public Animator anim;
    private bool isAnimated = false;
    public float triggerDistance = 3.0f;
    private Transform player;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        
        if (distance <= triggerDistance && !isAnimated && Input.GetKeyDown(KeyCode.F))
        {
            anim.Play("Scene");
            Debug.Log("Playing");
            isAnimated = true;
        }else if(isAnimated && distance <= triggerDistance && Input.GetKeyDown(KeyCode.F)) 
        {
            anim.Play("Reverse");
            Debug.Log("Reverse Playing");
            isAnimated= false;


        }
    }
}
