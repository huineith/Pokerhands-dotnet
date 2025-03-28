// Pokerhands Program for unit testing purposes

using System;
using CardGame;

class Program
{
    static void Main(string[] args)
    {
       var cardsInfo= new string[]{"♥2","♦3","♥4","♦5","♦6"};
       PokerTest.GenerateListOfCards(cardsInfo); 
    }
}