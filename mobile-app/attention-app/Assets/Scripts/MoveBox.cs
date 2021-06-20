using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    // Start is called before the first frame update
    private Renderer renderer;
    // private bool isShow = false;
    private int itemIndex;

    void Start()
    {
        renderer = GetComponent<Renderer>();

        //Начальная позиция объекта
        switch (GlobalVars.lastShowIndex) {
            case 0:
                transform.position = new Vector3(3, transform.parent.position.y, transform.parent.position.z);
                break;
            case 1:
                transform.position = new Vector3(4, transform.parent.position.y, transform.parent.position.z);
                break;
            case 2:
                transform.position = new Vector3(5, transform.parent.position.y, transform.parent.position.z);
                break;
            case 3:
                transform.position = new Vector3(6, transform.parent.position.y, transform.parent.position.z);
                break;
            case 4:
                transform.position = new Vector3(7, transform.parent.position.y, transform.parent.position.z);
                break;
        }
        changeMaterial();
    }



    void Update()
    {
        //update color
            // renderer.material.color = Color.black;


    //     var planes: Plane[] = GeometryUtility.CalculateFrustumPlanes(Camera.main);
    //  if (GeometryUtility.TestPlanesAABB(planes,renderer.bounds))
    //      Debug.Log("Object inside frustum");
    //  else
    //      Debug.Log("Object not visible");

        // Debug.Log("pos: x=" + transform.position.x + "; y=" + transform.position.y + "; z=" + transform.position.z);
        // Debug.Log("pos: x=" + transform.position.x + "; isVisible=" + renderer.isVisible);

        //Если вышли за границы видимости - то перемещаем в другую сторону и меняем материал
        if (!renderer.isVisible) {
            if (transform.position.x < 0) {
                float lastPosition = getLastBoxPosition();
                transform.position = new Vector3(lastPosition + 1, transform.parent.position.y, transform.parent.position.z);
                if (GlobalVars.lastShowIndex < GlobalVars.itemList.Count) {
                    changeMaterial();
                }
            }
        }
    }


    private void changeMaterial() {
        string materialName = string.Empty;

        switch (GlobalVars.itemList[GlobalVars.lastShowIndex].type) {
            case "1":
                materialName = "r1";
                break;
            case "2":
                materialName = "r2";
                break;
            case "3":
                materialName = "r3";
                break;
            case "4":
                materialName = "r4";
                break;
            case "5":
                materialName = "r5";
                break;
        }
        // Debug.Log("lastShowIndex=" + GlobalVars.lastShowIndex + "; materialName=" + materialName);
                // Debug.Log("lastShowIndex=" + GlobalVars.lastShowIndex + "; item=" + GlobalVars.itemList[GlobalVars.lastShowIndex].type);


        Material material = Resources.Load("Materials/" + materialName, typeof(Material)) as Material;
        renderer.material = material;

        GlobalVars.lastShowIndex++;
        // Debug.Log("Color: " + material.color.r.ToString() + "; " + material.color.g.ToString() + "; " + material.color.b.ToString());
    }


    private float getLastBoxPosition() {
        GameObject box1 = GameObject.Find("Box1");
        GameObject box2 = GameObject.Find("Box2");
        GameObject box3 = GameObject.Find("Box3");
        GameObject box4 = GameObject.Find("Box4");
        GameObject box5 = GameObject.Find("Box5");
        float res = 0;
        res = System.Math.Max(res, box1.transform.position.x);
        res = System.Math.Max(res, box2.transform.position.x);
        res = System.Math.Max(res, box3.transform.position.x);
        res = System.Math.Max(res, box4.transform.position.x);
        res = System.Math.Max(res, box5.transform.position.x);
        return res;
    }
}
