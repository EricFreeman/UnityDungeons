using UnityEngine;

namespace Assets.Resources.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        private Vector3 _movePosition;
        public float Speed = 3;

        private bool _isPositionSet;

        void Update()
        {
            CheckForNewPosition();

            // TODO: Do actual pathfinding here instead of just walking through walls!
            if(_isPositionSet)
                transform.position = Vector3.MoveTowards(transform.position, _movePosition, Speed * Time.deltaTime);
        }

        private void CheckForNewPosition()
        {
            if (Input.GetMouseButtonDown(0))
            {
                CheckForTile(Camera.main.ScreenPointToRay(Input.mousePosition));
            }
            if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
                CheckForTile(new Ray(transform.position - new Vector3(Input.GetAxisRaw("Horizontal"), -.1f, Input.GetAxisRaw("Vertical")), Vector3.down));
            
        }

        private void CheckForTile(Ray pos)
        {
            RaycastHit hit;
            if (Physics.Raycast(pos, out hit))
            {
                _isPositionSet = true;
                _movePosition = hit.collider.transform.position;
            }
        }
    }
}