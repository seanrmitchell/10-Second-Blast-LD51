using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{

    [SerializeField]
    private Transform boxTransform, leftTransform, rightTransform, topTransform, bottomTransform;

    private Vector3 boxSize, boxPosition, targetBoxSize;

    [SerializeField]
    public float damageOfBox, coolDownBox, boxShrinkSpeed;

    private void Awake()
    {
        boxTransform = transform.Find("SquareShrink");
        leftTransform = transform.Find("Left");
        rightTransform = transform.Find("Right");
        topTransform = transform.Find("Top");
        bottomTransform = transform.Find("Bottom");

        SetBoxSize(new Vector3 (0,0), new Vector3(200, 200));

        targetBoxSize = new Vector3(5,5);
    }

    private void SetBoxSize(Vector3 position, Vector3 size)
    {
        boxPosition = position;
        boxSize = size;
        Debug.Log(position);

        transform.position = position;

        boxTransform.localScale = size;

        topTransform.localScale = new Vector3(200, 200);
        topTransform.localPosition = new Vector3(0, topTransform.localScale.y * .5f + size.y * 0.45f);

        bottomTransform.localScale = new Vector3(200, 200);
        bottomTransform.localPosition = new Vector3(0, -topTransform.localScale.y * .5f - size.y * 0.45f);

        rightTransform.localScale = new Vector3(200, size.y);
        rightTransform.localPosition = new Vector3(+leftTransform.localScale.x * 0.5f + size.x * .5f, 0f);

        leftTransform.localScale = new Vector3(200, size.y);
        leftTransform.localPosition = new Vector3(-leftTransform.localScale.x * 0.5f - size.x * 0.45f, 0f);
    }

    public bool IsOutsideBox(Vector3 position)
    {
        if (coolDownBox >= 10 && Vector3.Distance(position, boxPosition) > boxSize.x/2)
        {
            Debug.Log("Outside Box");
            coolDownBox = 0f;
            return true;
        }
        else
        {
            coolDownBox += Time.deltaTime;
            return false;
        }
            
    }

    private void Update()
    {
        Vector3 sizeChangeVector = (targetBoxSize - boxSize).normalized;
        Vector3 newBoxSize = boxSize + sizeChangeVector * Time.deltaTime * boxShrinkSpeed;
        SetBoxSize(boxPosition, newBoxSize);
    }
}
