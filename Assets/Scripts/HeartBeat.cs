using UnityEngine;
using System.Collections;

public class HeartBeat : MonoBehaviour
{
    public float beatSize = 1.2f; // How much the heart scales up
    public float beatSpeed = 0.2f; // Speed of the beat animation

    public void Beat()
    {
        StartCoroutine(BeatAnimation());
    }

    private IEnumerator BeatAnimation()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 enlargedScale = originalScale * beatSize; // Scale up

        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / beatSpeed;
            transform.localScale = Vector3.Lerp(originalScale, enlargedScale, t);
            yield return null;
        }

        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / beatSpeed;
            transform.localScale = Vector3.Lerp(enlargedScale, originalScale, t);
            yield return null;
        }
    }
}

