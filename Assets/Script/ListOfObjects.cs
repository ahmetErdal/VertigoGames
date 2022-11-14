using UnityEngine;
using TMPro;

    public class ListOfObjects : MonoBehaviour
    {
    public TextMeshProUGUI textCount;
        public GameObject listIcon;
        public int countX;
        public bool didItUseBefore = false;
    private void Update()
    {
        textCount.text = countX.ToString()+"x";
    }
}
