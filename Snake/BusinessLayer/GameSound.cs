using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace BusinessLayer
{
    class GameSound
    {
        private string path = System.IO.Directory.GetCurrentDirectory();
        SoundPlayer soundOfDeath;
        SoundPlayer soundOfEatingFood;
        SoundPlayer soundOfGettingHighScore;
       
        public GameSound()
        {
            soundOfDeath = new SoundPlayer(path + "\\GameSounds\\die.wav");
            soundOfEatingFood = new SoundPlayer(path + "\\GameSounds\\eatFood.wav"); ;
            soundOfGettingHighScore = new SoundPlayer(path + "\\GameSounds\\highScore.wav"); ;
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
