using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transition : MonoBehaviour
{
    public bool pattern;
    public bool selected;
    public Sprite standardFrame;
    public Sprite selectedFrame;
    public Sprite crackedFrame;
    public Level levelObject;

    //Realiza a transição inicial da aparencia do Square
    void Start()
    {
        //Exibe o padrão
        GetComponent<Image>().sprite = selectedFrame;
        //Impede ações no botão
        GetComponent<Button>().interactable = false;
        //Realiza a espera e conclui o padrão
        StartCoroutine(showingFrame());
    }

    IEnumerator showingFrame()
    {
        //Aguarda por segundos
        yield return new WaitForSeconds(levelObject.timeToHidePattern);
        //Esconde o padrão
        GetComponent<Image>().sprite = standardFrame;
        //Torna o botão clicável
        GetComponent<Button>().interactable = true;
    }

}
