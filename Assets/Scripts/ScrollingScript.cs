using System.Collections.Generic;
using System.Linq;
using UnityEngine;


/// <summary>
/// Parallax scrolling script that should be assigned to a layer
/// </summary>
public class ScrollingScript : MonoBehaviour
{
    /// <summary>
    /// Скорость перемещения 
    /// </summary>
    public float speed = 1;

    /// <summary>
    /// Направление перемещения
    /// </summary>
    public DirectionType direction = DirectionType.left;

    /// <summary>
    /// Список префабов фонов
    /// </summary>
    public List<GameObject> backGroundPrefab;

    /// <summary>
    /// Список инициализованных на сцене фонов
    /// </summary>
    public List<Transform> initBackGround;

    public enum DirectionType { left, right, up, down };


    void Update()
    {

        // Находим границы камеры в World Space координатах
        var dist = (transform.position - Camera.main.transform.position).z;
        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        float topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        float bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

        // Получаем первый и последний элемент
        Transform lastBackGround = initBackGround.Last();
        Transform firstBackGround = initBackGround.First();
        SpriteRenderer spriteRendererLastBackGround = lastBackGround.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRendererFirstBackGround = firstBackGround.GetComponent<SpriteRenderer>();

        // Определяем какие границы являются входными и выходными, и определяем направление движения фона
        Vector3 exitBorder = Vector3.zero;
        Vector3 entryBorder = Vector3.zero;
        Vector3 movement = Vector3.zero;
        switch (direction)
        {
            case DirectionType.left:
                {
                    exitBorder.x = leftBorder;
                    entryBorder.x = rightBorder;
                    movement = speed * Vector3.left;

                    //Добавление нового фона в тот момент когда последний перескает входную границу эрана своей правой стороной
                    if (lastBackGround.position.x + spriteRendererLastBackGround.sprite.bounds.extents.x < entryBorder.x)
                    {
                        float x = lastBackGround.position.x + spriteRendererLastBackGround.sprite.bounds.extents.x + backGroundPrefab[0].GetComponent<SpriteRenderer>().sprite.bounds.extents.x;
                        int index = Random.Range(0, backGroundPrefab.Count);
                        Vector3 startPos = new Vector3(x, lastBackGround.position.y, lastBackGround.position.z);
                        GameObject initObj = (GameObject)Instantiate(backGroundPrefab[index], startPos, backGroundPrefab[index].transform.rotation);
                        initBackGround.Add(initObj.transform);
                    }

                    //Удаление первого фона в тот момент когда его правая сторона пересекает выходную границу эрана
                    if (firstBackGround.position.x + firstBackGround.GetComponent<SpriteRenderer>().sprite.bounds.extents.x < exitBorder.x)
                    {
                        initBackGround.Remove(firstBackGround);
                        Destroy(firstBackGround.gameObject);
                    }


                    break;
                }
            case DirectionType.right:
                {
                    exitBorder.x = rightBorder;
                    entryBorder.x = leftBorder;
                    movement = speed * Vector3.right;

                    //Добавление нового фона в тот момент когда последний перескает входную границу эрана своей левой стороной
                    if (lastBackGround.position.x - spriteRendererLastBackGround.sprite.bounds.extents.x > entryBorder.x)
                    {
                        float x = lastBackGround.position.x - spriteRendererLastBackGround.sprite.bounds.extents.x - backGroundPrefab[0].GetComponent<SpriteRenderer>().sprite.bounds.extents.x;
                        int index = Random.Range(0, backGroundPrefab.Count);
                        Vector3 startPos = new Vector3(x, lastBackGround.position.y, lastBackGround.position.z);
                        GameObject initObj = (GameObject)Instantiate(backGroundPrefab[index], startPos, backGroundPrefab[index].transform.rotation);
                        initBackGround.Add(initObj.transform);
                    }

                    //Удаление первого фона в тот момент когда его левая сторона пересекает выходную границу эрана
                    if (firstBackGround.position.x - firstBackGround.GetComponent<SpriteRenderer>().sprite.bounds.extents.x > exitBorder.x)
                    {
                        initBackGround.Remove(firstBackGround);
                        Destroy(firstBackGround.gameObject);
                    }

                    break;
                }
            case DirectionType.up:
                {
                    exitBorder.y = bottomBorder;
                    entryBorder.y = topBorder;
                    movement = speed * Vector3.up;

                    //Добавление нового фона в тот момент когда последний перескает входную границу эрана своей нижней стороной
                    if (lastBackGround.position.y - spriteRendererLastBackGround.sprite.bounds.extents.y > entryBorder.y)
                    {
                        float y = lastBackGround.position.y - spriteRendererLastBackGround.sprite.bounds.extents.y- backGroundPrefab[0].GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
                        int index = Random.Range(0, backGroundPrefab.Count);
                        Vector3 startPos = new Vector3(lastBackGround.position.x, y, lastBackGround.position.z);
                        GameObject initObj = (GameObject)Instantiate(backGroundPrefab[index], startPos, backGroundPrefab[index].transform.rotation);
                        initBackGround.Add(initObj.transform);
                    }

                    //Удаление первого фона в тот момент когда его нижняя сторона пересекает выходную границу эрана
                    if (firstBackGround.position.y - firstBackGround.GetComponent<SpriteRenderer>().sprite.bounds.extents.y > exitBorder.y)
                    {
                        initBackGround.Remove(firstBackGround);
                        Destroy(firstBackGround.gameObject);
                    }

                    break;
                }
            case DirectionType.down:
                {
                    exitBorder.y = topBorder;
                    entryBorder.y = bottomBorder;
                    movement = speed * Vector3.down;

                    //Добавление нового фона в тот момент когда последний перескает входную границу эрана своей верхней стороной
                    if (lastBackGround.position.y + spriteRendererLastBackGround.sprite.bounds.extents.y < entryBorder.y)
                    {
                        float y = lastBackGround.position.y + spriteRendererLastBackGround.sprite.bounds.extents.y + backGroundPrefab[0].GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
                        int index = Random.Range(0, backGroundPrefab.Count);
                        Vector3 startPos = new Vector3(lastBackGround.position.x, y, lastBackGround.position.z);
                        GameObject initObj = (GameObject)Instantiate(backGroundPrefab[index], startPos, backGroundPrefab[index].transform.rotation);
                        initBackGround.Add(initObj.transform);
                    }

                    //Удаление первого фона в тот момент когда его верхняя сторона пересекает выходную границу эрана
                    if (firstBackGround.position.y + firstBackGround.GetComponent<SpriteRenderer>().sprite.bounds.extents.y < exitBorder.y)
                    {
                        initBackGround.Remove(firstBackGround);
                        Destroy(firstBackGround.gameObject);
                    }

                    break;
                }
        }

        //Придаем движение фону
        movement *= Time.deltaTime;
        foreach (Transform background in initBackGround)
        {
            background.Translate(movement);
        }

     
    }
}
