using UnityEngine;
using DG.Tweening;

public enum StarType
{
    Bronze,
    Silver,
    Gold
}

public class StarManager : MonoBehaviour
{
    public static StarManager Instance;

    public int bronzeStarPoint = 10;
    public int silverStarPoint = 20;
    public int goldStarPoint = 50;

    [System.Serializable]
    public struct StarData
    {
        public GameObject sourceType;
        public StarType type;
    }

    public StarData[] starData;

    private StarType currentStartType;

    void Awake()
    {
        Instance = this;
    }

    void DeactiveStar(StarType starType)
    {
        GameObject startObject = GetStar(starType);
        startObject.SetActive(false);
    }

    StarType ActiveStar(StarType starType)
    {
        GameObject startObject = GetStar(starType);
        startObject.SetActive(true);

        startObject.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack);

        return starType;
    }

    public void EvalActiveStar()
    {
        int hightScore = ScoreManager.Instance.GetHighScore();

        if (hightScore >= bronzeStarPoint && hightScore < silverStarPoint)
        {
            ActiveStar(StarType.Bronze);
        }
        else if (hightScore >= silverStarPoint && hightScore < goldStarPoint)
        {
            ActiveStar(StarType.Silver);
        }
        else if (hightScore >= 50)
        {
            ActiveStar(StarType.Gold);
        }
    }

    public void UpdateStar(float hightScore)
    {
        if (hightScore >= bronzeStarPoint && hightScore < silverStarPoint)
        { 
            if(currentStartType != StarType.Bronze)
            {
                ActiveStar(StarType.Bronze);
            }
        }
        else if (hightScore >= silverStarPoint && hightScore < goldStarPoint)
        {
            if(currentStartType != StarType.Silver)
            {
                DeactiveStar(currentStartType);
                currentStartType = ActiveStar(StarType.Silver);
            }
        }
        else if (hightScore >= goldStarPoint)
        {
            if(currentStartType != StarType.Gold)
            {
                DeactiveStar(currentStartType);
                currentStartType = ActiveStar(StarType.Gold);
            }
        }
    }

    GameObject GetStar(StarType starType)
    {
        foreach (StarData star in starData)
        {
            if(star.type == starType)
                return star.sourceType;
        }
        Debug.LogWarning("StarManager: not reference to starType " + starType);
        return null;
    }
}
