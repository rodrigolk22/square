using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transitionError : MonoBehaviour {

    public bool pattern;
    public bool selected;
    public Sprite standardFrame;
    public Sprite selectedFrame;
    public Sprite crackedFrame;
    public Level levelObject;

    // Realiza a transição inicial da aparencia do Square
    void Start()
    {
        //Exibe o botão vazio para destacar do padrão
        GetComponent<Image>().sprite = standardFrame;
        //Impede ações no botão
        GetComponent<Button>().interactable = false;
        //Realiza a espera e conclui o padrão
        StartCoroutine(showingFrame());
    }

    IEnumerator showingFrame()
    {
        // Aguarda por segundos
        yield return new WaitForSeconds(levelObject.timeToHidePattern);
        //Torna o botão clicável
        GetComponent<Button>().interactable = true;
    }
}
