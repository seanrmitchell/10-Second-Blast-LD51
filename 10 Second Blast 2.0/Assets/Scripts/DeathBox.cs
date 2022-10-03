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

    private float currentCoolDown;

    private void Awake()
    {

        currentCoolDown = coolDownBox;

        boxTransform = transform.Find("SquareShrink");
        leftTransform = transform.Find("Left");
        rightTransform = transform.Find("Right");
        topTransform = transform.Find("Top");
        bottomTransform = transform.Find("Bottom");

        SetBoxSize(new Vector3 (0,0), new Vector3(200, 200));

        targetBoxSize = new Vector3(5,5);
    }

    // Sets the center box's size, and the following boxes surrounding it
    private void SetBoxSize(Vector3 position, Vector3 size)
    {
        // set variables for current box position, and current box size-
        boxPosition = position;
        boxSize = size;

        transform.position = position;

        boxTransform.localScale = size;

        //top box
        topTransform.localScale = new Vector3(200, 200);
        topTransform.localPosition = new Vector3(0, topTransform.localScale.y * .5f + size.y * 0.5f);

        //bottom box
        bottomTransform.localScale = new Vector3(200, 200);
        bottomTransform.localPosition = new Vector3(0, -topTransform.localScale.y * .5f - size.y * 0.5f);

        //right box
        rightTransform.localScale = new Vector3(200, size.y);
        rightTransform.localPosition = new Vector3(+leftTransform.localScale.x * 0.5f + size.x * 0.5f, 0f);

        //left box
        leftTransform.localScale = new Vector3(200, size.y);
        leftTransform.localPosition = new Vector3(-leftTransform.localScale.x * 0.5f - size.x * 0.5f, 0f);
    }

    public bool IsOutsideBox(Vector3 position)
    {
        if (Vector3.Distance(position, boxPosition) > boxSize.x/2)
        {
            return true;
        }
        else
        {
            return false;
        }
            
    }

    private void Update()
    {
        if (currentCoolDown < coolDownBox)
        {
            Vector3 sizeChangeVector = (targetBoxSize - boxSize).normalized;
            Vector3 newBoxSize = boxSize + sizeChangeVector * Time.deltaTime * boxShrinkSpeed;
            SetBoxSize(boxPosition, newBoxSize);
            currentCoolDown += Time.deltaTime;
        }
        else if (currentCoolDown >= coolDownBox && currentCoolDown < coolDownBox * 2)
        {
            currentCoolDown += Time.deltaTime;
        }
        else if (currentCoolDown >= coolDownBox * 2)
        {
            Debug.Log("Cooldown Up!");
            currentCoolDown = 0;
        }
    }
}
