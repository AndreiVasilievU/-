using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Generator : MonoBehaviour
{
    const int ROWS = 5;
    const int COLUMNS = 10;

    const float CELL_SIZE = 1.5f;

    [SerializeField]
    GameObject[] figurePrefab;

    [SerializeField]
    Text text;

    int[,] figures_matrix;

    List<GameObject> prefabs = new List<GameObject>();

    int miss = 0;
    int max_color = 0;

    int max_green;
    int max_blue;
    int max_white;
    int max_red;

    int token = 0;

    bool is_click = false;

    void Start()
    {
        figures_matrix = new int[ROWS, COLUMNS];
        for(int row = 0; row <ROWS; row++)
        {
            for(int col =0; col < COLUMNS; col++)
            {
                bool _need_create = Random.Range(0, 2) > 0;
                if (_need_create)
                {
                    var _figure_object = Instantiate(figurePrefab[Random.Range(0,16)]);
                    Vector3 _random_offset = new Vector3(Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f));
                    _figure_object.transform.position = new Vector3(CELL_SIZE * col, CELL_SIZE * row) + _random_offset;
                    prefabs.Add(_figure_object);
                }
            }
        }       
    }

    void Update()
    {
            if (is_click == false)
            {
                max_green = 0;
                max_blue = 0;
                max_white = 0;
                max_red = 0;
                max_color = 0;
            }
            Delete();
        if(token == 3)
        {
            Invoke("Load", 2f);
        }
        Debug.Log(token);
    }
    public void Check(string color)
    {
        is_click = true;
        foreach (var item in prefabs)
        {
            if (item.activeSelf)
            {
                if (color == item.tag)
                {
                    max_color += 1;
                }
                if (item.tag == "green")
                {
                    max_green += 1;
                }
                if (item.tag == "blue")
                {
                    max_blue += 1;
                }
                if (item.tag == "white")
                {
                    max_white += 1;
                }
                if (item.tag == "red")
                {
                    max_red += 1;
                }
            }
        }        
    }
    void Delete()
    {
        if (max_color != 0)
        {
            if (max_color == max_green && max_color >= max_blue && max_color >= max_white && max_color >= max_red)
            {
                foreach (var item in prefabs)
                {
                    if (item.tag == "green")
                    {
                        item.SetActive(false);
                        is_click = false;
                    }
                }
                token += 1;
            }
            else if (max_color == max_blue && max_color >= max_green && max_color >= max_white && max_color >= max_red)
            {
                foreach (var item in prefabs)
                {
                    if (item.tag == "blue")
                    {
                        item.SetActive(false);
                        is_click = false; 
                    }
                }
                token += 1;
            }
            else if (max_color == max_white && max_color >= max_blue && max_color >= max_green && max_color >= max_red)
            {
                foreach (var item in prefabs)
                {
                    if (item.tag == "white")
                    {
                        item.SetActive(false);
                        is_click = false;
                    }
                }
                token += 1;
            }
            else if (max_color == max_red && max_color >= max_blue && max_color >= max_white && max_color >= max_green)
            {
                foreach (var item in prefabs)
                {
                    if (item.tag == "red")
                    {
                        item.SetActive(false);
                        is_click = false;  
                    }
                }
                token += 1;
            }
            else
            {
                miss += 1;
                is_click = false;
                Debug.Log(miss);
                text.text = "Miss: " + miss.ToString();
            }
        }
    }
    void Load()
    {
        SceneManager.LoadScene(0);
    }
}
