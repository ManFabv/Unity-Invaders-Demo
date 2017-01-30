public class Literals : Singleton<Literals>
{
    protected Literals() { } //para que no pueda ser instanciada la clase

    /// <summary>
    /// 
    /// </summary>
    public static readonly string tagEnemy = "Enemy";

    /// <summary>
    /// 
    /// </summary>
    public static readonly string tagEnemyShot = "EnemyShot";

    /// <summary>
    /// 
    /// </summary>
    public static readonly string tagPlayerShot = "PlayerShot";

    /// <summary>
    /// 
    /// </summary>
    public static readonly string horizontalAxis = "Horizontal";

    /// <summary>
    /// 
    /// </summary>
    public static readonly string fireButton = "Fire1";

    /// <summary>
    /// 
    /// </summary>
    public static readonly string layerNamePlayerWeapon = "PlayerShot";

    /// <summary>
    /// 
    /// </summary>
    public static readonly string layerNamePlayer = "Player";

    /// <summary>
    /// 
    /// </summary>
    public static readonly float timeToInitPlayerInput = 1;

    /// <summary>
    /// 
    /// </summary>
    public static readonly string animatorNameToStartEnemyDeath = "Death";
}
