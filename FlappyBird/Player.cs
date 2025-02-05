using System.Drawing;

namespace FlappyBird
{
    public class Player
    {
        public float x;
        public float y;
        public Image birdImage;
        public int size;
        public float gravityValue;
        public bool isAlive;
        public Player(float x, float y)
        {
            this.x = x;
            this.y = y;
            birdImage = GameResource.bird;
            size = 50;
            gravityValue = 0.1f;
            isAlive = true;
        }
    }
}
