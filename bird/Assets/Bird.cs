using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    [SerializeField]
    bool is_pressed = false;

    [SerializeField]
    Rigidbody2D rigid_bird;

    [SerializeField]
    Rigidbody2D shoot_rigid;

    [SerializeField]
    float max_distance = 2f;

    [SerializeField]
    GameObject bird_prefab;
    [SerializeField]
    Transform bird_spawn_pos;

    [SerializeField]
    Text text;

    private void Start()
    {
        rigid_bird = GetComponent<Rigidbody2D>();
        rigid_bird.isKinematic = true;
        rigid_bird.GetComponent<SpringJoint2D>().enabled = true;
    }
    private void Update()
    {
        if(is_pressed == true)
        {
            Vector2 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(Vector2.Distance(mouse_pos,shoot_rigid.position) > max_distance)
            {
                rigid_bird.position = shoot_rigid.position + (mouse_pos - shoot_rigid.position).normalized * max_distance;
            }
            else
            {
                rigid_bird.position = mouse_pos;
            }
        }
    }
    private void OnMouseDown()
    {
        is_pressed = true;
        rigid_bird.isKinematic = true;
    }
    private void OnMouseUp()
    {
        is_pressed = false;
        rigid_bird.isKinematic = false;
        text.text += "1";

        StartCoroutine(Lets_go());
    }
    IEnumerator Lets_go()
    {
        yield return new WaitForSeconds(0.1f);

        gameObject.GetComponent<SpringJoint2D>().enabled = false;
        

        yield return new WaitForSeconds(2);

        Instantiate(bird_prefab, bird_spawn_pos.position, bird_spawn_pos.rotation);
        Score.x += 1;
    }
}
