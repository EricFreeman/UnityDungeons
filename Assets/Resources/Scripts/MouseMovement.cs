using UnityEngine;

namespace Assets.Resources.Scripts
{
    public class MouseMovement : MonoBehaviour
    {
        private Vector3 _movePosition;
        public float Speed = 3;

        void Start()
        {
            _movePosition = transform.position;
        }

        void Update()
        {
            CheckForNewPosition();
            transform.position = Vector3.MoveTowards(transform.position, _movePosition, Speed * Time.deltaTime);
        }

        private void CheckForNewPosition()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var pos = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(pos, out hit))
                    _movePosition = hit.point;
            }
        }
    }
}