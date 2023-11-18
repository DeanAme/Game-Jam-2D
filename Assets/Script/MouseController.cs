using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MouseController : Singleton<MouseController>
{

//public Rigidbody2D rb2D;
public event Action <Vector3> OnMouseClicked;
    // Start is called before the first frame update
    void Start()
    {
        //rb2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        mouseControl();
    }
    void mouseControl()
    {
     RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, -Vector2.up);
    //press the left button of the mouse
        if(Input.GetMouseButtonDown(0)&& hitInfo.collider !=null)
        {
            //hitInfo.point=从transform向下射出一条线碰撞到你选择的物体的碰撞盒表面上的一个点
            if (hitInfo.collider.gameObject.CompareTag("Ground"))
            OnMouseClicked?.Invoke(hitInfo.point);
            float distance = Mathf.Abs(hitInfo.point.y - transform.position.y);
            print(hitInfo.point.y);
            
        }
    }
}
