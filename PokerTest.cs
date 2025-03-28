using Xunit;
namespace CardGame;

//     "♥♦♣♠"
        
//"23456789TJQKA"
public class PokerTest{

[Fact]
    public void TestIsPairHelperMethodTrue(){

    
        // Arrange 

        // Act 
        //var ranks = new char[]{'2','2','4','5','6'}; 
        //var suits=new char[]{'♥','♦','♥','♦','♦'}; 
        var cardsInfo= new string[]{"♥2","♦2","♥4","♦5","♦6"};
        System.Console.WriteLine(cardsInfo.Length);
        List<Card> cards= GenerateListOfCards(cardsInfo) ;

        Hand pairHand=  new Hand(cards); 
       var result= CompareHands.IsPair(pairHand);
       bool doesNotContainPair= result is null;  
        //Assert
        Assert.True(!doesNotContainPair); 
    }
[Fact]
    public void TestIsPairHelperMethodFalse(){

        // Arrange 

        // Act 
        //var ranks = new char[]{'2','3','4','5','6'}; 
        //var suits=new char[]{'♥','♦','♥','♦','♦'}; 
         var cardsInfo= new string[]{"♥2","♦3","♥4","♦5","♦6"};
        List<Card> cards= GenerateListOfCards(cardsInfo) ;
   
        Hand pairHand=  new Hand(cards); 
       var result= CompareHands.IsPair(pairHand);
       bool doesNotContainPair= result is null;  
        //Assert
        Assert.False(!doesNotContainPair); 
    }


public static List<Card> GenerateListOfCards(string[] cardsInfo){
   List<Card> cards= new(); 

    foreach( string card in cardsInfo ){ 
        cards.Add(new Card(card[0],card[1])); 
    }

    return cards; 
}
}