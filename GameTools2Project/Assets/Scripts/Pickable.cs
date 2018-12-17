using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickable : MonoBehaviour {

    public Text ScoreText;
    public int KeysToAdd;
    private int _score;

    public bool picked;

    public void BePicked(Transform newParent)
    {
        //Parenting the Pillar to the Player
        picked = true;
        StartCoroutine(HandlePick(newParent));
        _score += KeysToAdd;
        ScoreText.text = "Keys: " + _score + "/7";
    }

    IEnumerator HandlePick(Transform newParent)
    {
        //Picking the Pillars at set times
        yield return new WaitForSeconds(0.1f);
        transform.localPosition = Vector3.zero;

        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

}
