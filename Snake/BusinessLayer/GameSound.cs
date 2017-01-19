using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace BusinessLayer
{
    public class GameSound
    {
        private string path = Directory.GetCurrentDirectory();
        SoundPlayer soundOfDeath;
        SoundPlayer soundOfEatingFood;
        SoundPlayer soundOfGettingHighScore;
       
        public GameSound()
        {
            soundOfDeath = new SoundPlayer(Properties.Resources.die);
            soundOfEatingFood = new SoundPlayer(Properties.Resources.eatFood); ;
            soundOfGettingHighScore = new SoundPlayer(Properties.Resources.highScore); ;
        }

        public void SnakeEatsSound()
        {
            soundOfEatingFood.Play();
        }

        public void SnakeDiesSound()
        {
            soundOfDeath.Play();
        }

        public void SnakeGetsHighScore()
        {
            soundOfGettingHighScore.Play();
        }

    }
}
