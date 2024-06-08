using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
public class SpawnFruits : MonoBehaviour
{
    public bool Have2Area;
    public GameObject[] Fruits;
    public Sprite[] FruitsSprite;
    public Camera cam;
    int RandomFruits;
    int RandomFruits2;
    public Image NextFruitImg;
    public Image NextFruitImg2;
    public Rect SpawnArea;
    public Rect SpawnArea2;
    private float clicktime = 1f;


    public GameObject PropertiesSystem;

    public RectTransform[] rectTransforms;

    void OnDrawGizmosSelected()//spawnalanýný gösterir
    {
        // Rect'in köþelerini hesapla
        Vector3 topLeft = new Vector3(SpawnArea.xMin, SpawnArea.yMin);
        Vector3 topRight = new Vector3(SpawnArea.xMax, SpawnArea.yMin);
        Vector3 bottomLeft = new Vector3(SpawnArea.xMin, SpawnArea.yMax);
        Vector3 bottomRight = new Vector3(SpawnArea.xMax, SpawnArea.yMax);

        // Köþeler arasýnda çizgi çiz
        Gizmos.color = Color.green;
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);


        // Rect'in köþelerini hesapla
        Vector3 topLeft2 = new Vector3(SpawnArea2.xMin, SpawnArea2.yMin);
        Vector3 topRight2 = new Vector3(SpawnArea2.xMax, SpawnArea2.yMin);
        Vector3 bottomLeft2 = new Vector3(SpawnArea2.xMin, SpawnArea2.yMax);
        Vector3 bottomRight2 = new Vector3(SpawnArea2.xMax, SpawnArea2.yMax);

        // Köþeler arasýnda çizgi çiz
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(topLeft2, topRight2);
        Gizmos.DrawLine(topRight2, bottomRight2);
        Gizmos.DrawLine(bottomRight2, bottomLeft2);
        Gizmos.DrawLine(bottomLeft2, topLeft2);
    }
    private void Start()
    {
        RandomFruits = Random.Range(0, Fruits.Length);
        RandomFruits2 = Random.Range(0, Fruits.Length);
        NextFruitImg.sprite = FruitsSprite[RandomFruits];
        NextFruitImg2.sprite = FruitsSprite[RandomFruits2];

    }

    // Update is called once per frame
    void Update()
    {
        //OnDrawGizmosSelected();

        clicktime -= Time.deltaTime;
        
        if (clicktime <= 0f)
        {
            if (Input.touchCount > 0)
            {
                bool canupgrade = PropertiesSystem.GetComponent<UpgradeFruit>().canUpgrade;
                bool candestroy = PropertiesSystem.GetComponent<ShootFruit>().canDestroy;

                if (!candestroy && !canupgrade && ClickingSelfOrChild()&& Time.timeScale ==1)
                {
                    Touch touch = Input.GetTouch(0);
                    Vector2 touchpos = cam.ScreenToWorldPoint(touch.position);
                    Vector2 Bornpos = new Vector2(touchpos.x, 4f);
                    if (touch.phase == TouchPhase.Began)
                    {

                        if ((SpawnArea.Contains(touchpos))||(SpawnArea2.Contains(touchpos) && Have2Area)) // Dokunma alaný spawn alaný içinde mi kontrol et
                        {
                            Instantiate(Fruits[RandomFruits], Bornpos, Quaternion.identity);

                            RandomFruits = RandomFruits2;
                            NextFruitImg.sprite = FruitsSprite[RandomFruits];
                            RandomFruits2 = Random.Range(0, Fruits.Length);
                            NextFruitImg2.sprite = FruitsSprite[RandomFruits2];

                            clicktime = .5f;
                        }

                    }
                }
                
            }

        }
        
    }

    public void ChangeFruits()
    {
        RandomFruits = Random.Range(0, Fruits.Length);
        RandomFruits2 = Random.Range(0, Fruits.Length);
        NextFruitImg.sprite = FruitsSprite[RandomFruits];
        NextFruitImg2.sprite = FruitsSprite[RandomFruits2];
    }

    private bool ClickingSelfOrChild()
    {
       
        foreach (RectTransform rectTransform in rectTransforms)
        {
            if (EventSystem.current.currentSelectedGameObject == rectTransform.gameObject)
            {
                return false;
            };
        }
        return true;
    }
}
