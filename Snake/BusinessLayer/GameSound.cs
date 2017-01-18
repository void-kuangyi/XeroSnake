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
            soundOfDeath = new SoundPlayer(checkSoundFile(path + "\\GameSounds\\die.wav"));
            soundOfEatingFood = new SoundPlayer(checkSoundFile(path + "\\GameSounds\\eatFood.wav")); ;
            soundOfGettingHighScore = new SoundPlayer(checkSoundFile(path + "\\GameSounds\\highScore.wav")); ;
        }

        private string checkSoundFile(string filePath)
        {
            if(File.Exists(filePath))
            {
                return filePath;
            }
            throw new System.Exception(filePath + " cannot be found!");
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
