using Xunit;
namespace CardGame;

//     "♥♦♣♠"
        
//"23456789TJQKA"
public class PokerTest{

[Fact]

    public void TestIsPairHelperMethodTrue(){

        // Arrange 

        // Act 
        var ranks = new char[]{'2','2','4','5','6'}; 
        var suits=new char[]{'♥','♦','♥','♦','♦'}; 
        List<Card> cards= GenerateListOfCards(suits,ranks) ;

        Assert.Equals(cards.Count==5);  
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
        var ranks = new char[]{'2','3','4','5','6'}; 
        var suits=new char[]{'♥','♦','♥','♦','♦'}; 
        List<Card> cards= GenerateListOfCards(suits,ranks) ;
        Assert.Equals(cards.Count==5); 
        
        Hand pairHand=  new Hand(cards); 
       var result= CompareHands.IsPair(pairHand);
       bool doesNotContainPair= result is null;  
        //Assert
        Assert.False(!doesNotContainPair); 
    }


private List<Card> GenerateListOfCards(char[] suits, char[] values){
   List<Card> cards= new(); 

    if(suits.Length != values.Length){
        return cards; 
    } 
    for(int i=0 ; i <suits.Length; i++ ){ 
        cards.Add(new Card(suits[i],values[i])); 
    }

    return cards; 
}
}