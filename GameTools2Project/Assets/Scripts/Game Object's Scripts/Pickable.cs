using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickable : MonoBehaviour {

    //Pickable Object Variables
    public Text ScoreText;
    public int KeysToAdd;
    private int _score;
    public bool picked;

    public void BePicked(Transform newParent)
    {
        //Parenting the Pillar Key to the Player
        picked = true;
        StartCoroutine(HandlePick(newParent));
        //When Key Parented to Player; +1 Added to the key score
        _score += KeysToAdd;
        ScoreText.text = "Keys: " + _score + "/7";
    }

    IEnumerator HandlePick(Transform newParent)   
    {
        //Picking the Pillars at set times
        yield return new WaitForSeconds(0.2f);
        transform.localPosition = Vector3.zero;

        //Destroying the Pillar Keys at a set time
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

}
