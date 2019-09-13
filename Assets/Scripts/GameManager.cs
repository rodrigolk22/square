using UnityEngine;
using UnityEngine.UI;

//Game Manager faz o gerenciamento das telas e níveis do jogo
public class GameManager : MonoBehaviour {

    public int initialLines = 3;
    public int initialColumns = 2;
    public int limitErrors = 3;
    public int currentLines;
    public int currentColumns;
    public int totalPoints = 0;
    private bool toggleAxis = true;
    //Variáveis para referência
    public Text resultGameUI;
    public LevelManager currentLevel;
    
    //Durante a execução do jogo, apertar o botão "Esc" permite encerrar a aplicação
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            quitGame();
        }
    }
    //Função que encerra a aplicação. Ela é chamada acionando o botão ExitGameButton.
    public void quitGame()
    {
        Application.Quit();
    }
    //Função modifica os parametros para construir novo nível
    public void nextLevel()
    {
        //Adiciona alternadamente as linhas e colunas e faz ajuste de posição na tela
        if (toggleAxis == true)
        {
            currentColumns++;
            currentLevel.offSetAdjustamentY -= 10;
            toggleAxis = false;
        }
        else
        {
            currentLines++;
            currentLevel.offSetAdjustamentX -= 16;
            toggleAxis = true;
        }
        currentLevel.sizeColumns = initialColumns + currentColumns;
        currentLevel.sizeLines = initialLines + currentLines;
        currentLevel.createMatrix();
    }
	//Realiza o reset dos atributos e informa o jogador o total de pontos
	public void gameOver()
    {
        currentLevel.offSetAdjustamentY = currentLevel.offSetAdjustamentYDefault;
        currentLevel.offSetAdjustamentX = currentLevel.offSetAdjustamentXDefault;
        currentColumns = 0;
        currentLines = 0;
        toggleAxis = true;
        resultGameUI.text = "Fim de jogo! Total de pontos:  " + totalPoints;
    }

}
