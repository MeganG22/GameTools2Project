using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour {

    public bool picked;

    public void BePicked(Transform newParent)
    {
        picked = true;
        StartCoroutine(HandlePick(newParent));
    }

    IEnumerator HandlePick(Transform newParent)
    {
        yield return new WaitForSeconds(1.5f); //finish for now & come back (wait few seconds before 'pick' & re-parent)
        transform.parent = newParent;
        transform.localPosition = Vector3.zero;

        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

    //Parent Object
    //Destroy Object
}
