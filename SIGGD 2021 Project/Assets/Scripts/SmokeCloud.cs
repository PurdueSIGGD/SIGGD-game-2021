using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeCloud : MonoBehaviour
{
    public List<Sprite> spriteOptions;
    public int orderVariance = 4;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = spriteOptions[Random.Range(0, spriteOptions.Count)];
        renderer.sortingOrder = Random.Range(0, orderVariance);

        transform.rotation = Quaternion.AngleAxis(90 * Random.Range(0, 4), Vector3.forward);
    }
}
