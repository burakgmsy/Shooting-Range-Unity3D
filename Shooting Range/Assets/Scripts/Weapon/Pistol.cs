public class Pistol : Weapon
{
    private void OnEnable()
    {
        //PlayerInput.OnShootSingle += Shoot;
        PlayerInput.OnShootAuto += Shoot;
        PlayerInput.OnReload += ReloadAmmo;
        isReloading = false;
        animatior.SetBool("isReload", false);
    }
    private void OnDisable()
    {
        //PlayerInput.OnShootSingle -= Shoot;
        PlayerInput.OnShootAuto -= Shoot;
        PlayerInput.OnReload -= ReloadAmmo;
    }
}
