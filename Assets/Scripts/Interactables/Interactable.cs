using UnityEngine;

//base for every object that we can interact with
public class Interactable : MonoBehaviour {

    //radius we can interact with object
    public float radius = 3f;
    public Transform interactionTranform;

    bool isFocus = false;
    bool hasInteracted = false;

    Transform player;

    void Update()
    {  
        if(isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTranform.position);

            if(distance <= radius)
            {
                Debug.Log("INTERACT");
                hasInteracted = true;
            }
        }
        
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDeFocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTranform.position, radius);
    }
}
