using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MineSweeper3D
{
    [RequireComponent(typeof(Renderer))]
    public class Block : MonoBehaviour
    {
        public int x, y, z;
        public bool isMine = false;
        [Header("Refs")]
        public Color[] textColors;
        public TextMesh tmesh;
        public Transform mine;

        private Renderer rend;

        private bool isRevealed = false;


        void Awake()
        {
            rend = GetComponent<Renderer>();
        }

        private void Start()
        {
            tmesh.transform.SetParent(null);
            isMine = Random.value < .05f;
        }

        void UpdateText(int adjacentMines)
        {
            if(adjacentMines > 0)
            {
                tmesh.text = adjacentMines.ToString();
                if(adjacentMines >= 0 && adjacentMines < textColors.Length)
                {
                    tmesh.color = textColors[adjacentMines];
                }
            }
        }
        public void Reveal(int adjacentMine)
        {
            isRevealed = true;
            if (isMine)
            {
                mine.gameObject.SetActive(true);
                mine.SetParent(null);
            }
            else
            {
                UpdateText(adjacentMine);
            }
            gameObject.SetActive(false);
        }

        void Update()
        {

        }
    }
}
