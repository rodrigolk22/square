using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitApplication : MonoBehaviour {

    //Função que encerra a aplicação. Ela é chamada acionando o botão ExitGameButton.
    public void quitGame()
    {
        Application.Quit();
    }

}
