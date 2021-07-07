using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    private int score;  //�������� ������
    [SerializeField]
    Text scoreText; //��������� Text ��� ����������� ������

    private int countSpawnedOblects; //�������� ���������� ������������ ��������
    [SerializeField]
    Text countSpawnedObjectsText; //��������� Text ��� ����������� �������� ��������� ���������� ��������

    private int currentLife; //������� ���������� ������
    [SerializeField]
    Text currentLifeText; //��������� Text ��� ����������� �������� ��������� ������


    public Text ScoreText { get; set; }
    public Text CountAsteroidsText { get; set; }
    public Text CurrentLifeText { get ; set; }

    /// <summary>
    /// ����� ���������� �������� ������
    /// </summary>
    /// <param name="newScore"></param>
    public void UpdateScore(int newScore)
    {
        scoreText.text = newScore.ToString();
    }

    /// <summary>
    /// ����� ���������� ����� ���������� ��������
    /// </summary>
    /// <param name="newCount"></param>
    public void UpdateCountSpawnedObjects(int newCount)
    {
        countSpawnedObjectsText.text = newCount.ToString();
    }

    /// <summary>
    /// ����� ���������� ���������� ������
    /// </summary>
    /// <param name="newCount"></param>
    public void UpdateCurrentLife(int newCount)
    {
        currentLifeText.text = newCount.ToString();
    }

}
