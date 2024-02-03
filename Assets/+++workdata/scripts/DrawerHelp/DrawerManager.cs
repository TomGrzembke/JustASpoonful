using UnityEngine;

namespace JustASpoonful
{
    public class DrawerManager : MonoBehaviour
    {
        [SerializeField] Sprite drawerOpen;
        [SerializeField] Sprite drawerClosed;
        [SerializeField] SpriteRenderer drawerSprite;
        [SerializeField] Collider2D drawerCollider;
        [SerializeField] Transform drawerTrans;
        [SerializeField] GameObject drawerHitbox;

        public void OnClick()
        {
            drawerSprite.sprite = drawerHitbox.activeSelf ? drawerClosed : drawerOpen;
            drawerHitbox.SetActive(!drawerHitbox.activeSelf);
            drawerCollider.enabled = !drawerHitbox.activeSelf;

        }
        public void OnDrag()
        {
            
        }
    }
}
