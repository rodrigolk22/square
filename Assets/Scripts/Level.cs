using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Realiza a contrução da matriz de quadrados de acrodo com os parametros dados pelo Game Manager
public class Level : MonoBehaviour {

    public int sizeLines;
    public int sizeColumns;
    public int totalSquares;
    public int numberOfPatterns;
    public int timeToHidePattern = 2;
    private bool[,] pattern;
    public GameObject errorSquare;
    public GameObject patternSquare;
    public int offSetX;
    public int offSetY;
    public int offSetAdjustamentX;
    public int offSetAdjustamentY;
    public int offSetTile;
    private string newName;
    public Canvas gameCanvas;
    public GameObject[] squareObjects;

    public void createMatrix(){
        //Definindo uma matriz de padrões
        pattern = new bool[sizeLines, sizeColumns];
        //Definindo o número de padrões que serão inseridos
        totalSquares = (sizeLines * sizeColumns);
        numberOfPatterns = totalSquares / 3;
        //Variáveis auxiliares para sorteio do padrão
        int remaningPatterns = numberOfPatterns;
        int randomX;
        int randomY;
        while (remaningPatterns > 0)
        {
            //Função que faz o sorteio baseado nos limites dados
            randomX = Random.Range(0, sizeLines);
            randomY = Random.Range(0, sizeColumns);
            //Impede padrão seja marcado mais de uma vez na mesma posição
            if (pattern[randomX, randomY] == false)
            {
                pattern[randomX, randomY] = true;
                remaningPatterns--;
            }
        }
        //Criando os squares
        //Variaveis para auxiliar a identificação dos Squares
        int positionY = 0;
        int positionX = 0;
        //Instancia os Squares conforme a matriz de padrões
        for (int y = 0; y < sizeColumns; y++)
        {
            for (int x = 0; x < sizeLines; x++)
            {
                //Atualiza a posição do novo Square através de um objeto Vector que tem as coordenadas x, y e z
                Vector3 actualPosition = patternSquare.transform.position;
                actualPosition.x = (x * offSetTile) + offSetX + offSetAdjustamentX;
                actualPosition.y = (y * offSetTile) + offSetY + offSetAdjustamentY;
                actualPosition.z = 10;
                GameObject newSquareInstance;
                //Checa se é padrão
                if (pattern[x, y] == true)
                {
                   newSquareInstance = Instantiate(patternSquare) as GameObject;   
                }
                else
                {
                   newSquareInstance = Instantiate(errorSquare) as GameObject;
                }
                //Define o nome do novo Square
                newSquareInstance.name = "Square Y" + positionY + " X " + positionX;
                //Adiciona uma etiqueta para auxiliar a busca dos objetos que serão destruídos no final da fase
                newSquareInstance.tag = "ObjectToDestroy";
                //Posiciona dentro do Canvas para que o unity renderize o botão corretamente
                newSquareInstance.transform.SetParent(gameCanvas.transform, false);
                newSquareInstance.transform.position = actualPosition;
                positionX++;
            }
            positionY++;
        }
    }
    //Função que procura e remove os objetos (Squares) marcados como "ObjectToDestroy"
    public void clean()
    {
        squareObjects = GameObject.FindGameObjectsWithTag("ObjectToDestroy");
        int lenght = squareObjects.Length;
        for(int i = 0; i < lenght; i++)
        {      
            Destroy(squareObjects[i]);
        }
    }
}
