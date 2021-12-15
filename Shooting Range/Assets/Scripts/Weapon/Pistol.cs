public class Pistol : Weapon
{
    private void OnEnable()
    {
        //PlayerInput.OnShootSingle += Shoot;
        InputManager.OnShootAuto += Shoot;
        InputManager.OnReload += ReloadAmmo;
        isReloading = false;
        animatior.SetBool("isReload", false);
    }
    private void OnDisable()
    {
        //PlayerInput.OnShootSingle -= Shoot;
        InputManager.OnShootAuto -= Shoot;
        InputManager.OnReload -= ReloadAmmo;
    }
}
