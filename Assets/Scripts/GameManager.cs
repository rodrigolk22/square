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
    public int currentErrors = 0;
    public static int currentHits = 0;
    //Variáveis para referência pois as funções alteram diretamente nas variáveis
    public LevelManager currentLevel;
    public Text infoGameUI;
    public GameObject title;
    public Text pointsUI;
    public Text errorUI;
    public Button nextLevelButton;
    public Button playButton;

    //Função modifica os parametros para construir novo nível
    public void nextLevel()
    {
        infoGameUI.text = "";
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

    //Checa o padrão do quadrado e encaminha para o procedimento correspondente
    public void selectedSquare(bool pattern)
    {
        if (pattern)
        {
            countPoint();
        }
        else
        {
            countError();
        }
    }
    //Realiza adiversas ações relacionadas a um padrão selecionado corretamente
    public void countPoint()
    {
        //Atualiza os pontos
        currentHits++;
        totalPoints++;
        //Atualiza a tela
        pointsUI.text = "Pontos: " + totalPoints;
        //Em caso de conclusão de fase
        if (currentLevel.numberOfPatterns <= currentHits)
        {
            //Limpa a tela
            GameObject[] squareObjects = GameObject.FindGameObjectsWithTag("ObjectToDestroy");
            int lenght = squareObjects.Length;
            for (int i = 0; i < lenght; i++)
            {
                Destroy(squareObjects[i]);
            }
            //Atualiza a tela de erros
            errorUI.text = "Erros: 0";
            infoGameUI.text = "Muito bom! Total de pontos: " + totalPoints;
            //Exibe um botão para que o jogador solicite uma nova fase
            nextLevelButton.gameObject.SetActive(true);
            //Reseta as ações da fase da fase
            currentErrors = 0;
            currentHits = 0;
        }
    }
    //Realiza diversas ações relacionadas a seleção errada
    public void countError()
    {
        //Atualiza os valores e a interface
        currentErrors++;
        errorUI.text = "Erros: " + currentErrors;
        //Checa se o jogador excedeu o limite de erros
        if (limitErrors <= currentErrors)
        {
            //Limpa a tela
            GameObject[] squareObjects = GameObject.FindGameObjectsWithTag("ObjectToDestroy");
            int lenght = squareObjects.Length;
            for (int i = 0; i < lenght; i++)
            {
                Destroy(squareObjects[i]);
            }
            //Exibe o botão de jogar novamente
            playButton.gameObject.SetActive(true);
            //Reseta as ações para um novo jogo
            currentErrors = 0;
            currentHits = 0;
            currentLevel.offSetAdjustamentY = currentLevel.offSetAdjustamentYDefault;
            currentLevel.offSetAdjustamentX = currentLevel.offSetAdjustamentXDefault;
            currentColumns = 0;
            currentLines = 0;
            toggleAxis = true;
            infoGameUI.text = "Fim de jogo! Total de pontos:  " + totalPoints;
            title.SetActive(true);
        }
    }
  
}
