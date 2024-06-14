using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCVisibilityController : MonoBehaviour
{
    public GameObject respawn;

    public List<GameObject> npcs; // List of NPC GameObjects

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("gatitos"))
        {
            foreach (GameObject npc in npcs)
            {
                npc.transform.position = respawn.transform.position; // Make NPCs appear
            }
        }
    }

}