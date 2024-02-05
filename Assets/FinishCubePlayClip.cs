using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCubePlayClip : MonoBehaviour
{
    public PlayerExplotionFinishCubes PlayerEFC;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(PlayerEFC.isTouched == false)
            {
                PlayerEFC.isTouched = true;
                audioSource.clip.name = "Cibiki";
                audioSource.Play();
            }
            else
            {

            }
        }
    }
}
