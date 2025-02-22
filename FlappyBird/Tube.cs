﻿using System.Drawing;

namespace FlappyBird
{
    public class Tube
    {
        public int x;
        public int y;
        public Image tubeImage;
        public int sizeX;
        public int sizeY;
        public Tube(int x, int y, bool isRotate = false)
        {
            this.x = x;
            this.y = y;
            tubeImage = GameResource.tube;
            sizeX = 100;
            sizeY = 250;
            if (isRotate == true)
            {
                tubeImage.RotateFlip(RotateFlipType.Rotate180FlipX);
            }
        }
    }
}
