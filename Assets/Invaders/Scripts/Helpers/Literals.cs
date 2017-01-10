public class Literals : Singleton<Literals>
{
    protected Literals() { } //para que no pueda ser instanciada la clase

    /// <summary>
    /// Referencia al layer de las armas de los enemigos
    /// </summary>
    public static readonly string tagEnemyShot = "EnemyShot";

    /// <summary>
    /// Referencia al layer de las armas del jugador
    /// </summary>
    public static readonly string tagPlayerShot = "PlayerShot";

    /// <summary>
    /// Referencia al layer de las armas del jugador
    /// </summary>
    public static readonly string horizontalAxis = "Horizontal";

    /// <summary>
    /// Referencia al layer de las armas del jugador
    /// </summary>
    public static readonly string fireButton = "Fire1";

    /// <summary>
    /// Referencia al layer de las armas del jugador
    /// </summary>
    public static readonly string layerNamePlayerWeapon = "PlayerShot";

    /// <summary>
    /// Referencia al layer del jugador
    /// </summary>
    public static readonly string layerNamePlayer = "Player";

    /// <summary>
    /// 
    /// </summary>
    public static readonly float timeToInitPlayerInput = 1;
}
