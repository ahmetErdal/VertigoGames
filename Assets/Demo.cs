using UnityEngine ;
using AeUI.PickerWheelUI;
using UnityEngine.UI ;
using TMPro;

public class Demo : MonoBehaviour
{
    public static Demo instance;
    private void Awake()
    {
        instance = this;
    }
    public int spinButtonCount;
    [SerializeField] private Button uiSpinButton ;
    [SerializeField] private TextMeshProUGUI uiSpinButtonText ;
    [SerializeField] private TextMeshProUGUI roundText;
    [SerializeField] private PickerWheel pickerWheel ;

    
    private void Start ()
    {
        uiSpinButton.onClick.AddListener (() => {
            spinButtonCount++;
            roundText.text = spinButtonCount.ToString() + "nd Round";
            uiSpinButton.interactable = false ;
            uiSpinButtonText.text = "Spinning" ;

            pickerWheel.OnSpinEnd (wheelPiece =>
            {
                wheelPiece.counter++;
                if (wheelPiece.Index==6)
                {
                    GiftsWon.instance.boomPanel.SetActive(true);
                    for (int i = 1; i < GiftsWon.instance.objects.Count; i++)
                    {
                        GiftsWon.instance.objects[i].GetComponent<Image>().enabled = false;
                        GiftsWon.instance.objects[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                    }
                }
                else
                {
                    GiftsWon.instance.earnedPanel.SetActive(true);
                    GiftsWon.instance.SwitchObject(wheelPiece.Index);

                }
                
                 GiftsWon.instance.WriteBoardWinningPiece(wheelPiece.didİtComeBefore, wheelPiece.Icon, wheelPiece.counter);
                Debug.Log (

                 @" <b>Index:</b> " + wheelPiece.Index + "           <b>Label:</b> " + wheelPiece.Label+"           <b>DidItBeforeCome</b> "+wheelPiece.didİtComeBefore
                 + "\n <b>Amount:</b> " + wheelPiece.Amount + "      <b>Chance:</b> " + wheelPiece.Chance + "%"
            ) ;
                 wheelPiece.didİtComeBefore = true;
            
             
                uiSpinButton.interactable = true ;
                uiSpinButtonText.text = "Spin" ;
         }) ;

         pickerWheel.Spin () ;
         
         
      }) ;

    }

}
