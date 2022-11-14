using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using AeUI.PickerWheelUI;
public class GiftsWon : MonoBehaviour
{
    #region singelton
    public static GiftsWon instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    #region Objects
    [Header("Win Objects")]
    public GameObject deathZone;
    public GameObject armor;
    public GameObject knife;
    public GameObject pistol;
    public GameObject riffle;
    public GameObject sniper;
    public GameObject vest;
    public GameObject submachine;
    #endregion
    public List<GameObject> objects;
    public List<GameObject> earnedObjects;
    public TextMeshProUGUI earnedText;
    public Image earnedImage;
    public GameObject earnedPanel;
    public GameObject boomPanel;

    [SerializeField] private Transform wheelObjectsTransform;
   

    public void SwitchObject(int itemNumber)
    {


        switch (itemNumber)
        {
            case 0:
                earnedImage.GetComponent<Image>().sprite = armor.GetComponent<SpriteRenderer>().sprite;
                earnedText.text = "Congratulations! Item you earn armor piece ";

                break;
            case 1:
                earnedImage.GetComponent<Image>().sprite = knife.GetComponent<SpriteRenderer>().sprite;
                earnedText.text = "Congratulations! Item you earn knife piece ";

                break;
            case 2:
                earnedImage.GetComponent<Image>().sprite = pistol.GetComponent<SpriteRenderer>().sprite;
                earnedText.text = "Congratulations! Item you earn pistol piece ";
                break;
            case 3:
                earnedImage.GetComponent<Image>().sprite = riffle.GetComponent<SpriteRenderer>().sprite;
                earnedText.text = "Congratulations! Item you earn riffle piece ";
                break;
            case 4:
                earnedImage.GetComponent<Image>().sprite = sniper.GetComponent<SpriteRenderer>().sprite;
                earnedText.text = "Congratulations! Item you earn sniper piece ";
                break;
            case 5:
                earnedImage.GetComponent<Image>().sprite = submachine.GetComponent<SpriteRenderer>().sprite;
                earnedText.text = "Congratulations! Item you earn submachine piece ";
                break;
            case 6:
                if (Demo.instance.spinButtonCount!=0&&Demo.instance.spinButtonCount%5==0)
                {
                    earnedImage.GetComponent<Image>().sprite = armor.GetComponent<SpriteRenderer>().sprite;
                    earnedText.text = "Congratulations! Item you earn armor piece ";
                }
                else
                {
                    earnedImage.GetComponent<Image>().sprite = deathZone.GetComponent<SpriteRenderer>().sprite;
                    earnedText.text = "Boom".ToString();
                }
              
                break;
            case 7:
                earnedImage.GetComponent<Image>().sprite = pistol.GetComponent<Image>().sprite;
                earnedText.text = "Congratulations! Item you earn pistol piece ";
                break;
            default:
                break;
        }

    }
    public void ClosePanel()
    {

        earnedPanel.SetActive(false);
        if (Demo.instance.spinButtonCount != 0 && Demo.instance.spinButtonCount % 5 == 0)
        {
            wheelObjectsTransform.GetChild(6).GetChild(0).GetChild(0).GetComponent<Image>().sprite = armor.GetComponent<SpriteRenderer>().sprite;
            wheelObjectsTransform.GetChild(6).GetChild(0).GetChild(1).GetComponent<Text>().text = "Armor".ToString();

            //PickerWheel.instance.Generate();
            //PickerWheel.instance.CalculateWeightsAndIndices();
        }
        else
        {
            wheelObjectsTransform.GetChild(6).GetChild(0).GetChild(0).GetComponent<Image>().sprite = deathZone.GetComponent<SpriteRenderer>().sprite;
            wheelObjectsTransform.GetChild(6).GetChild(0).GetChild(1).GetComponent<Text>().text = "Boom".ToString();
        }
      
       
    }
    public void WriteBoardWinningPiece(bool did, Sprite icon, int counter)
    {
        if (!did)
        {
            GameObject emptyListOfObject;
            for (int i = 0; i < objects.Count; i++)
            {
                if (!objects[i].GetComponent<ListOfObjects>().didItUseBefore)
                {
                    emptyListOfObject = objects[i];
                    emptyListOfObject.GetComponent<ListOfObjects>().listIcon.GetComponent<Image>().sprite = icon;
                    emptyListOfObject.GetComponent<ListOfObjects>().listIcon.GetComponent<Image>().enabled = true;
                    emptyListOfObject.GetComponent<ListOfObjects>().countX = counter;
                    emptyListOfObject.GetComponent<ListOfObjects>().textCount.GetComponent<TextMeshProUGUI>().enabled = true;
                    emptyListOfObject.GetComponent<ListOfObjects>().didItUseBefore = true;
                    earnedObjects.Add(objects[i]);
                    objects.Remove(objects[i]);
                    return;
                }
                else
                {

                    return;
                }


            }


        }
    }
}
