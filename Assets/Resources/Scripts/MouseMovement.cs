using System.Collections.Generic;
using UnityEngine;

namespace Assets.Resources.Scripts
{
    public class MouseMovement : MonoBehaviour
    {
        private Vector3 _movePosition;
        public float Speed = 3;

        private bool _isPositionSet;

        public Dictionary<KeyCode, Vector3> KeyOffset = new Dictionary<KeyCode, Vector3>
        {
            {KeyCode.W, new Vector3(0, 0, 1)},
            {KeyCode.S, new Vector3(0, 0, -1)},
            {KeyCode.A, new Vector3(-1, 0, 0)},
            {KeyCode.D, new Vector3(1, 0, 0)},
        }; 

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