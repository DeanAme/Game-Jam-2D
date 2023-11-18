using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    Rigidbody2D rbody;              //刚体
    public float speed = 2f;       //速度
    
    private bool isGround;                  //是否在地面

    /// <summary>
    /// 跳跃参数
    /// </summary>
    /// 

    public float jumpSpeed = 4f;
    public float fallSpeed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //跳跃
        //Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayerMask);

        float moveX = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space)  && rbody.velocity.y == 0)
        {
            Jump();
        }
        else if (rbody.velocity.y <= 0)
        {
            Fall();
        }

        if ( moveX != 0)
        {

            float move = moveX * speed;
            rbody.velocity = Vector2.right * move;
        } 
        else { 

            //水平移动
            //float moveX = Input.GetAxisRaw("Horizontal");
            //float moveY = Input.GetAxisRaw("Vertical");
            //float move = speed * Time.deltaTime;
            //rbody.velocity = Vector2.right * move;
            //rbody.MovePosition()
        
        }
    }

    private void Jump()     
    {
        rbody.velocity = Vector2.up * jumpSpeed;
    }
    private void Fall()
    {
        Physics2D.gravity = new Vector2( 0, -9.8f * fallSpeed);
    }
}
