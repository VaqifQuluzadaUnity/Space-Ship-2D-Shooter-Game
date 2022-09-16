using DynamicBox.EventManagement;
using GalaxyDefenders.Managers;
using System.Collections;
using UnityEngine;

namespace GalaxyDefenders.Spawners
{
	public class PlayerRespawn : MonoBehaviour
	{
		[SerializeField] private Collider2D cannonCollider;
		[SerializeField] private float respawnTime = 2f;
		[SerializeField] private SpriteRenderer sprite;
		[SerializeField] ShopItemSO shipData;

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
			{
				return;
			}
			else if (other.collider.gameObject.layer == LayerMask.NameToLayer("Heart"))
			{
				EventManager.Instance.Raise(new LivesEvent(1));
			}
			else
			{
				EventManager.Instance.Raise(new LivesEvent(-1));
				Vibrator.Vibrate();
				StopAllCoroutines();
				StartCoroutine(Respawn());
			}
		}

		IEnumerator Respawn()
		{
			enabled = false;
			cannonCollider.enabled = false;
			ChangeSpriteAlpha(0.0f);

			yield return new WaitForSeconds(0.25f * respawnTime);

			enabled = true;
			ChangeSpriteAlpha(0.25f);

			yield return new WaitForSeconds(0.75f * respawnTime);

			ChangeSpriteAlpha(1.0f);
			cannonCollider.enabled = true;
		}

		private void ChangeSpriteAlpha(float value)
		{
			var color = sprite.color;
			color.a = value;
			sprite.color = color;
		}

		public void SetShipData(ShopItemSO _shipData)
		{

			shipData = _shipData;
		}

		private void OnEnable()
		{
			EventManager.Instance.AddListener<ChangePlayerShipEvent>(ChangePlayerShipEventHandler);
		}


		private void OnDisable()
		{
			EventManager.Instance.RemoveListener<ChangePlayerShipEvent>(ChangePlayerShipEventHandler);
		}

		private void ChangePlayerShipEventHandler(ChangePlayerShipEvent eventdetails)
		{
			sprite.sprite = shipData.ReturnItemSprite();
		}
	}
}
