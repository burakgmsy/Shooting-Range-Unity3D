public class Rifle : Weapon
{
    private void OnEnable()
    {
        InputManager.OnShootAuto += Shoot;
        InputManager.OnReload += ReloadAmmo;
        isReloading = false;
        animatior.SetBool("isReload", false);
    }
    private void OnDisable()
    {
        InputManager.OnShootAuto -= Shoot;
        InputManager.OnReload -= ReloadAmmo;
    }
}
