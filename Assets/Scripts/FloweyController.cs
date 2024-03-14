using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloweyController : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;

    public void ActivateDialogue()
    {
        dialogue.SetActive(true);
    }

    public bool DialogueActive()
    {
        return dialogue.activeInHierarchy;
    }

    public void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
