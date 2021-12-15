public class Rifle : Weapon
{
    private void OnEnable()
    {
        PlayerInput.OnShootAuto += Shoot;
        PlayerInput.OnReload += ReloadAmmo;
        isReloading = false;
        animatior.SetBool("isReload", false);
    }
    private void OnDisable()
    {
        PlayerInput.OnShootAuto -= Shoot;
        PlayerInput.OnReload -= ReloadAmmo;
    }
}
