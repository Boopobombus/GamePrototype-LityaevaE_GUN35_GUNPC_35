using GamePrototype.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GamePrototype.Dungeon
{
    public sealed class DifficultySettings
    {
        public Difficult Levels { get; private set; } 

        public uint EnemyAttack => Levels switch
        {
            Difficult.Easy => 1u,
            Difficult.Hard => 2u,
            _ => 1u
        };


        public void SelectDifficulty()
        {
            Console.WriteLine("Выбери уровень сложности");
            Console.WriteLine("Легкий - нажми 1, Тяжелый - нажми 2");
            var Choice = Convert.ToInt32(Console.ReadLine());

            switch (Choice)
            {
                case 1:

                    Console.WriteLine( "Easy");
                    Levels = (Difficult)Choice;
                    break;

                case 2:

                    Console.WriteLine("Hard");
                    Levels = Difficult.Hard;
                    break;
                default:
                    Console.WriteLine("Ошибка ввода");
                    Levels = Difficult.Easy;
                    break;
            }
        }
        


            /*public Difficult SetDifficulty ()
            {
                int L = SelectDifficulty();
                            if (L == 1)
                {
                    Console.WriteLine("Easy");
                    return Difficult.Easy; 
                }
                else if (L == 2) 
                {
                    Console.WriteLine("Hard");
                    return Difficult.Hard; 
                }
                else
                {
                    Console.WriteLine("Ошибка, уровень по умолчанию Easy");
                    return Difficult.Easy;
                }



            }*/

        }
    }

