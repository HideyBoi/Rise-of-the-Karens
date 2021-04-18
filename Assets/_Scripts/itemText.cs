using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class itemText : MonoBehaviour
{
    public itemAccept Karen;
    public TextMeshProUGUI text;

    void FixedUpdate()
    {
        text.text = Karen.productName;
    }

}
