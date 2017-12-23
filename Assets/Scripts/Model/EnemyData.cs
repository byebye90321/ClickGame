//純資料結構的class
[System.Serializable] //序列化 可以被儲存的格式
public class EnemyData{
    public int health;
    public int willDropItemId; //寶物
    public float dropProbability; //掉寶率
    public float defeatTimeLimit;
    public EnemyBehavoir enemyPrefab;
}
