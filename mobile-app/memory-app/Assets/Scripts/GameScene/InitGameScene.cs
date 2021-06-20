using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InitGameScene : MonoBehaviour
{
    private string imageSetRootPath = "Images/TileSets";

    private string[] imageSetNameArr = new string[]{"Vegetables", "Vehicle", "Instruments"};


    void Start()
    {
        //скрываем панель выигрыша
        GameObject.Find("PanelBackground").SetActive(false);
        //скрываем объект подложку
        GameObject.Find("PlaneHider").SetActive(false);

        GlobalVars.init();
                
        //Загрузка текстур изображений
        loadTextures();

        //Рандомно формируем текстуры на материалы
        List<Material> materials = buildMaterials();

        //Присваиваем материалы для объектов типа Quad
        int j = 0;
        var imageSet = GameObject.Find("Cards").transform.Find("ImageSet");
        foreach (Transform line in imageSet.transform) {
            //find lines
            foreach (Transform cellBox in line.transform) {
                var quad = cellBox.transform.Find("Quad");
                quad.GetComponent<Renderer>().material = materials[j];
                j++;
            }
        }
    }


    private void loadTextures() {
        System.Random rnd = new System.Random();
        int rndIndex = rnd.Next(0, imageSetNameArr.Count());

        string imageSetName = imageSetNameArr[rndIndex];
        
        var textures = Resources.LoadAll(imageSetRootPath + "/" + imageSetName, typeof(Texture2D));
        int i = 0;
        foreach (var textureObj in textures) {
            i++;
            Material material = Resources.Load("Materials/mat" + i, typeof(Material)) as Material;
            material.SetTexture("_MainTex", (Texture2D) textureObj);
        }

    }

    private List<Material> buildMaterials() {
        List<Material> materials = new List<Material>();
        for (int i=1; i<=8; i++) {
            Material material = Resources.Load("Materials/mat" + i, typeof(Material)) as Material;
            materials.Add(material);
            materials.Add(material);
        }
        System.Random rnd = new System.Random();
        materials = materials.OrderBy(a => rnd.Next()).ToList();
        materials = materials.OrderBy(a => rnd.Next()).ToList();
        return materials;
    }
}
